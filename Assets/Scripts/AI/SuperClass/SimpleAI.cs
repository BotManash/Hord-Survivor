using System;
using System.Collections;
using Scripts.AI.ChildClass;
using Scripts.ObjectPoolSystem;
using Scripts.StatSystem.SuperClass;
using UnityEngine;

namespace Scripts.AI.SuperClass
{
    public abstract class SimpleAI : MonoBehaviour,IDamage
    {
        [SerializeField] protected AIProfile aiData;
        [SerializeField] protected Animator anim;


        [SerializeField] protected Transform detectionPoint;
        [SerializeField] protected float detectionRange;
        [SerializeField] protected LayerMask detectionMask;
        
        protected int WalkId = Animator.StringToHash("Walk");
        private readonly int _dieId = Animator.StringToHash("Dead");
        protected int GetHitId = Animator.StringToHash("Hit");
        private readonly int _attackId = Animator.StringToHash("Attack");

        [SerializeField] protected StatManager statManager;

        [SerializeField] protected GameObject deadParticle;
        
        
        private RaycastHit2D hit { get; set; }

        private float _currentRate=0f;
        private bool _isDead;
        private Coroutine _cBehaviourRoutine;

        protected virtual void Start()
        {
            if (_cBehaviourRoutine != null)
            {
                _cBehaviourRoutine = null;
            }
            else
            {
                _cBehaviourRoutine = StartCoroutine(ERunBehavior());
            }
           
        }

        protected virtual void OnDisable()
        {
            if (_cBehaviourRoutine != null)
            {
                StopCoroutine(_cBehaviourRoutine);
                _cBehaviourRoutine = null;
            }
            deadParticle.SetActive(false);
        }

        private IEnumerator ERunBehavior()
        {
            while (!_isDead)
            {
                Behavior();
                yield return new WaitForFixedUpdate();
            }
        }
        
        private void Behavior()
        {
            var currentStat = statManager.GetStatPresenter("Health").GetCurrentStat();
            if ( currentStat<= 0f)
            {
                anim.SetBool(_dieId,true);
                this.GetComponent<BoxCollider2D>().enabled = false;
                DeadBehavior();
                _isDead = true;
                return;
            }
            GetAttackRate();
            if (!HasDetect())
            {
                NoDetectionBehavior();
                Move();
                return;
            }

            if (_currentRate < 60f / aiData.attackRate) 
            {
                return;
            }
            anim.SetTrigger(_attackId);
            hit.collider.gameObject.GetComponent<StatManager>().GetStatPresenter("Health").DecreaseStat(aiData.damage);
            AttackBehavior(hit);
            _currentRate = 0f;
        }
        
        protected bool HasDetect()
        {
            return hit=Physics2D.Raycast(transform.position, -Vector2.right, detectionRange, detectionMask);
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

        protected abstract void AttackBehavior(RaycastHit2D hit);
        protected abstract void DeadBehavior();
        protected abstract void NoDetectionBehavior();
        

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(detectionPoint.transform.position, Vector2.left * detectionRange);
        }

        public void GetDamage(int damage)
        {
            statManager.GetStatPresenter("Health").
                DecreaseStat(damage);
            var hitParticle = ObjectPoolHandler.getInstance.GetPoolItem("Hit");
            var myTransform = this.transform;
            hitParticle.transform.SetParent(myTransform);
            hitParticle.transform.position = myTransform.position;
            hitParticle.transform.rotation=Quaternion.Euler(Vector2.zero);
            hitParticle.SetActive(true);
        }
    }

    [Serializable]
    public class AIProfile
    {
        public string Name;
        public int speed;
        public int damage;
        [Tooltip("attack Rate per Minute")]
        public float attackRate;
    }
}

