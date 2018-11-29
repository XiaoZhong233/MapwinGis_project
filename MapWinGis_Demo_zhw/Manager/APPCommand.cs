using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw
{
    public class APPCommand
    {
        public enum AppCommand
        {
            None = 0,
            Open = 1,
            ZoomIn = 2,
            ZoomOut = 3,
            Pan = 4,
            Measure = 5,
            MeasureArea = 6,
            Select = 7,
            CloseProject = 8,
            SaveProject = 9,
            Identify = 10,
            RemoveLayer = 11,
            ZoomToLayer = 12,
            SetProjection = 13,
            AddVector = 14,
            AddRaster = 15,
            CreateLayer = 16,
            ZoomToSelected = 17,
            ClearSelection = 18,
            SaveProjectAs = 19,
            CloseApp = 20,
            LoadProject = 21,
            Search = 22,
            SelectByPolygon = 23,
            HighlightShapes = 24,
            AddDatabase = 25,
            Snapshot = 26,
        }
    }
}
