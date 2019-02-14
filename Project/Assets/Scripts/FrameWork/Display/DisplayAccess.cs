using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    public class DisplayAccess : OnSceneSingleton<DisplayAccess>
    {

        [SerializeField]
        Camera accessCamera;

#if UNITY_EDITOR
        private void Update()
        {
            RaycastHit[] hits = CheckRayHitAll();

            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(i + " : hitName = " + hits[i].transform.name);
            }
        }
#endif
        public bool CheckRayHit(out RaycastHit hit)
        {
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit);
        }
        public RaycastHit[] CheckRayHitAll()
        {
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.RaycastAll(ray);
        }
        public bool CheckRayHit(out RaycastHit hit, Transform transform)
        {
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit) && hit.transform == transform;
        }
        public bool CheckRayHit(out RaycastHit hit, LayerMask layerMask, Transform transform)
        {
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, layerMask) && hit.transform == transform;
        }
        public bool CheckRayHit(int layerMask, Transform transform)
        {
            RaycastHit hit;
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, 10000, layerMask) && hit.transform == transform;
        }
        public bool CheckRayHit2D(int layerMask, Transform transform)
        {
            RaycastHit2D hit;
            Ray ray = accessCamera.ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.Raycast(ray.origin, ray.direction, 10000, layerMask);
            if (hit)
            {
                return hit.transform == transform;
            }
            return false;
        }
        public bool CheckRayHit2DTouch(int layerMask, Transform transform)
        {
            RaycastHit2D hit;
            Ray ray = accessCamera.ScreenPointToRay(Input.GetTouch(0).position);

            hit = Physics2D.Raycast(ray.origin, ray.direction, 10000, layerMask);
            if (hit)
            {
                return hit.transform == transform;
            }
            return false;
        }

        public Vector2 GetMousePos()
        {
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            return accessCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        public Vector2 GetMousePosInWindow()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
            mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

            // マウス位置座標をスクリーン座標からワールド座標に変換する
            return accessCamera.ScreenToWorldPoint(mousePos);
        }

        public bool GetTouchPos(out Vector3 vector3)
        {
            if (Input.touchCount == 0)
            {
                vector3 = Vector3.zero;
                return false;
            }
            vector3 = accessCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            return true;
        }
    }

}