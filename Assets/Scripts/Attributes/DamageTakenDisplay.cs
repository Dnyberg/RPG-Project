using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class DamageTakenDisplay : MonoBehaviour
    {
        // Health health;

        // private void Awake()
        // {
        //     health = GameObject.FindWithTag("Player").GetComponent<Health>();
        // }

        // private void Update()
        // {
        //     if (health.takesDamage)
        //     {
        //         StartCoroutine(ShowDamageTaken());
        //     }

        // }

        // private void ShowHealthPercentage()
        // {
        //     GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
        // }

        // public IEnumerator ShowDamageTaken()
        // {
        //     health.takesDamage = false;
        //     GetComponent<Text>().text = String.Format("{0:0}", health.GetDamageTaken());
        //     yield return new WaitForSeconds(1);
        //     GetComponent<Text>().text = String.Format("{0:0}", "");

        // }
    }
}