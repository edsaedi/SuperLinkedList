using System.Collections;
using System.Collections.Generic;

namespace SuperLinkedList
{
    public class MyNode<T>
    {
        public T Value;
        public MyNode<T> Next = null;
        public MyNode<T> Prev = null;

        internal MyNode(T value)
        {
            Value = value;
        }

        internal MyNode(T value, MyNode<T> next, MyNode<T> prev)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }

    /// <summary>
    /// A doubly circular linked list that can use System.Linq.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyLinkedList<T> : ICollection<T>, IEnumerable<MyNode<T>>
    {
        

        public T this[int index]
        {
            get
            {
                MyNode<T> curr = Head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }
                return curr.Value;
            }
            set
            {
                MyNode<T> curr = Head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }
                curr.Value = value;
            }
        }
        
        public int Count { get; private set; } = 0;

        bool ICollection<T>.IsReadOnly => false;

        public MyNode<T> Head { get; private set; }
        private MyNode<T> Tail => Head.Prev;

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
            if (Head == null)
            {
                Head = new MyNode<T>(item);
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                MyNode<T> node = new MyNode<T>(item, Head, Tail);
                Tail.Next = node;
                Head.Prev = node; //shifts and redefines what tail is
            }
            Count++;
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

        private MyNode<T> Find(T item)
        {
            MyNode<T> temp = Head;
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
            MyNode<T> node = Find(item);
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            return true;
        }

        public IEnumerator<MyNode<T>> GetEnumerator()
        {
            MyNode<T> currentNode = Head;
            for (int i = 0; i < Count; currentNode = currentNode.Next, i++)
            {
                yield return currentNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator().Current.Value;
        }        
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MyLinkedList<int> numbers = new MyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.AddFirst(i + 1);
            }
        }
    }
}
