using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnergySystemSwitchController : MonoBehaviour {

    public List<Button> SwitchButtons;
    public List<GameObject> contents;
    public List<GameObject> buildings;
    public Sprite Normal;
    public Sprite Hightlight;

    private void Start()
    {
        BuildButtons();
    }

    void BuildButtons()
    {
        for(int i = 0; i< SwitchButtons.Count; i++)
        {
            Button b = SwitchButtons[i];
            EventTriggerListener.GetListener(b.gameObject).onPointerClick += SwitchButtonClick;
        }
    }

    void SwitchButtonClick(GameObject go, BaseEventData data)
    {
        for(int i = 0; i < SwitchButtons.Count; i++)
        {
            bool isOn = go.name == SwitchButtons[i].gameObject.name;
            SwitchButtons[i].GetComponent<Image>().sprite = isOn ? Hightlight : Normal;            
            contents[i].SetActive(isOn);
            if(buildings[i] != null)
            {
                buildings[i].SetActive(isOn);
            }
        }
    }
}
