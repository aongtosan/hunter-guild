using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    const string TILE_NAME_FORMAT = "tile[{0}][{1}]";
    const string ROW_NAME_FORMAT = "row[{0}]";
    // Start is called before the first frame update
    [SerializeField]
    GameObject tilePrefab;
    [SerializeField]
    int width;
    [SerializeField]
    int height;
    [SerializeField]
    int depth;
    [SerializeField]
    int hillPercentage;
    [SerializeField]
    int missTilePercentage;
    
    int widthOld;

    int heightOld;
   
    int depthOld;
   
    int hillPercentageOld;
   
    int missTilePercentageOld;

    GameObject state;
    //define depth = axis Z
    //define height = axis y
    //define width = axis x
    List<GameObject> tileList;
    void Awake(){
        tileList = new List<GameObject>();
        loadTileData();
        widthOld = width;
        heightOld = height;
        depthOld = depth;
        missTilePercentageOld =missTilePercentage;
        hillPercentageOld = hillPercentage;
    }
    void loadTileData(){
         // tilePrefab = Resources.Load("Prefabs/Tiles/GrassLandtile") as GameObject ;
        tilePrefab = Resources.Load("Prefabs/Tiles/tile") as GameObject ;
        // if(Resources.Load("Prefabs/Tiles/GrassLandtile") as GameObject !=null){
        //     tilePrefab = Resources.Load("Prefabs/Tiles/GrassLandtile") as GameObject ;
        // }else{
        //      tilePrefab = Resources.Load("Prefabs/Tiles/tile") as GameObject ;
        // }
    }
    void Start()
    {
       tileGenerate();
    }
    bool detectChanges(){
        if( !(width==widthOld && height==heightOld && depth == depthOld && missTilePercentage == missTilePercentageOld && hillPercentage == hillPercentageOld) )return true;
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(detectChanges()){
            //tileGenerate();
            Debug.Log("change");
            widthOld = width;
            heightOld = height;
            depthOld = depth;
            missTilePercentageOld =missTilePercentage;
            hillPercentageOld = hillPercentage;
            Destroy(state);
            tileGenerate();
        }
    }
    void tileGenerate(){
         state = new GameObject("state");
         for(int i = 0 ; i<depth ; i++){//set X location 2d
             GameObject row = new GameObject(string.Format(ROW_NAME_FORMAT,i));
             row.transform.parent = state.transform;
             row.transform.position = new Vector3(0,0,0);
             for(int j = 0 ; j<width ; j++){//set Y Location 2d  as Z axis
                //for(int k = 0 ; k<height ; k++){// Ypos
                    GameObject tile = new GameObject(string.Format(TILE_NAME_FORMAT,i,j));
                    Vector3 tilePos = new Vector3 (i,0,j);
                    tile.transform.SetParent(row.transform);
                    tile.transform.localPosition = tilePos;
                    Instantiate(tilePrefab,tile.transform.transform);
                //}
            }
        }
    }
}
