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
            // データ準備
            int[] array = { 9, 7, 8, 5, 6, 3, 4, 1, 2, 0 };
            DebugPrint(array.ToList());
            Debug.WriteLine("--------");

            // ソーター生成
            var sorter = new BubbleSorter();
            sorter.OnUpdate += (sender, e) => DebugPrint(array.ToList());

            // ソート実行
            sorter.Sort(array);
        }

        static void DebugPrint(List<int> array)
        {
            array.ForEach(x => Debug.Write(x + ", "));
            Debug.WriteLine("");
        }
    }
}
