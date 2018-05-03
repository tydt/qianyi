using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mxy_MaintenanceManagementTableData
{

    public class MaintenanceManagementDataParameter
    {
        public int number { get; set; }
        public string title { get; set; }
        public string property { get; set; }
        public string state { get; set; }
        public string person { get; set; }
        public string time { get; set; }
        public string progress { get; set; }

        public string operation { get; set; }

        public MaintenanceManagementDataParameter(int number, string title, string property, string state, string person, string time, string progress, string operation)
        {
            this.number = number;
            this.title = title;
            this.property = property;
            this.state = state;
            this.person = person;
            this.time = time;
            this.progress = progress;
            this.operation = operation;
        }
    }

    public static List<MaintenanceManagementDataParameter> Generate(System.Random random)
    {
        List<MaintenanceManagementDataParameter> plist = new List<MaintenanceManagementDataParameter>();

        for (int i = 0; i < 30; i++)
        {
            plist.Add(new MaintenanceManagementDataParameter(i, RandomTitle(random), RandomProperty(random), RandomStata(random), RandomPerson(random), RandomTime(random), RandomProgress(random), SetOeration()));
        }
        return plist;
    }
    static string RandomTitle(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "水箱维修流程","电力检修流程","电力设备进场流程","冷水机组维修流程","热交换器维修流程","空调维修流程","窗户维修流程","病房门维修流程"
        };
        return str[random.Next(0, str.Count)];
    }

    static string RandomProperty(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "维保类流程","资产验收类流程","常用设备维保流程"
        };
        return str[random.Next(0, str.Count)];
    }
    static string RandomStata(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "审批中","已完成"
        };

        return str[random.Next(0, str.Count)];
    }
    static string RandomPerson(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "王建豪","孟启群","朱宇豪","郭建国","张建伟","李源朝"
        };

        return str[random.Next(0, str.Count)];
    }
    static string RandomTime(System.Random random)
    {

        List<string> str = new List<string>()
        {
            "2018.04.20","2018.04.17","2018.04.14","2018.04.18","2018.04.02","2018.04.16"
        };

        return str[random.Next(0, str.Count)];
    }

    static string RandomProgress(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "3/8","4/9","3/5","2/7","2/9","3/4"
        };

        return str[random.Next(0, str.Count)];
    }

    static string SetOeration()
    {
        return "查看/审核";
    }
}