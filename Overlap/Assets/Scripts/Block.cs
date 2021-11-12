using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IPooledObject
{
    private PlayingBlock[] BlockPrefabs = new PlayingBlock[2];
    private int blockActivated = 0;
    private int currentBlock = 0;
    enum ColorCoding
    {
        Unit,
        PinkP
    }
    private int num_of_available_blocks = 2;

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
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
        Debug.Log(index);
        blockActivated = index;
        BlockPrefabs[currentBlock].gameObject.SetActive(false);
        BlockPrefabs[blockActivated].gameObject.SetActive(true);
        currentBlock = blockActivated;
    }
}
