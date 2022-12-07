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
    // public MouseController mouseControll;
    void Awake(){
       
    }
    void Start()
    {
        Debug.Log("Game Start");
        // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum GameState{
        WORLD,
        COMBAT,
        BASE
    }
}
