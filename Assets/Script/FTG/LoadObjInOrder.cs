using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjInOrder : MonoBehaviour //scene開始時讀取的物件
{
    public GameObject Camera;
    public GameObject Hero;
    public GameObject Follower;
    //public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Camera, new Vector3(0, 0, -1), Quaternion.identity);
        Instantiate(Hero, new Vector3(-1, 0, 0), Quaternion.identity);
        Instantiate(Follower, new Vector3(-1, 0, 0), Quaternion.identity);
        //Instantiate(Enemy, new Vector3(1, 0, 0), Quaternion.identity); //2022/11/04 add by Slash


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

