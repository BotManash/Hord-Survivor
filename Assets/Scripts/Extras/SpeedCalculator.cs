using System;
using UnityEngine;

namespace Scripts.Global
{
    public class SpeedCalculator : MonoBehaviour
    {
        public float speed;
        private Vector2 _initialPos;
        private Vector2 _finalPos;

        private void Start()
        {
            _initialPos = Vector2.zero;
        }

        private void Update()
        {
            _initialPos = transform.position;
            speed = Vector3.Distance(_initialPos, _finalPos) / Time.deltaTime;
        }

        private void LateUpdate()
        {
            _finalPos = transform.position;
        }
    }
}

