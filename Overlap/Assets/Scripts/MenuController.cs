using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   [SerializeField] private BlockManager blockImage;
   [SerializeField] private Image PauseImage;
   private int currentImage = 0;
   private bool pause;
   
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

   public void Pause()
   {
      if (pause)
      {
         Time.timeScale = 1;
         pause = false;
      }
      else
      {
         Time.timeScale = 0;
         pause = true;
      }
      PauseImage.enabled = !PauseImage.enabled;
   }

   public void UpdateMenu()
   {
      // Will update points, level etc.
   }

   public void RestartGame()
   {
      SceneManager.LoadScene( SceneManager.GetActiveScene().name );
   }
}
