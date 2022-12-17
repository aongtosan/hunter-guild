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
    public GameState state;

    GameState saveState;
     public enum GameState{
        ONSTARTGAME,
        WORLD,
        COMBAT,
        BASE
    }

    // public MouseController mouseControll; 
    void Awake(){
       state = GameState.ONSTARTGAME;
       saveState = GameState.ONSTARTGAME;
    }
    void Start()
    {
        
        // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }
    public void gameStart(){
        Debug.Log("Game Start");
        state=GameState.WORLD;

        // SceneManager.LoadScene("TileEngineTest");
    }
    // Update is called once per frame
    void Update()
    {
        if(saveState!=state)
        switch(state){

            case  GameState.ONSTARTGAME : {
                SceneManager.LoadScene("SquenceGameTest");
                // state = GameState.WORLD;
                break;
            } 
            case  GameState.WORLD : {
                saveState =GameState.WORLD;
                SceneManager.LoadScene("WorldMapTest");
                //if(change location)
                break;
            } 
            case  GameState.BASE : {
                
                break;
            } 
            case  GameState.COMBAT : {
                
                break;
            }
            default : break;

            
        }
    }
    }


