using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstValuesEnums : MonoBehaviour {

    public static float Water = 1578;
    public static float Electric = 5879;

    public static string BuildingName(BuildingType type)
    {
        string rs = "";
        switch (type)
        {
            case BuildingType.儿科综合楼:
                {
                    rs = "儿科综合楼";
                    break;
                }
            case BuildingType.保健楼:
                {
                    rs = "保健楼";
                    break;
                }
            case BuildingType.内科楼:
                {
                    rs = "内科楼";
                    break;
                }
            case BuildingType.急诊楼:
                {
                    rs = "急诊楼";
                    break;
                }
            case BuildingType.科研楼:
                {
                    rs = "科研楼";
                    break;
                }
            case BuildingType.门诊楼:
                {
                    rs = "门诊楼";
                    break;
                }
        }
        return rs;
    }

    public static float BuildingRate(BuildingType type)
    {
        float rs = 1;
        switch (type)
        {
            case BuildingType.儿科综合楼:
                {
                    rs = 1;
                    break;
                }
            case BuildingType.保健楼:
                {
                    rs = 0.5f;
                    break;
                }
            case BuildingType.内科楼:
                {
                    rs = 0.8f;
                    break;
                }
            case BuildingType.急诊楼:
                {
                    rs = 1.2f;
                    break;
                }
            case BuildingType.科研楼:
                {
                    rs = 0.6f;
                    break;
                }
            case BuildingType.门诊楼:
                {
                    rs = 2f;
                    break;
                }
        }
        return rs;
    }
}

public enum BuildingType
{
    儿科综合楼,
    急诊楼,
    保健楼,
    内科楼,
    科研楼,
    门诊楼,
}

