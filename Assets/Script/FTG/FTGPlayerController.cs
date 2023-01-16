using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTGPlayerController : MonoBehaviour
{
    // for evaluate
    public float updateInterval = 1;
    private float lastInterval;


    private Rigidbody2D rigid_body;
    private Animator Anim;
    private float jump_interval = 0.1f;

    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    [SerializeField]
    private MySystem.FTGStatus my_system_status;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        my_system_status = GameObject.FindGameObjectWithTag("MySystem").GetComponent<MySystem.FTGStatus>();
        my_system_status.main_camera.GetComponent<FTGCameraControl>().Player = this.gameObject;

        lastInterval = 0;
        rigid_body = gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

        lastInterval += Time.deltaTime;

        
        MySystem.Mode system_mode = my_system_status.system_mode;
        Vector3 move_dir = my_system_status.movement;
        
        if (system_mode == MySystem.Mode.FTG)
        {
            rigid_body.simulated = true;
            rigid_body.gravityScale = 2.0f;

            var pose = transform.position;
            pose.x += move_dir.x / 2 * updateInterval;
            transform.position = pose;
            Anim.SetFloat("RobotRight", move_dir.x);
            Anim.SetFloat("RobotJump", move_dir.y);
            //Debug.Log("updateInterval:" + move_dir.x);
            //Debug.Log("Y:" + move_dir.y);
            var velocity = rigid_body.velocity;
            if ((Mathf.Abs(velocity.y) < 1e-6) && (lastInterval > jump_interval))
            {
                if (move_dir.y > 0)
                {                 
                    Debug.Log("updateInterval:" + move_dir.y);
                    lastInterval = 0;
                    velocity.y = 15;
                    rigid_body.velocity = velocity;
                }

            }
        }
        else
        {
            rigid_body.gravityScale = 0.0f;
            rigid_body.simulated = false;
        }

        if (system_mode == MySystem.Mode.ARPG)
        {
            transform.position += updateInterval * move_dir * 2;
        }

        if (updateInterval < lastInterval && system_mode == MySystem.Mode.JRPG)
        {
            lastInterval = 0;
            var pose = transform.position;
            if (system_mode == MySystem.Mode.JRPG)
            {
                if (!Mathf.Approximately(move_dir.x, 0))
                {
                    if (move_dir.x > 0)
                    {
                        pose.x += 1;
                    }
                    if (move_dir.x < 0)
                    {
                        pose.x -= 1;
                    }

                }
                if (!Mathf.Approximately(move_dir.y, 0))
                {
                    if (move_dir.y > 0)
                    {
                        pose.y += 1;
                    }
                    if (move_dir.y < 0)
                    {
                        pose.y -= 1;
                    }
                }
                transform.position = pose;
            }
        }

        //transform.position += 0.1f * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
