using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    /// <summary>
    /// 
    /// </summary>
   public class SerializeDeserialize
    {
        // Encodes a tree to a single string.
        /// <summary>
        /// "[1,2,3,null,null,4,5]"
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string serialize(TNode root)
        {
            return Serializehelper(root, string.Empty);
        }

        private string Serializehelper(TNode root, string strSerialize)
        {
            if(root==null)
            {
                strSerialize += "null,";                
            }
            else
            {
                strSerialize += root.value + ",";
                strSerialize = Serializehelper(root.left, strSerialize);
                strSerialize = Serializehelper(root.right, strSerialize);
            }            

            return strSerialize;
        }

        // Decodes your encoded data to tree.
        public TNode deserialize(string data)
        {
            string[] nodes = data.Split(',');
            IList<string> lstNodes = new List<string>(nodes);

            return DeserializeHelper(lstNodes);
        }

        private TNode DeserializeHelper(IList<string> lstNodes)
        {
            if(lstNodes[0]=="null")
            {
                lstNodes.RemoveAt(0);
                return null;
            }

            TNode deserNode = new TNode(Convert.ToInt32(lstNodes[0]));
            lstNodes.RemoveAt(0);

            deserNode.left = DeserializeHelper(lstNodes);
            deserNode.right = DeserializeHelper(lstNodes);

            return deserNode;
        }

        ///https://www.youtube.com/watch?v=ubKTA5WAaXM
    }
}
