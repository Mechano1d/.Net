using System;
using System.Collections;

namespace Enumerable
{
    internal class Program
    {
        private sealed class RandomEnumerator : IEnumerator
        {
            private int _index;
            private readonly int _size;
            private static readonly int _seed;
            private int _currentValue;
            private Random _random;

            static RandomEnumerator()
            {
                Random seedGenerator = new Random();
                _seed = seedGenerator.Next();
            }

            public RandomEnumerator(int size)
            {
                _size = size;
                _random = new Random(_seed);
            }

            public bool MoveNext()
            {
                _currentValue = _random.Next();
                _index++;

                bool retVal = _index <= _size;

                if (!retVal)
                {
                    Reset();
                }

                return retVal;
            }

            public void Reset()
            {
                _random = new Random(_seed);
                _index = 0;
            }

            public object Current
            {
                get { return _currentValue; }
            }
        }

        public class RandomCollection : ICollection
        {
            private readonly IEnumerator _random;

            private readonly int _size;

            public RandomCollection() : this(5)
            {
            }

            public RandomCollection(int size)
            {
                _size = size;
                _random = new RandomEnumerator(size);
            }

            public IEnumerator GetEnumerator()
            {
                return _random;
            }

            public void CopyTo(Array array, int index)
            {
                GetEnumerator().Reset();
                while (GetEnumerator().MoveNext())
                {
                    array.SetValue(GetEnumerator().Current, index++);
                }
            }

            public int Count
            {
                get { return _size; }
            }

            public object SyncRoot
            {
                get { return null; }
            }

            public bool IsSynchronized
            {
                get { return false; }
            }
        }

        private static void Main()
        {
            RandomCollection col = new RandomCollection(7);

            foreach (int item in col)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            int[] copy = new int[col.Count];
            col.CopyTo(copy, 0);

            for (int x = 0; x < copy.Length; x++)
            {
                Console.WriteLine(copy[x]);
            }
        }
    }
}
