using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace Test
{
    [TestClass]
    public class TestInsert
    {
        static DynArray<int> NotOverAndNone = SetArrayValues(new DynArray<int>(), 10);
        static DynArray<int> Over = SetArrayValues(new DynArray<int>(), 16);
        static DynArray<int> OverEnd = SetArrayValues(new DynArray<int>(), 16);

        [TestMethod]
        public void TestInsertNotOver()
        {
            var startCount = NotOverAndNone.count;
            var startCapacity = NotOverAndNone.capacity;
            var itm = 999;
            var index = 5;

            NotOverAndNone.Insert(itm, index);

            Assert.AreEqual(startCount + 1, NotOverAndNone.count);
            Assert.AreEqual(startCapacity, NotOverAndNone.capacity);
            Assert.AreEqual(itm, NotOverAndNone.array[index]);
        }

        [TestMethod]
        public void TestInsertOver()
        {
            var startCount = Over.count;
            var startCapacity = Over.capacity;
            var itm = 999;
            var index = 7;

            Over.Insert(itm, index);

            Assert.AreEqual(startCount + 1, Over.count);
            Assert.AreEqual(startCapacity * 2, Over.capacity);
            Assert.AreEqual(itm, Over.array[index]);
        }

        [TestMethod]
        public void TestInsertOverEnd()
        {
            var startCount = OverEnd.count;
            var startCapacity = OverEnd.capacity;
            var itm = 999;
            var index = startCount;

            OverEnd.Insert(itm, index);

            Assert.AreEqual(startCount + 1, OverEnd.count);
            Assert.AreEqual(startCapacity * 2, OverEnd.capacity);
            Assert.AreEqual(itm, OverEnd.array[index]);
        }

        [TestMethod]
        public void TestInsertNone()
        {
            var res = 0;
            var itm = 999;
            var index = NotOverAndNone.count + 1;
            try { NotOverAndNone.Insert(itm, index); }
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
