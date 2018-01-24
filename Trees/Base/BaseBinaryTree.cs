using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Interfaces;

namespace Trees.Base
{
    public class BaseBinaryTree<TValue, TNode> :IBaseBinaryTree<TValue, TNode>
        where TValue: IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
        public TNode Root { get; internal set; }
        public TNode Minimum()
        {
            TNode temp = Root;
            while (temp.LeftChild != null)
            {
                temp = temp.LeftChild;
            }
            return temp;

        }
        public TNode Maximum()
        {
            TNode temp = Root;
            while (temp.RightChild != null)
            {
                temp = temp.RightChild;
            }
            return temp;
        }
        //need to fix this
        public IEnumerable<TNode> InOrder()
        {
            TNode temp = Minimum();
            Stack<TNode> nodes = new Stack<TNode>();

            while (temp != null)
            {
                yield return temp;
                temp.Visited = true;
                if (temp.IsLeafNode && temp.Visited)
                {
                    //should go up
                }

            }
        }
    }
}
