using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWaterModelController : MonoBehaviour {

    public delegate void BuildingModelChange(int index, bool isOn);
    public List<GameObject> Buildings;
    private void Start()
    {
        GetComponent<EnergySubSystemSwitchControler>().WaterModelDelegate = BuildingModelChangeDelegate;
    }

    public void BuildingModelChangeDelegate(int index, bool isOn)
    {
        Buildings[index].SetActive(isOn);
    }
}
