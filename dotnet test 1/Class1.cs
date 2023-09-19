using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Yield
{
    public class _SortedList<T> : ICollection<T>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

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

        public IEnumerator<T> GetEnumerator()
        {
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class _Enumenator : IEnumerator<T>
        {

            private IList<T> _list;
            private T _current;
            public T Current => _current;
            object IEnumerator.Current => _current;

            private int _index;

            public _Enumenator(IList<T> list)
            {
                _index = 0;
                _list = list;

                if (_list.Any())
                {
                    _current = list[_index];
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (_index >= _list.Count - 1)
                {
                    return false;
                }
                _index++;
                _current = _list[_index];
                return _index < _list.Count - 1;
            }

            public void Reset()
            {
                _index = 0;
                _current = _list[0];
            }
        }
    }
}