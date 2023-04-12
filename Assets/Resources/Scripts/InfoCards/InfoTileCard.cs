using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoTileCard : MonoBehaviour
{
    public GameObject ui;
    public GameObject biom_text;  
    public GameObject location_text; 
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(biom_text.GetComponent<TextMeshProUGUI>().text);
        biom_text.GetComponent<TextMeshProUGUI>().text = TileGenerator.tileGenerator.getBiomName();
    }

    // Update is called once per frame
    void Update()
    {
        if(CombatManager.combatManager.Phase == CombatManager.CombatPhase.DEPLOY){
            ui.gameObject.SetActive(false);
        }
        else{
             ui.gameObject.SetActive(true);
        }
        if(MouseController.mouseController.OnHoverTile!=null){
            location_text.GetComponent<TextMeshProUGUI>().text = string.Format("Location({0},{1})",
            MouseController.mouseController.OnHoverTile.GetComponent<TileController>().Tile.LocationX,
            MouseController.mouseController.OnHoverTile.GetComponent<TileController>().Tile.LocationY); // "Location:("+MouseController.mouseController.OnHoverTile.GetComponent<TileController>().Tile.LocationX+","+MouseController.mouseController.OnHoverTile.GetComponent<TileController>().Tile.LocationY+")";
        }
         biom_text.GetComponent<TextMeshProUGUI>().text = TileGenerator.tileGenerator.getBiomName();
        
    }
}
