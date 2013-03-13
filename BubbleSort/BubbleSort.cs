namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Diagnostics;

    public interface ISorter
    {
        event EventHandler OnUpdate;

        void Sort<T>(IList<T> array)
            where T : IComparable<T>;
    }

    public class BubbleSorter : ISorter
    {
        public event EventHandler OnUpdate;

        public void Sort<T>(IList<T> a) where T : IComparable<T>
        {
            Contract.Requires(a != null);

            int n = a.Count - 1;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = n; i < j; j--)
                {
                    int k = j - 1;
                    if (a[j].CompareTo(a[k]) < 0)
                    {
                        T x  = a[j];
                        a[j] = a[k];                     
                        a[k] = x;

                        if (OnUpdate != null)
                        {
                            OnUpdate(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }


    public class App
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 7, 8, 5, 6, 3, 4, 1, 2, 0 };
            var sorter = new BubbleSorter();

            sorter.OnUpdate += (sender, e) => {
                Debug.Write("update: ");
                Array.ForEach(arr, x => Debug.Write(x + ", "));
                Debug.WriteLine("");
            };

            Debug.Write("before: ");
            Array.ForEach(arr, x => Debug.Write(x + ", "));
            Debug.WriteLine("");

            sorter.Sort(arr);

            Debug.Write("after : ");
            Array.ForEach(arr, x => Debug.Write(x + ", "));
            Debug.WriteLine("");
        }
    }
}
