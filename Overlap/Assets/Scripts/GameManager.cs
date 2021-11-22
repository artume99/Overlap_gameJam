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
    public AudioSource switchSound;
    public AudioSource pauseSound;
    public AudioSource gameSound;
    
    public Dictionary<string, AudioSource> AudioSources;
    public GameObject[] Blocks;
    public Animator cameraShake;
    public Animator switchPlayers;
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
        menu.UpdateMenu();
        SetBlockImage();
        AudioSources = new Dictionary<string, AudioSource>
        {
            {"switch",switchSound},
            {"pause",pauseSound},
            {"background", gameSound}
        };
    }

    public void SetBlockImage()
    {
        menu.SetBlockImage(Random.Range(0, Blocks.Length));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioSources["pause"].Play();
            menu.RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
        menu.UpdateMenu();
        // AudioSources["switch"].Play();
        if(streak%2==1)
            switchPlayers.SetTrigger("SwitchTime");
        else
            switchPlayers.SetTrigger("SwitchPlaces");

        BroadcastMessage(nextLevelFunc,SendMessageOptions.DontRequireReceiver);
    }

    public void PlayerDied()
    {
        streak = 0;
        menu.UpdateMenu();
        StartCoroutine(LoadLevel());
    }
    
    private IEnumerator LoadLevel()
    {
        cameraShake.SetTrigger("camerashake");
        yield return new WaitForSeconds(0.1f);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
