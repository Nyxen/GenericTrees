using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Interfaces
{
    public interface IAVLNode<TValue, TNode>
        where TValue : IComparable<TValue>
        where TNode : IBaseBinaryNode<TValue, TNode>
    {
    }
}
