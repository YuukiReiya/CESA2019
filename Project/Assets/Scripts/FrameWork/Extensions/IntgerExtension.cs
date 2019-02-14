using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DAGASIScripts
{
    public static class IntgerExtension
    {

        /// <summary>
        /// 数値をループさせる
        /// </summary>
        public static int AddLoop(this int v, int value, int max)
        {
            return v = (v + max + value) % max;
        }

        /// <summary>
        /// 数値を一桁ずつ取り出す
        /// 例)1596=>{6,9,5,1}
        /// </summary>
        /// <param name="num">数値</param>
        /// <returns>反転された数値</returns>
        public static int[] GetNumbers(this int num)
        {
            List<int> list = new List<int>();
            while (num > 0)
            {
                list.Add(num % 10);
                num /= 10;
            }
            return list.ToArray();
        }
    }
}
