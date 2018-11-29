using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw
{
    public class Enums
    {

        public enum LegendCommand
        {
            Labels = 1,
            Properties = 2,
            ZoomToLayer = 3,
            ImportOgrLayer = 4,
            SaveLayerStyle = 5,
            RemoveLayer = 6,
            LoadLayerStyle = 7,
            CalculateArea = 8,
            addGroup = 9
        }

        public enum ExtentType
        {
            Geogrpahic = 0,
            Projected = 1,
            Known = 2,
        }

        public enum ProjectState
        {
            NotSaved = 0,
            HasChanges = 1,
            NoChanges = 2,
            Empty = 3,
        }

        public enum LayerType
        {
            Vector = 0,
            Raster = 1,
            All = 2,
        }

        public enum FileType
        {
            Project = 0,
        }
    }
}
