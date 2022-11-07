using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    namespace Singleton
    {
        public class ObjectLists : MonoBehaviour
        {
            public static ObjectLists instance;

            public List<GameObject> g_object_list = new List<GameObject>();

            [SerializeField] private int for_debug_var;


            public int AddObject(GameObject input)
            {
                var pose = g_object_list.FindIndex(x => x == input);

                if (pose < 0)
                {
                    g_object_list.Add(input);
                    pose = g_object_list.Count - 1;
                }

                return pose;
            }


            void Awake()
            {
                instance = this;
                AddObject(this.gameObject);
            }


            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}