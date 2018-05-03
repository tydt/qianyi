using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mxy_MaintenancePlanTableData {

    public class MaintenancePlanDataParameter
    {
        public int number { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string tutorial { get; set; }
        public string operation { get; set; }

        public MaintenancePlanDataParameter(int number, string name, string operation)
        {
            this.number = number;
            this.name = name;
            switch (name)
            {
                case "立柜式空调（病房）":
                    this.type = "温控设备";
                    this.tutorial = RandomTutorial(new System.Random(1000));
                    break;
                case "装配式钢板给水箱":
                    this.type = "储藏设备";
                    this.tutorial = "水箱保养教程";
                    break;
                case "给水管道三叉阀门":
                    this.type = "储藏设备";
                    this.tutorial = "给水三叉阀门更换教程";
                    break;
                case "给水管道单向阀门":
                    this.type = "运输设备";
                    this.tutorial = "给水单向阀门更换教程";
                    break;
                case "排水管道三叉阀门":
                    this.type = "运输设备";
                    this.tutorial = "排水管道三叉阀门更换教程";
                    break;
                case "排水管道单向阀门":
                    this.type = "运输设备";
                    this.tutorial = "排水管道单向阀门更换教程";
                    break;
                case "热交换器":
                    this.type = "运输设备";
                    this.tutorial = "热交换器保养教程";
                    break;
                case "电动阀":
                    this.type = "控制开关";
                    this.tutorial = "电动阀检修教程";
                    break;
                case "离心式冷水机组":
                    this.type = "动力设备";
                    this.tutorial = "冷水机组维保教程";
                    break;

            }
            this.operation = operation;
        }
    }

    public static List<MaintenancePlanDataParameter> Generate(System.Random random)
    {
        List<MaintenancePlanDataParameter> plist = new List<MaintenancePlanDataParameter>();

        for (int i = 0; i < 30; i++)
        {
            plist.Add(new MaintenancePlanDataParameter(i, RandomName(random), SetOeration()));
        }
        return plist;
    }
    static string RandomName(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "立柜式空调（病房）","装配式钢板给水箱","给水管道三叉阀门","给水管道单向阀门","排水管道三叉阀门","排水管道单向阀门","热交换器","电动阀","离心式冷水机组"
        };
        return str[random.Next(0, str.Count)];
    }
    static string RandomTutorial(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "立柜式空调保养教程","立柜式空调加氟教程"
        };

        return str[random.Next(0, str.Count)];
    }

    static string SetOeration()
    {
        return "编辑/删除";
    }
}