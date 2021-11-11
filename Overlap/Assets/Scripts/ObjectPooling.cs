using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        GameObject objectSpawn = PoolDictionary[tag].Dequeue();
        objectSpawn.SetActive(true);
        objectSpawn.transform.position = pos;
        objectSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectSpawn.GetComponent<IPooledObject>();
        if (pooledObject != null)
        {
            pooledObject.ObjectSPawn();
        }
        
        PoolDictionary[tag].Enqueue(objectSpawn);

        return objectSpawn;

    }
}
