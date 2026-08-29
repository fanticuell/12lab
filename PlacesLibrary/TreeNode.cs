using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesLibrary
{
    public class TreeNode
    {
        public Place Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(Place data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
