using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* It's a class that controls rotate movement the camera */
public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    //TileGenerator.tileGeneratorerator TileGenerator.tileGenerator;
    void Start()
    {
        int camLoc =  Mathf.Max(TileGenerator.tileGenerator.Width,TileGenerator.tileGenerator.Depth,TileGenerator.tileGenerator.Height);
        transform.position = new Vector3 (-(camLoc-2),camLoc,-(camLoc-1));
        FindObjectOfType<Camera>().orthographicSize =camLoc-1;
    }

    // Update is called once per frame
    void Update()
    {
        changeRotation();
    }
    void changeRotation(){
        transform.LookAt(new Vector3(TileGenerator.tileGenerator.Depth/2f,0,TileGenerator.tileGenerator.Width/2f));
        if(Input.GetKey(KeyCode.Q)){
             transform.Translate(Vector3.left * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)){
             transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
