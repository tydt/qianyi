using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mxy_MaintenanceManagementTableDropDown : MonoBehaviour
{

    public Dropdown Property;
    public Dropdown State;
    public Dropdown Person;
    public mxy_MaintenanceManagementTable table;
    private int iPropertyIndex = 0;
    private int iStateIndex = 0;
    private int iPersonIndex = 0;

    void Start()
    {
        BuildDropdown();
    }

    void BuildDropdown()
    {
        List<Dropdown.OptionData> PropertyData = new List<Dropdown.OptionData>();
        PropertyData.Add(new Dropdown.OptionData("全部"));
        PropertyData.Add(new Dropdown.OptionData("维保类流程"));
        PropertyData.Add(new Dropdown.OptionData("资产验收类流程"));
        PropertyData.Add(new Dropdown.OptionData("常用设备维保流程"));
        Property.options = PropertyData;

        List<Dropdown.OptionData> StateData = new List<Dropdown.OptionData>();
        StateData.Add(new Dropdown.OptionData("全部"));
        StateData.Add(new Dropdown.OptionData("审批中"));
        StateData.Add(new Dropdown.OptionData("已完成"));
        State.options = StateData;

        List<Dropdown.OptionData> PersonData = new List<Dropdown.OptionData>();
        PersonData.Add(new Dropdown.OptionData("全部"));
        PersonData.Add(new Dropdown.OptionData("王建豪"));
        PersonData.Add(new Dropdown.OptionData("孟启群"));
        PersonData.Add(new Dropdown.OptionData("朱宇豪"));
        PersonData.Add(new Dropdown.OptionData("郭建国"));
        PersonData.Add(new Dropdown.OptionData("张建伟"));
        PersonData.Add(new Dropdown.OptionData("李源朝"));

        Person.options = PersonData;

        Property.onValueChanged.AddListener(NumberChanged);
        State.onValueChanged.AddListener(NameChanged);
        Person.onValueChanged.AddListener(PerdsonChanged);
    }

    void NumberChanged(int index)
    {
        iPropertyIndex = index;
        RebuildData();
    }

    void NameChanged(int index)
    {
        iStateIndex = index;
        RebuildData();
    }

    void PerdsonChanged(int index)
    {
        iPersonIndex = index;
        RebuildData();
    }

    void RebuildData()
    {
        //table.ShowSelect(str);
        table.Select(Property.options[iPropertyIndex].text, State.options[iStateIndex].text,
            Person.options[iPersonIndex].text);
    }
}