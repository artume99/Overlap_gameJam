using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private bool moveUP;

    private bool moveDown;

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
            yield return new WaitForSeconds(tikTime);
        }
    }

    private void ShootBlock()
    {
        // GameManager.Instance.GetNextBlock();
        PlayingBlock block = check;
        // rotation check
        GameObject.Instantiate(block, transform.position, Quaternion.Euler(0,0,block.currentRotation));
    }
}
