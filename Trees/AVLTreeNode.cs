
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Interfaces;

namespace Trees
{
    public class AVLTreeNode<TValue> : BaseBinaryNode<TValue, AVLTreeNode<TValue>>, IAVLNode<TValue, AVLTreeNode<TValue>>
        where TValue : IComparable<TValue>
    {
        public int Height { get; set; }
        public int Balance
        {
            get => RightChild.Height - LeftChild.Height;
        }
        

        public AVLTreeNode(TValue Value)
        {
            Height = 1;

        }
    }
}
