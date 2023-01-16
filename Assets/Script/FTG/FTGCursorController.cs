using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTGCursorController : MonoBehaviour
{

    private MySystem.FTGStatus my_system_status;

    void Start()
    {
        my_system_status = GameObject.FindGameObjectWithTag("MySystem").GetComponent<MySystem.FTGStatus>();
        my_system_status.main_camera.GetComponent<FTGCameraControl>().Cursor = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {


        float timeNow = Time.realtimeSinceStartup;

        if (my_system_status.system_mode == MySystem.Mode.SLG)
        {
            var pose = transform.position;
            pose += my_system_status.movement;
            transform.position = pose;
        }

        //transform.position += 0.1f * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
