using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFloatStatusSwitchController : MonoBehaviour {

    public GameObject HightlightPanel;
    public GameObject NormalPanel;
    public bool isOn = false;
    public float valueRate = 0.1f;
    public Text WaterText;
    public Text ElectricText;
    public bool isWater = true;
    public bool isElectric = true;
    public GameObject ToggleWater;
    public GameObject ToggleElectric;
    public Text TitleHighlight;
    public Text TitleNormal;
    public EnergyEquipmentHightlightSettingController.EnergyEquipmentHightlightSettingDelegate modelDelegate;

    [ContextMenu("Float Value Init")]
    public void FloatValueInit()
    {
        int water = isWater ? Mathf.RoundToInt(ConstValuesEnums.Water * valueRate) : 0;
        int eletric = isElectric ? Mathf.RoundToInt(ConstValuesEnums.Electric * valueRate) : 0;
        WaterText.text = water.ToString() + "m³";
        ElectricText.text = eletric.ToString() + "kwh";
        SetFloatHighlightActive(isOn);
        ToggleWater.SetActive(isWater);
        ToggleElectric.SetActive(isElectric);

        if(TitleHighlight != null && TitleNormal != null)
        {
            TitleHighlight.text = name;
            TitleNormal.text = name;
        }
    }

    public void SetFloatHighlightActive(bool isHOn)
    {
        SetFloatHighlightActive(isHOn, true);
    }

    public void SetFloatHighlightActiveEquipment(bool isHOn)
    {
        SendMessageUpwards("FocusGameObjectName", gameObject.name);
    }

    public void SetFloatHighlightActive(bool isHOn, bool isCallback)
    {
        HightlightPanel.SetActive(isHOn);
        NormalPanel.SetActive(!isHOn);
        if (modelDelegate != null)
        {
            modelDelegate(isOn);
        }
        if (!isCallback)
        {
            SendMessageUpwards("FocusGameObjectName", gameObject.name);
        }
        if (isHOn)
        {
            gameObject.transform.SetAsLastSibling();
        }
    }

    public void SetFloatHighlightActive()
    {
        isOn = !isOn;
        SetFloatHighlightActive(isOn);
    }
}
