using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        Transform target;
        float timeSinceLaastAttack = 0;

        [SerializeField] float weaponDamage = 10f;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;


        private void Update()
        {

            timeSinceLaastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
                
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLaastAttack >= timeBetweenAttacks)
            {
                // This will trigger the Hit() event.
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLaastAttack = 0f;

            }
        }

        // Animation Event. Called from animation.
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }


    }
}
