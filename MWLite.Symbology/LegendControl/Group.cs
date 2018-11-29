
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MWLite.Symbology.Classes;


namespace MWLite.Symbology.LegendControl
{
    //组管理类
    public class Group
	{
		#region 成员变量

		private string m_Caption;

		/// <summary>
        /// Tag用来保存组的某些信息
		/// </summary>
		public string Tag;
		private object m_Icon;
		private bool m_Expanded;
		private int m_Height;
		private Legend m_Legend;

		/// <summary>
		/// 组的句柄
		/// </summary>
		protected internal int m_Handle;

		/// <summary>
		/// 组中的最高位
		/// </summary>
		protected internal int Top;

		/// <summary>
		/// 保存的层列表
		/// </summary>
		public List<Layer> Layers;
		
		private VisibleStateEnum m_VisibleState;

        protected internal bool m_StateLocked;

        /// <summary>
        /// 返回图层信息
        /// </summary>
        public string LayersGuidList()
        {
            return string.Join(";", Layers.Select(item => item.GuidKey + (item.Expanded ? "1" : "0")).ToArray());
        }
		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public Group(Legend leg)
		{
			
			m_Legend = leg;
			

			Layers = new List<Layer>();
			Expanded = true;
			VisibleState = VisibleStateEnum.vsALL_VISIBLE;
			m_Handle = -1;
			Icon = null;
            m_StateLocked = false;
		}
		/// <summary>
		/// 析构函数
		/// </summary>
		~Group()
		{
			m_Legend = null;
			Layers.Clear();
			Layers = null;
			m_Icon = null;
		}

		/// <summary>
		/// 文本
		/// </summary>
		public string Text
		{
			get
			{
				return m_Caption;
			}
			set 
			{
				m_Caption = value;
				m_Legend.Redraw();
			}
		}

		/// <summary>
	    /// 图标
		/// </summary>
		public object Icon
		{
			get
			{
				return m_Icon;
			}
			set 
			{
				if(globals.IsSupportedPicture(value))
				{
					m_Icon = value;
					m_Legend.Redraw();
				}
				else
				{
					throw new System.Exception("Legend Error: Invalid Group Icon type");
				}
			}
		}

		/// <summary>
		/// 图层数
		/// </summary>
		public int LayerCount
		{
			get
			{
				return Layers.Count;
			}
		}
		
		/// <summary>
		/// 根据索引获取图层
		/// </summary>
		public Layer this[int LayerPosition]
		{
			get
			{
				if(LayerPosition >=0 && LayerPosition < this.Layers.Count)
					return (Layer)Layers[LayerPosition];

				globals.LastError = "Invalid Layer Position within Group";
					return null;
			}	
		}

		/// <summary>
		/// 获得组的句柄
		/// </summary>
		public int Handle
		{
			get
			{
				return m_Handle;
			}
		}

		/// <summary>
		/// 根据索引获取图层
		/// </summary>
		/// <param name="Handle">图层句柄</param>
		protected internal Layer LayerByHandle(int Handle)
		{
			int count = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < count; i++)
			{
				lyr = (Layer)Layers[i];
				if (lyr.Handle == Handle)
					return lyr;
			}
			return null;
		}

