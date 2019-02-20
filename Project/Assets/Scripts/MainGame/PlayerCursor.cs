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
        private const float HORIZONTAL_LIMIT = 12;
        private const float VERTICLE_LIMIT = 7;

        //private Vector3 

        // Update is called once per frame
        void Update()
        {
            // CursorUpdate();
            Input();
        }

        public void CursorUpdate()
        {
            switch (controlMode)
            {
                case ControlMode.MOUSE:
                    transform.position = DisplayAccess.Instance.GetMousePosInWindow();
                    if (!UnityEngine.Input.GetMouseButtonDown(0)) break;
                    PlayAction(Color.red);
                    break;
                case ControlMode.GAMEPAD_L:
                    //PlayAction(Color.blue);
                    break;
                case ControlMode.GAMEPAD_R:
                    //PlayAction(Color.green);
                    break;
            }


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

                        //  横画面限界
                        if (this.transform.position.x > HORIZONTAL_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.x = HORIZONTAL_LIMIT;
                            this.transform.position = tmp;
                        }
                        else if (this.transform.position.x < -HORIZONTAL_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.x = -HORIZONTAL_LIMIT;
                            this.transform.position = tmp;
                        }

                        //  縦画面限界
                        if (this.transform.position.y > VERTICLE_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.y = VERTICLE_LIMIT;
                            this.transform.position = tmp;
                        }
                        else if (this.transform.position.y < -VERTICLE_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.y = -VERTICLE_LIMIT;
                            this.transform.position = tmp;
                        }

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

                        //  横画面限界
                        if (this.transform.position.x > HORIZONTAL_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.x = HORIZONTAL_LIMIT;
                            this.transform.position = tmp;
                        }
                        else if (this.transform.position.x < -HORIZONTAL_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.x = -HORIZONTAL_LIMIT;
                            this.transform.position = tmp;
                        }

                        //  縦画面限界
                        if (this.transform.position.y > VERTICLE_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.y = VERTICLE_LIMIT;
                            this.transform.position = tmp;
                        }
                        else if (this.transform.position.y < -VERTICLE_LIMIT)
                        {
                            Vector3 tmp = this.transform.position;
                            tmp.y = -VERTICLE_LIMIT;
                            this.transform.position = tmp;
                        }

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