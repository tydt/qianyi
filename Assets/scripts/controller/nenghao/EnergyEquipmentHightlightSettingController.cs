using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyEquipmentHightlightSettingController : MonoBehaviour {

    public GameObject Model;

    public delegate void EnergyEquipmentHightlightSettingDelegate(bool isOn);

    private void Start()
    {
        //GetComponent<EnergyFloatStatusSwitchController>().modelDelegate = SetModelActive;
    }

    public void SetModelActive(bool isOn)
    {
        Model.GetComponent<MaterialHelper>().SetTargetActive(isOn);
    }

    public GameObject Models;
    [ContextMenu("Set Model to Float")]
    private void SetModel()
    {
        foreach(Transform ts in Models.GetComponentsInChildren<Transform>())
        {
            if(ts.name == name)
            {
                Model = ts.gameObject;
            }
        }
    }
}
