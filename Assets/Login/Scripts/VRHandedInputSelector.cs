//using UnityEngine;
//using UnityEngine.EventSystems;

//public class VRHandedInputSelector : MonoBehaviour
//{
//    public OVRCameraRig m_CameraRig;
//    public OVRRaycaster m_OVRRaycaster;
//    public OVRInputModule m_InputModule;
//    public LaserPointer m_LaserPointer;
//    public LaserPointer.LaserBeamBehavior laserBeamBehavior;

//    void Awake()
//    {
//        if (m_CameraRig == null)
//            m_CameraRig = FindObjectOfType<OVRCameraRig>();
//        if (m_InputModule == null)
//            m_InputModule = FindObjectOfType<OVRInputModule>();
//        if(m_LaserPointer == null)
//            m_LaserPointer = FindObjectOfType<LaserPointer>();
//        if (m_OVRRaycaster == null)
//            m_OVRRaycaster = FindObjectOfType<OVRRaycaster>();
//    }

//    void Start()
//    {
//        m_LaserPointer.laserBeamBehavior = laserBeamBehavior;
//        m_OVRRaycaster.pointer = m_LaserPointer.gameObject;
//    }

//    void Update()
//    {
//        if (OVRInput.GetActiveController() == OVRInput.Controller.LTrackedRemote)
//        {
//            SetActiveController(OVRInput.Controller.LTrackedRemote);
//        }
//        else if (OVRInput.GetActiveController() == OVRInput.Controller.RTrackedRemote)
//        {
//            SetActiveController(OVRInput.Controller.RTrackedRemote);
//        }
//        else if (OVRInput.GetActiveController() == OVRInput.Controller.LTouch)
//        {
//            SetActiveController(OVRInput.Controller.LTouch);
//        }
//        else if (OVRInput.GetActiveController() == OVRInput.Controller.RTouch)
//        {
//            SetActiveController(OVRInput.Controller.RTouch);
//        }
//        else
//        {
//            SetActiveController(OVRInput.Controller.None);
//        }
//    }

//    void SetActiveController(OVRInput.Controller c)
//    {
//        Transform t;
//        if (c == OVRInput.Controller.LTrackedRemote || c == OVRInput.Controller.LTouch)
//        {
//            t = m_CameraRig.leftHandAnchor;
//        }
//        else if (c == OVRInput.Controller.RTrackedRemote || c == OVRInput.Controller.RTouch)
//        {
//            t = m_CameraRig.rightHandAnchor;
//        }
//        else
//        {
//            t = m_CameraRig.centerEyeAnchor;
//        }
//        m_InputModule.rayTransform = t;
//    }
//}