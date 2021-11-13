using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisRoot : MonoBehaviour
{
    [SerializeField] private float tikTime = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(MoveObject());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private IEnumerator MoveObject()
    {
        yield return null;
        while (true)
        {
            BroadcastMessage("TetrisUpdate",SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(tikTime);
        }
        
    }
}
