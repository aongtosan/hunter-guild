using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InfoUnitListCard : MonoBehaviour
{
    // Start is called before the first frame update
 
    // public GameObject ui;
    // public GameObject characterDataUi;
    // Update is called once per frame
    //public int unitCount;
    public List<UIDocument> ui;
    void Start(){
        Debug.Log(ui[0].rootVisualElement.Q<Label>("header").text);

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
        ui[0].rootVisualElement.Q<Button>("close-btn").RegisterCallback<ClickEvent>(ev => Debug.Log("close"));
        // var uiDocument = GetComponent<UIDocument>();
        // var rootVisualElement = uiDocument.rootVisualElement;
 
        // frame = rootVisualElement.Q<VisualElement>("Frame");
        // label = frame.Q<Label>("Label");
        // button = frame.Q<Button>("Button");
 
        // button.RegisterCallback<ClickEvent>(ev => SetText());
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
