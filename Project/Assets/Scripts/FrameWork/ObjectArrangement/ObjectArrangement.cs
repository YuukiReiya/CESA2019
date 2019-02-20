using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    public static class ObjectArrangement
    {

        /// <summary>
        /// 円形の座標を取り出す xz
        /// </summary>
        /// <param name="size">数</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static Vector3[] CircleDeployXZ(int size, float radius)
        {
            Vector3[] rtVec = new Vector3[size];
            //オブジェクト間の角度差
            float angleDiff = 360f / size;

            //各オブジェクトを円状に配置
            for (int i = 0; i < size; i++)
            {
                Vector3 childPostion = Vector3.zero;

                float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
                childPostion.x += radius * Mathf.Cos(angle);
                childPostion.z += radius * Mathf.Sin(angle);
                rtVec[i] = childPostion;
            }
            return rtVec;
        }
        /// <summary>
        /// 円形の座標を取り出す xy
        /// </summary>
        /// <param name="size">数</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static Vector3[] CircleDeployXY(int size, float radius)
        {
            Vector3[] rtVec = new Vector3[size];
            //オブジェクト間の角度差
            float angleDiff = 360f / size;

            //各オブジェクトを円状に配置
            for (int i = 0; i < size; i++)
            {
                Vector3 childPostion = Vector3.zero;

                float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
                childPostion.x += radius * Mathf.Cos(angle);
                childPostion.y += radius * Mathf.Sin(angle);
                rtVec[i] = childPostion;
            }
            return rtVec;
        }

        /// <summary>
        /// 四角い方向座標を取り出す
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Vector2Int[] GetRectVectorsInt(int size)
        {
            Vector2Int[] vectors = new Vector2Int[(size * 2 + 1) * (size * 2 + 1)];
            for (int y = 0; y < size * 2 + 1; y++)
            {
                for (int x = 0; x < size * 2 + 1; x++)
                {
                    vectors[(size * 2 + 1) * y + x] = new Vector2Int(x - size, y - size);
                }
            }
            return vectors;
        }
        /// <summary>
        /// 四角い方向座標を取り出す
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Vector2[] GetRectVectors(int size)
        {
            Vector2[] vectors = new Vector2[(size * 2 + 1) * (size * 2 + 1)];
            for (int y = 0; y < size * 2 + 1; y++)
            {
                for (int x = 0; x < size * 2 + 1; x++)
                {
                    vectors[(size * 2 + 1) * y + x] = new Vector2(x - size, y - size);
                }
            }
            return vectors;
        }

        /// <summary>
        /// 円状の点座標を取り出す
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Vector2Int[] GetCircleVectors(int size)
        {
            List<Vector2Int> vectors = new List<Vector2Int>();
            for (int y = 0; y < size * 2 + 1; y++)
            {
                for (int x = 0; x < size * 2 + 1; x++)
                {
                    int vY = y - size;
                    int vX = x - size;

                    int range = vY * vY + vX * vX;
                    if (range < size * size)
                    {
                        vectors.Add(new Vector2Int(vX, vY));
                    }
                }
            }
            return vectors.ToArray();
        }
    }

}