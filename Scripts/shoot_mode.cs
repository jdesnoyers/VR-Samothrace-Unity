using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace VRStandardAssets.Utils
{

    public class shoot_mode : MonoBehaviour
    {

        [SerializeField] private VRInput m_VRInput;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private GameObject m_TextObject;

        public static bool shooting_mode = false;
        private Text m_Text;

        private void Start()
        {
            m_Text = m_TextObject.GetComponent<Text>();
        }

        private void OnEnable()
        {
            m_InteractiveItem.OnDown += HandleDown;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnDown -= HandleDown;
        }

        private void HandleDown()
        {
            if (shooting_mode == true)
            {
                shooting_mode = false;
                m_Text.text = "PICK UP";
            }
            else
            {
                shooting_mode = true;
                m_Text.text = "SHOOT";
            }
        }

    }
}