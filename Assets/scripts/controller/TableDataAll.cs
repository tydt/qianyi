using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SLS.Widgets.Table
{
    public class TableDataAll : MonoBehaviour
    {
        private Table table;
        public TableType type = TableType.设备_设备台账;
        private float width = 1000f;

        private void Start()
        {
            //BuildStandingBook(null, null);
            BuildTable();
        }

        void BuildTable()
        {
            switch (type)
            {
                case TableType.临时_相关文档:
                    BuildDocuments();
                    break;
                case TableType.临时_kong:
                    BuildTempKong();
                    break;
                default:
                    break;
            }
        }

        private List<TableColumnsData> ColumnDataStandingBook
        {
            get
            {
                List<TableColumnsData> rs = new List<TableColumnsData>();
                rs.Add(new TableColumnsData("序号", 1));
                rs.Add(new TableColumnsData("设备类型",2));
                rs.Add(new TableColumnsData("型号", 4));
                rs.Add(new TableColumnsData("技术参数", 2));
                rs.Add(new TableColumnsData("配件品牌", 2));
                rs.Add(new TableColumnsData("供应商", 2));
                rs.Add(new TableColumnsData("进场时间", 3));
                rs.Add(new TableColumnsData("进场负责人", 2));
                rs.Add(new TableColumnsData("单机调试情况", 2));
                rs.Add(new TableColumnsData("验收时间", 3));
                rs.Add(new TableColumnsData("验收负责人", 2));
                rs.Add(new TableColumnsData("安装位置", 3));
                rs.Add(new TableColumnsData("质保期", 2));
                rs.Add(new TableColumnsData("移交时间", 3));
                rs.Add(new TableColumnsData("附件", 2));
                rs.Add(new TableColumnsData("操作", 1.5f));
                rs.Add(new TableColumnsData("操作", 1.5f));
                return rs;
            }
        }

        private List<TableColumnsData> ColumnDataMaintenance
        {
            get
            {
                List<TableColumnsData> rs = new List<TableColumnsData>();
                rs.Add(new TableColumnsData("序号", 1));
                rs.Add(new TableColumnsData("设备名称", 1));
                rs.Add(new TableColumnsData("型号", 1));
                rs.Add(new TableColumnsData("技术参数", 1));
                rs.Add(new TableColumnsData("使用位置", 1));
                rs.Add(new TableColumnsData("供应商", 1));
                rs.Add(new TableColumnsData("启用时间", 1));
                rs.Add(new TableColumnsData("维修间隔月", 1));
                rs.Add(new TableColumnsData("检查人", 1));
                rs.Add(new TableColumnsData("检查时间", 1));
                rs.Add(new TableColumnsData("维修记录", 1));
                rs.Add(new TableColumnsData("维修时间", 1));
                rs.Add(new TableColumnsData("维修内容", 1));
                rs.Add(new TableColumnsData("保养等级", 1));
                rs.Add(new TableColumnsData("维修总额", 1));
                rs.Add(new TableColumnsData("操作", 1));
                return rs;
            }
        }

        private List<TableColumnsData> ColumnDataWarehousing
        {
            get
            {
                List<TableColumnsData> rs = new List<TableColumnsData>();
                rs.Add(new TableColumnsData("编号", 1));
                rs.Add(new TableColumnsData("类别", 1));
                rs.Add(new TableColumnsData("使用情况", 1));
                rs.Add(new TableColumnsData("使用人员", 1));
                rs.Add(new TableColumnsData("最近领用时间", 1));
                rs.Add(new TableColumnsData("最近采购时间", 1));
                return rs;
            }
        }

        private List<TableColumnsData> ColumnDataTempDocument
        {
            get
            {
                List<TableColumnsData> rs = new List<TableColumnsData>();
                rs.Add(new TableColumnsData("编号", 1));
                rs.Add(new TableColumnsData("文件名", 4));
                rs.Add(new TableColumnsData("分类", 3));
                rs.Add(new TableColumnsData("上传人",2));
                rs.Add(new TableColumnsData("上传时间", 4));
                rs.Add(new TableColumnsData("操作", 3));
                return rs;
            }
        }

        public void BuildStandingBook(List<TableClassEquipmentStandingBook> datas, Action<Datum, Column> clickDelegate)
        {
            if(datas == null)
            {
                datas = TableClassEquipmentStandingBook.TestData;
            }

            MakeDefaults.Set();
            table = GetComponent<Table>();
            table.ResetTable();

            float percents = 0f;
            ColumnDataStandingBook.ForEach(x => percents += x.widthPercent);
            float onePeace = width / percents;

            foreach (TableColumnsData data in ColumnDataStandingBook)
            {
                table.AddTextColumn(data.name, null, onePeace * data.widthPercent - 5, 200f).horAlignment = Column.HorAlignment.CENTER;                
            }

            if(clickDelegate != null)
            {
                table.Initialize(clickDelegate);
            }
            else
            {
                table.Initialize();
            }

            foreach(TableClassEquipmentStandingBook data in datas)
            {
                Datum d = Datum.Body(data.No);
                d.elements.Add(data.No);
                d.elements.Add(data.equipmentType);
                d.elements.Add(data.type);
                d.elements.Add(data.technical);
                d.elements.Add(data.brand);
                d.elements.Add(data.supplier);
                d.elements.Add(data.enterTime);
                d.elements.Add(data.enterResponsePerson);
                d.elements.Add(data.debugStatus);
                d.elements.Add(data.checkTime);
                d.elements.Add(data.checkResponsePerson);
                d.elements.Add(data.setupLocation);
                d.elements.Add(data.guaranteePeriod);
                d.elements.Add(data.transferTime);
                d.elements.Add("选择文件");
                d.elements.Add("查看");
                d.elements.Add("定位");
                
                table.data.Add(d);
            }
            table.StartRenderEngine();
        }

        void BuildMaintenance(List<TableClassEquipmentMaintenance> datas)
        {
            if(datas == null)
            {
                datas = TableClassEquipmentMaintenance.RandomClassData(30);
            }

            MakeDefaults.Set();
            table = GetComponent<Table>();
            table.ResetTable();

            float percents = 0f;
            ColumnDataMaintenance.ForEach(x => percents += x.widthPercent);
            float onePeace = width / percents;

            foreach (TableColumnsData data in ColumnDataStandingBook)
            {
                table.AddTextColumn(data.name, null, onePeace * data.widthPercent - 5, 200f); 
                
            }
            table.Initialize();

            foreach (TableClassEquipmentMaintenance data in datas)
            {
                Datum d = Datum.Body(data.No);
                d.elements.Add(data.No);
                d.elements.Add(data.name);
                d.elements.Add(data.type);
                d.elements.Add(data.technical);
                d.elements.Add(data.useLocation);
                d.elements.Add(data.supplier);
                d.elements.Add(data.beginTime);
                d.elements.Add(data.intervalMonth);
                d.elements.Add(data.checkPerson);
                d.elements.Add(data.checkTime);
                d.elements.Add(data.maintenanceRecord);
                d.elements.Add(data.maintenanceTime);
                d.elements.Add(data.maintenanceContent);
                d.elements.Add(data.maintenanceLevel);
                d.elements.Add(data.maintenancePrice);
                d.elements.Add("查看");
                table.data.Add(d);
            }
            table.StartRenderEngine();
        }

        void BuildWarehousing()
        {

        }

        void BuildOAFiles()
        {

        }

        void BuildDocuments()
        {
            
            MakeDefaults.Set();
            table = GetComponent<Table>();
            table.ResetTable();

            float percents = 0f;
            ColumnDataTempDocument.ForEach(x => percents += x.widthPercent);
            float onePeace = width / percents;

            foreach (TableColumnsData data in ColumnDataTempDocument)
            {
                Debug.Log(data.widthPercent);
                table.AddTextColumn(data.name, null, onePeace * data.widthPercent - 5, 1000f);
            }
            table.Initialize();

            for(int i = 0; i < 3; i++)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add((i + 1).ToString());
                d.elements.Add("新建 Microsoft Word 文档.docx");
                d.elements.Add("物业资料");
                d.elements.Add("张三而");
                d.elements.Add("2017.01.05 14:32:33");
                d.elements.Add("下载到本地");
                table.data.Add(d);
            }
            table.StartRenderEngine();
        }

        void BuildTempKong()
        {

            MakeDefaults.Set();
            table = GetComponent<Table>();
            table.ResetTable();

            float percents = 0f;
            ColumnDataTempDocument.ForEach(x => percents += x.widthPercent);
            float onePeace = width / percents;

            foreach (TableColumnsData data in ColumnDataTempDocument)
            {
                Debug.Log(data.widthPercent);
                table.AddTextColumn(data.name, null, onePeace * data.widthPercent - 5, 1000f);
            }
            table.Initialize();
            for (int i = 0; i < 5; i++)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add("EDAS07F9" + i.ToString());
                d.elements.Add("新建 Microsoft Word 文档.docx");
                d.elements.Add("相关资料");
                d.elements.Add("张三");
                d.elements.Add("2017-11-11 11:11:11");
                d.elements.Add("下载到本地");
                table.data.Add(d);
            }
            table.StartRenderEngine();
        }

        public enum TableType
        {
            设备_设备台账,
            设备_维保管理,
            设备_仓储管理,
            安全_门禁管理,
            安全_安全消防设备,
            OA_档案管理,
            OA_总和管理,
            临时_相关文档,
            临时_kong
        }

        
    }

    public class TableColumnsData {
        public string name = "行名称";
        public float widthPercent = 1f;

        public TableColumnsData(string name, float width)
        {
            this.name = name;
            this.widthPercent = width;
        }
    }



    public delegate void DelegateTableClick(Datum d, Column c);
}
