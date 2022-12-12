using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldManager : MonoBehaviour , IPointerClickHandler ,IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    bool isOnWorldMap;
    public WorldManager worldManager;
    void Start()
    {
        isOnWorldMap =true;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isOnWorldMap);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }
    public bool isOnWorldMapCheck(){
        return isOnWorldMap;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }
}
