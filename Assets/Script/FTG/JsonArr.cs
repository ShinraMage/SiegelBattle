using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class JsonArr : MonoBehaviour //寫來接JSON檔的資料結構
{
    string jsonString;
    [System.Serializable]
    public class Attributes
    {
        public Hp hp { get; set; }
        public Energy energy { get; set; }
        public Move move { get; set; }
        public List<double> triality { get; set; }
    }

    public class Hp
    {
        public int current { get; set; }
        public int max { get; set; }
    }

    public class Energy
    {
        public int current { get; set; }
        public int max { get; set; }
    }

    public class Move
    {
        public int current { get; set; }
        public int max { get; set; }
    }

    public class Attack
    {
        public string dice { get; set; }
    }

    public class MagicAttack
    {
        public string dice { get; set; }
    }

    public class AdvancedAttributes
    {
        public Attack attack { get; set; }
        public int defense { get; set; }
        public MagicAttack magic_attack { get; set; }
        public int magic_defense { get; set; }
    }

    public class Equipment
    {
        public string weapon { get; set; }
        public string armor { get; set; }
        public string accessory { get; set; }
    }

    public class Enemy
    {
        public string name { get; set; }
        public string race { get; set; }
        public Attributes attributes { get; set; }
        public AdvancedAttributes advanced_attributes { get; set; }
        public Equipment equipment { get; set; }
        public List<string> skills { get; set; }
    }

    public class Root
    {
        public List<Enemy> Enemy { get; set; }
        public List<Enemy> Player { get; set; }
    }
    private void Start()
    {
        //jsonString = File.ReadAllText(Application.dataPath + "/Script/Attribute.json");
        //Root data = JsonConvert.DeserializeObject<Root>(jsonString);
        //jsonString = File.ReadAllText(Application.dataPath + "/Script/Unit.json");
    }
    private void Update()
    {
        //Enemy enemy1 = new Enemy();
        //string json = JsonUtility.ToJson(enemy1);
    }
}
