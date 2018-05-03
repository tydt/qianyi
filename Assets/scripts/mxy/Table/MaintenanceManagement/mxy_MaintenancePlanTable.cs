using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SLS.Widgets.Table;
using UnityEngine;
using UnityEngine.EventSystems;

public class mxy_MaintenancePlanTable : MonoBehaviour {

    public Table table;
    public Sprite iconUp;
    public Sprite iconDown;
    private Dictionary<string, Sprite> spriteDict;
    static List<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> poplist;
    static List<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> poplist_Temp;

    System.Random random = new System.Random(1000);

    // Use this for initialization
    void Start()
    {
        MakeDefaults.Set();
        this.DrawTable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawTable()
    {
        // build our sprite cross-reference
        this.spriteDict = new Dictionary<string, Sprite>();

        if (iconUp != null) this.spriteDict.Add("UP", iconUp);
        if (iconDown != null) this.spriteDict.Add("DOWN", iconDown);

        // get our data list, this would be data retrieved from any source you wish
        poplist = mxy_MaintenancePlanTableData.Generate(random);

        this.table.ResetTable();

        poplist_Temp = poplist;

        // Define our columns
        Column c;
        c = this.table.AddTextColumn("编号", null, -1, 150);
        c.horAlignment = Column.HorAlignment.CENTER;
        c.headerIcon = "UP";
        c = this.table.AddTextColumn("设备名称", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("设备类别", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("维保教程", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("操作", null, -1, 250);
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
            delegate (mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p1,
                mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p2)
            {
                // 编号
                if (column.idx == 0)
                {
                    if (isAscending)
                        return p1.number.CompareTo(p2.number);
                    else
                        return p2.number.CompareTo(p1.number);
                }
                // 设备名称
                if (column.idx == 1)
                {
                    if (isAscending)
                        return p1.name.CompareTo(p2.name);
                    else
                        return p2.name.CompareTo(p1.name);
                }
                // 设备类别
                if (column.idx == 2)
                {
                    if (isAscending)
                        return p1.type.CompareTo(p2.type);
                    else
                        return p2.type.CompareTo(p1.type);
                }
                // 维保教程
                if (column.idx == 3)
                {
                    if (isAscending)
                        return p1.tutorial.CompareTo(p2.tutorial);
                    else
                        return p2.tutorial.CompareTo(p1.tutorial);
                }
                return p1.number.CompareTo(p2.number);
            }
        );



        this.table.data.Clear();
        for (int i = 0; i < poplist_Temp.Count; i++)
        {
            mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p = poplist_Temp[i];
            Datum d = Datum.Body(i.ToString());
            d.elements.Add(p.number);
            d.elements.Add(p.name);
            d.elements.Add(p.type);
            d.elements.Add(p.tutorial);
            d.elements.Add(p.operation);

            this.table.data.Add(d);
        }
    }

    float ChangetoFloat(string str)
    {
        float f1, f2;
        string[] strs = str.Split('/');
        float.TryParse(strs[0], out f1);
        float.TryParse(strs[1], out f2);

        return f1 / f2;
    }
    public void Select(string str1, string str2, string str3)
    {
        this.table.data.Clear();
        if (str1 == str2 && str2 == str3)
        {
            for (int i = 0; i < poplist.Count; i++)
            {
                mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            poplist_Temp = poplist;
        }
        else
        {
            List<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> _poplist = poplist;

            if (str1 != "全部")
            {
                IEnumerable<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> rs =
                    from data in _poplist
                    where data.name == str1
                    select data;
                _poplist = rs.ToList();
            }
            if (str2 != "全部")
            {
                IEnumerable<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> rs =
                    from data in _poplist
                    where data.type == str2
                    select data;
                _poplist = rs.ToList();
            }
            if (str3 != "全部")
            {
                IEnumerable<mxy_MaintenancePlanTableData.MaintenancePlanDataParameter> rs =
                    from data in _poplist
                    where data.tutorial == str3
                    select data;
                _poplist = rs.ToList();
            }
            for (int i = 0; i < _poplist.Count; i++)
            {
                mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p = _poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            poplist_Temp = _poplist;
        }
        this.table.StartRenderEngine();

    }


    public void ShowSelect(string str)
    {
        this.table.data.Clear();

        for (int i = 0; i < poplist.Count; i++)
        {
            mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p = poplist[i];

            if (p.name == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            else if (p.type == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);
                this.table.data.Add(d);
            }
            else if (p.tutorial == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);
                this.table.data.Add(d);
            }
        }
        if (str == "全部")
        {
            for (int i = 0; i < poplist.Count; i++)
            {
                mxy_MaintenancePlanTableData.MaintenancePlanDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.name);
                d.elements.Add(p.type);
                d.elements.Add(p.tutorial);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
        }
        this.table.StartRenderEngine();
    }

    private void OnMouseUpAsButton()
    {

    }


}
