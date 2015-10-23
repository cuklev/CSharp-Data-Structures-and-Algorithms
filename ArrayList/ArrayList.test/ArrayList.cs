namespace ArrayList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ArrayList<T>: IEnumerable<T>
    {
        public int Size { get; private set; }
        public int AllocatedSize { get; private set; }
        private T[] Items { get; set; }

        public ArrayList()
        {
            this.Size = 0;
            this.AllocatedSize = 0;
            this.Items = null;
        }

        public void Add(T value)
        {
            if (this.Size == this.AllocatedSize)
            {
                if (this.AllocatedSize > 0)
                {
                    this.AllocatedSize *= 2;
                }
                else
                {
                    this.AllocatedSize = 4;
                }

                T[] newItems = new T[this.AllocatedSize];

                Array.Copy(this.Items, newItems, this.Size);

                this.Items = newItems;
            }
            this.Items[this.Size] = value;
            
            ++this.Size;
        }

        public void PopBack()
        {
            if (this.Size == 0)
            {
                throw new System.IndexOutOfRangeException("Empty vector");
            }
            --this.Size;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return this.Items[index];
            }
            set
            {
                this.Items[index] = value;
            }
        }
    }
}