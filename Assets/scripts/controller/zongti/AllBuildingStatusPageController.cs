using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AllBuildingStatusPageController : MonoBehaviour {

    public Sprite LeftSprit;
    public Sprite RightSprit;
    public Text LeftText;
    public Text RightText;
    public GameObject DutyPanel;
    private Color tintColor = new Color(1f,1f,1f);
    private Color normalColor = Color.white;

    private bool isLeftOn = true;
    public void SwitchPage()
    {
        isLeftOn = !isLeftOn;
        SetLeftActive(isLeftOn);
    }

    private void SetLeftActive(bool isOn)
    {
        GetComponent<Image>().sprite = isOn ? LeftSprit : RightSprit;
        LeftText.color = isOn ? normalColor : tintColor;
        RightText.color = isOn ? tintColor : normalColor;
        DutyPanel.SetActive(!isOn);
    }

    private void Start()
    {
        EventTriggerListener.GetListener(gameObject).onPointerClick += SwitchButtonClick;
    }

    private void SwitchButtonClick(GameObject go, BaseEventData data)
    {
        SwitchPage();
    }
}
