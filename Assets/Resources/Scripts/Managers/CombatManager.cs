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
    Vector2Int initCursorPosition;
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
        initCursorPosition =new Vector2Int(0,0);
       
    }
    void Start()
    {
        phase = CombatPhase.DEPLOY;

        TileGenerator.tileGenerator.Width =6;
        TileGenerator.tileGenerator.Height=1;
        TileGenerator.tileGenerator.Depth =6;
    }
    void moveCursor(){
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ){
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                Debug.Log("Right"); //++ increase horizontal cursor location
                if(initCursorPosition.x + 1> TileGenerator.tileGenerator.Depth-1){
                    initCursorPosition.x=0;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }else{
                    initCursorPosition += new Vector2Int(1,0);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                Debug.Log("Left"); //-- decrease horizontal cursor location
                if(initCursorPosition.x - 1 < 0){
                    initCursorPosition.x= TileGenerator.tileGenerator.Depth-1;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }else{
                    initCursorPosition -= new Vector2Int(1,0);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Debug.Log("Up"); //++ increase Vertical cursor location
                 if(initCursorPosition.y + 1> TileGenerator.tileGenerator.Width-1){
                    initCursorPosition.y=0;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }else{
                    initCursorPosition += new Vector2Int(0,1);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                Debug.Log("Down"); //-- decrease Vertical cursor location
                if(initCursorPosition.y - 1 < 0){
                    initCursorPosition.y= TileGenerator.tileGenerator.Width-1;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }else{
                    initCursorPosition -= new Vector2Int(0,1);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+1.50f,0f);
                }
            }
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        moveCursor();
        if(phase==CombatPhase.DEPLOY){
            TileGenerator.tileGenerator.getMappingTile().showTileList();
            phase = CombatPhase.PLAYER;
            Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
            cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
            
            //set cursor parent
            Instantiate(cursorPrefab,TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform).transform.SetParent(cursor.transform);
            cursor.transform.GetChild(0).transform.localScale = new Vector3 (0.5f,.5f,.5f);
            cursor.transform.localPosition = new Vector3(cursorPosition.x,cursorPosition.y+1.50f,cursorPosition.z);
            
        }
        if(phase==CombatPhase.PLAYER){

        }
        if(phase==CombatPhase.OPPONENT){
            
        }

    }
}
