using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "PlayingBlock")
      {
         Destroy(other.transform.gameObject);
      }
   }
   
}
