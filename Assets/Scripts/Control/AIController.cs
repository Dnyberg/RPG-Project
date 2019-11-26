using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        Health health;
        GameObject player;
        Mover mover;
        //CapsuleCollider capsuleCollider;

        Vector3 guardPosition;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
            //capsuleCollider = GetComponent<CapsuleCollider>();
            mover = GetComponent<Mover>();

            guardPosition = transform.position;
        }

        void Update()
        {
            if (health.IsDead())
            {
                //capsuleCollider.enabled = !health.IsDead();
                GetComponent<Animator>().enabled = !health.IsDead();
                return;
            }

            
            if (InAttackkRangeOfPlayer()  && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                mover.StartMoveAction(guardPosition);
            }

        }

        private bool InAttackkRangeOfPlayer()
        {
            
            float distanceToPlayer =  Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        //Called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
