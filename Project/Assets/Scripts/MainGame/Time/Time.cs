/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Time
{
    /// <summary>
    /// 制限時間クラス
    /// </summary>
    public class Time : MonoBehaviour
    {
        //  ゲーム中のカウント
        ulong count = 0;

        // Start is called before the first frame update
        void Start()
        {
            count = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// カウントダウン
        /// </summary>
        public void CountDown()
        {
            count++;
        }
    }
}