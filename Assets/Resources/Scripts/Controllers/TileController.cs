using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    Tile tile;
    public Tile Tile{
        set{tile = value;}
        get{return tile;}
    }
}
