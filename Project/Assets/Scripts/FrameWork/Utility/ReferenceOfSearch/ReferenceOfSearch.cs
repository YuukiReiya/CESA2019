/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    /// <summary>
    /// 拡張メソッドクラス
    /// </summary>
    public static class ReferenceOfSearch
    {
        /// <summary>
        /// ヒエラルキー上に存在する指定のスクリプトを見つける。
        /// 複数の場合はFindObjectOfTypeで見つかった最初のものになる。
        /// ※FindObjectOfTypeを使うためEditor上でのみ使うことを推奨。
        /// 例)void Reset(){ hoge = FindObjectOfType<Hoge>(); }
        /// </summary>
        /// <typeparam name="T">見つけ出すクラス型</typeparam>
        /// <param name="self">拡張メソッド</param>
        /// <returns>成功:見つかった一番最初の参照 失敗:null</returns>
        public static T FindOfScript<T>(this Object self)
            where T : Object
        {
            T ret = null;
            ret = Object.FindObjectOfType<T>();
            if (!ret)
            {
                Debug.LogError("<color=red>" + typeof(T) + "</color>" + " is not found!");
            }
            return ret ?? null;
        }

    }
}