		/// <summary>
		/// 获取图层在组的位置
		/// </summary>
		/// <param name="Handle">图层句柄</param>
		/// <returns>0以上，-1表示查找失败</returns>
		protected internal int LayerPositionInGroup(int Handle)
		{
			int count = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < count; i++)
			{
				lyr = (Layer)Layers[i];
				if (lyr.Handle == Handle)
					return i;
			}
			return -1;
		}

		/// <summary>
		/// 获取图层通过位置
		/// </summary>
		/// <param name="PositionInGroup">位置</param>
		/// <returns>-1表示失败</returns>
		public int LayerHandle(int PositionInGroup)
		{
			if(PositionInGroup >=0 && PositionInGroup < Layers.Count)
				return ((Layer)Layers[PositionInGroup]).Handle;

			globals.LastError = "Invalid layer position within group";
			return -1;
		}

		/// <summary>
        /// 是否展开
        /// </summary>
		public bool Expanded
		{
			get
			{
				return m_Expanded;
			}
			set
			{
				if(value != m_Expanded)
				{
					m_Expanded = value;
					RecalcHeight();
					m_Legend.Redraw();
				}
			}
		}

	    /// <summary>
        /// 高度
        /// </summary>
		protected internal int Height
		{
			get
			{
                RecalcHeight();
				return m_Height;
			}
		}

        /// <summary>
        /// 展开高度
        /// </summary>
		protected internal int ExpandedHeight
		{
			get
			{
				int NumLayers = Layers.Count;
				int Retval = Constants.ITEM_HEIGHT;
				Layer lyr;
                
				for(int i = 0; i < NumLayers; i++)
				{
					lyr = (Layer)Layers[i];
					Retval += lyr.CalcHeight(true);
				}
				

				return Retval;
			}
		}


		/// <summary>
		/// 重新计算组的高度，在图例发生改变时
		/// </summary>
		protected internal void RecalcHeight()
		{
			int NumLayers = Layers.Count;
			m_Height = Constants.ITEM_HEIGHT;
			Layer lyr;

			if(m_Expanded == true)
			{
				for(int i = 0; i < NumLayers; i++)
				{
					lyr = (Layer)Layers[i];
					if (!lyr.HideFromLegend)
						m_Height += lyr.Height;
				}
			}
			else
			{
				m_Height = Constants.ITEM_HEIGHT;
			}
		}


		public bool LayersVisible
		{
			get
			{
				if (VisibleState == VisibleStateEnum.vsALL_HIDDEN)
					return false;
				else
					return true;
			}
			set
			{
				if(value == true)
					VisibleState = VisibleStateEnum.vsALL_VISIBLE;
				else
					VisibleState = VisibleStateEnum.vsALL_HIDDEN;
			}
		}


		protected internal VisibleStateEnum VisibleState
		{
			get
			{
				return m_VisibleState;
			}
			set
			{
				if(value == VisibleStateEnum.vsPARTIAL_VISIBLE)
				{

					throw new System.Exception("Invalid [Property set] value: vsPARTIAL_VISIBLE");					
				}
				
				m_VisibleState = value;
				UpdateLayerVisibility();
			}
		}


        public bool StateLocked
        {
            get
            {
                return m_StateLocked;
            }
            set
            {
                m_StateLocked = value;
            }
        }


		private void UpdateLayerVisibility()
		{
			int NumLayers = Layers.Count;
			Layer lyr = null;
			bool visible = false;
			if (m_VisibleState == VisibleStateEnum.vsALL_VISIBLE)
				visible = true;

			for(int i = 0; i < NumLayers; i++)
			{
				lyr = (Layer)Layers[i];
				bool oldState = m_Legend.m_Map.get_LayerVisible(lyr.Handle);

				m_Legend.m_Map.set_LayerVisible(lyr.Handle,visible);				

				if (oldState != visible)
				{
					bool cancel = false;
					m_Legend.FireLayerVisibleChanged(lyr.Handle,visible, ref cancel);
					if (cancel == true)
						lyr.Visible = !(visible);
				}
			}
		}


		protected internal void UpdateGroupVisibility()
		{
			int NumVisible = 0;
			int NumLayers = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < NumLayers; i++)
			{
				lyr = (Layer)Layers[i];
				if(m_Legend.m_Map.get_LayerVisible(lyr.Handle) == true)
					NumVisible++;
			}

			if (NumVisible == NumLayers)
				m_VisibleState = VisibleStateEnum.vsALL_VISIBLE;
			else if (NumVisible == 0)
				m_VisibleState = VisibleStateEnum.vsALL_HIDDEN;
			else
				m_VisibleState = VisibleStateEnum.vsPARTIAL_VISIBLE;
		}

		/// <summary>
        /// 提供闪照
        /// </summary>
        /// <param name="imgWidth"></param>
        /// <returns></returns>
		public System.Drawing.Bitmap Snapshot(int imgWidth)
		{
			Bitmap bmp = null;// = new Bitmap(imgWidth,imgHeight);
			Rectangle rect;

			System.Drawing.Graphics g;
					
			bmp = new Bitmap(imgWidth,this.ExpandedHeight);
			g = Graphics.FromImage(bmp);
			g.Clear(System.Drawing.Color.White);

			rect = new Rectangle(0,0,imgWidth,this.ExpandedHeight);

			m_Legend.DrawGroup(g,this,rect,true);

			return bmp;
		}

        
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(this.Text, font, maxWidth);
        }

        
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(this.Text, font);
        }
	}
}
