using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject m_controllables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject controlled = m_controllables.GetComponent<Controllables>().nowControlling;
        Vector3 direction = controlled.transform.position - transform.position;
        direction.z = 0;
        transform.position += direction;
    }
}
