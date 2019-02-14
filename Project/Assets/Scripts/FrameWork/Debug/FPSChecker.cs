using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    /// <summary>
    /// FPSがどのくらい出ているか確認する
    /// </summary>
    public static class FPSChecker
    {
        //fps
        static int frameCount;
        static float prevTime;
        static int[] cangeFPS = new int[] { -1, 60, 120 };
        static int cangeFPSNumber;
        public static float nowFPS;

        // Use this for initialization
        public static void Init()
        {
            prevTime = 0;
            frameCount = 0;
        }

        // Update is called once per frame
        public static void Update()
        {
            ++frameCount;
            float time = Time.realtimeSinceStartup - prevTime;
            if (time > 0.5f)
            {
                nowFPS = frameCount / time;
                frameCount = 0;
                prevTime = Time.realtimeSinceStartup;
            }
        }

        public static void CangeFPS()
        {
            cangeFPSNumber = ++cangeFPSNumber % cangeFPS.Length;
            Application.targetFrameRate = cangeFPS[cangeFPSNumber];
        }
        public static void SetFPS(FPSSPeed setNum)
        {
            Application.targetFrameRate = cangeFPS[(int)setNum];
            cangeFPSNumber = (int)setNum;
        }
        public enum FPSSPeed
        {
            MaxSpeed, Nomal, HiSpeed
        }
    }

}