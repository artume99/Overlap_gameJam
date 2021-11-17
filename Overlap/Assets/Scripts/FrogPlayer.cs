using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FrogPlayer : MonoBehaviour
{
    private bool moveLeft;

    private bool moveRight;

    private bool moveUP;

    private bool moveDown;

    private bool movementAllowed = true;

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
        transform.position = spawnPoint.position;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && movementAllowed)
        {
            moveLeft = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&& movementAllowed)
        {
            moveRight = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& movementAllowed)
        {
            moveUP = true;
            movementAllowed = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)&& movementAllowed)
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
                hit = Physics2D.OverlapBox(transform.position+Vector3.left, Vector2.one, 0f, LayerMask.GetMask
                ("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.left);
                moveLeft = false;
                movementAllowed = true;
            }
            if (moveRight)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.right, Vector2.one, 0f, LayerMask.GetMask("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.right);
                moveRight = false;
                movementAllowed = true;
            }
            if (moveUP)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.up, Vector2.one, 0f, LayerMask.GetMask("Blocks"));
                if(hit!=null) 
                    transform.Translate(Vector3.up);
                moveUP = false;
                movementAllowed = true;
            }
            if (moveDown)
            {
                hit = Physics2D.OverlapBox(transform.position+Vector3.down, Vector2.one, 0f, LayerMask.GetMask("Blocks"));
                if(hit!=null) {}
                    transform.Translate(Vector3.down);
                
                moveDown = false;
                movementAllowed = true;
            }
            yield return new WaitForSeconds(tikTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Map"))
        {
            transform.SetParent(null);
            transform.position = spawnPoint.position;
        }
        else if (other.gameObject.CompareTag("UnitBlock"))
        {
            transform.SetParent(other.transform);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("UnitBlock"))
        {
            transform.SetParent(null);
        }
    }
    
}
