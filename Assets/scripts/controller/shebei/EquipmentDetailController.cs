using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentDetailController : MonoBehaviour {

    public List<Button> buttons;
    public List<GameObject> panels;

    public Sprite Normal;
    public Sprite Hightlight;

    private void Start()
    {
        BuildButton();
    }

    void BuildButton()
    {
        foreach(Button btn in buttons)
        {
            EventTriggerListener.GetListener(btn.gameObject).onPointerClick += ButtonClick;
        }
    }

    void ButtonClick(GameObject go, BaseEventData data)
    {
        for(int i = 0; i< buttons.Count; i++)
        {
            bool isOn = buttons[i].gameObject.name == go.name;
            buttons[i].GetComponent<Image>().sprite = isOn ? Hightlight : Normal;
            panels[i].SetActive(isOn);
        }
    }

    public void ResetUI()
    {
        ButtonClick(buttons[0].gameObject,null);
    }

 
}
