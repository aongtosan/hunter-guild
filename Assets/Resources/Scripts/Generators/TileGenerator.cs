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
    GameObject tileHalfPrefab;
    GameObject tileSlopeHalfPrefab;

  

    MappingTile map;

    [SerializeField]
    Bioms.Biom biom;
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
    [SerializeField]
    bool change;
    int widthOld;
    Bioms.Biom biomOld;
    int heightOld;
   
    int depthOld;
   
    int hillPercentageOld;
   
    int missTilePercentageOld;
    int slopeTilePercentageOld;
    int halfTilePercentageOld;
    bool changeOld;
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
/// <summary>
/// This function is called when the game starts and it creates a list of tiles, loads the tile data,
/// sets the old values of the variables to the current values, creates a new map, and then generates
/// the tiles.
/// </summary>
    void Awake(){
        tileList = new List<GameObject>();
        loadTileData(biom);
        widthOld = width;
        heightOld = height;
        depthOld = depth;
        missTilePercentageOld = missTilePercentage;
        hillPercentageOld = hillPercentage;
        map = new MappingTile();
        tileGenerate();
    }
    /// <summary>
    /// It loads the prefabs of the tiles that will be used in the game
    /// </summary>
    /// <param name="Biom">The Biom enum is a list of all the bioms in the game.</param>
    void loadTileData(Bioms.Biom biom){
        if(biom == Bioms.Biom.GRASSFIELDLAND){
            tileHalfPrefab = Resources.Load("Prefabs/Tiles/GrassFieldLandHalfTile") as GameObject ;
            tilePrefab = Resources.Load("Prefabs/Tiles/GrassFieldLandTile") as GameObject ;
            tileSlopeHalfPrefab =  Resources.Load("Prefabs/Tiles/GrassFiieldSlopeHalfTile") as GameObject ;
            tileSlopePrefab = Resources.Load("Prefabs/Tiles/GrassFiieldSlopeTile") as GameObject ;
        }
        else{
             tilePrefab = Resources.Load("Prefabs/Tiles/tile") as GameObject ;
             tileHalfPrefab = Resources.Load("Prefabs/Tiles/halfTile") as GameObject ;
             tileSlopeHalfPrefab =  Resources.Load("Prefabs/Tiles/SlopeHalfTile") as GameObject ;
             tileSlopePrefab = Resources.Load("Prefabs/Tiles/SlopeHalfTile") as GameObject ;
        }
    }
    bool detectChanges(){
        if( !(width == widthOld && 
              height == heightOld && 
              depth == depthOld && 
              missTilePercentage == missTilePercentageOld &&
              hillPercentage == hillPercentageOld && 
              slopeTilePercentage == slopeTilePercentageOld &&
              halfTilePercentage == halfTilePercentageOld &&
              biom == biomOld &&
              change==changeOld
              ) )return  true;
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
            biomOld = biom;
            changeOld= change;
            Destroy(state);
            map.mapping.Clear();
            loadTileData(biom);
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
        // halfTilePrefab.transform.localScale = new Vector3(1f,1f,1f);
         for(int i = 0 ; i<depth ; i++){//set X location 2d
             GameObject row = new GameObject(string.Format(ROW_NAME_FORMAT,i));
             row.transform.parent = state.transform;
             row.transform.position = new Vector3(0,0,0);
             for(int j = 0 ; j<width ; j++){//set Y Location 2d  as Z axis
                if(Random.Range(1,100)>=missTilePercentage){//check ignore percent on this tile to create on state 
                    if(Random.Range(1,100)<=hillPercentage){//check generate percent create hill on this tile 
                        hillHeight = Random.Range(hillPercentage==100 ? 1 : 0 ,height);//random hill size
                    }
                    for(int k = 0 ; k<=hillHeight ; k++){// Ypos
                        tile = new GameObject(string.Format(Tile.TILE_NAME_FORMAT,i,j));
                        Vector3 tilePos = new Vector3 (i,k,j);
                        tile.transform.SetParent(row.transform);
                        tile.transform.localPosition = tilePos;
                        tile.transform.tag = "Tile";
                        Instantiate(tilePrefab,tile.transform.transform);
                    }
                     Vector2Int id = new Vector2Int(i,j);
                     Tile tileInfo = new Tile();
                     tileInfo.Id = id;
                     map.mapping.Add(tileInfo.Id,tile);
                    //  Debug.Log(map.mapping[tileInfo.Id].name);
                }
                hillHeight = 0;
            }
        }
       /* Generating half tile slope. */
        List<Vector2Int> keys = new List<Vector2Int>(map.mapping.Keys);
        foreach(var k in keys){
                if(Random.Range(1,100) <= halfTilePercentage/2){
                    Transform row = (map.mapping[k].transform.parent );
                    Vector2 id = k;
                    tile = new GameObject( string.Format(Tile.TILE_NAME_FORMAT,id.x,id.y) );
                    tile.transform.SetParent(row);
                    tile.transform.localPosition = (map.mapping[k].transform.localPosition + new Vector3(0,0.75f,0) );
                    tile.transform.tag = "HalfTile";
                    Instantiate(tileHalfPrefab,tile.transform.transform); 
                    map.mapping[k] = tile;
                } 
                // Debug.Log(map.mapping[k].transform.tag);
        }
        // Generate slope tile
        foreach(var k in keys){
            if( k.y+1<=width-1 && map.mapping[k].transform.tag.Equals("HalfTile") && !( map.mapping[k+new Vector2Int(0,1)].transform.tag.Equals("HalfTile"))) {
                 if(Random.Range(1,100) <= halfTilePercentage/2){
                    // if(k.y+1<=width-1){
                        Transform row = map.mapping[k+new Vector2Int(0,1)].transform.parent;
                        Debug.Log(map.mapping[k]);
                        Vector2Int id = k+(new Vector2Int(0,1));
                        tile = new GameObject( string.Format(Tile.TILE_NAME_FORMAT,id.x,id.y) );
                        tile.transform.SetParent(row);
                        tile.transform.localPosition = (map.mapping[id].transform.localPosition + new Vector3(0,0.75f,0) );
                        tile.transform.tag = "SlopeTile";
                        Instantiate(tileSlopeHalfPrefab,tile.transform.transform); 
                        map.mapping[id] = tile;
                    }
                // } 
            }
           
        }
        // Generate half slope tile
        foreach(var k in keys){
            if( k.y+1<=width-1 && map.mapping[k].transform.tag.Equals("Tile") && !( map.mapping[k+new Vector2Int(0,1)].transform.tag.Equals("Tile")) && map.mapping[k].transform.position.y>0 ) {
                    if(Random.Range(1,100) <= halfTilePercentage/2){
                        // if(k.y+1<=width-1){
                            Transform row = map.mapping[k+new Vector2Int(0,1)].transform.parent;
                            Debug.Log(map.mapping[k]);
                            Vector2Int id = k+(new Vector2Int(0,1));
                            tile = new GameObject( string.Format(Tile.TILE_NAME_FORMAT,id.x,id.y) );
                            tile.transform.SetParent(row);
                            tile.transform.localPosition = (map.mapping[id].transform.localPosition + new Vector3(0,0.75f,0) );
                            tile.transform.tag = "SlopeTile";
                            Instantiate(tileSlopePrefab,tile.transform.transform); 
                            map.mapping[id] = tile;
                        }
            }
        }

    }
    public MappingTile getMappingTile(){
        return map;
    }

    
}
