using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockManager : MonoBehaviour, IPooledObject
{ 
    public PlayingBlock[] BlockPrefabs;
    private int blockActivated = 0;
    private int currentBlock = 0;
    private int[] degrees = {0,90,180,270};

    private string BlockTag = "UnitBlock";
    public Sprite check;
    
    enum ShapeCoding
    {
        Unit,
        Plus,
        Row_2
    }
    private int num_of_available_blocks = 3;

    // Start is called before the first frame update
    void Awake()
    {
        num_of_available_blocks = BlockPrefabs.Length;
    }

    public void TetrisUpdate()
    {
        // BlockPrefabs[currentBlock].StartMoving(Vector3.down);
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
        block.StartMoving(Vector3.down);
        // ColorBlock(check, block);
        block.Rotate(degrees[Random.Range(0,degrees.Length)]);
        
        currentBlock = blockActivated;
        
    }
    // this function "COLORS" the block with a new sprite
    private void ColorBlock(Sprite sprite, PlayingBlock block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            Transform child = block.transform.GetChild(i);
            if (child.gameObject.CompareTag(BlockTag))
            {
                child.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }

}
