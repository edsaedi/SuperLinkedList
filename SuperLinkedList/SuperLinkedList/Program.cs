﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace SuperLinkedList
{
    /// <summary>
    /// A singular/doubly circular linked list that can use System.Linq.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyLinkedList<T> : ICollection<T>
    {
        internal class MyNode
        {
            public T Value;
            public MyNode Next = null;
            public MyNode Prev = null;

            internal MyNode(T value)
            {
                Value = value;
            }

            internal MyNode(T value, MyNode next, MyNode prev)
            {
                Value = value;
                Next = next;
                Prev = prev;
            }
        }

        public int Count { get; private set; } = 0;

        bool ICollection<T>.IsReadOnly => false;

        private MyNode Head;
        private MyNode Tail => Head.Prev;

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            AddLast(item);
            Head = Tail;
        }

        public void AddLast(T item)
        {
            Count++;
            if (Head == null)
            {
                Head = new MyNode(item);
                return;
            }
            MyNode node = new MyNode(item, Head, Tail);
            Tail.Next = node;
            Head.Prev = node; //shifts and redefines what tail is
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            if (Find(item) == null)
            {
                return false;
            }
            return true;
        }

        private MyNode Find(T item)
        {
            MyNode temp = Head;
            int count = 0;
            while (!temp.Value.Equals(item))
            {
                if (count > Count)
                {
                    return null;
                }
                temp = temp.Next;
            }
            return temp;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < array.Length; i++)
            {
                AddLast(array[i]);
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            MyNode node = Find(item);
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class Parent
    {
        public int X;
    }

    internal class Child : Parent
    {
        public int Y;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MyLinkedList<int> numbers = new MyLinkedList<int>();
        }
    }
}
