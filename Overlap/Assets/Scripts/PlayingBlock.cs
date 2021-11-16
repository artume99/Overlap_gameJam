using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayingBlock : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;
     public Transform spawnPoint;
    
    public int currentRotation = 0;
    private int defaultRotation = 90;
    private Vector3 currentDirection;
    private bool move = false;
    private float tikTime = 0.5f;
    

    // Update is called once per frame
    public void TetrisUpdate()
    {
        if (move)
            transform.Translate(currentDirection, Space.World);
    }
    private IEnumerator PlayerBlockMovement()
    {
        yield return null;
        while (true)
        {
            transform.Translate(currentDirection, Space.World);
            yield return new WaitForSeconds(tikTime);
        }
        
    }

    public void Rotate(int degrees=90, bool clockWise=true, bool inDisplay=false)
    {
        if (inDisplay)
        {
            if (clockWise)
            {
                transform.RotateAround(rotationPoint.position,new Vector3(0,0,1), defaultRotation);
                currentRotation += defaultRotation;
            }
            else
            {
                transform.RotateAround(rotationPoint.position,new Vector3(0,0,1), -defaultRotation);
                currentRotation -= defaultRotation;
            }
        }
        else
        {
            transform.RotateAround(rotationPoint.position,new Vector3(0,0,1), degrees);
        }
        // Rotationg the block from the rotation point of the block
        
    }

    public void StartMoving(Vector3 direction, bool playerBlock=false)
    {
        if(!playerBlock)
            transform.localPosition = Vector3.zero;
        else
            StartCoroutine(PlayerBlockMovement());
        move = true;
        currentDirection = direction;

    }

    public void SetBlockTikTime(float tik)
    {
        tikTime = tik;
    }
}
