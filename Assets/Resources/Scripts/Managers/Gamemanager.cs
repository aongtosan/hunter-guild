using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent gameEvent;
    void Start()
    {
        
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
