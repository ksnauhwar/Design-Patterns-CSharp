using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    public class BinaryTree<T>
    {
        public Node<T> Root;

        public BinaryTree(Node<T> root)
        {
            Root = root;
            root.Parent = null;
        }

        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    if (current.Left != null)
                    {
                        foreach (var left in Traverse(current.Left))
                        {
                            yield return left;
                        }
                    }
                    yield return current;
                    if (current.Right != null)
                    {
                        foreach (var right in Traverse(current.Right))
                        {
                            yield return right;
                        }
                    }
                }

                foreach (var node in Traverse(Root))
                    yield return node;

            }

        }

        public InOrderTraversal<T> GetEnumerator()
        {
            return new InOrderTraversal<T>(Root);
        }
    }
}
