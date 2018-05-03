using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EquipmentDropdownController : MonoBehaviour
{

    public Dropdown Equipment;
    public Dropdown Setup;
    public Dropdown Guarantee;
    public SLS.Widgets.Table.TableDataAll table;
    private int equipmentIndex = 0;
    private int setupIndex = 0;
    private int guaranteeIndex = 0;

    public List<string> EquipmentNames = TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.equipmentType);
    public List<GameObject> EquipmentGameObject;
    public EquipmentController TheEquipController;

    void Start()
    {
        BuildDropdown();
        //RegistGameObjectClickEvent();
    }

    void BuildDropdown()
    {
        List<Dropdown.OptionData> equipmentData = new List<Dropdown.OptionData>();
        equipmentData.Add(new Dropdown.OptionData("全部"));
        foreach (string name in TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.equipmentType))
        {
            equipmentData.Add(new Dropdown.OptionData(name));
        }
        Equipment.options = equipmentData;

        List<Dropdown.OptionData> setupData = new List<Dropdown.OptionData>();
        setupData.Add(new Dropdown.OptionData("全部"));
        foreach (string name in TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.setupLocation))
        {
            setupData.Add(new Dropdown.OptionData(name));
        }
        Setup.options = setupData;

        List<Dropdown.OptionData> guaranteeData = new List<Dropdown.OptionData>();
        guaranteeData.Add(new Dropdown.OptionData("全部"));
        foreach (string name in TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.guaranteePeriod))
        {
            guaranteeData.Add(new Dropdown.OptionData(name));
        }
        Guarantee.options = guaranteeData;

        Equipment.onValueChanged.AddListener(SelectEquipment);
        Setup.onValueChanged.AddListener(SelectSetup);
        Guarantee.onValueChanged.AddListener(SelectGuarantee);

        table.BuildStandingBook(null, TableClick);
    }

    void SelectEquipment(int index)
    {
        equipmentIndex = index;
        RebuildData();
    }

    void SelectSetup(int index)
    {
        setupIndex = index;
        RebuildData();
    }

    void SelectGuarantee(int index)
    {
        guaranteeIndex = index;
        RebuildData();
    }

    void RebuildData()
    {
        if (equipmentIndex == 0 && setupIndex == 0 && guaranteeIndex == 0)
        {
            table.BuildStandingBook(null, TableClick);
            return;
        }
        List<TableClassEquipmentStandingBook> datas = TableClassEquipmentStandingBook.TestData;
        if (equipmentIndex != 0)
        {
            string values = TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.equipmentType)[equipmentIndex - 1];
            IEnumerable<TableClassEquipmentStandingBook> rs =
                from data in datas
                where data.equipmentType == values
                select data;
            datas = rs.ToList();
        }
        if (setupIndex != 0)
        {
            string values = TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.setupLocation)[setupIndex - 1];
            IEnumerable<TableClassEquipmentStandingBook> rs =
                from data in datas
                where data.setupLocation == values
                select data;
            datas = rs.ToList();
        }
        if (guaranteeIndex != 0)
        {
            string values = TableClassEquipmentStandingBook.DataEnums(TableClassEquipmentStandingBook.DataType.guaranteePeriod)[guaranteeIndex - 1];
            IEnumerable<TableClassEquipmentStandingBook> rs =
                from data in datas
                where data.guaranteePeriod == values
                select data;
            datas = rs.ToList();
        }
        table.BuildStandingBook(datas, TableClick);
    }

    private void TableClick(SLS.Widgets.Table.Datum datum, SLS.Widgets.Table.Column column)
    {
        //int index = EquipmentNames.IndexOf(datum.elements[1].value);
        ////print(index);
        //if(index == -1)
        //{
        //    return;
        //}
        //Vector3 pos = EquipmentGameObject[index].transform.position;
        //for(int i = 0; i < EquipmentGameObject.Count; i++)
        //{
        //    if(i == index)
        //    {
        //        EquipmentGameObject[i].GetComponent<MaterialHelper>().SetTargetActive(true);
        //    }
        //    else
        //    {
        //        EquipmentGameObject[i].GetComponent<MaterialHelper>().SetTargetActive(false);
        //    }
        //}
        //iTween.MoveTo(Target.gameObject, pos, 1f);
        //Camera.SetZoom(1f);

        print(123);
        SendMessageUpwards("SetTableActive", false);
        //SendMessageUpwards("FocusGameObjectName", datum.elements[1].value);
        TheEquipController.FocusGameObjectName(datum.elements[1].value);
    }


}
