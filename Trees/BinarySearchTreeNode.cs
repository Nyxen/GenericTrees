using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Interfaces;

namespace Trees
{
    public class BinarySearchTreeNode<TValue> : BaseBinaryNode<TValue, BinarySearchTreeNode<TValue>> , IBSTNode<TValue,BinarySearchTreeNode<TValue>>
       where TValue : IComparable<TValue>
    {
        public BinarySearchTreeNode(TValue value)
        {
            Visited = false;
        }
    }
}
