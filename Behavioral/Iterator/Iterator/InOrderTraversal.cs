using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    public class InOrderTraversal<T>
    {
        public Node<T> Current { get; set; }
        public readonly Node<T> Root;
        private bool isYieldedStart;

        public InOrderTraversal(Node<T> root)
        {
            Current = root;
            Root = root;
            while (Current.Left != null)
                Current = Current.Left;
        }

        public bool MoveNext()
        {
            if (isYieldedStart == false)
            {
                isYieldedStart = true;
                return true;
            }
            if (Current.Right != null)
            {
                Current = Current.Right;
                while (Current.Left != null)
                    Current = Current.Left;

                return true;
            }
            else
            {
                var parent = Current.Parent;
                while (parent != null && parent.Right == Current)
                {
                    Current = parent;
                    parent = Current.Parent;
                }

                Current = parent;
                return Current != null;
            }
        }
  }
}
