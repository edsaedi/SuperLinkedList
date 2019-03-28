using System;
using System.Linq;

namespace SuperLinkedList
{
    public enum AddType
    {
        AddLast,
        AddFirst
    }

    public static class SetupLinkList
    {
        private static Random rand = new Random(26);

        private static MyLinkedList<int> AddFunction(int[] nums, AddType addType)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();

            switch (addType)
            {
                case AddType.AddLast:
                    for (int i = 0; i < nums.Length; i++)
                    {
                        list.AddLast(nums[i]);
                    }
                    break;
                case AddType.AddFirst:
                    for (int i = 0; i < nums.Length; i++)
                    {
                        list.AddFirst(nums[i]);
                    }
                    break;
                default:
                    throw new Exception("Invalid add type");
            }

            return list;
        }

        public static MyLinkedList<int> ListGenerator(int[] array, AddType addType)
        {
            return AddFunction(array, addType);
        }

        public static int[] UniqueRandomization(int size)
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
    }
}
