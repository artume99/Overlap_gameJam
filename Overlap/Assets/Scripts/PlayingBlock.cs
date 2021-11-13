using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayingBlock : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;
    public int currentRotation = 0;
    private int defaultRotation = 90;
    private Vector3 currentDirection;
    private bool move = false;

    // Update is called once per frame
    public void TetrisUpdate()
    {
        if (move)
            transform.Translate(currentDirection, Space.World);
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
        // Rotationg the block from the rotation point of the block
        transform.RotateAround(rotationPoint.position,new Vector3(0,0,1), degrees);
        
    }

    public void StartMoving(Vector3 direction)
    {
        move = true;
        currentDirection = direction;

    }
}
