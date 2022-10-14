using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    const string ROW_NAME_FORMAT = "row[{0}]";
    // Start is called before the first frame update
    //[SerializeField]
    GameObject tilePrefab;
    GameObject tileSlopePrefab;
    MappingTile map;
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
     [SerializeField]
    int slopeTilePercentage;
    int widthOld;

    int heightOld;
   
    int depthOld;
   
    int hillPercentageOld;
   
    int missTilePercentageOld;
    int slopeTilePercentageOld;
    public int Width{
        set {width = value;}
        get {return width;}
    }
    
    public int Height{
        set {height = value;}
        get {return height;}
    }
     public int Depth{
        set {depth = value;}
        get {return depth;}
    }

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
        if(Resources.Load("Prefabs/Tiles/GrassFieldLandTile") as GameObject !=null){
            tilePrefab = Resources.Load("Prefabs/Tiles/GrassFieldLandTile") as GameObject ;
        }if(Resources.Load("Prefabs/Tiles/GrassFiieldSlopeTile") as GameObject !=null){
            tileSlopePrefab = Resources.Load("Prefabs/Tiles/GrassFiieldSlopeTile") as GameObject ;
        }
        else{
             tilePrefab = Resources.Load("Prefabs/Tiles/tile") as GameObject ;
        }
    }
    void Start()
    {
       tileGenerate();
    }
    bool detectChanges(){
        if( !(width==widthOld && 
              height==heightOld && 
              depth == depthOld && 
              missTilePercentage == missTilePercentageOld &&
              hillPercentage == hillPercentageOld && 
              slopeTilePercentage == slopeTilePercentageOld
              ) )return true;
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(detectChanges()){
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
   /* Generating a random map. */
    /// <summary>
    /// It creates a 2D array of tiles movement, and then instantiates a prefab for each tile
    /// </summary>
    void tileGenerate(){
         state = new GameObject("state");
         int hillHeight = 0;
         for(int i = 0 ; i<depth ; i++){//set X location 2d
             GameObject row = new GameObject(string.Format(ROW_NAME_FORMAT,i));
             row.transform.parent = state.transform;
             row.transform.position = new Vector3(0,0,0);
             for(int j = 0 ; j<width ; j++){//set Y Location 2d  as Z axis
                if(Random.Range(1,100)>=missTilePercentage){//check ignore percent on this tile to create on state 
                    if(Random.Range(1,100)<=hillPercentage){//check generate percent create hill on this tile 
                        hillHeight = Random.Range(0,height);//random hill size
                    }
                    for(int k = 0 ; k<=hillHeight ; k++){// Ypos
                        Tile tileInfo = new Tile();
                        GameObject tile = new GameObject(string.Format(Tile.TILE_NAME_FORMAT,i,j));
                        Vector3 tilePos = new Vector3 (i,k,j);
                        tile.transform.SetParent(row.transform);
                        tile.transform.localPosition = tilePos;
                        Instantiate(tilePrefab,tile.transform.transform);
                    }
                    // Vector2 id = new Vector2(i,j);
                    // Tile tileInfo = new Tile();
                    // tileInfo.Id = id;
                }
                hillHeight = 0;
            }
        }

    }

    public void generateSlopeTile(Tile tile){
        
    }  
}
