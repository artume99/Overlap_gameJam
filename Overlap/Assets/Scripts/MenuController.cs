using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   [SerializeField] private BlockManager blockImage;
   [SerializeField] private Image PauseImage;
   [SerializeField] private TextMeshProUGUI streaksText;
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
      blockImage.BlockPrefabs[currentImage].gameObject.SetActive(true);
      return blockImage.BlockPrefabs[currentImage];
   }

   public void Pause()
   {
      if (pause)
      {
         // GameManager.Instance.AudioSources["game"].Play();
         Time.timeScale = 1;
         pause = false;
      }
      else
      {
         // GameManager.Instance.AudioSources["game"].Stop();
         Time.timeScale = 0;
         pause = true;
      }
      PauseImage.enabled = !PauseImage.enabled;
   }

   public void UpdateMenu()
   {
      if(streaksText)
         streaksText.text = String.Format("Streaks: {0:000}", GameManager.Instance.Streak);
   }

   public void RestartGame()
   {
      SceneManager.LoadScene(0);
   }
}
