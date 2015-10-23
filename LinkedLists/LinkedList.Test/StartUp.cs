using System;

using LinkedLists;

namespace LinkedList.Test
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = new DoubleLinkedList<int>();

            for (int i = 0; i < 15; i++)
            {
                numbers.PushFront(i + 1);
            }
            var index = numbers.GetEnumerator();
            while (index.MoveNext())
            {
                Console.WriteLine(index.Current);
            }
        }
    }
}