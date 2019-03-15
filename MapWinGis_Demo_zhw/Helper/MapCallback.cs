using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Manager
{
    /// <summary>
    /// 地图状态回调管理
    /// </summary>
    class MapCallback: ICallback
    {
        ToolStripProgressBar _progress;
        ToolStripLabel _progressLabel;
        StatusStrip _statusStrip;

        public MapCallback(StatusStrip status, ToolStripProgressBar progress, ToolStripLabel progressLabel)
        {
            _statusStrip = status;
            _progress = progress;
            _progressLabel = progressLabel;
        }


        #region ICallback interface

        public void Progress(string KeyOfSender, int Percent, string Message)
        {
            if (Percent == 0)
            {
                _progress.Visible = false;
                _progressLabel.Text = "";
            }
            else
            {
                _progress.Visible = true;
                _progress.Value = Percent;
                _progressLabel.Text = Message;
            }
            _statusStrip.Refresh();
        }

        public void Error(string KeyOfSender, string ErrorMsg)
        {
            Debug.Print("OCX 错误回调: " + ErrorMsg);
        }

        #endregion
    }
}
