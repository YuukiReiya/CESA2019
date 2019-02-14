using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DAGASIScripts
{
    /// <summary>
    /// FPSを表示する
    /// </summary>
    public class FPSDraw : MonoBehaviour
    {

        [SerializeField]
        Text text;

        // Use this for initialization
        void Start()
        {
            FPSChecker.Init();
        }

        // Update is called once per frame
        void Update()
        {
            FPSChecker.Update();
            text.text = "FPS: " + FPSChecker.nowFPS;
        }
    }
}