using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StaticGloableVariable
{
    public static System.Random r = new System.Random(1);

    public static List<string> dates
    {
        get
        {
            List<string> rs = new List<string>();
            for (int i = 0; i < 400; i++)
            {
                DateTime dateTemp = new DateTime(2017, 1, 1).AddDays(i);
                rs.Add(dateTemp.ToString("yyyy-MM-dd"));
            }
            return rs;
        }
    }

    public static List<string> person
    {
        get
        {
            return new List<string>() { "蓝伟林", "肖明明", "王雨末", "谭萌萌", "薛明杰", "宋慧峰", "秋月", "张三", "李四", "王老菊", "王师傅", "杨凯", "李斌", "李强", "侯晨", "李程" };
        }
    }

    public static List<string> brands
    {
        get
        {
            return new List<string>() { "格力", "海尔", "美的", "戴尔", "三星", "西门子", "索尼", "日立", "LG" };
        }
    }

    public static string RandomFromList(List<string> list)
    {
        int index = r.Next(0, list.Count - 1);
        return list[index];
    }


    public static string RandomFromDate()
    {
        return RandomFromList(dates);
    }

    public static string RandomFromPerson()
    {
        return RandomFromList(person);
    }

    public static string RandomFromBrand()
    {
        return RandomFromList(brands);
    }
    
}
