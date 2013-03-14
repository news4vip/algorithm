namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    public class InsertSorter : ISorter
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
            int last  = array.Count;

            int i, j, k;
            T t;

            for (i = 1; i < last; i++)
            {
                t = array[i];
                if (0 < array[i - 1].CompareTo(t))
                {
                    j = i;
                    k = j - 1;
                    do 
                    {
                        array[j] = array[k];
                        j = j - 1;
                        k = j - 1;
                    } while (0 < j && 0 < array[k].CompareTo(t));
                    
                    array[j] = t;

                    // OnUpdateイベント
                    if (OnUpdate != null)
                    {
                        OnUpdate(this, EventArgs.Empty);
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
