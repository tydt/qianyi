using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mxy_MaintenancePlanTableDropDown : MonoBehaviour {

    public Dropdown Name;
    public Dropdown Type;
    public Dropdown Tutorial;
    public mxy_MaintenancePlanTable table;
    private int iNameIndex = 0;
    private int iTypeIndex = 0;
    private int iTutorialIndex = 0;

    void Start()
    {
        BuildDropdown();
    }

    void BuildDropdown()
    {
        List<Dropdown.OptionData> PropertyData = new List<Dropdown.OptionData>();
        PropertyData.Add(new Dropdown.OptionData("全部"));
        PropertyData.Add(new Dropdown.OptionData("立柜式空调（病房）"));
        PropertyData.Add(new Dropdown.OptionData("装配式钢板给水箱"));
        PropertyData.Add(new Dropdown.OptionData("给水管道三叉阀门"));
        PropertyData.Add(new Dropdown.OptionData("给水管道单向阀门"));
        PropertyData.Add(new Dropdown.OptionData("排水管道三叉阀门"));
        PropertyData.Add(new Dropdown.OptionData("排水管道单向阀门"));
        PropertyData.Add(new Dropdown.OptionData("热交换器"));
        PropertyData.Add(new Dropdown.OptionData("电动阀"));
        PropertyData.Add(new Dropdown.OptionData("离心式冷水机组"));
        Name.options = PropertyData;

        List<Dropdown.OptionData> StateData = new List<Dropdown.OptionData>();
        StateData.Add(new Dropdown.OptionData("全部"));
        StateData.Add(new Dropdown.OptionData("温控设备"));
        StateData.Add(new Dropdown.OptionData("储藏设备"));
        StateData.Add(new Dropdown.OptionData("运输设备"));
        StateData.Add(new Dropdown.OptionData("控制开关"));
        StateData.Add(new Dropdown.OptionData("动力设备"));
        Type.options = StateData;

        List<Dropdown.OptionData> PersonData = new List<Dropdown.OptionData>();
        PersonData.Add(new Dropdown.OptionData("全部"));
        PersonData.Add(new Dropdown.OptionData("立柜式空调保养教程"));
        PersonData.Add(new Dropdown.OptionData("立柜式空调加氟教程"));
        PersonData.Add(new Dropdown.OptionData("水箱保养教程"));
        PersonData.Add(new Dropdown.OptionData("给水三叉阀门更换教程"));
        PersonData.Add(new Dropdown.OptionData("给水单向阀门更换教程"));
        PersonData.Add(new Dropdown.OptionData("排水管道三叉阀门更换教程"));
        PersonData.Add(new Dropdown.OptionData("排水管道单向阀门更换教程"));
        PersonData.Add(new Dropdown.OptionData("热交换器保养教程"));
        PersonData.Add(new Dropdown.OptionData("电动阀检修教程"));
        PersonData.Add(new Dropdown.OptionData("冷水机组维保教程"));

        Tutorial.options = PersonData;

        Name.onValueChanged.AddListener(NameChanged);
        Type.onValueChanged.AddListener(TypeChanged);
        Tutorial.onValueChanged.AddListener(TutorialChanged);
    }

    void NameChanged(int index)
    {
        iNameIndex = index;
        RebuildData(Name.options[iNameIndex].text);
    }

    void TypeChanged(int index)
    {
        iTypeIndex = index;
        RebuildData(Type.options[iTypeIndex].text);
    }

    void TutorialChanged(int index)
    {
        iTutorialIndex = index;
        RebuildData(Tutorial.options[iTutorialIndex].text);
    }

    void RebuildData(string str)
    {
        //table.ShowSelect(str);
        table.Select(Name.options[iNameIndex].text, Type.options[iTypeIndex].text,
            Tutorial.options[iTutorialIndex].text);
    }
}