namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Diagnostics;

    public class BubbleSort
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static void Sort<T>(T[] a)
            where T : IComparable<T>
        {
            Contract.Requires(a != null);

            int n = a.Length - 1;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = n; i < j; j--)
                {
                    int k = j - 1;
                    if (a[j].CompareTo(a[k]) < 0)
                    {
                        Swap(ref a[j], ref a[k]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 9, 7, 8, 5, 6, 3, 4, 1, 2, 0 };

            Debug.Write("before: ");
            Array.ForEach(arr, x => Debug.Write(x + ", "));
            Debug.WriteLine("");

            Sort(arr);

            Debug.Write("after : ");
            Array.ForEach(arr, x => Debug.Write(x + ", "));
            Debug.WriteLine("");
        }
    }
}
