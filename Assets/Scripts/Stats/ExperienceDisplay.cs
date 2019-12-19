using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experinece;

        private void Awake()
        {
            experinece = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        private void Update()
        {
            GetComponent<Text>().text = String.Format("{0:0}xp", experinece.GetPoints());
        }
    }
}