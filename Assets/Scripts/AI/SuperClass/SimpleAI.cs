using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.AI.SuperClass
{
    public abstract class SimpleAI : MonoBehaviour
    {
        [SerializeField] protected AIProfile aiData;
        [SerializeField] protected Animator anim;


        [SerializeField] protected Transform detectionPoint;
        [SerializeField] protected float detectionRange;
        [SerializeField] protected LayerMask detectionMask;
        
        [SerializeField] private GameObject hitObject;
        protected int WalkId = Animator.StringToHash("Walk");
        protected int DieId = Animator.StringToHash("Dead");
        protected int GetHitId = Animator.StringToHash("Hit");
        protected int AttackId = Animator.StringToHash("Attack");

        private float _currentRate=0f;
        private void FixedUpdate()
        {
            GetAttackRate();
            if (!HasDetect())
            {
                hitObject.SetActive(false);
                Move();
                return;
            }

            if (_currentRate < 60f / aiData.attackRate) 
            {
                return;
            }
            Attack();
            hitObject.SetActive(true);
            _currentRate = 0f;


        }
        
        private bool HasDetect()
        {
            return Physics2D.Raycast(transform.position, -Vector2.right, detectionRange, detectionMask);
        }
        
        private void Move()
        {
            transform.Translate(Vector2.left * (aiData.speed * Time.fixedDeltaTime),Space.World);
        }

        private void GetAttackRate()
        {
            if (_currentRate < 60f/aiData.attackRate)
            {
                _currentRate += Time.fixedDeltaTime;
            }
        }

        protected abstract void Attack();
        

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
        [Tooltip("attack Rate per Minute")]
        public float attackRate;
    }
}

