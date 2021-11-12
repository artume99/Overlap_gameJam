using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingBlock : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     Rotate(90);
        // }
    }

    public void Rotate(int degrees)
    {
        // Rotationg the block from the rotation point of the block
        transform.RotateAround(rotationPoint.position,new Vector3(0,0,1), degrees);
    }
}
