using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FrogPlayer : MonoBehaviour
{
    // Movement memmory
    private bool moveLeft;
    private bool moveRight;
    private bool moveUP;
    private bool moveDown;
    private bool movementAllowed = true;
    
    // Movement Keys
    private KeyCode _up;
    private KeyCode _down;
    private KeyCode _left;
    private KeyCode _right;
    private Collider2D hit;

    [SerializeField]private float tikTime = 0.1f;

    [SerializeField]
    private Transform spawnPoint;
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
        if (Input.GetKeyDown(_left) && movementAllowed)
        {
            moveLeft = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(_right)&& movementAllowed)
        {
            moveRight = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(_up)&& movementAllowed)
        {
            moveUP = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(_down)&& movementAllowed)
        {
            moveDown = true;
            movementAllowed = false;
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
            if (moveLeft)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.left, Vector2.zero, 0f, LayerMask.GetMask
                ("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.left);
                moveLeft = false;
                movementAllowed = true;
            }
            if (moveRight)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.right, Vector2.zero, 0f, LayerMask.GetMask("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.right);
                moveRight = false;
                movementAllowed = true;
            }
            if (moveUP)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.up, Vector2.zero, 0f, LayerMask.GetMask("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.up);
                moveUP = false;
                movementAllowed = true;
            }
            if (moveDown)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.down, Vector2.zero, 0f, LayerMask.GetMask("Blocks"));
                if (hit != null)
                {
                    transform.Translate(Vector3.down);
                }

                moveDown = false;
                movementAllowed = true;
            }
            yield return new WaitForSeconds(tikTime);
        }
        
    }
    public void SetMovementKeys(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        this._up = up;
        this._down = down;
        this._right = right;
        this._left = left;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightEdge") ||other.gameObject.CompareTag("LeftEdge") )
        {
            transform.SetParent(GameManager.Instance.transform);
            transform.position = spawnPoint.position;
        }
        else if (other.gameObject.CompareTag("UnitBlock"))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            transform.SetParent(GameManager.Instance.transform);
            GameManager.Instance.NextLevel();
        }
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("YOU LOOSE");
        }
        
    }
}
