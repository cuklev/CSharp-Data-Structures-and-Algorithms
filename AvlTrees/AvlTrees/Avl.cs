using System;
using System.Collections;
using System.Collections.Generic;

namespace AvlTrees
{
    public class Avl<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class Node : IEnumerable<T>
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node()
            {
                Left = null;
                Right = null;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if(this.Left != null)
                {
                    foreach(var node in this.Left)
                    {
                        yield return node;
                    }
                }

                yield return this.Value;

                if(this.Right != null)
                {
                    foreach(var node in this.Right)
                    {
                        yield return node;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private Node root;
        private int size;

        public Avl()
        {
            root = null;
            size = 0;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        private Node Add(Node node, T value)
        {
            if (node == null)
            {
                ++this.size;
                node = new Node();
                node.Value = value;
                return node;
            }

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Add(node.Left, value);
            }
            else if (cmp > 0)
            {
                node.Right = this.Add(node.Right, value);
            }
            else
            {
                // Already exist
            }
            return node;
        }

        public void Add(T value)
        {
            this.root = this.Add(this.root, value);
        }

        private bool Contains(T value)
        {
            Node x = this.root;
            while (x != null)
            {
                int cmp = value.CompareTo(x.Value);
                if (cmp == 0)
                {
                    return true;
                }
                x = (cmp < 0) ? x.Left : x.Right;
            }
            return false;
        }

        private Node Remove(Node node, T value)
        {
            if (node == null)
            {
                // Value not found
                return null;
            }

            int cmp = value.CompareTo(node.Value);
            if (cmp == 0)
            {
                // Found it
                --this.size;

                if (node.Right == null)
                {
                    return node.Left;
                }

                Node next = node.Right;
                if(next.Left == null)
                {
                    next.Left = node.Left;
                    return next;
                }
                while(next.Left.Left != null)
                {
                    next = next.Left;
                }
                var inorder = next.Left;
                next.Left = inorder.Right;
                inorder.Left = node.Left;
                inorder.Right = node.Right;
                return inorder;
            }

            if(cmp < 0)
            {
                node.Left = this.Remove(node.Left, value);
            }
            else
            {
                node.Right = this.Remove(node.Right, value);
            }
            return node;
        }

        public void Remove(T value)
        {
            this.root = this.Remove(this.root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var node in this.root)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}