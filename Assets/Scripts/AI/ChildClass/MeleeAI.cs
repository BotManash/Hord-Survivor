using System.Collections;
using Scripts.AI.SuperClass;
using Scripts.StatSystem.SuperClass;
using UnityEngine;

namespace Scripts.AI.ChildClass
{
    public class MeleeAI : SimpleAI
    {
        
        [SerializeField] private GameObject hitObject;
        protected override void AttackBehavior(RaycastHit2D hit)
        {
            hitObject.SetActive(HasDetect());
            Debug.Log("Attack");
        }

        protected override void DeadBehavior()
        {
            hitObject.SetActive(false);
            Invoke(nameof(OnDead),1f);
        }

        protected override void NoDetectionBehavior()
        {
            hitObject.SetActive(false);
        }

        private void OnDead()
        {
            this.gameObject.SetActive(false);
        }
    }
}

