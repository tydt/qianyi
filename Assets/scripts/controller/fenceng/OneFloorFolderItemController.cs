using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneFloorFolderItemController : MonoBehaviour {

    public Button TitleButton;
    public GameObject content;
    public float contentHeight = 100f;
    public List<string> modelNames;
    public List<GameObject> models;
    public GameObject FloatObject;

    private int index;

    private void Start()
    {
        BuildToggle();
    }

    void BuildToggle()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            Toggle t = toggles[i];
            t.onValueChanged.AddListener(delegate { ToggleOnValueChanged(t); });
        }   
    }

    void ToggleOnValueChanged(Toggle t)
    {
        string name = t.GetComponentInChildren<Text>().text;
        int index = modelNames.IndexOf(name);
        if(index < 0)
        {
            return;
        }
        models[index].SetActive(t.isOn);
    }

    public void SetThisSystemEnable(bool isOn)
    {
        foreach(Toggle t in toggles)
        {
            t.isOn = isOn;
        }
        if (FloatObject != null)
        {
            FloatObject.SetActive(isOn);
            FloatObject.GetComponent<EnergyFloatStatusSwitchController>().SetFloatHighlightActive(false);
        }
    }

    public void SetThisSystemEnableWithFloat(bool isOn)
    {
        foreach (Toggle t in toggles)
        {
            t.isOn = isOn;
        }
        if (FloatObject != null)
        {
            FloatObject.SetActive(isOn);
            FloatObject.GetComponent<EnergyFloatStatusSwitchController>().SetFloatHighlightActive(isOn);
        }
    }

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    private Toggle[] toggles
    {
        get
        {
            return GetComponentsInChildren<Toggle>();
        }
    }
}
