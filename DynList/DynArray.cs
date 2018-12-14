using System;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            var newArray = new T[new_capacity];
            if (array != null) Array.Copy(array, newArray, count);
            array = newArray;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index > count - 1) throw new IndexOutOfRangeException();
            return array[index];
        }

        public void Apeend(T itm)
        {
            if (count == capacity) MakeArray(capacity * 2);
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count) throw new IndexOutOfRangeException();
            if (count == capacity) MakeArray(capacity * 2);
            for (int i = count; i > index; i--)
                array[i] = array[i - 1];
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > count - 1) throw new IndexOutOfRangeException();
            for (int i = index; i < count - 1; i++)
                array[i] = array[i + 1];
            count--;
            array[count] = default(T);

            if (count < (double)capacity / 2)
            {
                if ((int)(capacity / 1.5) < 16 && capacity > 16) MakeArray(16);
                else if (capacity != 16) MakeArray((int)(capacity / 1.5));
            }
        }
    }
}
