using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CombatManager combatManager;

    public GameObject cursorPrefab;
    GameObject cursor;
    List<GameObject> unitList;
    List<GameObject> enemyList;
    public Tile selectedTile;
    CombatPhase phase;
    enum CombatPhase{
        DEPLOY,
        PLAYER,
        OPPONENT
    }
    bool isCombatEnd;
    public bool IsCombatEnd{
        set {isCombatEnd = value;}
        get {return isCombatEnd ;}
    }
    void Awake(){
        combatManager =this;
        cursor = new GameObject("Cursor");
       
    }
    void Start()
    {
        phase = CombatPhase.DEPLOY;

        TileGenerator.tileGenerator.Width =6;
        TileGenerator.tileGenerator.Height=1;
        TileGenerator.tileGenerator.Depth =6;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if( Input.GetAxis("Horizontal") * Time.deltaTime !=0f || Input.GetAxis("Vertical") * Time.deltaTime !=0f ){
            Debug.Log("cursor move");
        }
        if(phase==CombatPhase.DEPLOY){
            TileGenerator.tileGenerator.getMappingTile().showTileList();
            phase = CombatPhase.PLAYER;
            Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[new Vector2Int(0,0)].transform.position;
            cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[new Vector2Int(0,0)].transform);
            
            //set cursor parent
            Instantiate(cursorPrefab,TileGenerator.tileGenerator.getMappingTile().mapping[new Vector2Int(0,0)].transform).transform.SetParent(cursor.transform);
            cursor.transform.GetChild(0).transform.localScale = new Vector3 (0.5f,.5f,.5f);
            cursor.transform.localPosition = new Vector3(cursorPosition.x,cursorPosition.y+1.50f,cursorPosition.z);
            
        }
        if(phase==CombatPhase.PLAYER){

        }
        if(phase==CombatPhase.OPPONENT){
            
        }

    }
}
