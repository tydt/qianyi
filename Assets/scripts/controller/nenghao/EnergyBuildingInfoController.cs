using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBuildingInfoController : MonoBehaviour {

    public BuildingType bType = BuildingType.儿科综合楼;

    //public string BuildingName;
    public Text BuildingText;
    public float ValueRate = 1f;
    public Text WaterText;
    public Text EletricText;
    const int waterValue = 1578;
    const int eletricValue = 5879;

    private void Start()
    {
        //Init();
    }

    [ContextMenu("Init Building Setting")]
    void InitBuilding()
    {
        BuildingText.text = ConstValuesEnums.BuildingName(bType);
        int water = Mathf.RoundToInt(waterValue * ConstValuesEnums.BuildingRate(bType));
        int eletric = Mathf.RoundToInt(eletricValue * ConstValuesEnums.BuildingRate(bType));
        WaterText.text = water.ToString();
        EletricText.text = eletric.ToString();
        ValueRate = ConstValuesEnums.BuildingRate(bType);
    }

    [ContextMenu("Init Floor Setting")]
    void InitFloor()
    {
        //BuildingText.text = ConstValuesEnums.BuildingName(bType);
        int water = Mathf.RoundToInt(waterValue * ValueRate);
        int eletric = Mathf.RoundToInt(eletricValue * ValueRate);
        WaterText.text = water.ToString();
        EletricText.text = eletric.ToString();
        //ValueRate = ConstValuesEnums.BuildingRate(bType);
    }
}

