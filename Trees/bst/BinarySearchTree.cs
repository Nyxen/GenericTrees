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

        public IEnumerable<T> InOrder()
        {
            BinarySearchTreeNode<T> temp = Minimum();
            Stack<BinarySearchTreeNode<T>> nodes = new Stack<BinarySearchTreeNode<T>>(); 
            while(temp != null)
            {
                if (temp.Visited == false)
                {
                    yield return temp.Value;
                    temp.Visited = true;
                    nodes.Push(temp);
                }
                
                if (temp.LeftChild != null && temp.LeftChild.Visited == false)
                {
                    temp = temp.LeftChild;
                }
                if (temp.RightChild != null && temp.RightChild.Visited == false)
                {
                    temp = temp.RightChild; 
                }
                else
                {
                    temp = temp.Parent;
                }
            }
            while(nodes.Count > 0)
            {
                nodes.Pop().Visited = false;
            }
        }
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
        public BinarySearchTreeNode<T> Minimum()
        {
            BinarySearchTreeNode<T> temp = Root;
            while(temp.LeftChild != null)
            {
                temp = temp.LeftChild;
            }
            return temp;

        }
        public BinarySearchTreeNode<T> Maximum()
        {
            BinarySearchTreeNode<T> temp = Root;
            while (temp.RightChild != null)
            {
                temp = temp.RightChild;
            }
            return temp;
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
            BinarySearchTreeNode<T> currentParent = null;
            while (temp != null)
            {
                if (value.CompareTo(temp.Value) < 0)
                {
                    currentParent = temp;
                    temp = temp.LeftChild;
                }
                else if (value.CompareTo(temp.Value) > 0)
                {
                    currentParent = temp;
                    temp = temp.RightChild;
                }
            }
            temp = new BinarySearchTreeNode<T>(value);
            if(temp.Value.CompareTo(currentParent.Value) < 0)
            {
                currentParent.LeftChild = temp;
            }
            else
            {
                currentParent.RightChild = temp;
            }
            temp.Parent = currentParent;
        }
        public void Remove(T value)
        {

        }
    }
}
