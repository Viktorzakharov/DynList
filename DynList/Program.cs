using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var array = SetArrayValues(new DynArray<int>());
            Write(array);
        }

        public static void Write(DynArray<int> array)
        {
            for (int i = 0; i < array.array.Length; i++)
            {
                if (i < array.count) Console.Write("{0} ", array.array[i].ToString());
                else Console.Write("- ");
            }
            Console.WriteLine();
        }

        public static DynArray<int> SetArrayValues(DynArray<int> array)
        {
            var rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                array.array[i] = rnd.Next(255);
                array.count++;
            }
            return array;
        }
    }
}
