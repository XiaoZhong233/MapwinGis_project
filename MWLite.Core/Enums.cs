using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MWLite.Core
{
    /// <summary>
    /// 包围盒类型
    /// </summary>
    public enum ExtentType
    {
        Geogrpahic = 0,
        Projected = 1,
        Known = 2,
    }

    /// <summary>
    /// 工程状态
    /// </summary>
    public enum ProjectState
    {
        NotSaved = 0,
        HasChanges = 1,
        NoChanges = 2,
        Empty = 3,
    }

    /// <summary>
    /// 图层类型
    /// </summary>
    public enum LayerType
    {
        Vector = 0,
        Raster = 1,
        All = 2,
    }

    /// <summary>
    /// 填充类型
    /// </summary>
    public enum FileType
    {
        Project = 0,
    }
}
