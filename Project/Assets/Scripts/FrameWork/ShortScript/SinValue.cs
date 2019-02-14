using UnityEngine;

namespace DAGASIScripts
{

    [System.Serializable]
    public class SinValue
    {
        [SerializeField, Range(0, 1f)]
        float minValue = 0.5f;
        [SerializeField]
        float sinSpeed;
        float sinValue;

        public void SinCount()
        {
            sinValue += sinSpeed;
        }
        public float GetSinValue()
        {
            return Mathf.Sin(sinValue) * (1 - minValue) / 2 + minValue;
        }
    }

}