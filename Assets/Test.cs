using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
    */
    [System.Serializable]
    public enum Race
    {
        orc,
        dwarf,
        human
    }
    [System.Serializable]
    public class Attributes
    {
        public Dictionary<string, int> hp;
        public Dictionary<string, int> energy;
        public Dictionary<string, int> move;
        public List<float> triality;
    }
    [System.Serializable]
    public class AdvAttributes
    {
        public Dictionary<string, string> attack;
        public int defense;
        public Dictionary<string, string> magic_attack;
        public int magic_defense;
    }
    [System.Serializable]
    public class Unit
    {
        public string name;
        public Race race;
        //public Attributes attributes;
        //public AdvAttributes advanced_attributes;
        public Dictionary<string, string> equipment;
        public List<string> skills;

        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
    [System.Serializable]
    public class PersonData
    {
        public string name;
        public int age;
        // Dictionary is NOT serializable, need to use plain structure
        public Dictionary<string, string> contacts = new Dictionary<string, string>();
        public Dictionary<string, string> address;
    }

    [System.Serializable]
    public class InitialUnits
    {
        public List<Unit> enemy;
        public List<Unit> player;
    }
    /* example 1
    [System.Serializable]
    public class AddressData
    {
        public string street;
        public string city;
        public string state;
        public string zip;
    }

    [System.Serializable]
    public class PersonData
    {
        public string name;
        public int age;
        public AddressData address;
        public List<string> phone_numbers;
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        //string jsonString = File.ReadAllText(Application.dataPath + "/Script/Attribute.json");
        //string jsonString = File.ReadAllText(Application.dataPath + "/Script/Unit.json");

        /* example 1
        string jsonString = "{\"name\":\"John\",\"age\":30,\"address\":{\"street\":\"123 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"},\"phone_numbers\":[\"555-555-1234\",\"555-555-5678\"]}";
        PersonData personData = JsonUtility.FromJson<PersonData>(jsonString);

        Debug.Log(personData.name);
        Debug.Log(personData.age);
        Debug.Log(personData.address.street);
        Debug.Log(personData.address.city);
        Debug.Log(personData.address.state);
        Debug.Log(personData.address.zip);

        foreach (string phone_number in personData.phone_numbers)
        {
            Debug.Log(phone_number);
        }
        */
        string jsonString = "{\"name\":\"John\",\"age\":30,\"contacts\":{\"email\":\"john@example.com\",\"phone\":\"123-456-7890\"},\"address\":{\"street\":\"123 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"}}";
        PersonData personData = JsonUtility.FromJson<PersonData>(jsonString);

        string email;
        if (personData.contacts.TryGetValue("email", out email))
        {
            Debug.Log(email);
        }
        else
        {
            Debug.Log("Email key not found in contacts dictionary.");
        }

        /* my code
        Unit unit = JsonUtility.FromJson<Unit>(jsonString);
        Debug.Log(unit.name);
        Debug.Log(unit.race);
        Debug.Log(unit.equipment);
        for(int i = 0;i < 2;i++)
        {
            Debug.Log(unit.skills[i]);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
