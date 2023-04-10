using System.Collections.Generic;
using UnityEngine;

public class MappingTile
{
 
    public Dictionary<Vector2Int,GameObject> mapping;
    public List<Tile> tileInfoList;
    public MappingTile(){
        mapping = new Dictionary<Vector2Int, GameObject>();     
        tileInfoList = new List<Tile>();
    }
    public void mergeInfo(Vector2Int key,int height){
        Tile tileModel =new Tile(key,height);
        tileInfoList.Add(tileModel);
    }
    public void showTileList(){
        Debug.Log(tileInfoList.Count);
    }
    public void addTileInfo(){
        foreach( var t in mapping ){
            t.Value.gameObject.AddComponent<TileController>();
            t.Value.gameObject.GetComponent<TileController>().Tile = new Tile();
            t.Value.gameObject.GetComponent<TileController>().Tile.LocationX = t.Key.x;
            t.Value.gameObject.GetComponent<TileController>().Tile.LocationY = t.Key.y;
            t.Value.gameObject.GetComponent<TileController>().Tile.Height = (int) t.Value.gameObject.transform.position.y;
        }
    }
    public string logTileInfo(Vector2Int key){
        return "";
    }

    
}
