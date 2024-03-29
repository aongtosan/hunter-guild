using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public static MouseController mouseController;
    private GameObject onHoverTile;
    public GameObject OnHoverTile{
        set{ onHoverTile = value;}
        get{return onHoverTile;}
    }
    Vector3 mouseLocationOld;
    void Awake(){
        mouseController = this ;
    }
    void Start()
    {
        // mouseLocationOld =  Input.mousePosition;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray,out RaycastHit hit);
        if(hit.collider!=null) {
            
            if( onHoverTile == null || onHoverTile != hit.collider.gameObject.transform.parent.gameObject){
                OnHoverTile=hit.collider.gameObject.transform.parent.gameObject; 
                // Debug.Log (OnHoverTile.GetComponent<TileController>().Tile.LocationX+","+OnHoverTile.GetComponent<TileController>().Tile.LocationY);
            }
        }
        // CombatManager.combatManager.cursor.transform.position = hit.point ;
        // if(detectPositionChange()){
        //      Debug.Log(Input.mousePosition);
        //      mouseLocationOld=Input.mousePosition;
        // }
        
       
    }
    bool detectPositionChange(){
        return mouseLocationOld!=Input.mousePosition ? true : false ; 
    }
}
