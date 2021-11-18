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
    private int score;
    private int streak;
    public int Score
    {
        get => score;
        set => score = value;
    }

    public int Streak => streak;


    // References
    // plyaer 1
    // player 2
    public MenuController menu;
    public Transform leftEdge;
    public Transform rightEdge;
    
   
    // Resources
    public Dictionary<string, AudioSource> AudioSources;
    public GameObject[] Blocks;
    private string nextLevelFunc = "OnLevelStart";




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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            menu.RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            menu.Pause();
        }
    }

    public PlayingBlock GetNextBlock()
    {
        return menu.GetDisplayBlock();
    }

    public void NextLevel()
    {
        leftEdge.Translate(Vector3.left);
        rightEdge.Translate(Vector3.right);
        streak++;
        BroadcastMessage(nextLevelFunc,SendMessageOptions.DontRequireReceiver);
    }
    
}
