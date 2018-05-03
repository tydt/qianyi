using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AllBuildingLocationLeftUIController : MonoBehaviour
{


    private void Start()
    {
        RegistButtonClickEvent();
    }

    void RegistButtonClickEvent()
    {
        foreach (AllBuildingLocationLeftUIButtonController btn in buttons)
        {
            EventTriggerListener.GetListener(btn.gameObject).onPointerClick += LocationButtonClick;
        }
    }

    void LocationButtonClick(GameObject go, BaseEventData data)
    {
        foreach (AllBuildingLocationLeftUIButtonController btn in buttons)
        {
            btn.SetHighlight(go.GetComponentInChildren<Text>().text == btn.GetComponentInChildren<Text>().text);
        }
        SendMessageUpwards("SetActiveBuilding", go.GetComponentInChildren<Text>().text);
    }

    public void ResetLocationUI()
    {
        foreach (AllBuildingLocationLeftUIButtonController btn in buttons)
        {
            btn.SetHighlight(false);
        }
    }

    private AllBuildingLocationLeftUIButtonController[] buttons
    {
        get
        {
            return GetComponentsInChildren<AllBuildingLocationLeftUIButtonController>();
        }
    }
}
