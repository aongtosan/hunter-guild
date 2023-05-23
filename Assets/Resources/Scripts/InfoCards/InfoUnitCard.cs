using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnitCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ui;
    void Start()
    {
        
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
    }
}
