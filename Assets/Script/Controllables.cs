using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class Controllables : MonoBehaviour
{
    public List<GameObject> controllables = new List<GameObject>();
    public GameObject nowControlling;
    public GameObject toBeControlled;
    //public GameObject m_PlayerOptions;
    private GameObject my_system;
    public MySystem.Mode myMode;
    public GameObject m_cursor;
    // Start is called before the first frame update
    void Start()
    {
        my_system = GameObject.Find("MySystem");
        nowControlling = controllables[0];
        toBeControlled = controllables[0];
        // GameObject _eventSystem = GameObject.Find("EventSystem");
        // _eventSystem.currentSelectedGameObject = Instantiate(m_PlayerOptions, nowControlling.transform);
    }

    // Update is called once per frame
    void Update()
    {
        MySystem.Mode system_mode = my_system.GetComponent<MySystem.Status>().system_mode;
        if (system_mode != myMode) return;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            nowControlling.GetComponent<PlayerController>().enabled = false;
            toBeControlled.GetComponent<PlayerController>().enabled = true;
            nowControlling = toBeControlled;
        }
    }
}
