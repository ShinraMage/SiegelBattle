using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySystem
{
    public enum Mode
    {
        JRPG, ARPG, SLG, FTG
    }
    public class FTGStatus : MonoBehaviour
    {

        public MySystem.Mode system_mode;
        public Vector3 movement;

        public GameObject main_camera;


        // Start is called before the first frame update
        void Start()
        {
            system_mode = MySystem.Mode.FTG;

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                system_mode = MySystem.Mode.JRPG;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                system_mode = MySystem.Mode.ARPG;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                system_mode = MySystem.Mode.SLG;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                system_mode = MySystem.Mode.FTG;
            }


            Vector3 input_movement;
            input_movement.z = 0;
            input_movement.x = Input.GetAxis("Horizontal");
            input_movement.y = Input.GetAxis("Vertical");
            movement = input_movement;

        }
    }
}