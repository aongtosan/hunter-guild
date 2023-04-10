using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2Int initCursorPosition;
    GameObject cursor = new GameObject("Cursor");
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void moveCursor(){
        // for new input: mouse
        // mouseRay = Camera.main.ViewportPointToRay(Input.mousePosition);

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
}
