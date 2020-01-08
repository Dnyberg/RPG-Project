using UnityEngine;

namespace RPG.ObjectTransform
{
    public class IgnoreParentTransform : MonoBehaviour
    {
        Quaternion startRotation;
        private void Awake()
        {
            startRotation = transform.rotation;

        }
        void Update()
        {
            transform.rotation = startRotation;
        }
    }
}