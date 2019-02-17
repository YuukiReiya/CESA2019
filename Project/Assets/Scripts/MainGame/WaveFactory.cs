using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DAGASIScripts;

namespace MainGame.Wave
{
    public class WaveFactory : SimpleFactory<Wave>
    {
        [SerializeField]
        private Wave prefab;

        public override Wave GetPrefab()
        {
            return prefab;
        }

        protected override void Reset()
        {
            gameObject.name = typeof(WaveFactory).Name;
        }
    }
}
