using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public class BinaryTree<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
        }

        public Node Root { get; set; }
        private Random random = new Random();

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node { Value = value };
                return;
            }

            Node node = Root;

            while (true)
            {
                if (node.Left == null)
                {
                    node.Left = new Node { Value = value, Parent = node };
                    return;
                }
                else if (node.Right == null)
                {
                    node.Right = new Node { Value = value, Parent = node };
                    return;
                }
                else
                {
                    if (random.Next(2) == 0)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }

        public void Delete(T value)
        {
            Node nodeToDelete = Find(value);

            if (nodeToDelete == null)
            {
                return;
            }

            if (nodeToDelete == Root && nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                Root = null;
                return;
            }

            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                if (nodeToDelete == nodeToDelete.Parent.Left)
                {
                    nodeToDelete.Parent.Left = null;
                }
                else
                {
                    nodeToDelete.Parent.Right = null;
                }
            }
            else if (nodeToDelete.Left != null && nodeToDelete.Right != null)
            {
                Node successor = GetSuccessor(nodeToDelete);
                nodeToDelete.Value = successor.Value;
                Delete(successor.Value);
            }
            else
            {
                Node child = (nodeToDelete.Left != null) ? nodeToDelete.Left : nodeToDelete.Right;

                if (nodeToDelete == nodeToDelete.Parent.Left)
                {
                    nodeToDelete.Parent.Left = child;
                }
                else
                {
                    nodeToDelete.Parent.Right = child;
                }

                child.Parent = nodeToDelete.Parent;
            }
        }

        public Node Find(T value)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return node;
                }
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return null;
        }

        private Node GetSuccessor(Node node)
        {
            if (node.Right == null)
            {
                return null;
            }

            var current = node.Right;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }
    }

    public static class BinaryTreeExtensions
    {
        public static IEnumerable<T> GetReverseEnumerator<T>(this BinaryTree<T> tree)
        {
            Stack<BinaryTree<T>.Node> stack = new Stack<BinaryTree<T>.Node>();
            BinaryTree<T>.Node node = tree.Root;
            while (node != null || stack.Count > 0)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Left;
                }
                else
                {
                    stack.Push(node);
                    node = node.Right;
                }
            }
        }

        private static IEnumerable<T> InOrder<T>(BinaryTree<T>.Node node)
        {
            if (node == null) yield break;

            foreach (T value in InOrder(node.Left))
                yield return value;

            yield return node.Value;

            foreach (T value in InOrder(node.Right))
                yield return value;
        }
        public static IEnumerable<T> GetEnumerator<T>(this BinaryTree<T> tree)
        {
            return InOrder(tree.Root);

        }

        public static T Find<T>(IEnumerable<T> iterator, Func<T, bool> predicate)
        {
            foreach (T item in iterator)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }
        public static void ForEach<T>(IEnumerable<T> iterator, Action<T> function)
        {
            foreach (T item in iterator)
            {
                function(item);
            }
        }

        public static int CountIf<T>(IEnumerable<T> iterator, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (T item in iterator)
            {
                if (predicate(item))
                {
                    count++;
                }
            }
            return count;
        }

        public static void Print<T>(IEnumerable<T> iterator, Func<T, bool> predicate)
        {
            foreach (T item in iterator)
            {
                if (predicate(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

