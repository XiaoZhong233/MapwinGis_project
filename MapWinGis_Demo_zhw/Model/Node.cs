using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw
{
    public enum NodeType
    {
        group,
        layer
    }

    /// <summary>
    /// 节点类 用于保存节点信息
    /// </summary>
    public class Node
    {
        //图层树中图层或者组的句柄
        private int legendHandle;
        
        public int LegendHandle
        {
            get { return legendHandle; }
            set { legendHandle = value; }
        }

        //如果当前节点类型是图层，则会记录parentGroupHadnle
        private int parentGroupHandle = -1;

        public int ParentGroupHandle
        {
            get { return parentGroupHandle; }
            set {
                if(nodeType==NodeType.layer)
                    parentGroupHandle = value;
            }
        }



        private NodeType nodeType;

        public NodeType NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }

        private int layerHandle;

        public int LayerHandle
        {
            get { return layerHandle; }
            set { layerHandle = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        //组节点构造函数
        public Node(int legendGroupHandle,int layerHandle,string path)
        {
            this.legendHandle = legendGroupHandle;
            this.nodeType = NodeType.group;
            this.layerHandle = layerHandle;
            this.path = path;
        }

        //图层节点构造函数
        public Node(int legendLayerHandle,int parentGroupHandle,int layerHandle, string path)
        {
            this.legendHandle = legendLayerHandle;
            this.parentGroupHandle = parentGroupHandle;
            this.nodeType = NodeType.layer;
            this.layerHandle = layerHandle;
            this.path = path;
        }



    }
}
