using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Base;

namespace Trees
{
    public class BinarySearchTree<TValue> : BaseBinaryTree<TValue, BinarySearchTreeNode<TValue>>
        where TValue : IComparable<TValue>
    {
        int nodeCount;

        public BinarySearchTree()
        {
            Root = null;
            nodeCount = 0;
        }

      

        public BinarySearchTreeNode<TValue> Find(TValue Value)
        {
            BinarySearchTreeNode<TValue> temp = Root;
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
       
        
        #region RecursiveSearch (not ideal)   
        public bool Search(TValue value)
        {
            return FindValue(Root, value);
        }
        bool result = false;
        private bool FindValue(BinarySearchTreeNode<TValue> currentNode, TValue value)
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

        public void Add(TValue value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<TValue>(value);
                nodeCount++;
                return;
            }
            BinarySearchTreeNode<TValue> temp = Root;
            BinarySearchTreeNode<TValue> currentParent = null;
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
            temp = new BinarySearchTreeNode<TValue>(value);
            if (temp.Value.CompareTo(currentParent.Value) < 0)
            {
                currentParent.LeftChild = temp;
            }
            else
            {
                currentParent.RightChild = temp;
            }
            temp.Parent = currentParent;
            nodeCount++;
        }
        public bool Remove(TValue value)
        {
            //Use Find instead to get the node, as it will be O(nlog(n)) operation, instead of O(n) with InOrder traversal
            BinarySearchTreeNode<TValue> nodeToDelete = Find(value);
            

            if(nodeToDelete == null)
            {
                return false;
            }

            BinarySearchTreeNode<TValue> deleteNodeParent = nodeToDelete.Parent;

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
                BinarySearchTreeNode<TValue> temp = nodeToDelete.LeftChild;
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
