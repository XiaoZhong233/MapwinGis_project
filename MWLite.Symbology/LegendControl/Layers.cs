

using System.Collections.Generic;
using MWLite.Symbology.Classes;

namespace MWLite.Symbology.LegendControl
{
    /// <summary>
    /// 层的管理类，包含操作Legend中的层基本方法
    /// </summary>
	public class Layers: IEnumerable<Layer>
	{
		private Legend m_Legend;

        #region 构造函数
        public Layers(Legend leg)
		{
			//The next line MUST GO FIRST in the constructor
			m_Legend = leg;
			//The previous line MUST GO FIRST in the constructor
		}
        #endregion

        #region IEnumerable 接口实现
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Layer> GetEnumerator()
        {
            for (int i = 0; i < Count; i++ )
            {
                var l = this[i];
                if (l == null)
                    break;
                yield return l;
            }
        }
        #endregion

        /// <summary>
        ///  索引器，通过层的列表迭代
        /// </summary>
        /// <param name = "position">索引从0开始</param>
        /// <returns>The layer</returns>
        public Layer this[int Position]
		{
			get
			{
				if(Position >=0 && Position < Count)	
				{
					int Handle = m_Legend.m_Map.get_LayerHandle(Position);
					return m_Legend.FindLayerByHandle(Handle);
				}

				globals.LastError = "Invalid Layer Position";
				return null;
			}
		}

        /// <summary>
		/// 获取层的数量
		/// </summary>
		public int Count
		{
			get
			{
				if (m_Legend == null) return 0;
				if (m_Legend.m_Map == null) return 0;
				return m_Legend.m_Map.NumLayers;
			}
		}

		/// <summary>
		/// Get a Layer by the handle to the layer (without knowing what group the layer is in)
		/// </summary>
		/// <param name="Handle">The handle to the layer</param>
		/// <returns>Layer class item, null (nothing) on success</returns>
		public Layer ItemByHandle(int Handle)
		{
			return m_Legend.FindLayerByHandle(Handle);
		}


		/// <summary>
		/// Move a layer to a specified location within a specified group
		/// </summary>
		/// <param name="LayerHandle">Handle to the layer to move</param>
		/// <param name="TargetGroupHandle">Handle of the group into which to move the layer</param>
		/// <param name="PositionInGroup">0-Based index into the list of layers within the Target Group</param>
		/// <returns>True on success, False otherwise</returns>
		public bool MoveLayer(int LayerHandle, int TargetGroupHandle, int PositionInGroup)
		{
			return m_Legend.MoveLayer(TargetGroupHandle,LayerHandle,PositionInGroup);
		}

		/// <summary>
		/// Clears all layers from the legend (from all groups)
		/// </summary>
		public void Clear()
		{
			m_Legend.ClearLayers();
		}

		/// <summary>
		/// Move a layer to a new position within a group
		/// </summary>
		/// <param name="LyrHandle">Handle to the layer to move</param>
		/// <param name="NewPosition">0-based index of the desired position</param>
		/// <returns>True on Success, False otherwise</returns>
		public bool MoveLayerWithinGroup(int LyrHandle, int NewPosition)
		{
			int GroupIndex,
				LayerIndex;
          
			if (m_Legend.FindLayerByHandle(LyrHandle, out GroupIndex, out LayerIndex) != null)
			{
				Group grp = (Group)m_Legend.m_AllGroups[GroupIndex];
				return m_Legend.MoveLayer(grp.Handle,LyrHandle,NewPosition);
			}

			globals.LastError = "Invalid Layer Handle";
			return false;			
		}

        /// <summary>
        /// 往地图上添加一个图层,位置在当前选择的层的上方或者在层列表的顶部
        /// </summary>
		public int Add(object newLayer, bool Visible)
		{
			return m_Legend.AddLayer(newLayer,Visible);
		}

        /// <summary>
        /// 在组的顶部添加一个图层
        /// </summary>
        /// <returns>返回图层的句柄，-1添加失败
		public int Add(object newLayer, bool Visible, bool PlaceAboveCurrentlySelected)
		{
			return m_Legend.AddLayer(newLayer,Visible,PlaceAboveCurrentlySelected);
		}

        /// <summary>
        /// 在组的顶部添加一个图层
        /// </summary>
        /// <param name="legendVisible">层在lengend上是否可见</param>
        /// <param name="newLayer">符合层类型的对象</param>
        /// <param name="mapVisible">所添加的层是否在地图上显示</param>
		public int Add(object newLayer, bool Visible, int TargetGroupHandle)
		{
			return m_Legend.AddLayer(newLayer,Visible,TargetGroupHandle);
		}

        /// <summary>
        /// 在组的特定位置添加一个图层
        /// </summary>
        public int Add(object newLayer, bool Visible, int TargetGroupHandle, int afterLayerHandle)
        {
            return m_Legend.AddLayer(newLayer, Visible, TargetGroupHandle, true, afterLayerHandle);
        }

        /// <summary>
        /// 在最高层的组中的顶部添加图层
        /// </summary>
        public int Add(bool LegendVisible, object newLayer, bool MapVisible)
        {
            return m_Legend.AddLayer(newLayer, MapVisible, -1, LegendVisible);
        }

		/// <summary>
		/// 移除层
		/// </summary>
		/// <param name="LayerHandle">待移除图层的句柄</param>
		/// <returns>bool</returns>
		public bool Remove(int LayerHandle)
		{
			return m_Legend.RemoveLayer(LayerHandle);
		}

		/// <summary>
        /// 返回图层在组中的位置
        /// </summary>
        /// <param name="LayerHandle"></param>
        /// <returns></returns>
		public int PositionInGroup(int LayerHandle)
		{
			int LayerIndex ,
				GroupIndex ;
			Layer lyr = m_Legend.FindLayerByHandle(LayerHandle,out GroupIndex, out LayerIndex);

			if(lyr != null)
				return LayerIndex;
			
			globals.LastError = "Invalid Layer Handle";
			return -1;
		}

		/// <summary>
		/// 返回包含某个图层的组
		/// </summary>
		/// <param name="LayerHandle">图层句柄</param>
		/// <returns>组句柄，-1表示失败</returns>
		public int GroupOf(int LayerHandle)
		{

			int LayerIndex,
				GroupIndex;
			Layer lyr = m_Legend.FindLayerByHandle(LayerHandle,out GroupIndex, out LayerIndex);

			if(lyr != null)
			{
                Group grp = (Group)m_Legend.m_AllGroups[GroupIndex];
				return grp.Handle;
			}
			
			globals.LastError = "Invalid Layer Handle";
			return -1;
		}

		/// <summary>
		/// 指示某个组是否可用
		/// </summary>
		/// <param name="Handle">组句柄</param>
		/// <returns>bool</returns>
		public bool IsValidHandle(int Handle)
		{
			if(m_Legend.m_Map.get_LayerPosition(Handle) >=0)
				return true;
			else
				return false;
		}


		/// <summary>
		/// Collapse 所有图层
		/// </summary>
		public void CollapseAll()
		{
			m_Legend.Lock();
			int i, count;

			count = Count;
			for( i = 0; i < count; i++)
				this[i].Expanded = false;
			m_Legend.Unlock();
		}

		/// <summary>
		///展开所有图层
		/// </summary>
		public void ExpandAll()
		{
			m_Legend.Lock();
			int i, count;

			count = Count;
			for( i = 0; i < count; i++)
				this[i].Expanded = true;
			m_Legend.Unlock();
		}

        
    }
}
