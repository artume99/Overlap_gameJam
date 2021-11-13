using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] float interval = 0.5f;
    private float timer;
    private ObjectPooling pooler;
    
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
        pooler.SpawnFromPool("Block", transform.position, Quaternion.identity);
    }
}
