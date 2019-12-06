using UnityEngine;
using System.Collections;
using RPG.Saving;

namespace RPG.Core
{
    public class Health : MonoBehaviour, ISaveable
    {

        [SerializeField] float healthPoints = 100f;

        bool isDead = false;


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

        private void Die()
        {
            if(isDead) return;

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
