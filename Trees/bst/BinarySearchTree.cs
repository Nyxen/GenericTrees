using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; set; }
        int size;

        public BinarySearchTree()
        {
            Root = null;
            size = 0;
        }

        //public string PrintInOrder()
        //{
        //    string text = "";
        //    BinarySearchTreeNode<T> temp = Root;


        //}
        public bool Find(T Value)
        {
            BinarySearchTreeNode<T> temp = Root;
            while(temp != null && !temp.Value.Equals(Value))
            {
                if(Value.CompareTo(temp.Value) < 0)
                {
                    temp = temp.LeftChild;
                }
                else
                {
                    temp = temp.RightChild;
                }
            }
            if (temp != null)
            {
                return temp.Value.CompareTo(Value) == 0;
            }
            else
            {
                return false;
            }
        }
        public T Minimum()
        {
            BinarySearchTreeNode<T> temp = Root;
            while(temp.LeftChild != null)
            {
                temp = temp.LeftChild;
            }
            return temp.Value;

        }
        public T Maximum()
        {
            BinarySearchTreeNode<T> temp = Root;
            while (temp.RightChild != null)
            {
                temp = temp.RightChild;
            }
            return temp.Value;
        }
        public bool Search(T value)
        {
            return FindValue(Root, value);
        }
        bool result = false;
        private bool FindValue(BinarySearchTreeNode<T> currentNode, T value)
        {
            if(value.CompareTo(currentNode.Value) == 0)
            {
                result = true;
                return result;
            }
            if(value.CompareTo(currentNode.Value) < 0 && currentNode.LeftChild != null)
            {
                FindValue(currentNode.LeftChild, value);
            }
            else if(value.CompareTo(currentNode.Value) > 0 && currentNode.RightChild != null)
            {
                FindValue(currentNode.RightChild, value);
            }
            return result;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(value);
                size++;
                return;
            }

            BinarySearchTreeNode<T> temp = Root;
            while (temp.LeftChild != null || temp.RightChild != null)
            {
                //if value is less than roots value
                if (value.CompareTo(temp.Value) < 0)
                {
                    temp = temp.LeftChild;

                }
                else
                {
                    temp = temp.RightChild;
                }
            }
            if (value.CompareTo(temp.Value) < 0)
            {
                temp.LeftChild = new BinarySearchTreeNode<T>(value);
            }
            else
            {
                temp.RightChild = new BinarySearchTreeNode<T>(value);
            }

        }
    }
}
