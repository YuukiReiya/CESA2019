using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    /// <summary>
    /// Escapeでゲーム終了
    /// </summary>
    public static class ESCGameEnd
    {
        public static void CheckEND()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            Application.Quit();
        }
    }
}
