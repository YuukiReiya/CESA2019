using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DAGASIScripts
{
    public static class TransformExtension
    {
        public static void SetPosX(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.x = value;
            t.position = v;
        }
        public static void SetPosY(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.y = value;
            t.position = v;
        }
        public static void SetPosZ(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.z = value;
            t.position = v;
        }
        public static void SetPosXZ(this Transform t, float valX, float valZ)
        {
            Vector3 v = t.position;
            v.x = valX;
            v.z = valZ;
            t.position = v;
        }
        public static void SetRotateX(this Transform t, float value)
        {
            Vector3 v = t.eulerAngles;
            v.x = value;
            t.eulerAngles = v;
        }
        public static void SetRotateY(this Transform t, float value)
        {
            Vector3 v = t.eulerAngles;
            v.y = value;
            t.eulerAngles = v;
        }
        public static void SetRotateZ(this Transform t, float value)
        {
            Vector3 v = t.eulerAngles;
            v.z = value;
            t.eulerAngles = v;
        }

        public static void ClampX(this Transform t, float minX, float maxX)
        {
            Vector3 v = t.position;
            v.x = Mathf.Clamp(v.x, minX, maxX);
            t.position = v;
        }
        public static void ClampY(this Transform t, float minY, float maxY)
        {
            Vector3 v = t.position;
            v.y = Mathf.Clamp(v.y, minY, maxY);
            t.position = v;
        }
        public static void ClampXY(this Transform t, float minX, float maxX, float minY, float maxY)
        {
            Vector3 v = t.position;
            v.x = Mathf.Clamp(v.x, minX, maxX);
            v.y = Mathf.Clamp(v.y, minY, maxY);
            t.position = v;
        }
        public static bool IsRotateMax(this Transform t, float value)
        {
            if (t.transform.eulerAngles.x > 180)
            {
                //マイナス値
                float a = t.transform.eulerAngles.x - 360;
                return a >= value;
            }
            else
            {
                //プラス値
                float a = t.transform.eulerAngles.x;
                return a >= value;
            }
        }
        public static bool IsRotateMin(this Transform t, float value)
        {
            if (t.transform.eulerAngles.x > 180)
            {
                //マイナス値
                float a = t.transform.eulerAngles.x - 360;
                return a <= value;
            }
            else
            {
                //プラス値
                float a = t.transform.eulerAngles.x;
                return a <= value;
            }
        }
    }
}