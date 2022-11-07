using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch0 : MonoBehaviour
{
    private float width;
    private float height;

    Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 pos = touch.position;

            Vector3 right_top = cam.WorldToScreenPoint(new Vector2(1, 1));
            Vector2 left_bottom = cam.WorldToScreenPoint(new Vector2(0, 0));

            pos.x = (pos.x - (right_top.x + left_bottom.x) / 2) / (right_top.x - left_bottom.x);
            pos.y = (pos.y - (right_top.y + left_bottom.y) / 2) / (right_top.y - left_bottom.y);
            Vector3 position = new Vector3(pos.x, pos.y, 0.0f);

            // Position the cube.
            transform.position = position;
        }
    }
}
