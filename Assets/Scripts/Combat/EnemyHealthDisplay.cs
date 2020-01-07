using System;
using RPG.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;
        Health health;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                GetComponent<Text>().text = "N/A";
                return;
            }
            health = fighter.GetTarget();
            ShowHealthPoints();
        }

        private void ShowHealthPercentage()
        {
            GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
        }

        private void ShowHealthPoints()
        {
            GetComponent<Text>().text = String.Format("{0:0}/{1:0}", health.GetHealtPoints(), health.GetMaxHealthPoints());
        }
    }
}