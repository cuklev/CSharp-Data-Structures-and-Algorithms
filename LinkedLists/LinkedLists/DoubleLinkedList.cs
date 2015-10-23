namespace LinkedLists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private class DoubleLinkedListNode
        {
            public T Value { get; set; }

            public DoubleLinkedListNode Next { get; set; }

            public DoubleLinkedListNode Previous { get; set; }
        }

        private DoubleLinkedListNode first;
        private DoubleLinkedListNode last;
        private int count;

        public DoubleLinkedList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public void PushFront(T value)
        {
            var newNode = new DoubleLinkedListNode();
            newNode.Value = value;
            newNode.Previous = null;
            newNode.Next = this.first;

            if (count == 0)
            {
                this.last = newNode;
            }
            else
            {
                this.first.Previous = newNode;
            }
            this.first = newNode;
            ++count;
        }

        public void PopFront()
        {
            if (this.count == 0)
            {
                throw new ArgumentNullException("No items in the list");
            }

            --this.count;
            if (this.first.Next != null)
            {
                this.first.Next.Previous = null;
            }
            this.first = this.first.Next;
        }

        public T First
        {
            get
            {
                return this.first.Value;
            }
        }

        public T Last
        {
            get
            {
                return this.last.Value;
            }
        }
        public void PushBack(T value)
        {
            var newNode = new DoubleLinkedListNode();
            newNode.Value = value;
            newNode.Previous = this.last;
            newNode.Next = null;

            if (this.count == 0)
            {
                this.first = newNode;
            }
            else
            {
                this.last.Next = newNode;
            }

            this.last = newNode;

            ++this.count;
        }

        public void PopBack()
        {
            //var tmp = this.last;
            //if (tmp.prev != null)
            //    tmp.prev.next = tmp.next;
            //tmp.next.prev = tmp.prev;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = this.first;
            Console.WriteLine("spam {0}", enumerator.Value);
            while (enumerator != null)
            {
                yield return enumerator.Value;
                enumerator = enumerator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}