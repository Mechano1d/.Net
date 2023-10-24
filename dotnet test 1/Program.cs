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
            for (int i = 0; i < 50; i++)
            {
                Random rand = new Random(i);
                MyList.Add(rand.Next() % 1000, rand.Next() % 1000);
            }
            Console.WriteLine(MyList.Count);

            Console.WriteLine("\nFOR\n________________________");
            int j = 0;
            while (j < MyList.Count)
            {
                Console.WriteLine(MyList.keys[j].ToString() + " " + MyList.values[j].ToString());
                j++;
            }
            int u = 0;
            int y = 0;
            for (j = 0; j < MyList.Count-1; j++)
            {
                if (MyList.keys[j] < MyList.keys[j + 1])
                {
                    u++;
                }
                if (MyList.Contains(MyList[j].Key) != true)
                {
                    Console.Write("Not contained: ");
                    Console.WriteLine(MyList[j].Key);
                    y++;
                }
            }
            Console.WriteLine(u);
            Console.WriteLine(y);
            Console.ReadLine();
            /*

            Console.WriteLine("\nFOREACH\n________________________");
            foreach (var i in MyList)
            {
                Console.WriteLine(i.Key.ToString() + " " + i.Value.ToString());
            }

            Console.WriteLine("\nCOPY\n________________________");
            KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[10];
            MyList.CopyTo(arr, 4);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nREMOVE\n________________________");
            MyList.Remove(4);
            Console.WriteLine(MyList.Count);
            foreach (var i in MyList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nCONTAINS\n________________________");
            Console.WriteLine("3, value");
            Console.WriteLine(MyList.Contains(3));

            Console.WriteLine("10, value");
            Console.WriteLine(MyList.Contains(10));

            Console.WriteLine("\nCLEAR\n________________________");
            MyList.Clear();
            Console.WriteLine(MyList.Count);
            Console.ReadLine();
            */
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
