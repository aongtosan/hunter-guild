using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent gameEvent;
    public MapManager mapManage;
    public CombatManager combatManage;
    private GameState state;

    private GameState State { get => state; set => state = value; }

    // public MouseController mouseControll; 
    void Awake(){
       state = GameState.ONSTARTGAME;
    }
    void Start()
    {
        
        // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }
    public void gameStart(){
        Debug.Log("Game Start");
        SceneManager.LoadScene("TileEngineTest");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public enum GameState{
        ONSTARTGAME,
        WORLD,
        COMBAT,
        BASE
    }
}
