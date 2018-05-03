using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CustomEditor(typeof(MyPlayer))]

public class EnergySubSystemSwitchControler : MonoBehaviour
{
    public Toggle[] toggles;
    [SerializeField] public ZenFulcrum.EmbeddedBrowser.Browser theWeb;
    public Toggle[] TimeToggles;
    public Toggle[] SystemToggles;
    public float ValueRate = 1f;
    public WebFormType wType = WebFormType.水_本月;
    //const int waterValue = 1578;
    //const int eletricValue = 5879;
    //const string waterNowUrl = "localhost/echarts/buildingWaterNow.php";
    //const string waterHistoryUrl = "localhost/echarts/buildingWaterHistory.php";
    //const string eletricNowUrl = "localhost/echarts/buildingEletricNow.php";
    //const string eletricHistoryUrl = "localhost/echarts/buildingEletricHistory.php";
    const string waterNowUrl = "https://rdd.tybim.com/echarts/buildingWaterNow.php";
    const string waterHistoryUrl = "https://rdd.tybim.com/echarts/buildingWaterHistory.php";
    const string eletricNowUrl = "https://rdd.tybim.com/echarts/buildingEletricNow.php";
    const string eletricHistoryUrl = "https://rdd.tybim.com/echarts/buildingEletricHistory.php";

    public EnergyWaterModelController.BuildingModelChange WaterModelDelegate;

    public enum WebFormType
    {
        水_本月,
        水_历史,
        电_本月,
        电_历史
    }

    private void Start()
    {
        BuildToggles();
    }

    void BuildToggles()
    {
        foreach (Toggle t in toggles)
        {
            t.onValueChanged.AddListener(TogglesCheckChange);
        }
        foreach (Toggle t in TimeToggles)
        {
            t.onValueChanged.AddListener(TimeTogglesCheckChange);
        }
        foreach(Toggle t in SystemToggles)
        {
            t.onValueChanged.AddListener(SystemTogglesCheckChange);
        }
        //InitUrl();
    }
    
    [ContextMenu("InitUrl")]
    [SerializeField]
    public void InitUrl()
    {
        GameObject go = Instantiate(gameObject);
        go.transform.parent = transform.parent;
        go.name = name;
        go.GetComponent<EnergySubSystemSwitchControler>().TogglesCheckChange(true);
        //TogglesCheckChange(true);
    }

    [SerializeField]
    void TogglesCheckChange(bool isOn)
    {
        List<string> rs = new List<string>();
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                rs.Add((i + 1).ToString());
            }
            if (WaterModelDelegate != null)
            {
                WaterModelDelegate(i, toggles[i].isOn);
            }
        }
        string srs = string.Join(",", rs.ToArray());
        
        string baseUrl = waterNowUrl;
        switch (wType)
        {
            case WebFormType.水_本月:
                {
                    baseUrl = waterNowUrl;
                    break;
                }
            case WebFormType.水_历史:
                {
                    baseUrl = waterHistoryUrl;
                    break;
                }
            case WebFormType.电_本月:
                {
                    baseUrl = eletricNowUrl;
                    break;
                }
            case WebFormType.电_历史:
                {
                    baseUrl = eletricHistoryUrl;
                    break;
                }
        }
        theWeb.Url = baseUrl + "?type=" + srs + "&per=" + ValueRate;
        Debug.Log(baseUrl + "?type=" + srs + "&per=" + ValueRate);
    }

    void TimeTogglesCheckChange(bool isOn)
    {
        if (isOn)
        {
            foreach (Toggle t in TimeToggles)
            {
                if (!t.isOn)
                {
                    continue;
                }
                if ("Toggle_water_now" == t.gameObject.name)
                {
                    wType = WebFormType.水_本月;
                }
                if ("Toggle_water_history" == t.gameObject.name)
                {
                    wType = WebFormType.水_历史;
                }
                if ("Toggle_eletric_now" == t.gameObject.name)
                {
                    wType = WebFormType.电_本月;
                }
                if ("Toggle_eletric_history" == t.gameObject.name)
                {
                    wType = WebFormType.电_历史;
                }
            }
            TogglesCheckChange(true);
        }
    }

    void SystemTogglesCheckChange(bool isOn)
    {
        if (isOn)
        {
            foreach (Toggle t in SystemToggles)
            {
                if (!t.isOn)
                {
                    continue;
                }
                if ("Toggle_dian" == t.gameObject.name)
                {
                    wType = WebFormType.电_本月;
                }
                if ("Toggle_shui" == t.gameObject.name)
                {
                    wType = WebFormType.水_本月;
                }               
            }
            TogglesCheckChange(true);
        }
    }
}


