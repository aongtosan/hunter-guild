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

    enum Biom {
        DEFAULT,
        GRASSFIELDLAND
    };

    MappingTile map;

    [SerializeField]
    Biom biom;
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
    [SerializeField]
    int halfTilePercentage;
    int widthOld;
    Biom biomOld;
    int heightOld;
   
    int depthOld;
   
    int hillPercentageOld;
   
    int missTilePercentageOld;
    int slopeTilePercentageOld;
    int halfTilePercentageOld;
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
        missTilePercentageOld = missTilePercentage;
        hillPercentageOld = hillPercentage;
        map = new MappingTile();
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
              slopeTilePercentage == slopeTilePercentageOld &&
              halfTilePercentage == halfTilePercentageOld
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
            slopeTilePercentageOld = slopeTilePercentage;
            halfTilePercentageOld = halfTilePercentage;
            Destroy(state);
            map.mapping.Clear();
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
         GameObject tile  = null ;
        //  GameObject halfTilePrefab = Resources.Load("Prefabs/Tiles/tile") as GameObject ; test 
        //  halfTilePrefab.transform.localScale = new Vector3(1f,0.5f,1f);
        GameObject halfTilePrefab = Resources.Load("Prefabs/Tiles/GrassFieldLandHalfTile") as GameObject ;
        // halfTilePrefab.transform.localScale = new Vector3(1f,1f,1f);
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
                        tile = new GameObject(string.Format(Tile.TILE_NAME_FORMAT,i,j));
                        Vector3 tilePos = new Vector3 (i,k,j);
                        tile.transform.SetParent(row.transform);
                        tile.transform.localPosition = tilePos;
                        Instantiate(tilePrefab,tile.transform.transform);
                    }
                     Vector2Int id = new Vector2Int(i,j);
                     Tile tileInfo = new Tile();
                     tileInfo.Id = id;
                     map.mapping.Add(tileInfo.Id,tile);
                     Debug.Log(map.mapping[tileInfo.Id].name);
                }
                hillHeight = 0;
            }
        }
       /* Generating half tile slope. */
        foreach(var v  in map.mapping ){
                if(Random.Range(1,100) <= halfTilePercentage){
                    Transform row = v.Value.transform.parent ;
                    Vector2 id = v.Key;
                    tile = new GameObject( string.Format(Tile.TILE_NAME_FORMAT,id.x,id.y) );
                    tile.transform.SetParent(row);
                    tile.transform.localPosition = (v.Value.transform.localPosition + new Vector3(0,0.75f,0) );
                    Instantiate(halfTilePrefab,tile.transform.transform);
                }            
        }

    }

    
}
