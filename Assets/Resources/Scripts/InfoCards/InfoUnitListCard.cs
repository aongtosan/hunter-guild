using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUnitListCard : MonoBehaviour
{
    // Start is called before the first frame update
 
    public GameObject ui;
    public GameObject characterDataUi;
    // Update is called once per frame
    public int unitCount;
    void Start(){
        for(int i=0;i<unitCount;i++){
            GameObject unitCard = new GameObject("UnitCard");
            unitCard.AddComponent<RectTransform>();
            unitCard.AddComponent<CanvasRenderer>();
            unitCard.AddComponent<Image>();
            unitCard.gameObject.transform.parent = 
            ui
            .gameObject.transform.GetChild(0)
            .gameObject.transform.GetChild(0)
            .gameObject.transform.GetChild(0)
            .gameObject.transform.GetChild(0);
        }
        
    }
    void Update()
    {
          if(CombatManager.combatManager.Phase == CombatManager.CombatPhase.DEPLOY){
            ui.gameObject.SetActive(true);
            characterDataUi.gameObject.SetActive(true);
        }
        else {
            ui.gameObject.SetActive(false);
            characterDataUi.gameObject.SetActive(false);
        }
        
    }
}
