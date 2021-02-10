using System;
using System.Collections;
using System.Collections.Generic;
using _090221Task.Exception;

namespace _090221Task.DataStructures
{
    public sealed class CustomList<T>:IEnumerable
    {
        public T[] Data { get; private set; }

        public void Add(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Object is null!");

            var newLength = (Data != null) ? Data.Length + 1 : 1;

            var tmp = new T[newLength];

            if (tmp.Length != 0)
            {
                if (Data != null)
                    Array.Copy(Data, tmp, Data.Length);

                tmp[newLength - 1] = obj;
            }

            Data = tmp;
        }

        public void Delete(int index)
        {
            if (Data == null)
                throw new ListEmptyException("List is empty");

            var newLength = Data.Length - 1;
            var tmp = new T[newLength];

            if (tmp.Length != 0)
            {
                Array.Copy(Data, tmp, index);
                Array.Copy(Data, index + 1, tmp, index, Data.Length - index - 1);
            }
            else
            {
                tmp = null;
            }

            Data = tmp;
        }

        public void Clear() => Data = null;

        public int Length => Data.Length;

        public T this[int index] => Data[index];

        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public bool Empty => Length == 0;
    }
}
