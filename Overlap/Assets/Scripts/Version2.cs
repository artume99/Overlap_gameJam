using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version2 : MonoBehaviour
{
    public static Version2 SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake() {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool, transform);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledObject(Vector3 pos, Quaternion rotation) {

        for (int i = 0; i < pooledObjects.Count; i++) {

            if (!pooledObjects[i].activeInHierarchy) {
                GameObject objectSpawn = pooledObjects[i] ;
                objectSpawn.SetActive(true);
                objectSpawn.transform.position = pos;
                objectSpawn.transform.rotation = rotation;
                objectSpawn.GetComponent<IPooledObject>().ObjectSPawn();
                return objectSpawn;
            }
        }
  
        return null;
    }
}
