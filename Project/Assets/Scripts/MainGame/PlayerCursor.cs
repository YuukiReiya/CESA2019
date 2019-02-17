using DAGASIScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Player
{
    public class PlayerCursor : MonoBehaviour
    {

        private enum ControlMode
        {
            MOUSE, GAMEPADL, GAMEPADR
        }

        [SerializeField]
        private ControlMode controlMode;

        // Update is called once per frame
        void Update()
        {
            CursorUpdate();
        }

        public void CursorUpdate()
        {
            switch (controlMode)
            {
                case ControlMode.MOUSE:
                    transform.position = DisplayAccess.Instance.GetMousePosInWindow();
                    if (!Input.GetMouseButtonDown(0)) break;
                    PlayAction(Color.red);
                    break;
                case ControlMode.GAMEPADL:
                    //PlayAction(Color.blue);
                    break;
                case ControlMode.GAMEPADR:
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
    }
}