using System;
using Trees.Interfaces;

namespace Trees
{

    public abstract class BaseBinaryNode<TValue, TNode> : IBaseBinaryNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        public TNode Parent { get;  set; }
        public TNode LeftChild { get; set; }
        public TNode RightChild { get; set; }
        public TValue Value { get; set; }
        public bool Visited { get; set; }
   
        public bool IsLeftChild => Parent.LeftChild.Equals(this);
        public bool IsRightChild => Parent.RightChild.Equals(this);

        public bool HasLeftChild => LeftChild != null;
        public bool HasRightChild => RightChild != null;
        public bool HasLeftChildOnly => HasLeftChild && !HasRightChild;
        public bool HasRightChildOnly => HasRightChild && !HasLeftChild;
        public bool IsLeafNode => !HasLeftChild && !HasRightChild;

    }
}
