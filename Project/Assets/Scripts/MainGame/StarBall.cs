using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Player
{
    public class StarBall : MonoBehaviour
    {
        public Rigidbody rigid { get; private set; }

        [SerializeField]
        float maxSpeed = 10f;
        [SerializeField]
        float minSpeed = 1f;
        private void Start()
        {
            rigid = GetComponentInParent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(rigid.velocity.sqrMagnitude >= maxSpeed * maxSpeed)
            {
                rigid.velocity = rigid.velocity.normalized * maxSpeed;
            }
            if (rigid.velocity.sqrMagnitude <= minSpeed * minSpeed)
            {
                rigid.velocity = rigid.velocity.normalized * minSpeed;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            HitObject.HitObject hitObject = collision.gameObject.GetComponent<HitObject.HitObject>();
            if (hitObject == null) return;
            hitObject.Hit(this);
        }
    }
}