using DAGASIScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace MainGame.Player
{
    public class PlayerCursor : MonoBehaviour
    {

        private enum ControlMode
        {
            MOUSE, GAMEPAD_L, GAMEPAD_R
        }

        [SerializeField]
        private ControlMode controlMode;

        //  左側カーソルの波色
        private readonly Color LEFT_WAVE_COLOR = Color.blue;

        //  右側カーソルの波色
        private readonly Color RIGHT_WAVE_COLOR = Color.green;

        //  マウスのキーコード(右クリック)
        private const int CLICK_KEYCODE = 0;

        //  カーソルの移動制限
        private const float HORIZONTAL_LIMIT = 1f;
        private const float VERTICLE_LIMIT = 1.2f;

        //private Vector3 

        // Update is called once per frame
        void Update()
        {
            Input();
        }

        public void PlayAction(Color waveColor)
        {
            Wave.Wave wave = Wave.WaveFactory.Instance.Create(transform.position, Quaternion.identity);
            wave.SetColor(waveColor);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 1);
        }

        /// <summary>
        /// 入力処理
        /// </summary>
        private void Input()
        {
            //  デバイスに応じた入力処理
            switch (controlMode)
            {
                //  マウス入力
                case ControlMode.MOUSE:
                    {
                        //  マウスの位置取得
                        this.transform.position = DisplayAccess.Instance.GetMousePosInWindow();

                        //  クリック取得
                        if(!UnityEngine.Input.GetMouseButtonDown(CLICK_KEYCODE))
                        {
                            //  クリックされていなければ処理しない
                            break;
                        }

                        //  色の決定処理(画面左側:青 右側:緑)
                        Color cr = Color.red;

                        //  アクション
                        PlayAction(cr);
                    }
                    break;
                //  ゲームパッド:左
                case ControlMode.GAMEPAD_L:
                    {
                        //  位置更新
                        Vector3 cast = GamePadController.Instance.LStick;
                        this.transform.position += cast;

                        transform.position = DisplayAccess.Instance.ClampDisplayArea(transform.position,HORIZONTAL_LIMIT,VERTICLE_LIMIT);

                        //  トリガー取得
                        if (!GamePadController.Instance.LB)
                        {
                            //  トリガーが押されていなければ処理しない
                            break;
                        }

                        //-----------------------------------
                        //  デバッグ
                        if(GamePadController.Instance.A)
                        {
                            Debug.Log("blue = " + this.transform.position);
                        }
                        //-----------------------------------

                        //  アクション
                        PlayAction(LEFT_WAVE_COLOR);
                    }
                    break;
                //  ゲームパッド:右
                case ControlMode.GAMEPAD_R:
                    {
                        //  位置更新
                        Vector3 cast = GamePadController.Instance.RStick;
                        this.gameObject.transform.position += cast;

                        transform.position = DisplayAccess.Instance.ClampDisplayArea(transform.position, HORIZONTAL_LIMIT, VERTICLE_LIMIT);

                        //  トリガー取得
                        if (!GamePadController.Instance.RB)
                        {
                            //  トリガーが押されていなければ処理しない
                            break;
                        }

                        //-----------------------------------
                        //  デバッグ
                        if (GamePadController.Instance.A)
                        {
                            Debug.Log("green = " + this.transform.position);
                        }
                        //-----------------------------------

                        //  アクション
                        PlayAction(RIGHT_WAVE_COLOR);
                    }
                    break;

            }
        }
    }
}