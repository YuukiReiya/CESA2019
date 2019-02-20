using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    public static class MyScript
    {
        public static bool DistanceIns(Vector3 baseVec, Vector3 tagerVec, float size)
        {
            return Vector3.SqrMagnitude(tagerVec - baseVec) < size;
        }
        public static bool IsScopeAngleIns(Vector3 target, Vector3 basePos, Vector3 baseForad, float angle)
        {
            Vector3 tar = target - basePos;
            tar.Normalize();
            float targetAngle = tar.GetRotateXZ() + 180;
            float baseAngle = baseForad.GetRotateXZ() + 180;
            return Mathf.Abs(targetAngle - baseAngle) < angle || Mathf.Abs(targetAngle + 360 - baseAngle) < angle;
        }

        /// <summary>
        /// 壁に沿って移動する
        /// </summary>
        public static Vector3 WallMoveAlong(RaycastHit hit, Vector3 baseDirection)
        {
            //坂道に当たってないか
            if (Mathf.Abs(hit.normal.y) >= 0.4f) return Vector3.zero;
            Vector3 h = new Vector3(-hit.normal.z, 0, hit.normal.x);//並行
            float rad = baseDirection.x * h.x + baseDirection.z * h.z;
            return h * rad;
        }



        /// <summary>
        /// 物が入れ替わっているかチェックする
        /// </summary>
        public class OldNewChecker
        {
            public delegate void OldNewNumAction(int num);

            public int oldValue { get; private set; }
            public int value { get; private set; }

            public OldNewChecker(int startValue = 0)
            {
                oldValue = startValue;
                value = startValue;
            }

            public void SetValue(int _value)
            {
                oldValue = this.value;
                this.value = _value;
            }

            public bool Check()
            {
                return oldValue == value;
            }

            public void CheckAction(OldNewNumAction newAction, OldNewNumAction oldAction)
            {
                oldAction(oldValue);
                newAction(value);
            }
        }

        public static Vector3 CheckValueRectArea(Vector3 values, Vector3 minArea, Vector3 maxArea)
        {
            Vector3 returnValue = Vector3.zero;
            returnValue.x = Mathf.Clamp(values.x, minArea.x, maxArea.x);
            returnValue.y = Mathf.Clamp(values.y, minArea.y, maxArea.y);
            returnValue.z = Mathf.Clamp(values.z, minArea.z, maxArea.z);
            return returnValue;
        }
    }

}