using System;

namespace AvlTrees
{
    public class Avl<T>
        where T : IComparable<T>
    {
        private class Node
        {
            private int size;
            private int height;

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value)
            {
                this.size = 1;
                this.height = 1;
                this.Value = Value;
                this.Left = null;
                this.Right = null;
            }

            private int Balance()
            {
                int leftHeight = (this.Left == null) ? 0 : this.Left.height;
                int rightHeight = (this.Right == null) ? 0 : this.Right.height;
                return leftHeight - rightHeight;
            }

            public void BalanceLeft()
            {

            }

            public void BalanceRight()
            {

            }
        }

        private Node root;

        private void Add(Node node, T value)
        {
            if (node == null)
            {
                node = new Node(value);
                return;
            }
            if (value.CompareTo(node.Value) < 0)
            {
                Add(node.Left, value);
                node.BalanceLeft();
            }
            else
            {
                Add(node.Right, value);
                node.BalanceRight();
            }
        }

        public void Add(T value)
        {
            Add(this.root, value);
        }
    }
}