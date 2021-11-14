using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] float interval = 0.5f;
    private float timer;
    private ObjectPooling pooler;
    [SerializeField] private Transform[] spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        pooler = ObjectPooling.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > interval)
        {
            Spawn();
            timer -= interval;
        }

        timer += Time.deltaTime;
    }

    private void Spawn()
    {
        var rnd = spawnPoints[Random.Range(0,spawnPoints.Length)];
        pooler.SpawnFromPool("Block", rnd.position, Quaternion.identity);
        // Version2.SharedInstance.GetPooledObject(transform.position, Quaternion.identity);
    }
}
