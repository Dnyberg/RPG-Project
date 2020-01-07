using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Resources
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private void Update()
        {
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