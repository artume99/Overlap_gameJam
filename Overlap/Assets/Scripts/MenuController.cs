using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   [SerializeField] private BlockManager blockImage;
   private int currentImage = 0;
   public void RotateBlockImage(bool right)
   {
      if (right)
      {
         blockImage.BlockPrefabs[currentImage].Rotate(clockWise:false,inDisplay:true);
      }
      else
      {
         blockImage.BlockPrefabs[currentImage].Rotate(clockWise:true,inDisplay:true);
      }
   }

   public void SetBlockImage(int prefab)
   {
      blockImage.BlockPrefabs[currentImage].gameObject.SetActive(false);
      blockImage.BlockPrefabs[prefab].gameObject.SetActive(true);
      currentImage = prefab;

   }

   public PlayingBlock GetDisplayBlock()
   {
      return blockImage.BlockPrefabs[currentImage];
   }
}
