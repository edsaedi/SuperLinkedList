using SuperLinkedList;
using System;
using System.Linq;
using Xunit;

namespace SuperLinkedListTest
{
    public class UnitTest1
    {

        private Random rand = new Random(26);
        public delegate MyLinkedList<int> Creation(int[] array, Action<int> addFunction);

        public MyLinkedList<int> ListGenerator(int[] array)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();

            for (int i = 0; i < array.Length; i++)
            {
                list.AddLast(array[i]);
            }

            return list;
        }

        public int[] UniqueRandomization(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                int val;
                do
                {
                    val = rand.Next(0, size * 2);
                } while (array.Contains(val));

                array[i] = val;
            }

            return array;
        }

        public void CheckNode(int[] array, MyLinkedList<int> list)
        {
            int index = 0;
            int next;
            int prev;
            foreach (MyNode<int> item in list)
            {
                Assert.True(array[index] == item.Value);
                next = index + 1;
                prev = index - 1;
                if (next >= list.Count)
                {
                    next = 0;
                }
                if (prev < 0)
                {
                    prev = list.Count - 1;
                }
                Assert.True(array[next] == item.Next.Value);
                Assert.True(array[prev] == item.Prev.Value);
                index++;
            }
        }

        public void CheckNodeFirst(int[] array, MyLinkedList<int> list)
        {
            int index = list.Count - 1;
            int next;
            int prev;
            foreach (MyNode<int> item in list)
            {
                Assert.True(array[index] == item.Value);
                next = index - 1;
                prev = index + 1;
                if (next < 0)
                {
                    next = list.Count - 1;
                }
                if (prev >= list.Count)
                {
                    prev = 0;
                }
                Assert.True(array[next] == item.Next.Value);
                Assert.True(array[prev] == item.Prev.Value);
                index--;
            }
        }

        public void CheckList(int[] array, MyLinkedList<int> list, int count)
        {
            CheckNode(array, list);
            Assert.True(list.Count == count);
        }

        public void CheckListFirst(int[] array, MyLinkedList<int> list, int count)
        {
            CheckNodeFirst(array, list);
            Assert.True(list.Count == count);
        }

        [Fact]
        public void AddFirst()
        {
            int size = 100;
            int[] array = SetupLinkList.UniqueRandomization(size);
            //TODO:
            //    |
            //    | 
            //   \|/
            MyLinkedList<int> list = SetupLinkList.ListGenerator(array, AddType.AddFirst);
            CheckListFirst(array, list, size);
        }

        [Fact]
        public void AddLast()
        {
            int size = 100;
            int[] array = SetupLinkList.UniqueRandomization(size);
            MyLinkedList<int> list = SetupLinkList.ListGenerator(array, AddType.AddLast);
            CheckList(array, list, size);
        }

        [Fact]
        public void Remove()
        {
            int size = 100;
            int[] array = SetupLinkList.UniqueRandomization(size);
            MyLinkedList<int> list = SetupLinkList.ListGenerator(array, AddType.AddLast);
            Assert.True(list.Remove(array[0]));
            Assert.False(list.Contains(array[0]));
            Assert.True(list.Remove(array[49]));
            Assert.False(list.Contains(array[49]));
            Assert.True(list.Remove(array[99]));
            Assert.False(list.Contains(array[99]));
        }

    }
}