using System;
using System.Linq;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Console.WriteLine("----------------------------------");
            Test3();
            Console.WriteLine("-------------------------");
            Test4();
            Console.WriteLine("-------------------------");
            Test5();

        }

        private static void Test5()
        {
            var root = new Node<int>(1);
            
            root.Left = new Node<int>(2, new Node<int>(4, new Node<int>(10), new Node<int>(11)), new Node<int>(5, new Node<int>(6), new Node<int>(7)));
            root.Left.Parent = root;

            root.Right = new Node<int>(3, new Node<int>(8), new Node<int>(9));
            root.Right.Parent = root;

            var bTree = new BinaryTree<int>(root);
            foreach (var node in bTree)
            {
                Console.WriteLine(node.Value);
            }
        }

        private static void Test4()
        {
            var root = new Node<int>(1);
            var bTree = new BinaryTree<int>(root);
            root.Left = new Node<int>(2, new Node<int>(4, new Node<int>(10), new Node<int>(11)), new Node<int>(5, new Node<int>(6), new Node<int>(7)));
            root.Left.Parent = root;

            root.Right = new Node<int>(3, new Node<int>(8), new Node<int>(9));
            root.Right.Parent = root;
            Console.WriteLine(string.Join(",",bTree.InOrder.Select(node => node.Value)));
        }

        private static void Test1()
        {
            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var inOrder = new InOrderTraversal<int>(root);
            while (inOrder.MoveNext())
            {
                Console.WriteLine(inOrder.Current.Value);
            }
        }

        private static void Test3()
        {
            var root = new Node<int>(1);
            var bTree = new BinaryTree<int>(root);
            root.Left = new Node<int>(2, new Node<int>(4, new Node<int>(10), new Node<int>(11)), new Node<int>(5, new Node<int>(6), new Node<int>(7)));
            root.Left.Parent = root;

            root.Right = new Node<int>(3, new Node<int>(8), new Node<int>(9));
            root.Right.Parent = root;

            var traversal = new InOrderTraversal<int>(bTree.Root);

            while (traversal.MoveNext())
            {
                Console.WriteLine(traversal.Current.Value);
            }
        }
    }
}
