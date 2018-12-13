using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace Test
{
    [TestClass]
    public class TestRemove
    {
        static DynArray<int> Compress = SetArrayValues(new DynArray<int>(), 16);


        [TestMethod]
        public void TestRemoveNotCompress()
        {
            Compress.Apeend(999);

            var startCount = Compress.count;
            var startCapacity = Compress.capacity;
            var index = 7;
            var itm = Compress.array[index];

            Compress.Remove(index);

            Assert.AreEqual(startCount - 1, Compress.count);
            Assert.AreEqual(startCapacity, Compress.capacity);
            Assert.AreNotEqual(itm, Compress.array[index]);
        }

        [TestMethod]
        public void TestRemoveCompress()
        {
            var startCount = Compress.count;
            var startCapacity = Compress.capacity;
            var index = 7;
            var itm = Compress.array[index];

            Compress.Remove(index);

            Assert.AreEqual(startCount - 1, Compress.count);
            Assert.AreEqual((int)(startCapacity / 1.5), Compress.capacity);
            Assert.AreNotEqual(itm, Compress.array[index]);
        }

        [TestMethod]
        public void TestRemoveNone()
        {
            var res = 0;
            var index = Compress.count + 1;
            try { Compress.Remove(index); }
            catch (IndexOutOfRangeException) { res = 1; }
            Assert.AreEqual(1, res);
        }

        public static DynArray<int> SetArrayValues(DynArray<int> array, int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                array.array[i] = rnd.Next(255);
                array.count++;
            }
            return array;
        }
    }
}
