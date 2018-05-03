using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SLS.Widgets.Table;
using UnityEngine;
using UnityEngine.EventSystems;

public class mxy_RecordDataTable : MonoBehaviour {

    public Table table;
    public Sprite iconUp;
    public Sprite iconDown;
    private Dictionary<string, Sprite> spriteDict;
    static List<mxy_RecordDataTableData.RecordDataParameter> poplist;
    static List<mxy_RecordDataTableData.RecordDataParameter> poplist_Temp;

     System.Random random = new System.Random(1000);
    // Use this for initialization
    void Start () {
        MakeDefaults.Set();
        this.DrawTable();
    }
    public void DrawTable()
    {

        // build our sprite cross-reference
        this.spriteDict = new Dictionary<string, Sprite>();

        if (iconUp != null) this.spriteDict.Add("UP", iconUp);
        if (iconDown != null) this.spriteDict.Add("DOWN", iconDown);

        // get our data list, this would be data retrieved from any source you wish
        poplist = mxy_RecordDataTableData.Generate(random);

//        int popTotal = 0;
//        for (int i = 0; i < this.poplist.Count; i++)
//        {
//            popTotal += this.poplist[i].population;
//        }

        this.table.ResetTable();

        poplist_Temp = poplist;
        // Define our columns
        Column c;
        c = this.table.AddTextColumn("资料编号", null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;
        c.headerIcon = "UP";
        c = this.table.AddTextColumn("资料名称", null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("资料类型", null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("上传人员", null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("附件", null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("操作",null, -1, 360);
        c.horAlignment = Column.HorAlignment.CENTER;

        // Initialize Your Table
        this.table.Initialize(this.OnTableSelectedWithCol, this.spriteDict, true, this.OnHeaderClick);

        // Just activate our default sort
        this.OnHeaderClick(this.table.columns[0], null);

        // Draw Your Table
        this.table.StartRenderEngine();

    }

    private void OnInputFieldChange(Datum d, Column c, string oldVal, string newVal)
    {
        print("Change from " + oldVal + " to " + newVal);
    }

    private void OnTableSelectedWithCol(Datum datum, Column column)
    {
        if (datum == null) return;
        string cidx = "N/A";
        if (column != null)
            cidx = column.idx.ToString();
        print("You Clicked: " + datum.uid + " Column: " + cidx);
    }

    public void MoveSelection()
    {
        Element e = table.GetSelectedElement();
        if (e == null) return; // no selected cell
        table.MoveSelectionDown(false);
    }

    private void OnHeaderClick(Column column, PointerEventData e)
    {

        bool isAscending = false;
        // Reset current sort UI
        for (int i = 0; i < this.table.columns.Count; i++)
        {
            if (column == this.table.columns[i])
            {
                if (column.headerIcon == "UP")
                {
                    isAscending = true;
                    column.headerIcon = "DOWN";
                }
                else
                {
                    isAscending = false;
                    column.headerIcon = "UP";
                }
            }
            else
                this.table.columns[i].headerIcon = null;
        }

        // do the sort
        poplist_Temp.Sort(
            delegate (mxy_RecordDataTableData.RecordDataParameter p1, mxy_RecordDataTableData.RecordDataParameter p2)
            {
                // 资料编号
                if (column.idx == 0)
                {
                    if (isAscending)
                        return p1.number.CompareTo(p2.number);
                    else
                        return p2.number.CompareTo(p1.number);
                }
                // 资料名称
                if (column.idx == 1)
                {
                    if (isAscending)
                        return p1.name.CompareTo(p2.name);
                    else
                        return p2.name.CompareTo(p1.name);
                }
                // 资料类型
                if (column.idx == 2)
                {
                    if (isAscending)
                        return p1.type.CompareTo(p2.type);
                    else
                        return p2.type.CompareTo(p1.type);
                }
                // 上传人员
                if (column.idx == 3)
                {
                    if (isAscending)
                        return p1.person.CompareTo(p2.person);
                    else
                        return p2.person.CompareTo(p1.person);
                }
                // 附件
                if (column.idx == 4)
                {
                    if (isAscending)
                        return p1.accessory.CompareTo(p2.accessory);
                    else
                        return p2.accessory.CompareTo(p1.accessory);
                }
                return p1.number.CompareTo(p2.number);
            }
        );

        this.table.data.Clear();
        for (int i = 0; i < poplist.Count; i++)
        {
            mxy_RecordDataTableData.RecordDataParameter p = poplist[i];
            Datum d = Datum.Body(i.ToString());
            d.elements.Add(p.number);
            d.elements.Add(p.name);
            d.elements.Add(p.type.ToString());
            d.elements.Add(p.person);
            d.elements.Add(p.accessory);
            d.elements.Add(p.operation);
            
            this.table.data.Add(d);
        }
    }


    public void ShowSelect(string str)
    {
        this.table.data.Clear();
        Debug.Log(table.data.Count);
        for (int i = 0; i < poplist.Count; i++)
        {
            mxy_RecordDataTableData.RecordDataParameter p = poplist[i];
            
            if (p.number == str)
            {
                Datum d1 = Datum.Body(i.ToString());
                d1.elements.Add(p.number);
                d1.elements.Add(p.name);
                d1.elements.Add(p.type.ToString());
                d1.elements.Add(p.person);
                d1.elements.Add(p.accessory);
                d1.elements.Add(p.operation);

                this.table.data.Add(d1);
            }
            else if (p.name == str)
            {
                Datum d2 = Datum.Body(i.ToString());
                d2.elements.Add(p.number);
                d2.elements.Add(p.name);
                d2.elements.Add(p.type.ToString());
                d2.elements.Add(p.person);
                d2.elements.Add(p.accessory);
                d2.elements.Add(p.operation);
                this.table.data.Add(d2);
            }
            else if (p.person == str)
            {
                Datum d3 = Datum.Body(i.ToString());
                d3.elements.Add(p.number);
                d3.elements.Add(p.name);
                d3.elements.Add(p.type.ToString());
                d3.elements.Add(p.person);
                d3.elements.Add(p.accessory);
                d3.elements.Add(p.operation);
                this.table.data.Add(d3);
            }
        }
        if ("全部" == str)
        {
            Debug.Log(table.data.Count);
            
            for (int i = 0; i < poplist.Count; i++)
            {
                mxy_RecordDataTableData.RecordDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type.ToString());
                d.elements.Add(p.person);
                d.elements.Add(p.accessory);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
        }
        //OnHeaderClick(this.table.columns[0], null);
        this.table.StartRenderEngine();
    }
    public void Select(string str1, string str2, string str3)
    {
        this.table.data.Clear();
        if (str1 == str2 && str2 == str3)
        {
            for (int i = 0; i < poplist.Count; i++)
            {
                mxy_RecordDataTableData.RecordDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type.ToString());
                d.elements.Add(p.person);
                d.elements.Add(p.accessory);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            poplist_Temp = poplist;
        }
        else
        {
            List<mxy_RecordDataTableData.RecordDataParameter> _poplist = poplist;

            if (str1 != "全部")
            {
                IEnumerable<mxy_RecordDataTableData.RecordDataParameter> rs =
                    from data in _poplist
                    where data.number == str1
                    select data;
                _poplist = rs.ToList();
            }
            if (str2 != "全部")
            {
                IEnumerable<mxy_RecordDataTableData.RecordDataParameter> rs =
                    from data in _poplist
                    where data.name == str2
                    select data;
                _poplist = rs.ToList();
            }
            if (str3 != "全部")
            {
                IEnumerable<mxy_RecordDataTableData.RecordDataParameter> rs =
                    from data in _poplist
                    where data.person == str3
                    select data;
                _poplist = rs.ToList();
            }
            for (int i = 0; i < _poplist.Count; i++)
            {
                mxy_RecordDataTableData.RecordDataParameter p = _poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type.ToString());
                d.elements.Add(p.person);
                d.elements.Add(p.accessory);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            poplist_Temp = _poplist;
        }
        this.table.StartRenderEngine();

    }
}
