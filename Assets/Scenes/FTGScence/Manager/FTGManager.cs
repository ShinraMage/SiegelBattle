using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTGManager : MonoBehaviour
{
    private int EnemyMaxhp=100;
    private int Enemyhp=100;
    private Rigidbody2D rigid_body;
    public Animator Anim;
    [SerializeField]
    private MySystem.FTGStatus my_system_status;
    public float updateInterval = 1;
    private float lastInterval;
    private float jump_interval = 0.1f;
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthbarBehaviour Healthbar;
    public ParticleSystem bloodeffect;




    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        
        my_system_status = GameObject.FindGameObjectWithTag("MySystem").GetComponent<MySystem.FTGStatus>();
        bloodeffect = GameObject.Find("bloodeffect").GetComponent<ParticleSystem>();
        lastInterval = 0;
        Anim = GetComponent<Animator>();
        rigid_body = gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        lastInterval += Time.deltaTime;


        MySystem.Mode system_mode = my_system_status.system_mode;
        Vector3 move_dir = my_system_status.movement;

        if (system_mode == MySystem.Mode.FTG)
        {
            rigid_body.simulated = true;
            rigid_body.gravityScale = 2.0f;

            var pose = transform.position;
            //pose.x += move_dir.x / 2 * updateInterval;
            transform.position = pose;
            //Debug.Log("updateInterval:" + move_dir.x);

            var velocity = rigid_body.velocity;
            /*if ((Mathf.Abs(velocity.y) < 1e-6) && (lastInterval > jump_interval))
            {
                if (move_dir.y > 0)
                {
                    lastInterval = 0;
                    velocity.y = 15;
                    rigid_body.velocity = velocity;
                }

            }*/
        }
        else
        {
            rigid_body.gravityScale = 0.0f;
            rigid_body.simulated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Hitpoints -= 1;
            Anim.SetTrigger("Hurt");
            Instantiate(bloodeffect, transform.position, Quaternion.identity);
            if (Hitpoints <= 0)
                Destroy(gameObject);
        }
    }
    void FlashColor(float time)
    {

    }

    void ResetColor()
    {

    }

}
