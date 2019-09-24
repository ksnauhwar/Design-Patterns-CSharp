using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right,Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value,Node<T> left,Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            Left.Parent = Right.Parent = this;
        }
    }
}
