using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TileGenerator tileGen;
    // void Start()
    // {
    //     // tileGen = GetComponent<TileGenerator>();
    //     // transform.Translate( new Vector4(-tileGen.Width,3,tileGen.Height) ,Space.World);
    //     transform.position = new Vector3 (-tileGen.Width,3,tileGen.Height);
    // }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate( new Vector4(-tileGen.Width,3,tileGen.Height) ,Space.World);
        int camLoc =  Mathf.Max(tileGen.Width,tileGen.Depth,tileGen.Height);
        transform.position = new Vector3 (-(camLoc-2),camLoc,-(camLoc-1));
        FindObjectOfType<Camera>().orthographicSize =camLoc-1;
        changeRotation();


    }
    void changeRotation(){
        if(Input.GetKey(KeyCode.Q)){

        }
        if(Input.GetKey(KeyCode.E)){

        }
    }
}
