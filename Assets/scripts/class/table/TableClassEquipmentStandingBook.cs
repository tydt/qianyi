using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class TableClassEquipmentStandingBook {
    public string No = "1";
    public string equipmentType = "立柜式空调";
    public string type = "KFR-72LW/(72596)FNAa-A3";
    public string technical = "3匹";
    public string brand = "格力";
    public string supplier = "格力";
    public string enterTime = "2017.08.20";
    public string enterResponsePerson = "张世敏";
    public string debugStatus = "合格";
    public string checkTime = "2017.08.10";
    public string checkResponsePerson = "李坚";
    public string setupLocation = "11F3#病房";
    public string guaranteePeriod = "1年";
    public string transferTime = "2017.08.10";

    private static List<TableClassEquipmentStandingBook> testData;

    public static List<TableClassEquipmentStandingBook> TestData
    {
        get
        {
            if(testData != null)
            {
                return testData;
            }
            else
            {
                return RandomClassData(30);
            }
        }       
    }

    public static List<TableClassEquipmentStandingBook> RandomClassData(int listCount)
    {
        List<TableClassEquipmentStandingBook> rs = new List<TableClassEquipmentStandingBook>();
        for(int i = 0; i < listCount; i++)
        {
            TableClassEquipmentStandingBook temp = new TableClassEquipmentStandingBook();
            temp.No = (i + 1).ToString();
            temp.equipmentType = StaticGloableVariable.RandomFromList(DataEnums(DataType.equipmentType));
            temp.type = StaticGloableVariable.RandomFromList(DataEnums(DataType.type));
            temp.technical = StaticGloableVariable.RandomFromList(DataEnums(DataType.technical));
            temp.brand = StaticGloableVariable.RandomFromBrand();
            temp.supplier = temp.brand;
            temp.enterTime = StaticGloableVariable.RandomFromDate();
            temp.enterResponsePerson = StaticGloableVariable.RandomFromPerson();
            temp.debugStatus = StaticGloableVariable.RandomFromList(DataEnums(DataType.debugStatus));
            temp.checkTime = StaticGloableVariable.RandomFromDate();
            temp.checkResponsePerson = StaticGloableVariable.RandomFromPerson();
            temp.setupLocation = StaticGloableVariable.RandomFromList(DataEnums(DataType.setupLocation));
            temp.guaranteePeriod = StaticGloableVariable.RandomFromList(DataEnums(DataType.guaranteePeriod));
            temp.transferTime = StaticGloableVariable.RandomFromDate();
            rs.Add(temp);
        }
        testData = rs;
        return rs;
    }

    public static List<string> DataEnums(DataType type)
    {
        switch (type)
        {
            case DataType.equipmentType:
                return new List<string>() { "分集水器", "离心式冷水机组", "装配式钢板给水箱", "单级单吸立式管道离心泵", "软水器", "热交换器", "电动阀", "立式增压稳压设备", "水泵" };
                //return new List<string>() { "立柜式空调", "壁式空调", "水表", "电表", "温度表" };
            case DataType.type:
                return new List<string>() { "KFR-72LW/(72596)FNAa-A3", "KFR-72LW/(72596)FNAa-A2", "KFR-72LW/(72596)FNAa-A1", "KFR-72LW/(72596)FNAa-B3" };
            case DataType.technical:
                return new List<string>() { "" };
                //return new List<string>() { "1匹", "2匹", "3匹", "4匹" };
            case DataType.debugStatus:
                return new List<string>() { "合格" };
            case DataType.setupLocation:
                return new List<string>() { "-1F设备层" };
                //return new List<string>() { "11F13#病房", "14F23#病房", "15F7#病房", "12F3#病房", "13F1#病房", "12F17#病房" };
            case DataType.guaranteePeriod:
                return new List<string>() { "12个月", "6个月", "18个月", "24个月" };
            default:
                return new List<string>();
        }
    }

    public static List<TableClassEquipmentStandingBook> SelectByEquipmentType(string type)
    {
        if (testData == null)
            return null;
        IEnumerable<TableClassEquipmentStandingBook> rs =
            from data in testData
            where data.equipmentType == type
            select data;
        return rs.ToList();
    }


    
    public enum DataType
    {
        No,
        equipmentType,
        type,
        technical,
        brand,
        supplier,
        enterTime,
        enterResponsePerson,
        debugStatus,
        checkTime,
        checkResponsePerson,
        setupLocation,
        guaranteePeriod,
        transferTime,
    }
}

