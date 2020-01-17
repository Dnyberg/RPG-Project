using UnityEngine;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;
using GameDevTV.Utils;
using UnityEngine.Events;

namespace RPG.Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {

        //[SerializeField] float regenerationPercentage = 70;
        [SerializeField] TakeDamageEvent takeDamage;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }

        LazyValue<float> healthPoints;
        float damageTaken;

        bool isDead = false;


        private void Awake()
        {
            healthPoints = new LazyValue<float>(GetInitialHealth);
        }

        private float GetInitialHealth()
        {
            return GetHealthWithStamina();
        }



        private void Start()
        {
            healthPoints.ForceInit();
        }

        private void OnEnable()
        {
            GetComponent<BaseStats>().onLevelUp += RegenerateHealth;
        }

        private void OnDisable()
        {
            GetComponent<BaseStats>().onLevelUp -= RegenerateHealth;
        }


        public bool IsDead()
        {
            return isDead;
        }


        public void TakeDamage(GameObject instigator, float damage)
        {
            print($"<color=yellow> {gameObject.name} </color>" + " took " + $"<color=red> {damage} </color>" + " damage");

            healthPoints.value = Mathf.Max(healthPoints.value - damage, 0);
            damageTaken = damage;
            takeDamage.Invoke(damage);

            if (healthPoints.value == 0)
            {
                Die();
                AwardExperience(instigator);
            }
        }

        public float GetDamageTaken()
        {
            return damageTaken;
        }

        public float GetHealtPoints()
        {
            return healthPoints.value;
        }

        private float GetHealthWithStamina()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health) + GetComponent<BaseStats>().GetStat(Stat.Stamina);
        }

        public float GetMaxHealthPoints()
        {
            return GetHealthWithStamina();
        }

        public float GetPercentage()
        {
            return 100 * GetFraction();
        }

        public float GetFraction(){
            return healthPoints.value / GetHealthWithStamina();
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

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.ExperienceReward));
        }

        private void RegenerateHealth()
        {
            //float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage / 100);
            //healthPoints = Mathf.Max(healthPoints, regenHealthPoints);
            healthPoints.value = GetHealthWithStamina();
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints.value = (float)state;

            if (healthPoints.value <= 0)
            {
                Die();
            }
        }

    }
}
