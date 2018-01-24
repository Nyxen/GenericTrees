using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Interfaces
{
    public interface IBaseBinaryNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        TNode Parent { get; set; }
        TNode LeftChild { get; set; }
        TNode RightChild { get; set; }
        TValue Value { get; set; }
        bool Visited { get; set; }
        bool IsLeafNode { get; }
    }
}
