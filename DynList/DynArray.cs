using System;

namespace List
{
    class DynArray
    {
        public int Count;
        public int Capacity;
        public object[] array;

        public DynArray()
        {
            Count = 0;
            Capacity = 16;
            array = new object[Capacity];
        }

        public void MakeArray(bool flag)
        {
            if (flag) Capacity = (Capacity * 3) / 2 + 1;
            else Capacity = ((Capacity - 1) * 2) / 3;

            var newArray = new object[Capacity];
            Array.Copy(array, newArray, Count);
            array = newArray;
        }

        public object GetItem(int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекс вышел за границы массива!");
                return null;
            }
        }

        public void Apeend(object item)
        {
            if (Count == Capacity)
                MakeArray(true);
            array[Count] = item;
            Count++;
        }

        public void Insert(int i, object item)
        {
            if (Count == Capacity)
                MakeArray(true);
            for (int j = Count; j > i; j--)
                array[j] = array[j - 1];
            array[i] = item;
            Count++;
        }

        public void Delete(int i)
        {
            var deCapacity = ((Capacity - 1) * 2) / 3;
            for (int j = i; j < Count - 1; j++)
                array[j] = array[j + 1];
            Count--;
            array[Count] = null;
            if (Count == deCapacity && deCapacity >= 16)
                MakeArray(false);
        }
    }
}
