using System.Collections.Generic;
using UnityEngine;

public class MappingTile
{
    public static MappingTile mappingTileInstance;
    public Dictionary<Vector2Int,GameObject> mapping;
    public List<Tile> tileInfoList;
    public MappingTile(){
        mapping = new Dictionary<Vector2Int, GameObject>();     
    }
    void mergeInfo(){
        Tile tileModel =new Tile();
    }
    public string logTileInfo(Vector2Int key){
        return "";
    }
    
}
