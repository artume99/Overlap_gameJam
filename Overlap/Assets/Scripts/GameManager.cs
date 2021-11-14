using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // GAME STATE
    public int Score { get; set; }


    // References
    // plyaer 1
    // player 2
    public MenuController menu;
    
   
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

    private void Start()
    {
        SetBlockImage();
    }

    public void SetBlockImage()
    {
        menu.SetBlockImage(Random.Range(0, Blocks.Length));
    }

    public PlayingBlock GetNextBlock()
    {
        return menu.GetDisplayBlock();
    }
    
    
}
