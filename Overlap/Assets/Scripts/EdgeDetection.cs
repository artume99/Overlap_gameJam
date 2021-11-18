using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour
{
    private BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftEdge"))
        {
            if(!transform.parent.GetComponent<PlayingBlock>().direction) 
                bc.enabled = false;
        }
        else if(other.gameObject.CompareTag("RightEdge"))
        {
            if(transform.parent.GetComponent<PlayingBlock>().direction) 
                bc.enabled = false;
        }
    }
}
