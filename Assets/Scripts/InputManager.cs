//Created by Dilmer Valecillos, amended by Alex Coulombe @ibrews to signal presses and releases and log controller

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private XRNode xRNode = XRNode.LeftHand;

    [SerializeField]
    private GameObject _scriptGameObject;

    [SerializeField]
    private GameObject _mainServer_GameObject;
    //public TextMeshProUGUI triggerText;
    //public TextMeshProUGUI triggerPrimer2D;

    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;

    //to avoid repeat readings
    private bool triggerIsPressed;
    private bool primaryButtonIsPressed;
    private bool primary2DAxisIsChosen;
    private Vector2 primary2DAxisValue = Vector2.zero;
    private Vector2 prevPrimary2DAxisValue;
    private bool gripIsPressed;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices);
        device = devices.FirstOrDefault();
    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        // capturing trigger button press and release    
        bool triggerButtonValue = false;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonValue) && triggerButtonValue && !triggerIsPressed)
        {
            triggerIsPressed = true;
            Debug.Log($"TriggerButton activated {triggerButtonValue} on {xRNode}");
            if (xRNode == XRNode.LeftHand)
            {
                _scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._leftHandTriggerPressed = true;
                //triggerText.text = $"TriggerButton activated {triggerButtonValue} on {xRNode} on {_scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._leftHandTriggerPressed}";
            }
            if (xRNode == XRNode.RightHand)
            {
                _scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._rightHandTriggerPressed = true;
                //triggerPrimer2D.text = $"TriggerButton activated {triggerButtonValue} on {xRNode} on {_scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._rightHandTriggerPressed}";
            }
        }
        else if (!triggerButtonValue && triggerIsPressed)
        {
            triggerIsPressed = false;
            Debug.Log($"TriggerButton deactivated {triggerButtonValue} on {xRNode}");
            if (xRNode == XRNode.LeftHand)
            {
                _scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._leftHandTriggerPressed = false;
                //triggerText.text = $"TriggerButton activated {triggerButtonValue} on {xRNode} on {_scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._leftHandTriggerPressed}";
            }
            if (xRNode == XRNode.RightHand)
            {
                _scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._rightHandTriggerPressed = false;
                //triggerPrimer2D.text = $"TriggerButton activated {triggerButtonValue} on {xRNode} on {_scriptGameObject.GetComponent<ZoomIn_ZoomOut_Manager>()._rightHandTriggerPressed}";
            }
        }

        // capturing primary button press and release
        bool primaryButtonValue = false;
        InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;

        if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
        {
            primaryButtonIsPressed = true;
            Debug.Log($"PrimaryButton activated {primaryButtonValue} on {xRNode}");
        }
        else if (!primaryButtonValue && primaryButtonIsPressed)
        {
            primaryButtonIsPressed = false;
            Debug.Log($"PrimaryButton deactivated {primaryButtonValue} on {xRNode}");
        }

        // capturing primary 2D Axis changes and release
        InputFeatureUsage<Vector2> primary2DAxisUsage = CommonUsages.primary2DAxis;
        // make sure the value is not zero and that it has changed
        if (primary2DAxisValue != prevPrimary2DAxisValue)
        {
            primary2DAxisIsChosen = false;
            //Debug.Log($"CHANGED and prev value is {prevPrimary2DAxisValue} and the new value is {primary2DAxisValue}");
        }
        // was for checking to see if the axis values were reading as changed properly
        /* else
        {
            Debug.Log($"Nope, prev value is {prevPrimary2DAxisValue} and the new value is {primary2DAxisValue}");
        } */
        if (device.TryGetFeatureValue(primary2DAxisUsage, out primary2DAxisValue) && primary2DAxisValue != Vector2.zero && !primary2DAxisIsChosen)
        {
            prevPrimary2DAxisValue = primary2DAxisValue;
            primary2DAxisIsChosen = true;
            Debug.Log($"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}");
            //triggerPrimer2D.text = $"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}";
            if (xRNode == XRNode.LeftHand && _mainServer_GameObject.activeInHierarchy)
            {
                _mainServer_GameObject.transform.Rotate(new Vector3(0f, primary2DAxisValue.x * Time.deltaTime * -270f, 0f));
                //triggerText.text = $"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}";

            }
            if (xRNode == XRNode.RightHand && _mainServer_GameObject.activeInHierarchy)
            {
                _mainServer_GameObject.transform.Rotate(new Vector3(0f, primary2DAxisValue.x * Time.deltaTime * -270f, 0f));
                //triggerPrimer2D.text = $"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}";

            }
        }
        else if (primary2DAxisValue == Vector2.zero && primary2DAxisIsChosen)
        {
            prevPrimary2DAxisValue = primary2DAxisValue;
            primary2DAxisIsChosen = false;
            Debug.Log($"Primary2DAxis deactivated {primary2DAxisValue} on {xRNode}");
            //triggerPrimer2D.text = $"Primary2DAxis deactivated {primary2DAxisValue} on {xRNode}";
            if (xRNode == XRNode.LeftHand && _mainServer_GameObject.activeInHierarchy)
            {
                //triggerText.text = $"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}";
            }
            if (xRNode == XRNode.RightHand && _mainServer_GameObject.activeInHierarchy)
            {
                //triggerPrimer2D.text = $"Primary2DAxis value activated {primary2DAxisValue} on {xRNode}";
            }

        }

        // capturing grip value
        float gripValue;
        InputFeatureUsage<float> gripUsage = CommonUsages.grip;

        if (device.TryGetFeatureValue(gripUsage, out gripValue) && gripValue > 0 && !gripIsPressed)
        {
            gripIsPressed = true;
            Debug.Log($"Grip value {gripValue} activated on {xRNode}");
        }
        else if (gripValue == 0 && gripIsPressed)
        {
            gripIsPressed = false;
            Debug.Log($"Grip value {gripValue} deactivated on {xRNode}");
        }
    }
}
