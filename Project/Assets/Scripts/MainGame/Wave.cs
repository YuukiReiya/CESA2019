using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Wave
{
    public class Wave : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;
        public float waveTime;
        public float waveSpeed;

        [SerializeField]
        private float addForcePower = 400f;
        [SerializeField]
        private float torquePower = 150f;

        private int CIRCLE_SHARP = 100;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(WaveUpdate());
        }

        IEnumerator WaveUpdate()
        {
            float count = 0;
            float waveSize = 0;
            while (count < waveTime)
            {
                count += Time.deltaTime;
                waveSize += waveSpeed * Time.deltaTime;
                lineRenderer.positionCount = CIRCLE_SHARP;
                lineRenderer.SetPositions(DAGASIScripts.ObjectArrangement.CircleDeployXY(CIRCLE_SHARP - 1, waveSize));
                lineRenderer.SetPosition(CIRCLE_SHARP - 1, Vector3.up * waveSize);

                Collider[] hits = Physics.OverlapSphere(transform.position, waveSize);
                foreach (var hit in hits)
                {
                    var v = hit.GetComponentInParent<Player.StarBall>();
                    if (v == null) continue;
                    Vector3 vec = (v.transform.position - transform.position).normalized;
                    v.rigid.AddForce(vec * addForcePower);

                    Vector3 t = new Vector3(vec.z, vec.y, -vec.x);
                    v.rigid.AddTorque(t * torquePower, ForceMode.Force);
                }

                yield return null;
            }
            Destroy(this.gameObject);
        }
        public void SetColor(Color color)
        {
            Gradient gradient = new Gradient();
            gradient.colorKeys = new GradientColorKey[] { new GradientColorKey(color, 0f) };
            lineRenderer.colorGradient = gradient;
        }

    }
}
