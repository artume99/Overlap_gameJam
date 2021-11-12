using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour, IPooledObject
{
    private PlayingBlock[] BlockPrefabs = new PlayingBlock[3];
    private int blockActivated = 0;
    private int currentBlock = 0;
    private int[] degrees = {0,90,180,270};
    enum ColorCoding
    {
        Unit,
        PinkP
    }
    private int num_of_available_blocks = 3;

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            BlockPrefabs[i] = transform.GetChild(i).GetComponent<PlayingBlock>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }

    public void ObjectSPawn()
    {
        
        ActiveBlock(Random.Range(0,num_of_available_blocks));
    }

    private void ActiveBlock(int index)
    {
        blockActivated = index; 
        // Setting the previous active block inactive and activates the random chosen block
        BlockPrefabs[currentBlock].gameObject.SetActive(false);
        PlayingBlock block = BlockPrefabs[blockActivated];
        block.gameObject.SetActive(true);
        block.Rotate(degrees[Random.Range(0,degrees.Length)]);
        
        currentBlock = blockActivated;
    }
}
