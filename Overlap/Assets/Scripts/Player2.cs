using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private bool moveUP;

    private bool moveDown;

    private bool shootRight;
    private bool shootLeft;
    private int startLevelOffset = 6;

    [SerializeField] private Transform tetrisRoot;

    public PlayingBlock check;
    private float timer;

    [SerializeField] private float tikTime = 0.2f;
    [SerializeField] private float blockTikTime = 0.7f;

    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(MoveObject());
    }
    
    private void Start()
    {
        OnLevelStart();
    }
    public void OnLevelStart()
    {
        transform.position = spawnPoint.position;
    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUP = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && timer>(tikTime*4))
        {
            shootRight = true;
            timer = 0;
        }
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     GameManager.Instance.menu.RotateBlockImage(false);
        // }
        if (Input.GetKeyDown(KeyCode.D) && timer>(tikTime*4))
        {
            shootLeft = true;
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void TetrisUpdate()
    {
        
    }
    private IEnumerator MoveObject()
    {
        yield return null;
        while (true)
        {
            if (moveUP)
            {

                transform.Translate(Vector3.up);
                moveUP = false;
            }
            if (moveDown)
            {
                transform.Translate(Vector3.down);
                moveDown = false;
            }

            if (shootRight)
            {
                ShootBlock(Vector3.right,transform.position);
                shootRight = false; 
            }

            if (shootLeft)
            {
                int offset = startLevelOffset + GameManager.Instance.Streak*2;
                ShootBlock(Vector3.left,transform.position+new Vector3(offset,0,0));
                shootLeft = false; 
            }
            yield return new WaitForSeconds(tikTime);
        }
    }

    private void ShootBlock(Vector3 direction, Vector3 pos)
    {
        var block = GameManager.Instance.GetNextBlock();
        block = Instantiate(block, transform.parent);
        // block.transform.SetParent(tetrisRoot);
        block.transform.position = pos;
        block.tag = "PlayingBlock";
        block.direction = direction == Vector3.right;
        block.transform.rotation = Quaternion.Euler(0, 0,block.currentRotation);
        block.SetBlockTikTime(blockTikTime);
        block.StartMoving(direction, playerBlock:true);
        GameManager.Instance.SetBlockImage();
    }
}
