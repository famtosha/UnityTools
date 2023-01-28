using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityTools.Collections
{
    [Serializable]
    public class SimpleObservableList<T> : IEnumerable<T>
    {
        public event Action Changed;

        private readonly List<T> _originalList;

        public int Count => _originalList.Count;

        public T this[int index]
        {
            get
            {
                return _originalList[index];
            }
            set
            {
                _originalList[index] = value;
                Changed?.Invoke();
            }
        }

        public SimpleObservableList()
        {
            _originalList = new List<T>();
        }

        public SimpleObservableList(IEnumerable<T> collection)
        {
            _originalList = new List<T>(collection);
        }

        public void Add(T element)
        {
            _originalList.Add(element);
            Changed?.Invoke();
        }

        public void Remove(T element)
        {
            _originalList.Remove(element);
            Changed?.Invoke();
        }

        public void Insert(int index, T element)
        {
            _originalList.Insert(index, element);
            Changed?.Invoke();
        }

        public int IndexOf(T element)
        {
            return _originalList.IndexOf(element);
        }

        public void RemoveAt(int index)
        {
            _originalList.RemoveAt(index);
            Changed?.Invoke();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_originalList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_originalList).GetEnumerator();
        }
    }
}