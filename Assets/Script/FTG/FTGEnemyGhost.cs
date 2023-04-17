using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class FTGEnemyGhost : FTGEnemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    public int Hitpoints;
    public int MaxHitpoints;
    public Animator Anim;
    public ParticleSystem bloodeffect;
    public HealthbarBehaviour Healthbar;
    JsonArr.Root data;
    string tojsonfile;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        string jsonString = File.ReadAllText(Application.dataPath + "/Script/Attribute.json"); //讀取共用的json檔
        data = JsonConvert.DeserializeObject<JsonArr.Root>(jsonString);
        Hitpoints = data.Enemy[0].attributes.hp.current;
        MaxHitpoints = data.Enemy[0].attributes.hp.max;
        waitTime = startWaitTime; //移動完停止的時間
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    Vector2 GetRandomPos() //範圍內隨機抽地點移動
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hitpoints -= 10;
            Anim.SetTrigger("Hurt");
            data.Enemy[0].attributes.hp.current = Hitpoints;
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/Script/Attribute.json"))
            {
                tojsonfile = JsonConvert.SerializeObject(data);
                sw.WriteLine(tojsonfile);
            }
                Instantiate(bloodeffect, transform.position, Quaternion.identity);
            if (Hitpoints <= 0)
                Destroy(gameObject);
        }
    }
}
