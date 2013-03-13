namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// バブルソート
    /// </summary>
    public class BubbleSorter : ISorter
    {
        public event EventHandler OnBegin;

        public event EventHandler OnUpdate;

        public event EventHandler OnComplete;

        public void Sort<T>(IList<T> array) where T : IComparable<T>
        {
            // 引数チェック
            Contract.Requires(array != null);

            // OnBeginイベント
            if (this.OnBegin != null)
            {
                // はじまるよ～
                this.OnBegin(this, EventArgs.Empty);
            }

            // ソート開始
            int count = array.Count - 1;
            
            for (int i = 0; i < count; i++)
            {
                for (int j = count; i < j; j--)
                {
                    int k = j - 1;

                    if (array[j].CompareTo(array[k]) < 0)
                    {
                        // スワップする
                        T tmp = array[j];
                        array[j] = array[k];                     
                        array[k] = tmp;

                        // OnUpdateイベント
                        if (OnUpdate != null)
                        {
                            OnUpdate(this, EventArgs.Empty);
                        }
                    }
                }
            }

            // OnCompleteイベント
            if (this.OnComplete != null)
            {
                this.OnComplete(this, EventArgs.Empty);
            }
        }
    }
}
