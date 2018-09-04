using System;

namespace List
{
    class Test
    {
        public static void Insert(DynArray array, int i, object item)
        {
            var count = array.Count;
            var valueI = array.Array[i];

            Write(array);
            array.Insert(i, item);
            Write(array);

            if (array.Count == count + 1 && array.Array[i] == item && array.Array[i + 1] == valueI)
                Console.WriteLine("Добавление прошлео верно!\n");
            else Console.WriteLine("Добавление прошло НЕВЕРНО!\n");
        }

        public static void Delete(DynArray array, int i)
        {
            var count = array.Count;
            var valueNextI = array.Array[i + 1];

            Write(array);
            array.Delete(i);
            Write(array);

            if (array.Count == count - 1 && array.Array[i] == valueNextI)
                Console.WriteLine("Удаление прошлео верно!\n");
            else Console.WriteLine("Удаление прошло НЕВЕРНО!\n");
        }

        public static void Append(DynArray array, object item)
        {
            Write(array);
            array.Apeend(item);
            Write(array);
            Console.WriteLine("Добавление элемента в конец списка.\n");
        }

        public static void GetItem(DynArray array, int i)
        {
            Write(array);
            Console.WriteLine("Элемент индекса i = {0}\n", array.GetItem(i));
        }

        public static void Write(DynArray array)
        {
            foreach (var e in array.Array)
            {
                if (e != null) Console.Write(e + " ");
                else Console.Write("- ");
            }
            Console.WriteLine();
        }
    }
}

