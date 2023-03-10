using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        public List<Pool> pools;
        public static Dictionary<string, Queue<GameObject>> poolDictionary;

        void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                GameObject rootObject = Instantiate(new GameObject(pool.tag), transform);

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, rootObject.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public static GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                throw new Exception("Pool with tag " + tag + " doesn't exist.");
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}