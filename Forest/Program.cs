using System;

namespace DeleteMeForest
{
    public abstract class BaseBinaryNode<TValue, TNode> : IBaseBinaryNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        public virtual TNode Left { get; protected set; }
        public virtual TNode Right { get; protected set; }
        public virtual TNode Parent { get; protected set; }
    }

    public abstract class BaseBinaryTree<TValue, TNode> : IBaseBinaryTree<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        public virtual TNode Root { get; protected set; }
    }

    public static class TreeFactory
    {
        public static BST<TValue, BSTNode<TValue>> CreateBST<TValue>()
            where TValue : IComparable<TValue>
            => new BST<TValue, BSTNode<TValue>>();

        public static AVLTree<TValue, AVLNode<TValue>> CreateAVL<TValue>()
            where TValue : IComparable<TValue>
            => new AVLTree<TValue, AVLNode<TValue>>();

        public static RBTree<TValue, RBNode<TValue>> CreateRBTree<TValue>()
            where TValue : IComparable<TValue>
            => new RBTree<TValue, RBNode<TValue>>();
    }


    public interface IBaseBinaryNode<TValue, in TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {

    }

    public interface IBSTNode<TValue, in TNode> : IBaseBinaryNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {

    }

    public interface IAVLNode<TValue, in TNode> : IBSTNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        int Height { get; }
    }

    public interface IRBNode<TValue, in TNode> : IAVLNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {

    }

    public interface IBaseBinaryTree<TValue, in TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {

    }

    public class BSTNode<TValue> : BaseBinaryNode<TValue, BSTNode<TValue>>, IBSTNode<TValue, BSTNode<TValue>>
        where TValue : IComparable<TValue>
    {

    }

    public class AVLNode<TValue> : BaseBinaryNode<TValue, AVLNode<TValue>>, IAVLNode<TValue, AVLNode<TValue>>
        where TValue : IComparable<TValue>
    {
        public int Height { get; protected set; }
    }

    public class RBNode<TValue> : BaseBinaryNode<TValue, RBNode<TValue>>, IRBNode<TValue, RBNode<TValue>>
        where TValue : IComparable<TValue>
    {
        public enum RBNodeColor { Red, Black };

        public int Height { get; protected set; }
        public RBNodeColor Color { get; set; }
    }

    public class BST<TValue, TNode> : BaseBinaryTree<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBSTNode<TValue, TNode>
    {
        internal BST()
        {

        }
    }

    public class AVLTree<TValue, TNode> : BST<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IAVLNode<TValue, TNode>
    {
        internal AVLTree()
        {

        }
    }

    public class RBTree<TValue, TNode> : AVLTree<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IRBNode<TValue, TNode>
    {
        internal RBTree()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var bst = TreeFactory.CreateBST<int>();
            var avl = TreeFactory.CreateAVL<int>();
            var rbt = TreeFactory.CreateRBTree<int>();



            //var test = new AVLTree<int, AVLNode<int>>();
        }
    }
}