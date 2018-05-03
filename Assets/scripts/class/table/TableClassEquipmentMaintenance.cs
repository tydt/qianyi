using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableClassEquipmentMaintenance
{

    public string No;
    public string name = "立柜式空调";
    public string type = "KFR-72LW/(72596)FNAa-A3";
    public string technical = "3匹";
    public string useLocation = "11F3#病房";
    public string supplier = "格力";
    public string beginTime = "2017.08.20";
    public string intervalMonth = "3月";
    public string checkPerson = "赵磊";
    public string checkTime = "2017.10.10";
    public string maintenanceRecord = "已有";
    public string maintenanceTime = "2017.10.10";
    public string maintenanceContent = "日常维护";
    public string maintenanceLevel = "一级";
    public string maintenancePrice = "1000";

    public static List<TableClassEquipmentMaintenance> RandomClassData(int listCount)
    {
        List<TableClassEquipmentMaintenance> rs = new List<TableClassEquipmentMaintenance>();
        for (int i = 0; i < listCount; i++)
        {
            TableClassEquipmentMaintenance temp = new TableClassEquipmentMaintenance();
            temp.No = (i + 1).ToString();
            temp.name = StaticGloableVariable.RandomFromList(new List<string>() { "立柜式空调", "壁式空调", "水表", "电表", "温度表" });
            temp.type = StaticGloableVariable.RandomFromList(new List<string>() { "KFR-72LW/(72596)FNAa-A3", "KFR-72LW/(72596)FNAa-A2", "KFR-72LW/(72596)FNAa-A1", "KFR-72LW/(72596)FNAa-B3" });
            temp.technical = StaticGloableVariable.RandomFromList(new List<string>() { "1匹", "2匹", "3匹", "4匹" });
            temp.useLocation = StaticGloableVariable.RandomFromList(new List<string>() { "11F13#病房", "4F23#病房", "15F7#病房", "12F3#病房", "13F1#病房", "9F17#病房", });
            temp.supplier = StaticGloableVariable.RandomFromBrand();
            temp.beginTime = StaticGloableVariable.RandomFromDate();
            temp.intervalMonth = StaticGloableVariable.RandomFromList(new List<string>() { "30天", "180天", "60天", "90天" });
            temp.checkPerson = StaticGloableVariable.RandomFromPerson();
            temp.checkTime = StaticGloableVariable.RandomFromDate();
            temp.maintenanceRecord = StaticGloableVariable.RandomFromList(new List<string>() { "已有" });
            temp.maintenanceTime = StaticGloableVariable.RandomFromDate();
            temp.maintenanceContent = StaticGloableVariable.RandomFromList(new List<string>() { "日常维护", "损坏物件更换", "故常排除" });
            temp.maintenanceLevel = StaticGloableVariable.RandomFromList(new List<string>() { "一级", "二级", "三级" });
            temp.maintenancePrice = StaticGloableVariable.RandomFromList(new List<string>() { "100", "50", "1000", "3000"});
            rs.Add(temp);
        }
        return rs;
    }


}
