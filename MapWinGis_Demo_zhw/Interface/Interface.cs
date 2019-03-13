using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw
{
    public interface IMapApp
    {
        Legend Legend { get; }
        AxMapWinGIS.AxMap Map { get; }
        void RefreshUI();
        void AddMenu(ToolStripMenuItem menu);
        void AddToolbar(ToolStrip toolbar);
        IProject Project { get; }
        void RunCommand(APPCommand.AppCommand command);
    }

    public interface IProject
    {
        bool IsEmpty { get; }
        string GetPath();
        Enums.ProjectState GetState();
        bool Save();
        void SaveAs();
        void Load(string filename);
        bool TryClose();
        event EventHandler<EventArgs> ProjectChanged;
    }






}
