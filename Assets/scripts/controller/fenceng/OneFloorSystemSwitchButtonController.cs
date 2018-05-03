using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OneFloorSystemSwitchButtonController : MonoBehaviour
{

    //public Button SystemButton;
    //public Button UsageButton;
    public List<Button> Buttons;
    public List<GameObject> Forms;
    public List<GameObject> Floats;
    public Sprite Normal;
    public Sprite Highlight;
    public Color NormalColor;
    public Color HighlightColor;

    public GameObject JiDian;
    public GameObject TuJian;
    public GameObject TuJianFade;
    public GameObject Rooms;

    private void Start()
    {
        BuildButton();
        ButtonClickEventHandler(Buttons[0].gameObject, null);
    }

    void BuildButton()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            EventTriggerListener.GetListener(Buttons[i].gameObject).onPointerClick += ButtonClickEventHandler;
        }
    }

    void ButtonClickEventHandler(GameObject go, BaseEventData data)
    {
        int index = dic[go.GetComponentInChildren<Text>().text];
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].GetComponent<Image>().sprite = i == index ? Highlight : Normal;
            Buttons[i].GetComponentInChildren<Text>().color = i == index ? HighlightColor : NormalColor;
            Forms[i].SetActive(i == index);
            if(Floats != null && Floats.Count > 0)
            {
                Floats[i].SetActive(i == index);
            }
        }
        if (index == 0)
        {
            TuJian.SetActive(false);
            TuJianFade.SetActive(true);
            JiDian.SetActive(true);
            Rooms.SetActive(false);
        }
        else if (index == 1)
        {
            TuJian.SetActive(true);
            TuJianFade.SetActive(false);
            JiDian.SetActive(false);
            Rooms.SetActive(true);
        }
    }

    Dictionary<string, int> dic = new Dictionary<string, int>() { { "分系统展示", 0 }, { "分功能区展示", 1 } };
}
