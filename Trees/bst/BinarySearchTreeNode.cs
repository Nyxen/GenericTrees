using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
   

    public class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode<T> Parent { get; set; }
        public BinarySearchTreeNode<T> LeftChild { get; set; }
        public BinarySearchTreeNode<T> RightChild { get; set; }
      
        internal bool Visited { get; set; }
        public T Value { get; set; }
        public bool IsLeftChild => Parent?.LeftChild == this;
        public bool IsRightChild => Parent?.RightChild == this;

        public bool HasLeftChild => LeftChild != null;
        public bool HasRightChild => RightChild != null;
        public bool HasLeftChildOnly => HasLeftChild && !HasRightChild;
        public bool HasRightChildOnly => HasRightChild && !HasLeftChild;
        public bool IsLeafNode => !HasLeftChild && !HasRightChild;

        public BinarySearchTreeNode(T value)
        {
            Parent = null;
            LeftChild = null;
            RightChild = null;
            Value = value;
        }
    }
}
