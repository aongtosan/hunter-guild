using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour{
    // Start is called before the first frame update
    
    public static WorldManager instance;
    public Behaviour uiCanvas;
     void Awake(){
        instance =this;
       
    }
    // void Start()
    // {
    //     isOnWorldMap =true;
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            uiCanvas.enabled = !uiCanvas.enabled;
            Debug.Log("clicked");
            Debug.Log(Input.mousePosition);
        }
        // Debug.Log(isOnWorldMap);
    }
    public void enterMap(){
        
         Debug.Log("enter map "+Gamemanager.instance.state);
         Gamemanager.instance.state = Gamemanager.GameState.COMBAT;
         Debug.Log("enter map "+Gamemanager.instance.state);
         SceneManager.LoadScene("SquenceGameTest");
    } 


    //Detect if clicks are no longer registering

}
