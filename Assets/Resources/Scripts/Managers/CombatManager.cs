using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CombatManager combatManager;
    Ray mouseRay;
    // public LayerMask layerTarget;
    public GameObject cursorPrefab;
    public GameObject cursor;
    GameObject selectedUnit;
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

      enum FieldSize{
        TINY,
        SMALL,
        MEDIUM,
        LARGE,

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
        initCombatState();
        //Animate generate tile
    }
    void initCombatState(){
        FieldSize size = (FieldSize) Random.Range( (int)FieldSize.TINY ,(int)FieldSize.LARGE + 1);
        switch(size){
            case FieldSize.TINY : break ;  // 10*1*10 
            case FieldSize.SMALL : break ; // 25*1*25
            case FieldSize.MEDIUM : break ; // 50*1*50
            case FieldSize.LARGE : break ;  // 80*1*80
        }
        TileGenerator.tileGenerator.Width =6;
        TileGenerator.tileGenerator.Height=1;
        TileGenerator.tileGenerator.Depth =6;
        TileGenerator.tileGenerator.HillPercentage=10;
        //TileGenerator.tileGenerator.Biom = Bioms.Biom.GRASSFIELDLAND;
    }
    void moveCursor(){
        // for new input: mouse
         mouseRay = Camera.main.ViewportPointToRay(Input.mousePosition);
         //Debug.Log(Input.mousePosition);
         if(Input.GetMouseButton(0)){
                if(Physics.Raycast(mouseRay,out RaycastHit hit ) ){
                Debug.Log(hit.collider.gameObject.name);
         }
         }
         

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ){
            if(Input.GetKeyDown(KeyCode.RightArrow ) || Input.GetKeyDown(KeyCode.D)){
                Debug.Log("Right"); //++ increase horizontal cursor location
                if(initCursorPosition.x + 1> TileGenerator.tileGenerator.Depth-1){
                    initCursorPosition.x=0;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }else{
                    initCursorPosition += new Vector2Int(1,0);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                Debug.Log("Left"); //-- decrease horizontal cursor location
                if(initCursorPosition.x - 1 < 0){
                    initCursorPosition.x= TileGenerator.tileGenerator.Depth-1;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }else{
                    initCursorPosition -= new Vector2Int(1,0);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) ){
            if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)){
                Debug.Log("Up"); //++ increase Vertical cursor location
                 if(initCursorPosition.y + 1> TileGenerator.tileGenerator.Width-1){
                    initCursorPosition.y=0;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }else{
                    initCursorPosition += new Vector2Int(0,1);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
                Debug.Log("Down"); //-- decrease Vertical cursor location
                if(initCursorPosition.y - 1 < 0){
                    initCursorPosition.y= TileGenerator.tileGenerator.Width-1;
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
                }else{
                    initCursorPosition -= new Vector2Int(0,1);
                    Vector3  cursorPosition = TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform.position;
                    cursor.transform.SetParent(TileGenerator.tileGenerator.getMappingTile().mapping[initCursorPosition].transform);
                    cursor.transform.localPosition = new Vector3(0f,cursorPosition.y+3.50f,0f);
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
            cursor.transform.localPosition = new Vector3(cursorPosition.x,cursorPosition.y+3.50f,cursorPosition.z);
            
        }
        if(phase==CombatPhase.PLAYER){

        }
        if(phase==CombatPhase.OPPONENT){
            
        }

    }
}
