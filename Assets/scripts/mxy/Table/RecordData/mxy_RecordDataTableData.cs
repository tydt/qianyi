using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mxy_RecordDataTableData
{
    public enum MyDataType
    {
        消防设备维护记录,
        安全管理法规,
        工程维护作业指引,
        清洁设备使用方法
    }

    public class RecordDataParameter
    {
        public string number { get; set; }

        public string name { get; set; }

        public MyDataType type { get; set; }

        public string person { get; set; }

        public int accessory { get; set; }
        public string operation { get; set; }

        public RecordDataParameter(string number, string name, MyDataType type, string person, int accessory,string operation)
        {
            this.number = number;
            this.name = name;
            this.type = type;
            this.person = person;
            this.accessory = accessory;
            this.operation = operation;
        }
    }

    public static List<RecordDataParameter> Generate(System.Random random)
    {
        List<RecordDataParameter> plist = new List<RecordDataParameter>();

        for (int i = 0; i < 30; i++)
        {
            plist.Add(new RecordDataParameter(RandomNumber(random), RandomName(random), RandomType(random), RandomPerson(random), RandomAccessory(random),"详情 修改 删除 下载"));
        }
        return plist;
    }

    static string RandomNumber(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "DH214563","JZ101258","KS151023","LJ100011"
        };

        return str[random.Next(0, str.Count)];
    }

    static string RandomName(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "模型概念错位","建筑表现","空间数学动力学","综合实例","理解结构"
        };

        return str[random.Next(0, str.Count)];
    }

    static MyDataType RandomType(System.Random random)
    {
        int a = random.Next(0, 4);
        MyDataType v = (MyDataType)a; //转枚举
        return v;
    }

    static string RandomPerson(System.Random random)
    {
        List<string> str = new List<string>()
        {
            "李丽","赵海","刘照为","刘国良","刘文","王静","王慧","王红红"
        };

        return str[random.Next(0, str.Count)];
    }
    static int RandomAccessory(System.Random random)
    {
        return random.Next(0, 6);
    }
}
