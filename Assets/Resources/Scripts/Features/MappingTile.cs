using System.Collections.Generic;
using UnityEngine;

public class MappingTile
{
    public Dictionary<Vector2Int,GameObject> mapping;
  
    public MappingTile(){
        mapping = new Dictionary<Vector2Int, GameObject>();
    }
  
}
