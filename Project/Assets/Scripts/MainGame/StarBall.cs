using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Player
{
    public class StarBall : MonoBehaviour
    {
        public Rigidbody rigid { get; private set; }

        private void Start()
        {
            rigid = GetComponentInParent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            HitObject.HitObject hitObject = collision.gameObject.GetComponent<HitObject.HitObject>();
            if (hitObject == null) return;
            hitObject.Hit(this);
        }
    }
}