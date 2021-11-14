using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private bool moveUP;

    private bool moveDown;

    private bool shoot;

    [SerializeField] private Transform tetrisRoot;

    public PlayingBlock check;

    [SerializeField] private float tikTime = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(MoveObject());
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.Instance.menu.RotateBlockImage(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.Instance.menu.RotateBlockImage(true);
        }
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

            if (shoot)
            {
                ShootBlock();
                shoot = false; 
            }
            yield return new WaitForSeconds(tikTime);
        }
    }

    private void ShootBlock()
    {
        
        var block = GameManager.Instance.GetNextBlock();
        block = Instantiate(block);
        block.transform.SetParent(tetrisRoot);
        block.transform.position = transform.position + Vector3.right;
        block.transform.rotation = Quaternion.Euler(0, 0,block.currentRotation);
        block.StartMoving(Vector3.right, playerBlock:true);
        GameManager.Instance.SetBlockImage();
    }
}
