using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CombatManager combatManager;
    
    void Awake(){
        combatManager =this;
    }
    void Start()
    {
        TileGenerator.tileGenerator.Width =6;
        TileGenerator.tileGenerator.Height=6;
        TileGenerator.tileGenerator.Depth =6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
