namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    public class BubbleSorter : ISorter
    {
        public event EventHandler OnBegin;
        public event EventHandler OnUpdate;
        public event EventHandler OnComplete;

        public void Sort<T>(IList<T> a) where T : IComparable<T>
        {
            // 引数チェック
            Contract.Requires(a != null);

            // OnBeginイベント
            if (this.OnBegin != null)
            {
                this.OnBegin(this, EventArgs.Empty);
            }

            // ソート開始
            int n = a.Count - 1;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = n; i < j; j--)
                {
                    int k = j - 1;

                    if (a[j].CompareTo(a[k]) < 0)
                    {
                        // スワップする
                        T x  = a[j];
                        a[j] = a[k];                     
                        a[k] = x;

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
