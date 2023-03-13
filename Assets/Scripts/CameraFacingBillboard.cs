using UnityEngine;

namespace PearsonMath
{
    public class CameraFacingBillboard : MonoBehaviour
    {

        public Camera m_Camera;
        public bool enableXRotation = true;
        public bool enableYRotation = true;
        public bool enableZRotation = true;

        Vector3 defaultRotation;

        [SerializeField]
        bool restrictRotation = false;

        [SerializeField]
        float minX, maxX, minY, maxY, minZ, maxZ;

        void Start()
        {
            m_Camera = Camera.main;
            defaultRotation = transform.localEulerAngles;
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                m_Camera.transform.rotation * Vector3.up);
            if (!enableXRotation)
            {
                if (restrictRotation)
                {
                    transform.localEulerAngles = new Vector3(defaultRotation.x, Mathf.Clamp(transform.localEulerAngles.y, minY, maxY), Mathf.Clamp(transform.localEulerAngles.z, minZ, maxZ));
                }
                else
                {
                    transform.localEulerAngles = new Vector3(defaultRotation.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                }
            }
            if (!enableYRotation)
            {
                if (restrictRotation)
                {
                    transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, minX, maxX), defaultRotation.y, Mathf.Clamp(transform.localEulerAngles.z, minZ, maxZ));
                }
                else
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, defaultRotation.y, transform.localEulerAngles.z);
                }
            }
            if (!enableZRotation)
            {
                if (restrictRotation)
                {
                    transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, minX, maxX), Mathf.Clamp(transform.localEulerAngles.y, minY, maxY), defaultRotation.z);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, defaultRotation.z);
                }
            }
        }
    }
}