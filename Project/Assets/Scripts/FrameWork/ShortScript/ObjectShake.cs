using System.Collections;
using UnityEngine;

namespace DAGASIScripts
{

    public class ObjectShake : MonoBehaviour
    {
        [SerializeField]
        float shake_decay = 0.002f;
        [SerializeField]
        float coef_shake_intensity = 0.3f;
        [SerializeField]
        float power = 1;

        Vector3 originPosition;
        Quaternion originRotation;
        float shake_intensity;

        [SerializeField]
        bool lockRotateX;
        [SerializeField]
        bool lockRotateY;
        [SerializeField]
        bool lockRotateZ;

        public void StartShakeColl()
        {
            StartCoroutine(Shake());
        }
        private IEnumerator Shake()
        {
            originPosition = transform.position;
            originRotation = transform.rotation;
            shake_intensity = coef_shake_intensity;
            while (shake_intensity > 0)
            {
                Quaternion q = transform.rotation;
                transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
                transform.rotation = new Quaternion(
                                                 originRotation.x + Random.Range(-shake_intensity, shake_intensity) * power,
                                                 originRotation.y + Random.Range(-shake_intensity, shake_intensity) * power,
                                                 originRotation.z + Random.Range(-shake_intensity, shake_intensity) * power,
                                                 originRotation.w + Random.Range(-shake_intensity, shake_intensity) * power);
                q.x = lockRotateX ? q.x : transform.rotation.x;
                q.y = lockRotateY ? q.y : transform.rotation.y;
                q.z = lockRotateZ ? q.z : transform.rotation.z;
                transform.rotation = q;

                shake_intensity -= shake_decay;
                yield return new WaitForFixedUpdate();
            }
            transform.position = originPosition;
            transform.rotation = originRotation;
        }

        public bool IsShakeEnd()
        {
            return shake_intensity <= 0;
        }
    }
}