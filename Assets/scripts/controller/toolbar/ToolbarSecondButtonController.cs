using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolbarSecondButtonController : MonoBehaviour {

    private void Start()
    {
        
    }

    public void RegistButton()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(delegate { ButtonOnClickHandler(btn.GetComponentInChildren<Text>().text); });
        }
    }

    void ButtonOnClickHandler(string name)
    {
        SendMessageUpwards("SecondClickHandler", name);
    }

    Button[] btns
    {
        get
        {
            return GetComponentsInChildren<Button>();
        }
    }
}
