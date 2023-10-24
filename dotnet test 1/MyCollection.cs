using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyCollection
{
    public class _SortedList<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
    {
        public KeyValuePair<TKey, TValue>[] _items;
        public TKey[] keys;
        public TValue[] values;
        public int size;
        private int _capacity;

        public event EventHandler AddElement;
        public event EventHandler RemoveElement;
        public event EventHandler ClearArray;

        public int Count => size;

        public bool IsReadOnly => false;

        public _SortedList(int? capacity)
        {
            if (capacity == null)
            {
                throw new ArgumentNullException(nameof(capacity));
            }
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            size = 0;
            _capacity = (int)capacity;
            if (capacity == 0)
            {
                _items = Array.Empty<KeyValuePair<TKey, TValue>>();
            }
            else
            {
                _items = new KeyValuePair<TKey, TValue>[(int)capacity];
                values = new TValue[(int)capacity];
                keys = new TKey[(int)capacity];
            }
        }

        public KeyValuePair<TKey, TValue> this[int index]
        {
            get => _items[index];
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (_capacity <= size)
            {
                ExpandCapacity();
            }
            int num = 0;
            if (size == 0)
            {
                size++;
                values[0] = item.Value;
                keys[0] = item.Key;
                _items[0] = item;
                AddElement?.Invoke(this, EventArgs.Empty);
                return;
            }
            num = Search(item.Key);
            if (num < 0)
            {
                return;
            }
            var TempArray = new KeyValuePair<TKey, TValue>[size + 1];
            var TempKeys = new TKey[size + 1];
            var TempValues = new TValue[size + 1];

            for (int i = 0; i < size + 1; i++)
            {
                if (i == num)
                {
                    TempArray[i] = item;
                    TempKeys[i] = item.Key;
                    TempValues[i] = item.Value;
                }
                else if (i < num)
                {
                    TempArray[i] = _items[i];
                    TempKeys[i] = keys[i];
                    TempValues[i] = values[i];
                }
                else
                {
                    TempArray[i] = _items[i - 1];
                    TempKeys[i] = keys[i - 1];
                    TempValues[i] = values[i - 1];
                }
            }

            _items = TempArray;
            keys = TempKeys;
            values = TempValues;
            size++;
            AddElement?.Invoke(this, EventArgs.Empty);

        }
        public void Add(TKey key, TValue value)
        {
            if (_capacity <= size)
            {
                ExpandCapacity();
            }
            int num;
            if (size == 0)
            {
                size++;
                values[0] = value;
                keys[0] = key;
                _items[0] = new KeyValuePair<TKey, TValue>(key, value);
                AddElement?.Invoke(this, EventArgs.Empty);
                return;
            }
            num = Search(key);

            if (num < 0)
            {
                return;
            }
            var TempArray = new KeyValuePair<TKey, TValue>[size + 1];
            var TempKeys = new TKey[size + 1];
            var TempValues = new TValue[size + 1];

            for (int i = 0; i < size + 1; i++)
            {
                if (i == num)
                {
                    TempArray[i] = new KeyValuePair<TKey, TValue>(key, value);
                    TempKeys[i] = key;
                    TempValues[i] = value;
                }
                else if (i < num)
                {
                    TempArray[i] = _items[i];
                    TempKeys[i] = keys[i];
                    TempValues[i] = values[i];
                }
                else
                {
                    TempArray[i] = _items[i - 1];
                    TempKeys[i] = keys[i - 1];
                    TempValues[i] = values[i - 1];
                }
            }

            _items = TempArray;
            keys = TempKeys;
            values = TempValues;
            size++;
            AddElement?.Invoke(this, EventArgs.Empty);

        }

        public void Clear()
        {
            _items = Array.Empty<KeyValuePair<TKey, TValue>>();
            values = Array.Empty<TValue>();
            keys = Array.Empty<TKey>();
            _capacity = 0;
            size = 0;
            ClearArray?.Invoke(this, EventArgs.Empty);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int num = Search(item.Key);
            if (num < 0)
            {
                return true;
            }
            return false;
        }
        public bool Contains(TKey key)
        {
            int num = num = Search(key);
            if (num <= 0)
            {
                return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = _items[i];
            }
        }
        public void CopyTo(TValue[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = values[i];
            }
        }

        public void ExpandCapacity()
        {
            var TempSize = _capacity * 2;
            var TempArray = new KeyValuePair<TKey, TValue>[TempSize];
            var TempKeys = new TKey[TempSize];
            var TempValues = new TValue[TempSize];
            CopyTo(TempArray, 0);
            _capacity = TempSize;
            _items = TempArray;
            keys = TempKeys;
            values = TempValues;
            for (int i = 0; i < TempSize; i++)
            {
                keys[i] = TempArray[i].Key;
                values[i] = TempArray[i].Value;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int num = Search(item.Key);
            if (num > 0)
            {
                return false;
            }
            num = -num;
            var TempArray = new KeyValuePair<TKey, TValue>[_capacity - 1];
            var TempKeys = new TKey[_capacity - 1];
            var TempValues = new TValue[_capacity - 1];
            for (int i = 0; i < _items.Length; i++)
            {
                if (i != num)
                {
                    if (i < num)
                    {
                        TempArray[i] = _items[i];
                        TempKeys[i] = _items[i].Key;
                        TempValues[i] = _items[i].Value;
                    }
                    else
                    {
                        TempArray[i - 1] = _items[i];
                        TempKeys[i - 1] = _items[i].Key;
                        TempValues[i - 1] = _items[i].Value;
                    }
                }
            }
            _items = TempArray;
            keys = TempKeys;
            values = TempValues;
            size--;
            RemoveElement?.Invoke(this, EventArgs.Empty);
            return true;
        }
        public bool Remove(TKey key)
        {
            int num = Search(key);
            if (num > 0)
            {
                return false;
            }
            num = -num;
            var TempArray = new KeyValuePair<TKey, TValue>[_capacity - 1];
            var TempKeys = new TKey[_capacity - 1];
            var TempValues = new TValue[_capacity - 1];
            for (int i = 0; i < Count; i++)
            {
                if (i != num)
                {
                    if (i < num)
                    {
                        TempArray[i] = _items[i];
                        TempKeys[i] = _items[i].Key;
                        TempValues[i] = _items[i].Value;
                    }
                    else
                    {
                        TempArray[i - 1] = _items[i];
                        TempKeys[i - 1] = _items[i].Key;
                        TempValues[i - 1] = _items[i].Value;
                    }
                }
            }
            _items = TempArray;
            keys = TempKeys;
            values = TempValues;
            size--;
            RemoveElement?.Invoke(this, EventArgs.Empty);
            return true;
        }

        private int Search(TKey key)
        {
            Comparer comparer = Comparer.Default;
            int left = 0;
            int right = size - 1;
            int comp;
            TKey current = keys[(right + left) / 2]; ;
            while(left + 1 < right)
            {
                if (left == right)
                {
                    return left;
                }
                current = keys[(right + left) / 2];
                comp = comparer.Compare(current, key);
                if (comp == 0)
                {
                    if (((right + left) / 2) == 0)
                    {
                        return ((right + left) / 2 - 1);
                    }
                    else
                    {
                        return -((right + left) / 2);
                    }
                }
                if (comp > 0)
                {
                    left = (right + left) / 2;
                }
                else
                {
                    right = (right + left) / 2;
                }
            }
            comp = comparer.Compare(keys[right], key);
            if (comp == 0)
            {
                return -right;
            }
            if (comp > 0)
            {
                return right + 1;
            }
            comp = comparer.Compare(key, keys[left]);
            if (comp == 0)
            {
                return -left;
            }
            if (comp < 0)
            {
                return right;
            }
            return left;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new NewEnumenator(_items);
        }

        private class NewEnumenator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private readonly KeyValuePair<TKey, TValue>[] _items;
            private int index;
            private KeyValuePair<TKey, TValue> current;
            public KeyValuePair<TKey, TValue> Current => current;

            object IEnumerator.Current => current;

            public NewEnumenator (KeyValuePair<TKey, TValue>[] items)
            {
                _items = items;
                index = 0;

                if (_items.Any())
                    current = items[index];
            }

            public void Dispose()
            {
                return;
            }

            public bool MoveNext()
            {
                if (index >= _items.Length)
                {
                    return false;
                }
                current = _items[index];
                index++;
                return true;
            }

            public void Reset()
            {
                index = 0;
                current = _items[index];
            }
        }
    }


}