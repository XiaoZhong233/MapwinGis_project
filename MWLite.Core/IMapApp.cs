using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MWLite.GUI.Classes;
using MWLite.Symbology.LegendControl;

namespace MWLite.Core
{
    /// <summary>
    /// IMapApp是系统的关键接口，实现此接口负责管理整个窗口
    /// </summary>
    public interface IMapApp
    {
        Legend Legend { get; }
        AxMapWinGIS.AxMap Map { get; }
        void RefreshUI();
        void AddMenu(ToolStripMenuItem menu);
        void AddToolbar(ToolStrip toolbar);
        IProject Project { get; }
        void RunCommand(AppCommand command);
    }

    public interface IProject
    {
        bool IsEmpty {get;}
        string GetPath();
        ProjectState GetState();
        bool Save();
        void SaveAs();
        void Load(string filename);
        bool TryClose();
        event EventHandler<EventArgs> ProjectChanged;
    }
}
