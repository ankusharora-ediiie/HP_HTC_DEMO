using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZoomIn_ZoomOut_Manager : MonoBehaviour
{
    public TextMeshProUGUI _leftHandPosition_Value;
    public TextMeshProUGUI _rightHandPosition_Value;

    public TextMeshProUGUI _distanceBetween_Value;

    public GameObject _leftHand_VR;
    public GameObject _rightHand_VR;

    public bool _leftHandTriggerPressed;
    public bool _rightHandTriggerPressed;
    private bool _takeValueOnce;
    public GameObject _server_MainGameObject;
    public GameObject _server_MainGameObject_XRay;

    public Vector3 _initialScale_Server;

    public float _initialDistance_Controller;
    public float _variableDistance_Controller;

    // Start is called before the first frame update
    void Start()
    {
        //if(GameObject.Find("HPE_Server_Parent").activeInHierarchy)
        //{
        //    _server_MainGameObject = GameObject.Find("HPE_Server_Parent");
        //}
        //if (GameObject.Find("HPE_Server_Parent_X-Ray_Mode").activeInHierarchy)
        //{
        //    _server_MainGameObject = GameObject.Find("HPE_Server_Parent_X-Ray_Mode");
        //}
        _leftHandPosition_Value.text = _leftHand_VR.GetComponent<RectTransform>().position.ToString();
        _rightHandPosition_Value.text = _rightHand_VR.GetComponent<RectTransform>().position.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(_server_MainGameObject.activeInHierarchy)
        {
            _leftHandPosition_Value.text = _leftHand_VR.GetComponent<RectTransform>().position.ToString();
            _rightHandPosition_Value.text = _rightHand_VR.GetComponent<RectTransform>().position.ToString();

            _distanceBetween_Value.text = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position).ToString();
            _variableDistance_Controller = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position);

            if (_leftHandTriggerPressed && _rightHandTriggerPressed)
            {
                if (!_takeValueOnce)
                {
                    _takeValueOnce = true;
                    _initialScale_Server = _server_MainGameObject.transform.localScale;
                    _initialDistance_Controller = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position);
                }
                if (_variableDistance_Controller > _initialDistance_Controller)
                {
                    _server_MainGameObject.transform.localScale = new Vector3(_initialScale_Server.x + (_variableDistance_Controller - _initialDistance_Controller), _initialScale_Server.y + (_variableDistance_Controller - _initialDistance_Controller), _initialScale_Server.z + (_variableDistance_Controller - _initialDistance_Controller));
                }
            }
            else if (_takeValueOnce)
            {
                _server_MainGameObject.transform.localScale = Vector3.one;
                _takeValueOnce = false;
            }
        }
        
        if(_server_MainGameObject_XRay.activeInHierarchy)
        {
            _leftHandPosition_Value.text = _leftHand_VR.GetComponent<RectTransform>().position.ToString();
            _rightHandPosition_Value.text = _rightHand_VR.GetComponent<RectTransform>().position.ToString();

            _distanceBetween_Value.text = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position).ToString();
            _variableDistance_Controller = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position);

            if (_leftHandTriggerPressed && _rightHandTriggerPressed)
            {
                if (!_takeValueOnce)
                {
                    _takeValueOnce = true;
                    _initialScale_Server = _server_MainGameObject_XRay.transform.localScale;
                    _initialDistance_Controller = Vector3.Distance(_leftHand_VR.transform.position, _rightHand_VR.transform.position);
                }
                if (_variableDistance_Controller > _initialDistance_Controller)
                {
                    _server_MainGameObject_XRay.transform.localScale = new Vector3(_initialScale_Server.x + (_variableDistance_Controller - _initialDistance_Controller), _initialScale_Server.y + (_variableDistance_Controller - _initialDistance_Controller), _initialScale_Server.z + (_variableDistance_Controller - _initialDistance_Controller));
                }
            }
            else if (_takeValueOnce)
            {
                _server_MainGameObject_XRay.transform.localScale = Vector3.one;
                _takeValueOnce = false;
            }
        }
    }
}
