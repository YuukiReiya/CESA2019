using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput.Gamepad;

namespace Utility
{
    public class GamePadController : MonoBehaviour
    {
        public enum Property
        {
            //  感度
            SENSITIVITY,
            //  死域
            DEAD,
            //  ニュートラルに戻る速度
            GRAVITY,
        }

        /// <summary>
        /// 入力をとるコントローラー
        /// </summary>
        public static GamePad Instance { get; private set; }

        private void Awake()
        {
            if (!Instance) { Instance = gameObject.AddComponent<GamePad>(); }
            Instance.Controller = GamePad.Index.ALL;
        }
    }
}
