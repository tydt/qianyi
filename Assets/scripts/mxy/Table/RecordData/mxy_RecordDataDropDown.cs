using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class mxy_RecordDataDropDown : MonoBehaviour {

    public Dropdown Number;
    public Dropdown Name;
    public Dropdown Person;
    public mxy_RecordDataTable table;
    private int iNumberIndex = 0;
    private int iNameIndex = 0;
    private int iPersonIndex = 0;

    void Start()
    {
        BuildDropdown();
    }

    void BuildDropdown()
    {
        List<Dropdown.OptionData> equipmentData = new List<Dropdown.OptionData>();
        equipmentData.Add(new Dropdown.OptionData("全部"));
        equipmentData.Add(new Dropdown.OptionData("DH214563"));
        equipmentData.Add(new Dropdown.OptionData("JZ101258"));
        equipmentData.Add(new Dropdown.OptionData("KS151023"));
        equipmentData.Add(new Dropdown.OptionData("LJ100011"));
        Number.options = equipmentData;

        List<Dropdown.OptionData> setupData = new List<Dropdown.OptionData>();
        setupData.Add(new Dropdown.OptionData("全部"));
        setupData.Add(new Dropdown.OptionData("模型概念错位"));
        setupData.Add(new Dropdown.OptionData("建筑表现"));
        setupData.Add(new Dropdown.OptionData("空间数学动力学"));
        setupData.Add(new Dropdown.OptionData("综合实例"));
        setupData.Add(new Dropdown.OptionData("理解结构"));

        Name.options = setupData;

        List<Dropdown.OptionData> guaranteeData = new List<Dropdown.OptionData>();
        guaranteeData.Add(new Dropdown.OptionData("全部"));
        guaranteeData.Add(new Dropdown.OptionData("李丽"));
        guaranteeData.Add(new Dropdown.OptionData("赵海"));
        guaranteeData.Add(new Dropdown.OptionData("刘照为"));
        guaranteeData.Add(new Dropdown.OptionData("刘国良"));
        guaranteeData.Add(new Dropdown.OptionData("刘文"));
        guaranteeData.Add(new Dropdown.OptionData("王静"));
        guaranteeData.Add(new Dropdown.OptionData("王慧"));
        guaranteeData.Add(new Dropdown.OptionData("王红红"));

        Person.options = guaranteeData;

        Number.onValueChanged.AddListener(NumberChanged);
        Name.onValueChanged.AddListener(NameChanged);
        Person.onValueChanged.AddListener(PerdsonChanged);
    }

    void NumberChanged(int index)
    {
        iNumberIndex = index;
        RebuildData();
    }

    void NameChanged(int index)
    {
        iNameIndex = index;
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
        table.Select(Number.options[iNumberIndex].text, Name.options[iNameIndex].text, Person.options[iPersonIndex].text);
    }

}