using UnityEngine;
using System.Collections;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;

namespace RPG.Resources
{
    public class Health : MonoBehaviour, ISaveable
    {

        public float healthPoints = 100f;

        bool isDead = false;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetHealth();
        }

        public bool IsDead()
        {
            return isDead;
        }


        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print($"<color=yellow> {gameObject.name} </color>" + " health is " + $"<color=red> {healthPoints} </color>");
            if (healthPoints == 0)
            {
                Die();
            }
        }

        public float GetPercentage()
        {
            return 100 * (healthPoints / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;

            GetComponent<ActionScheduler>().CancelCurrentAction();

            // For objects that miss animator. 
            if (!GetComponent<Animator>()) return;

            GetComponent<Animator>().SetTrigger("die");

        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if (healthPoints == 0)
            {
                Die();
            }
        }
    }
}
