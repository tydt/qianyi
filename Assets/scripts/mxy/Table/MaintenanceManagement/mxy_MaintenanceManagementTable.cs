using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SLS.Widgets.Table;
using UnityEngine;
using UnityEngine.EventSystems;

public class mxy_MaintenanceManagementTable : MonoBehaviour
{

    public Table table;
    public Sprite iconUp;
    public Sprite iconDown;
    private Dictionary<string, Sprite> spriteDict;
    public static List<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> poplist;
    public static List<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> poplist_Temp;

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
        poplist = mxy_MaintenanceManagementTableData.Generate(random);

        this.table.ResetTable();
        poplist_Temp = poplist;


        // Define our columns
        Column c;
        c = this.table.AddTextColumn("编号", null, -1, 150);
        c.horAlignment = Column.HorAlignment.CENTER;
        c.headerIcon = "UP";
        c = this.table.AddTextColumn("流程标题", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("流程属性", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("审批状态", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("发起人", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("发起时间", null, -1, 250);
        c.horAlignment = Column.HorAlignment.CENTER;
        c = this.table.AddTextColumn("流程进度", null, -1, 250);
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
            delegate (mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p1,
                mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p2)
            {
                // 编号
                if (column.idx == 0)
                {
                    if (isAscending)
                        return p1.number.CompareTo(p2.number);
                    else
                        return p2.number.CompareTo(p1.number);
                }
                // 流程标题
                if (column.idx == 1)
                {
                    if (isAscending)
                        return p1.title.CompareTo(p2.title);
                    else
                        return p2.title.CompareTo(p1.title);
                }
                // 流程属性
                if (column.idx == 2)
                {
                    if (isAscending)
                        return p1.property.CompareTo(p2.property);
                    else
                        return p2.property.CompareTo(p1.property);
                }
                // 审批状态
                if (column.idx == 3)
                {
                    if (isAscending)
                        return p1.state.CompareTo(p2.state);
                    else
                        return p2.state.CompareTo(p1.state);
                }
                // 发起人
                if (column.idx == 4)
                {
                    if (isAscending)
                        return p1.person.CompareTo(p2.person);
                    else
                        return p2.person.CompareTo(p1.person);
                }
                // 发起时间
                if (column.idx == 5)
                {
                    if (isAscending)
                        return p1.time.CompareTo(p2.time);
                    else
                        return p2.time.CompareTo(p1.time);
                }
                // 流程进度
                if (column.idx == 6)
                {
                    if (isAscending)
                        return ChangetoFloat(p1.progress).CompareTo(ChangetoFloat(p2.progress));
                    else
                        return ChangetoFloat(p2.progress).CompareTo(ChangetoFloat(p1.progress));
                }
                return p1.number.CompareTo(p2.number);
            }
        );



        this.table.data.Clear();
        for (int i = 0; i < poplist_Temp.Count; i++)
        {
            mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p = poplist_Temp[i];
            Datum d = Datum.Body(i.ToString());
            d.elements.Add(p.number);
            d.elements.Add(p.title);
            d.elements.Add(p.property);
            d.elements.Add(p.state);
            d.elements.Add(p.person);
            d.elements.Add(p.time);
            d.elements.Add(p.progress);
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
                mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            poplist_Temp = poplist;
        }
        else
        {
            List<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> _poplist = poplist;

            if (str1 != "全部")
            {
                IEnumerable<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> rs =
                    from data in _poplist
                    where data.property == str1
                    select data;
                _poplist = rs.ToList();
                Debug.Log(poplist_Temp.Count);
            }
            if (str2 != "全部")
            {
                IEnumerable<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> rs =
                    from data in _poplist
                    where data.state == str2
                    select data;
                _poplist = rs.ToList();
                Debug.Log(poplist_Temp.Count);
            }
            if (str3 != "全部")
            {
                IEnumerable<mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter> rs =
                    from data in _poplist
                    where data.person == str3
                    select data;
                _poplist = rs.ToList();
                Debug.Log(poplist_Temp.Count);
            }
            Debug.Log(poplist_Temp.Count);
            for (int i = 0; i < _poplist.Count; i++)
            {
                mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p = _poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
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
            mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p = poplist[i];

            if (p.property == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
            else if(p.state == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
                d.elements.Add(p.operation);
                this.table.data.Add(d);
            }
            else if (p.person == str)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
                d.elements.Add(p.operation);
                this.table.data.Add(d);
            }
        }
        if (str == "全部")
        {
            for (int i = 0; i < poplist.Count; i++)
            {
                mxy_MaintenanceManagementTableData.MaintenanceManagementDataParameter p = poplist[i];
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(p.number);
                d.elements.Add(p.title);
                d.elements.Add(p.property);
                d.elements.Add(p.state);
                d.elements.Add(p.person);
                d.elements.Add(p.time);
                d.elements.Add(p.progress);
                d.elements.Add(p.operation);

                this.table.data.Add(d);
            }
        }
        this.table.StartRenderEngine();
    }
}
