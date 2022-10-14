using System.Collections.Generic;
using UnityEngine;

public class MappingTile
{
    Dictionary<Vector2,GameObject> mapping;
    public MappingTile(){
        mapping = new Dictionary<Vector2, GameObject>();
    }

}
