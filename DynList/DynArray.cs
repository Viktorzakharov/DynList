using System;

namespace List
{
    class DynArray
    {
        public int Count;
        public int Capacity;
        public object[] Array;

        public DynArray()
        {
            Count = 0;
            Capacity = 16;
            Array = new object[Capacity];
        }

        public void MakeArray(bool flag)
        {
            if (flag) Capacity = (Capacity * 3) / 2 + 1;
            else Capacity = ((Capacity - 1) * 2) / 3;

            var newArray = new object[Capacity];

            if (flag) Array.CopyTo(newArray, 0);
            else for (int i = 0; i < newArray.Length; i++)
                    newArray[i] = Array[i];

            Array = newArray;
        }

        public object GetItem(int index)
        {
            try
            {
                return Array[index];
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
            Array[Count] = item;
            Count++;
        }

        public void Insert(int i, object item)
        {
            if (Count == Capacity)
                MakeArray(true);
            for (int j = Count; j > i; j--)
                Array[j] = Array[j - 1];
            Array[i] = item;
            Count++;
        }

        public void Delete(int i)
        {
            var deCapacity = ((Capacity - 1) * 2) / 3;
            for (int j = i; j < Count - 1; j++)
                Array[j] = Array[j + 1];
            Count--;
            Array[Count] = null;
            if (Count == deCapacity && deCapacity >= 16)
                MakeArray(false);
        }
    }
}
