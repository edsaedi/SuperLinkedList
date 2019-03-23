using SuperLinkedList;
using System;
using System.Linq;
using Xunit;

namespace SuperLinkedListTest
{
    public class UnitTest1
    {

        private Random rand = new Random(26);

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
                    array[i] = val;
                } while (array.Contains(val));
            }

            return array;
        }

        public bool CheckNode(int[] array, MyLinkedList<int> list)
        {
            int index = 0;
            foreach (int item in list)
            {
                if (array[index] != item)
                {
                    return false;
                }
                else if (array[index + 1] == item)
                {
                    if (index + 1 >= list.Count)
                    {

                    }
                }

                index++;
            }

            return true;
        }

        public void CheckList(int[] array, MyLinkedList<int> list, int count)
        {
            CheckNode(array, list);
            Assert.True(list.Count == count);
        }

        [Fact]
        public void Add()
        {
            int size = 100;
            int[] array = UniqueRandomization(size);
            MyLinkedList<int> list = ListGenerator(array);
            for (int i = 0; i < size; i++)
            {

            }
        }
    }
}