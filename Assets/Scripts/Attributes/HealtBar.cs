using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Attributes
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] Health healthComponent = null;
        [SerializeField] RectTransform foreground = null;
        [SerializeField] CanvasGroup rootCanvas = null;
        [SerializeField] float fadeAwayRate = 1f;
        [SerializeField] float fadeInRate = 5f;

        void Update()
        {
            foreground.localScale = new Vector3(healthComponent.GetFraction(), 1, 1);

            FadeOut();
            FadeIn();
        }

        public void FadeIn()
        {
            if (Mathf.Approximately(healthComponent.GetFraction(), 1))
            {
                rootCanvas.alpha = 0;
                return;
            }
            else
            {
                rootCanvas.alpha += fadeInRate * Time.deltaTime;
                return;
            }
        }

        public void FadeOut()
        {
            if (healthComponent.GetHealtPoints() == 0)
            {
                rootCanvas.alpha -= fadeAwayRate * Time.deltaTime;
                return;
            }
        }
    }
}
