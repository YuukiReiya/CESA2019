using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DAGASIScripts
{
    /// <summary>
    /// float[]の書き換え
    /// </summary>
    public class ArrCmpr : IEqualityComparer<float[]>
    {
        public bool Equals(float[] a, float[] b)
        {
            return a.Length == b.Length && Enumerable.Range(0, a.Length).All(i => a[i] == b[i]);
        }

        public int GetHashCode(float[] a)
        {
            return a.Aggregate(0, (acc, i) => unchecked(acc * 457 + (int)(i * 389)));

        }
    }
}