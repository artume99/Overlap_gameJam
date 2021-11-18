using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Movement memmory
    private bool moveUP;
    private bool moveDown;
    private bool shootRight;
    private bool shootLeft;
    
    // Movement Keys
    private KeyCode _up;
    private KeyCode _down;
    private KeyCode _leftShot;
    private KeyCode _rightShot;
    
    private int startLevelOffset = 6;
    [SerializeField] private Transform tetrisRoot;
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
        
        if (Input.GetKeyDown(_up))
        {
            moveUP = true;
        }
        if (Input.GetKeyDown(_down))
        {
            moveDown = true;
        }
        if (Input.GetKeyDown(_leftShot) && timer>(tikTime*4))
        {
            shootRight = true;
            timer = 0;
        }
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     GameManager.Instance.menu.RotateBlockImage(false);
        // }
        if (Input.GetKeyDown(_rightShot) && timer>(tikTime*4))
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

    public void SetMovementKeys(KeyCode up, KeyCode down, KeyCode leftShot, KeyCode rightShot)
    {
        this._up = up;
        this._down = down;
        this._rightShot = rightShot;
        this._leftShot = leftShot;
    }
}
