using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; protected set; }
        int size;

        public BinarySearchTree()
        {
            Root = null;
            size = 0;
        }

        //need to fix this
        public IEnumerable<BinarySearchTreeNode<T>> InOrder()
        {
            BinarySearchTreeNode<T> temp = Minimum();
            Stack<BinarySearchTreeNode<T>> nodes = new Stack<BinarySearchTreeNode<T>>();

            while (temp != null)
            {
                yield return temp;
                temp.Visited = true;
                if(temp.IsLeafNode && temp.Visited)
                {
                    //should go up
                }

            }
        }

        public BinarySearchTreeNode<T> Find(T Value)
        {
            BinarySearchTreeNode<T> temp = Root;
            while (temp != null && !temp.Value.Equals(Value))
            {
                if (Value.CompareTo(temp.Value) < 0)
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
                return temp;
            }
            else
            {
                return null;
            }
        }
        public BinarySearchTreeNode<T> Minimum()
        {
            BinarySearchTreeNode<T> temp = Root;
            while (temp.LeftChild != null)
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
        
        #region RecursiveSearch (not ideal)   
        public bool Search(T value)
        {
            return FindValue(Root, value);
        }
        bool result = false;
        private bool FindValue(BinarySearchTreeNode<T> currentNode, T value)
        {
            if (value.CompareTo(currentNode.Value) == 0)
            {
                result = true;
                return result;
            }
            if (value.CompareTo(currentNode.Value) < 0 && currentNode.LeftChild != null)
            {
                FindValue(currentNode.LeftChild, value);
            }
            else if (value.CompareTo(currentNode.Value) > 0 && currentNode.RightChild != null)
            {
                FindValue(currentNode.RightChild, value);
            }
            return result;
        }
        #endregion RecursiveSearch (not ideal)

        public void Add(T value)
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
                else if (value.CompareTo(temp.Value) >= 0)
                {
                    currentParent = temp;
                    temp = temp.RightChild;
                }
            }
            temp = new BinarySearchTreeNode<T>(value);
            if (temp.Value.CompareTo(currentParent.Value) < 0)
            {
                currentParent.LeftChild = temp;
            }
            else
            {
                currentParent.RightChild = temp;
            }
            temp.Parent = currentParent;
            size++;
        }
        public bool Remove(T value)
        {
            //Use Find instead to get the node, as it will be O(nlog(n)) operation, instead of O(n) with InOrder traversal
            BinarySearchTreeNode<T> nodeToDelete = Find(value);
            

            if(nodeToDelete == null)
            {
                return false;
            }

            BinarySearchTreeNode<T> deleteNodeParent = nodeToDelete.Parent;

            if (nodeToDelete.IsLeafNode)
            {
                if (nodeToDelete.IsLeftChild)
                {
                    deleteNodeParent.LeftChild = null;
                }
                else
                {
                    deleteNodeParent.RightChild = null;
                }

                return true;
            }

            if (nodeToDelete.HasRightChildOnly)
            {
                if (nodeToDelete.IsRightChild)
                {
                    deleteNodeParent.RightChild = nodeToDelete.RightChild;
                }
                else
                {
                    deleteNodeParent.LeftChild = nodeToDelete.RightChild;
                }
                return true;
            }
            else if (nodeToDelete.HasLeftChildOnly)
            {
                if (nodeToDelete.IsLeftChild)
                {
                    deleteNodeParent.LeftChild = nodeToDelete.LeftChild;
                }
                else
                {
                    deleteNodeParent.RightChild = nodeToDelete.LeftChild;
                }
                return true;
            }
            //if both left and right child are not null
            else
            {
                BinarySearchTreeNode<T> temp = nodeToDelete.LeftChild;
                while (temp.RightChild != null)
                {
                    temp = temp.RightChild;
                }
                nodeToDelete.Value = temp.Value;
                if (temp.IsLeftChild)
                {
                    temp.Parent.LeftChild = null;
                }
                else
                {
                    temp.Parent.RightChild = null;
                }
            }


            return true;
        }
    }
}
