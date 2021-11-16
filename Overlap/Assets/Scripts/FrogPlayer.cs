using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPlayer : MonoBehaviour
{
    private bool moveLeft;

    private bool moveRight;

    private bool moveUP;

    private bool moveDown;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUP = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
            if (moveLeft)
            {
                transform.Translate(Vector3.left);
                moveLeft = false;
            }
            if (moveRight)
            {
                transform.Translate(Vector3.right);
                moveRight = false;
            }
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("UnitBlock"))
        {
            Debug.Log("hi");
            transform.SetParent(other.transform);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("UnitBlock"))
        {
            Debug.Log("bye");
            transform.SetParent(null);
        }
    }
    
}
