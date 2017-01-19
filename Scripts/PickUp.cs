using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{

    public class PickUp : MonoBehaviour {


        [SerializeField]  private float m_Torque = 10f;
        [SerializeField]  private VRInput m_VRInput;
        [SerializeField]  private Rigidbody m_Rigidbody;
        [SerializeField]  private VRInteractiveItem m_InteractiveItem;
        [SerializeField]  private bool gravitate;

        private float smooth = 2;
        private bool gaze;
        private bool grabbed;
        private float grabdist;

        private void OnEnable()
            {
                m_VRInput.OnSwipe += HandleSwipe;
                m_InteractiveItem.OnOver += HandleOver;
                m_InteractiveItem.OnOut += HandleOut;
                m_InteractiveItem.OnDoubleClick += HandleDouble;
            }
    

        private void OnDisable()
            {
                m_VRInput.OnSwipe -= HandleSwipe;
                m_InteractiveItem.OnOver -= HandleOver;
                m_InteractiveItem.OnOut -= HandleOut;
                m_InteractiveItem.OnDoubleClick -= HandleDouble;
        }


            private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
            {
            if (grabbed == true)
            {
                switch (swipeDirection)
                {
                    case VRInput.SwipeDirection.NONE:
                        break;
                    case VRInput.SwipeDirection.UP:
                        grabdist++;//move grabbed object further
                        break;
                    case VRInput.SwipeDirection.DOWN:
                        grabdist--; //move grabbed object closer
                        break;
                    case VRInput.SwipeDirection.LEFT:
                        m_Rigidbody.AddTorque(Vector3.up * m_Torque * m_Rigidbody.mass); //rotate grabbed object
                        break;
                    case VRInput.SwipeDirection.RIGHT:
                        m_Rigidbody.AddTorque(-Vector3.up * m_Torque * m_Rigidbody.mass); //rotate grabbed object

                        break;
                }
            }
            }
        private void HandleOver()
        {
            gaze=true;
            Debug.Log("gaze on", m_InteractiveItem);
        }
        private void HandleOut()
        {
            gaze=false;
            Debug.Log("gaze off", m_InteractiveItem);
        }
        private void HandleDouble()
        {
            if (shoot_mode.shooting_mode == false) //if in pick up mode
            {
                if (grabbed == false) //if object not grabbed then grab, otherwise drop
                {
                    grabbed = true;
                    Vector3 grabdistcalc = m_InteractiveItem.transform.position - Camera.main.transform.position;
                    grabdist = grabdistcalc.magnitude;
                    m_Rigidbody.useGravity = false;
                    Debug.Log("grab", m_InteractiveItem);
                }
                else
                {
                    grabbed = false;
                    if (gravitate == true)
                        m_Rigidbody.useGravity = true;
                    Debug.Log("drop", m_InteractiveItem);
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (grabbed == true)
            {
                m_Rigidbody.velocity = (((Camera.main.transform.forward * grabdist)+(Vector3.up*3/2)) - (m_Rigidbody.transform.position));
            }
        }


    }
}