using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public List<UIDocument> ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        Debug.Log(ui[0].rootVisualElement.Q<Label>("header").text);
        ui[0].rootVisualElement.Q<Button>("close-btn").RegisterCallback<ClickEvent>(ev => 
            {
                Debug.Log("close");
                ui[0].rootVisualElement.Q<GroupBox>("menu-unit-list").style.visibility = Visibility.Hidden;
            }
        );
  
    }
}
