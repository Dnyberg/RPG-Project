using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffect = null;

        float damage = 0;
        Vector3 randomPosition;
        Health target = null;
        new CapsuleCollider collider;

        private void Start()
        {
            collider = GetComponent<CapsuleCollider>();
            randomPosition = new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.2f, 0.6f), 0);

            transform.LookAt(GetAimLocation());
        }

        void Update()
        {
            if (target == null) return;
            if (isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2 + randomPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target) return;
            if (target.IsDead()) return;
            target.TakeDamage(damage);

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, transform.rotation);
            }
            Destroy(gameObject);

            
            //StartCoroutine(DealDamage());

        }
        /*private IEnumerator DealDamage()
        {
            float waitTime;
            target.TakeDamage(damage);
            collider.enabled = false;
            if (target.healthPoints < 0.1f)
            {
                waitTime = 0f;
            }
            else
            {
                waitTime = 1f;
            }
            yield return new WaitForSeconds(waitTime);
            Destroy(gameObject);
        }*/
    }
}
