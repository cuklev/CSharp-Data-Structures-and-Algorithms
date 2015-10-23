namespace ArrayList.Test
{
    using System;
    using ArrayList;

    class StartUp
    {
        static void Main(string[] args)
        {
            var vector = new ArrayList<int>();
            for (int i = 0; i < 10; ++i)
            {
                vector.Add(i);
            }
        }
    }
}