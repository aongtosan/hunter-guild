using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;


public class InfoUnitListCard : MonoBehaviour
{
    // Start is called before the first frame update
 
    // public GameObject ui;
    // public GameObject characterDataUi;
    // Update is called once per frame
    //public int unitCount;
    public List<UIDocument> ui;
    void Start(){
        StyleSheet ss = (StyleSheet) EditorGUIUtility.Load("UnitInfoCardStyle.uss");

        // for(int i=0;i<unitCount;i++){
        //     GameObject unitCard = new GameObject("UnitCard");
        //     unitCard.AddComponent<CanvasRenderer>();
        //     unitCard.AddComponent<Image>();
        //     unitCard.gameObject.transform.parent = 
        //     ui
        //     .gameObject.transform.GetChild(0)
        //     .gameObject.transform.GetChild(0)
        //     .gameObject.transform.GetChild(0)
        //     .gameObject.transform.GetChild(0);
        // }
        
    }

    void OnEnable()
    {
        Debug.Log(ui[0].rootVisualElement.Q<Label>("header").text);
        ui[0].rootVisualElement.Q<Button>("close-btn").RegisterCallback<ClickEvent>(ev => 
            {
                Debug.Log("close");
                ui[0].rootVisualElement.Q<GroupBox>("horiziontal").style.visibility = Visibility.Hidden;
            }
        );
  
    }
    void showUnitInfo(){

    }

    void Update()
    {
        
        //   if(CombatManager.combatManager.Phase == CombatManager.CombatPhase.DEPLOY){
        //     ui.gameObject.SetActive(true);
        //     characterDataUi.gameObject.SetActive(true);
        // }
        // else {
        //     ui.gameObject.SetActive(false);
        //     characterDataUi.gameObject.SetActive(false);
        // }
        
    }
}
