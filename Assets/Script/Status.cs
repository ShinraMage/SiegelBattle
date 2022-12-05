using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySystem
{
    public enum Mode
    {
        JRPG, ARPG, SLG, FTG
    }
    public class Status : MonoBehaviour
    {

        public MySystem.Mode system_mode;
        public Vector3 movement;
        public GameObject m_controllables;
        private MySystem.Mode previousMode;

        // public GameObject main_camera;


        // Start is called before the first frame update
        void Start()
        {
            system_mode = MySystem.Mode.FTG;

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
        }

        void handleModeChange()
        {
            GameObject _cursor = m_controllables.GetComponent<Controllables>().m_cursor;
            if (system_mode == _cursor.GetComponent<CursorController>().myMode)
            {
                _cursor.transform.position =
                    m_controllables.GetComponent<Controllables>().
                    nowControlling.transform.position;
                _cursor.SetActive(true);
            }
            else
            {
                _cursor.SetActive(false);
            }
            previousMode = system_mode;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                previousMode = system_mode;
                system_mode = MySystem.Mode.JRPG;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                previousMode = system_mode;
                system_mode = MySystem.Mode.ARPG;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                previousMode = system_mode;
                system_mode = MySystem.Mode.SLG;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                previousMode = system_mode;
                system_mode = MySystem.Mode.FTG;
            }
            if(previousMode != system_mode)
            {
                handleModeChange();
            }



            Vector3 input_movement;
            input_movement.z = 0;
            input_movement.x = Input.GetAxis("Horizontal");
            input_movement.y = Input.GetAxis("Vertical");
            movement = input_movement;

        }
    }
}