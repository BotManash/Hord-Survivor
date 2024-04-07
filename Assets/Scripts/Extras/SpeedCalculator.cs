using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Global
{
    public class SpeedCalculator : MonoBehaviour
    {
        
        [SerializeField] private bool calculateSpeed;
        public float speed;

        private void Start()
        {
            StartCoroutine(ECalculateSpeed());
        }

        private IEnumerator ECalculateSpeed()
        {
            while (calculateSpeed)
            {
                var prevPos = transform.position;
                yield return new WaitForFixedUpdate();
                speed = Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime;

            }
        }

    }
}

