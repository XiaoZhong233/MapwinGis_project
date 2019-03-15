using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWLite.Symbology.Forms
{

    /// <summary>
    /// 写的什么垃圾 fuck
    /// </summary>
    public partial class InformationForm : Form
    {
        public static bool flag = false;
        private bool singleSelectionFlag = true;
        private int layerHandle = -1;
        private int[] shapeIndexs = null;

        AxMap _axMap;
        private _DMapEvents_ShapeHighlightedEvent _e;//点击位置

        public InformationForm(AxMap axMap, _DMapEvents_ShapeHighlightedEvent e)
        {
            _axMap = axMap;
            _e = e;
            flag = true;

            InitializeComponent();
        }

        public InformationForm(AxMap axMap, _DMapEvents_ShapeIdentifiedEvent e)
        {
            _DMapEvents_ShapeHighlightedEvent ee = new _DMapEvents_ShapeHighlightedEvent(e.layerHandle, e.shapeIndex);
            _axMap = axMap;
            _e = ee;
            flag = true;

            InitializeComponent();
        }

   
        public InformationForm(AxMap axMap,int layerHandle,int[] shapeIndexs)
        {
            _axMap = axMap;
            flag = true;
            singleSelectionFlag = false;
            this.layerHandle = layerHandle;
            this.shapeIndexs = shapeIndexs;
            InitializeComponent();
        }


        private void InformationForm_Load(object sender, EventArgs e)
        {
            if (singleSelectionFlag)
            {
                this.layerHandle = _e.layerHandle;
                Shapefile shapefile = _axMap.get_Shapefile(_e.layerHandle);
                if (shapefile != null)
                {

                    informationDGV.Columns.Add("column1", "Field");
                    informationDGV.Columns.Add("column2", "Value");

                    for (int i = 0; i < shapefile.NumFields; i++)
                    {
                        informationDGV.Rows.Add();
                        informationDGV.Rows[i].Cells[0].Value = shapefile.Field[i].Name;
                        informationDGV.Rows[i].Cells[1].Value = shapefile.CellValue[i, _e.shapeIndex];

                    }
                }
            }
            else
            {
                Shapefile sf = _axMap.get_Shapefile(this.layerHandle);
                if (sf != null && shapeIndexs!=null && shapeIndexs.Count()>0)
                {
                    int shapeIndex = -1;
                    bool initFlag = true;
                    informationDGV.Columns.Add("0", "Field");
                    for (int i = 0; i < shapeIndexs.Count(); i++)
                    {

                        informationDGV.Columns.Add(i.ToString(), "shapeIndex "+i+" ");
                        //informationDGV.Columns.Add("column1", "index");
                        //informationDGV.Columns.Add("column2", "Field");
                        //informationDGV.Columns.Add("column3", "Value");
                        if (initFlag)
                        {
                            for (int q = 0; q < sf.NumFields; q++)
                            {

                                informationDGV.Rows.Add();
                                informationDGV.Rows[q].Cells[0].Value = sf.Field[q].Name;
                                //informationDGV.Rows[j].Cells[0].Value = sf.CellValue[j, i];
                            }
                        }
              
                        initFlag = false; ;
                        //informationDGV.Rows[i].Cells[0].Value = sf.Field[i].Name;

                        for(int j = 0; j < sf.NumFields; j++)
                        {
                            informationDGV.Rows[j].Cells[i+1].Value = sf.CellValue[j, i];
                        }
                        

                    }



                }
            }


        }

        private void InformationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            flag = false;
        }
    }
}
