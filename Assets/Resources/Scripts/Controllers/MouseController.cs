using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mouseLocationOld;
    void Start()
    {
        mouseLocationOld =  Input.mousePosition;

    }

    // Update is called once per frame
    void Update()
    {
        if(detectPositionChange()){
             Debug.Log(Input.mousePosition);
             mouseLocationOld=Input.mousePosition;
        }
       
    }
    bool detectPositionChange(){
        return mouseLocationOld!=Input.mousePosition ? true : false ; 
    }
}
