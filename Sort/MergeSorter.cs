namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// マージソート
    /// </summary>
    public class MergeSorter : ISorter
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
            int count = array.Count;
            T[] work  = new T[count];
            Sort(array, 0, count - 1, work);

            // OnCompleteイベント
            if (this.OnComplete != null)
            {
                this.OnComplete(this, EventArgs.Empty);
            }
        }

        void Sort<T>(IList<T> array, int left, int right, T[] work) where T : IComparable<T>
        {
            if (right <= left)
            {
                return;
            }

            int mid = (left + right) / 2;
            Sort(array, left   , mid  , work);
            Sort(array, mid + 1, right, work);

            // merge
            for (int i = left; i <= mid; i++)
            {
                work[i] = array[i];
            }
            for (int i = mid + 1, j = right; i <= right; i++, j--)
            {
                work[i] = array[j];
            }

            int a = left;
            int b = right;
            for (int k = left; k <= right; k++)
            {
                if (work[a].CompareTo(work[b]) < 0)
                {
                    array[k] = work[a++];
                }
                else
                {
                    array[k] = work[b--];
                }

            }

            // OnUpdateイベント
            if (OnUpdate != null)
            {
                OnUpdate(this, EventArgs.Empty);
            }
        }
    }
}
