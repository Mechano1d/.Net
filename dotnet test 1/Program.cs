using System;
using System.Collections;
using System.Collections.Generic;
using MyCollection;

namespace Enumerable
{
    internal class Program
    {
        public static void Main()
        {
            _SortedList<int, int> MyList = new _SortedList<int, int>(10);

            MyList.AddElement += AddedElement;
            MyList.RemoveElement += RemovedElement;
            MyList.ClearArray += ClearedArray;

            Console.WriteLine("ADD\n________________________");
            MyList.Add(1, 3);
            MyList.Add(6, 35);
            MyList.Add(3, 12);
            MyList.Add(5, 4);
            MyList.Add(4, 532);
            MyList.Add(6, 63);
            Console.WriteLine(MyList.Count);
            Console.WriteLine("FOR\n________________________");
            for (var i = 0; i < MyList.Count; i++)
            {
                Console.WriteLine(MyList.keys[i].ToString() + " " + MyList.values[i].ToString());
            }
            Console.WriteLine("FOREACH\n________________________");
            foreach (var i in MyList)
            {
                Console.WriteLine(i.Key.ToString() + " " + i.Value.ToString());
            }
            Console.WriteLine("COPY\n________________________");
            KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[10];
            MyList.CopyTo(arr, 5);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("REMOVE\n________________________");
            MyList.Remove(4);
            Console.WriteLine(MyList.Count);
            foreach (var i in MyList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("CONTAINS\n________________________");
            Console.WriteLine(MyList.Contains(3));
            Console.ReadLine();
            
        }
        
        static void AddedElement(object sender, EventArgs e)
        {
            Console.WriteLine("Element Added");
        }
        static void RemovedElement(object sender, EventArgs e)
        {
            Console.WriteLine("Element Removed");
        }
        static void ClearedArray(object sender, EventArgs e)
        {
            Console.WriteLine("Array Cleared");
        }
    }
}
