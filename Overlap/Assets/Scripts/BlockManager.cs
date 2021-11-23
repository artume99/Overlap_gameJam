using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockManager : MonoBehaviour, IPooledObject
{ 
    public PlayingBlock[] BlockPrefabs;
    public Sprite[] colorBlocks;
    public bool inTutorial= false;
    private int blockActivated = 0;
    private int currentBlock = 0;
    private int[] degrees = {0,90,180,270};
    

    private string BlockTag = "UnitBlock";
    
    private int num_of_available_blocks;

    // Start is called before the first frame update
    void Awake()
    {
        num_of_available_blocks = BlockPrefabs.Length;
    }
    
    public void ObjectSPawn(bool tutorial = false)
    {
        inTutorial = tutorial;
        ActiveBlock(Random.Range(0,num_of_available_blocks));
    }
    

    private void ActiveBlock(int index)
    {
        if (inTutorial)
        {
            PlayingBlock block = BlockPrefabs[1];
            block.gameObject.SetActive(true);
            block.StartMoving(Vector3.down);
            block.Rotate(degrees[1]);
            block.ColorBlock(colorBlocks[Random.Range(0, colorBlocks.Length)]);
        }
        else
        {
            blockActivated = index;
            // Setting the previous active block inactive and activates the random chosen block
            BlockPrefabs[currentBlock].gameObject.SetActive(false);
            PlayingBlock block = BlockPrefabs[blockActivated];
            block.gameObject.SetActive(true);
            block.StartMoving(Vector3.down);
            block.Rotate(degrees[Random.Range(0, degrees.Length)]);
            block.ColorBlock(colorBlocks[Random.Range(0, colorBlocks.Length)]);

            currentBlock = blockActivated;
        }

    }

}
