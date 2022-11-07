using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TryMovingObject : MonoBehaviour
{
    private float lastInterval;

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        lastInterval = 0;
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        lastInterval += Time.deltaTime * 3;


        Vector3 move_dis;
        move_dis.x = (float)Math.Cos(lastInterval);
        move_dis.y = (float)Math.Sin(lastInterval);
        move_dis.z = 0;


        Vector2 ratio = new Vector2(1, 1);
        Vector3 screenPos = cam.WorldToScreenPoint(ratio);
        ratio.x = (Screen.width) / screenPos.x;
        ratio.y = (Screen.height) / screenPos.y;


        move_dis.x *= ratio.x * 2;
        move_dis.y *= ratio.y * 2;

        transform.position = move_dis;

    }
}
