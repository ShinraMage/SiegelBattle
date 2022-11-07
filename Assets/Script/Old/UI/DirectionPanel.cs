using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Screen.width * 0.2f, Screen.height * 0.2f, 0);
    }
}
