using System;

public class BaseNode<T>
{
    internal BaseNode<T> Parent { get; set; }
    BaseNode<T> LeftChild { get; set; }
    BaseNode<T> RightChild { get; set; }
    public T Value { get; set; }
    public bool IsLeftChild => Parent?.LeftChild == this;
    public bool IsRightChild => Parent?.RightChild == this;

    public bool HasLeftChild => LeftChild != null;
    public bool HasRightChild => RightChild != null;
    public bool HasLeftChildOnly => HasLeftChild && !HasRightChild;
    public bool HasRightChildOnly => HasRightChild && !HasLeftChild;
    public bool IsLeafNode => !HasLeftChild && !HasRightChild;

    public BaseNode()
	{
        Parent = null;
        LeftChild = null;
        RightChild = null;
        Value = value;
    }
}
