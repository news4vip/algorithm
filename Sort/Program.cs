namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// デバッグ用
    /// </summary>
    class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // バブルソート生成
            var sorters = new List<ISorter>() {
                //new BubbleSorter(),
                //new MergeSorter(),
                new InsertSorter(),
            };

            foreach (var sorter in sorters)
            {
                // データ準備
                int[] array = { 9, 7, 8, 5, 6, 3, 4, 1, 2, 0 };
                DebugPrint(array.ToList());
                Debug.WriteLine("--------");

                sorter.OnUpdate += (sender, e) => DebugPrint(array.ToList());
                // ソート実行
                sorter.Sort(array);
            }
        }

        static void DebugPrint(List<int> array)
        {
            array.ForEach(x => Debug.Write(x + ", "));
            Debug.WriteLine("");
        }
    }
}
