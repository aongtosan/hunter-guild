using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    TileGenerator tileEngine;
    public MouseController mouseController;
    void Start()
    {
    //    foreach(var m in tileEngine.getMappingTile().mapping){
    //         Debug.Log(m.Value.name);
    //    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
