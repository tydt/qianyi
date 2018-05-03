using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableClassEquipmentWarehousing {

    public string No;
    public string type;
    public string useStatus;
    public string usePerson;
    public string useTime;
    public string buyTime;

    public static List<TableClassEquipmentWarehousing> RandomClassData(int listCount)
    {
        List<TableClassEquipmentWarehousing> rs = new List<TableClassEquipmentWarehousing>();
        for (int i = 0; i < listCount; i++)
        {
            TableClassEquipmentWarehousing temp = new TableClassEquipmentWarehousing();
            temp.No = "DH" + (2141563 + i).ToString();
            temp.type = StaticGloableVariable.RandomFromList(new List<string>() { "工程用品", "日常用品", "电子用品" });
            temp.useStatus = StaticGloableVariable.RandomFromList(new List<string>() { "一般", "良好" });
            temp.usePerson = StaticGloableVariable.RandomFromPerson();
            temp.useTime = StaticGloableVariable.RandomFromDate();
            temp.buyTime = StaticGloableVariable.RandomFromDate();
            rs.Add(temp);
        }
        return rs;
    }
}
