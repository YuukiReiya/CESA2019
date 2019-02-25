/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace MainGame
{   
    /// <summary>
    /// ゲームシーンのコントローラー
    /// </summary>
    public class GameSceneController : MonoBehaviour
    {
        public Time.Time time;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*****************************************
            //  ゲームシーン中の更新処理は、ここに書く
            ******************************************/

            //  制限時間
            time.CountDown();

        }

        /// <summary>
        /// インスペクター上に設定する参照の設定
        /// </summary>
        [ContextMenu("Set Reference")]
        void SetReference()
        {
            time = this.FindOfScript<Time.Time>();
        }
    }
}
