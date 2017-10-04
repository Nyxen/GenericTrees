using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    public class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode<T> LeftChild { get; set; }
        public BinarySearchTreeNode<T> RightChild { get; set; }
        public T Value { get; set; }

        public BinarySearchTreeNode(T value)
        {
            LeftChild = null;
            RightChild = null;
            Value = value;
        }
    }
}
