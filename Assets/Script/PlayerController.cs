using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;
    private bool isInMenu;
    private bool justCanceled;
    public GameObject my_system;

    public float x, y;
    public MySystem.Mode myMode;
    // public GameObject menuPrefab;
    public GameObject menu;
    public EventSystem eventSystem;


    void Start()
    {
        my_system = GameObject.Find("MySystem");
    }

    public void Selected()
    {

    }
    public void handleJump()
    {

    }
    public void handleCancel()
    {
        menu.SetActive(false);
        isInMenu = false;
        justCanceled = true;
    }
    private void Update()
    {
        MySystem.Mode system_mode = my_system.GetComponent<MySystem.Status>().system_mode;
        if (system_mode != myMode) return;
        if(Input.GetKeyDown(KeyCode.Return) && !isInMenu && !justCanceled)
        {
            // menu = Instantiate(menuPrefab);
            menu.SetActive(true);
            Button[] allChildren = menu.GetComponentsInChildren<Button>();
            foreach (Button child in allChildren)
            {
                Debug.Log(child.gameObject.ToString());
            }
            eventSystem.SetSelectedGameObject(allChildren[0].gameObject);
            isInMenu = true;
            justCanceled = false;
        }
        if (isInMenu) return;
        if (velocity.y == 0)
        {
            hasMoved = false;
        }
        else if (velocity.y != 0 && !hasMoved)
        {
            hasMoved = true;
            MoveByDirection();
        }

        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void MoveByDirection()
    {
        if (velocity.y < 0) // Move down
        {
            if (velocity.x < 0)
            { // left
                direction = new Vector3(-0.5f * x, -0.5f * y);
            }
            else if (velocity.x > 0)
            { // right
                direction = new Vector3(0.5f * x, -0.5f * y);
            }
            else
            {
                direction = new Vector3(0, -1 * y);
            }
        }
        else if (velocity.y > 0) // Move up
        {
            if (velocity.x < 0)
            { // left
                direction = new Vector3(-0.5f * x, 0.5f * y);
            }
            else if (velocity.x > 0)
            { // right
                direction = new Vector3(0.5f * x, 0.5f * y);
            }
            else
            {
                direction = new Vector3(0, y);
            }
        }

        transform.position += direction;
    }

    //MARKER Once we attach an obstacle (contains Collider2D Component)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(my_system == null)
        {
            my_system = GameObject.Find("MySystem");
        }
        MySystem.Mode system_mode = my_system.GetComponent<MySystem.Status>().system_mode;
        if (system_mode != myMode) return;
        transform.position -= direction;
    }

}
