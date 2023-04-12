using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnitListCard : MonoBehaviour
{
    // Start is called before the first frame update
 
    public GameObject ui;
    public GameObject characterDataUi;
    // Update is called once per frame
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
