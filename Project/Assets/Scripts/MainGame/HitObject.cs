using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.HitObject
{
    public class HitObject : MonoBehaviour
    {

        public Rigidbody rigid { get; private set; }

        private void Start()
        {
            rigid = GetComponentInParent<Rigidbody>();
        }

        public virtual void Hit(Player.StarBall hitParent)
        {
            Destroy(this.gameObject);
            Wave.WaveFactory.Instance.Create(transform.position, Quaternion.identity);
        }
    }
}
