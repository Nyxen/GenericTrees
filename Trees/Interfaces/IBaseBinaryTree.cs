using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Interfaces
{
    public interface IBaseBinaryTree<TValue, in TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {

    }
}
