using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    public static class VectorExtension
    {

        public static Vector2 ConvertVector3ToVector2XZ(this Vector3 pos)
        {
            return new Vector2(pos.x, pos.z);
        }
        public static Vector3 ConvertVector2ToVector3XZ(this Vector2 pos)
        {
            return new Vector3(pos.x, 0, pos.y);
        }
        public static Vector3 ConvertVector2IntToVector3XZ(this Vector2Int pos)
        {
            return new Vector3(pos.x, 0, pos.y);
        }

        public static Vector3 CheckValueRectArea(this Vector3 values, Vector3 minArea, Vector3 maxArea)
        {
            Vector3 returnValue = Vector3.zero;
            returnValue.x = Mathf.Clamp(values.x, minArea.x, maxArea.x);
            returnValue.y = Mathf.Clamp(values.y, minArea.y, maxArea.y);
            returnValue.z = Mathf.Clamp(values.z, minArea.z, maxArea.z);
            return returnValue;
        }

        /// <summary>
        /// xが横　zが奥 の方向ベクトルから角度を求める
        /// </summary>
        /// <param name="vec">方向</param>
        /// <returns>角度(-180 ~ 180)</returns>
        public static float GetRotateXZ(this Vector3 vec)
        {
            return Mathf.Atan2(vec.x, vec.z) * 180 / Mathf.PI;
        }
        /// <summary>
        /// xが横　yが奥 の方向ベクトルから角度を求める
        /// </summary>
        /// <param name="vec">方向</param>
        /// <returns>角度(-180 ~ 180)</returns>
        public static float GetRotateXY(this Vector3 vec)
        {
            return Mathf.Atan2(vec.x, -vec.y) * 180 / Mathf.PI;
        }
    }

}