using System;

namespace List
{
    class Program
    {
        static void Main()
        {
            var array = SetArrayValues(new DynArray());

            Test.Append(array, 999);
            Test.Insert(array, 5, 777);
            Test.GetItem(array, 30);
            Test.Delete(array, 5);
        }

        public static DynArray SetArrayValues(DynArray array)
        {
            var rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                array.Array[i] = rnd.Next(255);
                array.Count++;
            }
            return array;
        }
    }
}
