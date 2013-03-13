namespace Algorithm
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// 開始時イベント
        /// </summary>
        event EventHandler OnBegin;

        /// <summary>
        /// 更新時イベント
        /// </summary>
        event EventHandler OnUpdate;

        /// <summary>
        /// 完了時イベント
        /// </summary>
        event EventHandler OnComplete;

        /// <summary>
        /// ソート関数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">ソート対象のリスト</param>
        void Sort<T>(IList<T> array)
            where T : IComparable<T>;
    }
}
