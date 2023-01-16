using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Enum declared outside of the class


public class FTGCameraControl : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject Player;


    private GameObject my_system;

    // Start is called before the first frame update
    void Start()
    {
        my_system = GameObject.FindGameObjectWithTag("MySystem");
        my_system.GetComponent<MySystem.FTGStatus>().main_camera = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MySystem.Mode system_mode = my_system.GetComponent<MySystem.FTGStatus>().system_mode;


        switch (system_mode)
        {
            case MySystem.Mode.JRPG:
                {
                    //Debug.Log("Case 1");
                    break;
                }
            case MySystem.Mode.ARPG:
                {
                    transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
                    //Debug.Log("Case 2");
                    break;
                }
            case MySystem.Mode.FTG:
                {
                    transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
                    //Debug.Log("Case 2");
                    break;
                }
            case MySystem.Mode.SLG:
                {
                    transform.position = new Vector3(Cursor.transform.position.x, Cursor.transform.position.y, transform.position.z);
                    //Debug.Log("Case 2");
                    break;
                }
            default:
                break;
        }

    }


}
