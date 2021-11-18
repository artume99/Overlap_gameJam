using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private SpriteRenderer frogger;
    [SerializeField] private SpriteRenderer creator;
    
    private static PlayersManager _instance;

    public static PlayersManager Instance { get { return _instance; } }

    private class Controls
    {
        public KeyCode _up ;
        public KeyCode _down;
        public KeyCode _left ;
        public KeyCode _right ;
    }

    private class FroggerKeys : Controls
    {
        public FroggerKeys()
        {
            _up = KeyCode.UpArrow; 
            _down = KeyCode.DownArrow;
            _left = KeyCode.LeftArrow;
            _right = KeyCode.RightArrow;
        }
       
    }
    private class CreatorKeys : Controls
    {
        public CreatorKeys()
        {
            _up = KeyCode.W;
            _down = KeyCode.S;
            _left = KeyCode.A;
            _right = KeyCode.D;
            
        }
    }

    private List<Controls> controls = new List<Controls>{new FroggerKeys(), new CreatorKeys()};
    private int controlIndex = 0;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    void Start()
    {
        var ctrl = controls[controlIndex % 2];
        player1.GetComponent<FrogPlayer>().SetMovementKeys(ctrl._up, ctrl._down, ctrl._left, ctrl._right);
        controlIndex++;
        ctrl = controls[controlIndex % 2];
        player2.GetComponent<Player2>().SetMovementKeys(ctrl._up, ctrl._down, ctrl._left, ctrl._right);
    }

    // Update is called once per frame
    public void OnLevelStart()
    {
        var ctrl = controls[controlIndex % 2];
        player1.GetComponent<FrogPlayer>().SetMovementKeys(ctrl._up, ctrl._down, ctrl._left, ctrl._right);
        controlIndex++;
        ctrl = controls[controlIndex % 2];
        player2.GetComponent<Player2>().SetMovementKeys(ctrl._up, ctrl._down, ctrl._left, ctrl._right);
        
        (frogger.sprite, creator.sprite) = (creator.sprite, frogger.sprite);
    }
}
