using System;
using System.Collections.Generic;

namespace AvlTrees.Test
{
    public class Baba : IComparable<Baba>
    {
        public int age;
        public String name;

        public Baba(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Baba other)
        {
            if(this.age < other.age)
        	{
        	    return 1;
        	}
        	if(this.age > other.age)
        	{
        	    return -1;
        	}
        	return 0;
        }
        public override int GetHashCode()
        {
            return 72 - this.age;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            var set = new Avl<int>();

            var numbers = new int[] { 64, 12, 10, 0, 4, 7, 11 };
            
            foreach(var x in numbers)
            {
                set.Add(x);
            }

            Console.WriteLine("Size is {0}", set.Size);
            foreach(var x in set)
            {
                Console.WriteLine(x);
            }

            set.Remove(12);
            set.Remove(8);

            Console.WriteLine("Size is {0}", set.Size);
            foreach(var x in set)
            {
                Console.WriteLine(x);
            }
        }
    }
}