using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockSpawner : MonoBehaviour
{
    [Serializable]
    public class Levels
    {
        public Transform[] spawnPoints;
    }
    [SerializeField] float interval = 0.5f;
    private float timer;
    private ObjectPooling pooler;
    [SerializeField] private List<Levels> spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        pooler = ObjectPooling.Instance;
    }
    public void OnLevelStart()
    {
        timer = 0;
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
        var currentLevel = spawnPoints[GameManager.Instance.Streak];
        Transform[] spawnPointsAvailable = currentLevel.spawnPoints;

        var rnd = spawnPointsAvailable[Random.Range(0,spawnPointsAvailable.Length)];
        pooler.SpawnFromPool("Block", rnd.position, Quaternion.identity);
        // Version2.SharedInstance.GetPooledObject(transform.position, Quaternion.identity);
    }
}
