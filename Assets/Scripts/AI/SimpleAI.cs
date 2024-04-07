using System;
using UnityEngine;

namespace Scripts.AI
{
    public class SimpleAI : MonoBehaviour
    {
        [SerializeField] private AIProfile aiData;
        [SerializeField] private Animator anim;


        [SerializeField] private Transform detectionPoint;
        [SerializeField] private float detectionRange;
        [SerializeField] private LayerMask detectionMask;
        [SerializeField] private bool hasDetected;

        private int _attackId = Animator.StringToHash("Attack");
        private int _walkId = Animator.StringToHash("Walk");
        private int _dieId = Animator.StringToHash("Die");

        private Vector2 _velocity=Vector2.zero;

        private void Update()
        {
            if (HasDetect())
            {
                Attack();
            }
            Move();
        }
        
        private bool HasDetect()
        {
            return hasDetected=Physics2D.Raycast(transform.position, -Vector2.right, detectionRange, detectionMask);
        }
        
        private void Move()
        {
            transform.Translate(Vector2.left * (aiData.speed * Time.deltaTime),Space.World);
        }

        private void Attack()
        {
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(detectionPoint.transform.position, Vector2.left * detectionRange);
        }
    }

    [Serializable]
    public class AIProfile
    {
        public string Name;
        public int speed;
        public int damage;
        public int health;
    }
}

