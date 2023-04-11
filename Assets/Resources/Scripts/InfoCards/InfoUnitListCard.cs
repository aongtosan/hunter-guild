using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnitListCard : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
          if(CombatManager.combatManager.Phase == CombatManager.CombatPhase.DEPLOY){
            gameObject.SetActive(true);
        }
        
    }
}
