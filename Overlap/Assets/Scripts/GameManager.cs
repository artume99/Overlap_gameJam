using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // GAME STATE
    public int Score { get; set; }


    // References
    // plyaer 1
    // player 2
    // menue (ui manager)
    
   
    // Resources
    public Dictionary<string, AudioSource> AudioSources;
    public GameObject[] Blocks;




    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public PlayingBlock GetNextBlock()
    {
        return null;
    }
    
    
}
