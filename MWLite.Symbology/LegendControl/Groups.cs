

using System.Collections.Generic;
using System.Linq;
using MWLite.Symbology.Classes;
using MWLite.Symbology.Classes;

namespace MWLite.Symbology.LegendControl
{
    //组列表
	public class Groups: IEnumerable<Group>
	{
		private Legend m_Legend;
	
		public Groups(Legend leg)
		{

			m_Legend = leg;
		}

        #region IEnumerable 接口实现
        public IEnumerator<Group> GetEnumerator()
        {
            foreach (Group group in m_Legend.m_AllGroups)
            {
               
                yield return group;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

         /// <summary>
         /// 新增组到legend中
         /// </summary>
         /// <returns></returns>
		public int Add()
		{
			return m_Legend.AddGroup("New Group");
		}

        /// <summary>
        /// 新增组到legend中
        /// </summary>
        /// <returns></returns>
        public int Add(string Name)
		{
			return m_Legend.AddGroup(Name);
		}

        /// <summary>
        /// 新增组到legend中
        /// </summary>
        /// <returns></returns>
        public int Add(string Name, int Position)
		{
			return m_Legend.AddGroup(Name,Position);
		}

	    /// <summary>
        /// 移除组
        /// </summary>
        /// <param name="Handle"></param>
        /// <returns></returns>
		public bool Remove(int Handle)
		{
			return m_Legend.RemoveGroup(Handle);
		}

		/// <summary>
        /// 数目
        /// </summary>
		public int Count
		{
			get
			{
				return m_Legend.NumGroups;
			}
		}

		/// <summary>
        /// 根据索引获得组
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
		public Group this[int Position]
		{
			get
			{
				if(Position >=0 && Position < this.Count)
					return (Group)m_Legend.m_AllGroups[Position];
				else
				{
					globals.LastError = "Invalid Group Position ( Must be >= 0 and < Count )";
					return null;
				}
			}
		}

		/// <summary>
        /// 清除组
        /// </summary>
		public void Clear()
		{
			m_Legend.ClearGroups();
		}

		
		public Group ItemByPosition(int Position)
		{
			return this[Position];
		}	

		
		public Group ItemByHandle(int Handle)
		{
			if(m_Legend.IsValidGroup(Handle))
				return this[(int)m_Legend.m_GroupPositions[Handle]];
			else
			{
				globals.LastError = "Invalid Group Handle";
				return null;
			}
		}


		
		public int PositionOf(int GroupHandle)
		{
			if(m_Legend.IsValidGroup(GroupHandle))
			{
				return (int)m_Legend.m_GroupPositions[GroupHandle];
			}	
			else
			{
				globals.LastError = "Invalid Group Handle";
				return -1;
			}
		}

		
		public bool IsValidHandle(int Handle)
		{
			return m_Legend.IsValidGroup(Handle);
		}

		
		public bool MoveGroup(int GroupHandle,int NewPos)
		{
			return m_Legend.MoveGroup(GroupHandle,NewPos);
		}

		/// <summary>
		/// Collapses 所有组
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
		/// 展开所有组
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

  
        public Group GroupByLayerHandle(int layerHandle)
        {
            return this.FirstOrDefault(g => g.Layers.Exists(l => l.Handle == layerHandle));
        }

	    public Group GroupByName(string groupName, bool createIfNotExists = false)
        {
            var group = this.FirstOrDefault(g => g.Text.ToLower() == groupName.ToLower());
            if (group == null && createIfNotExists)
            {
                int handle = this.Add(groupName);
                group = this.ItemByHandle(handle);
            }
	        return group;
        }
    }
}
