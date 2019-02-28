using System;
using System.Collections;
using System.Collections.Generic;

namespace SuperLinkedList
{
    /// <summary>
    /// A singular/doubly circular linked list that can use System.Linq.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MyLinkedList<T> : ICollection<T>
    {
        internal class MyNode
        {
            public T Value;
            public T Next;
        }
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public T Head;
        public T Tail;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
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

    internal class Program
    {
        private static void Main(string[] args)
        {



        }
    }
}
