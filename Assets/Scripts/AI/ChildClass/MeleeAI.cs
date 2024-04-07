using System.Collections;
using Scripts.AI.SuperClass;
using Scripts.StatSystem.SuperClass;
using UnityEngine;

namespace Scripts.AI.ChildClass
{
    public class MeleeAI : SimpleAI
    {
        
        protected override void Attack(RaycastHit2D hit)
        {
            hit.collider.gameObject.GetComponent<StatManager>().GetStatPresenter("Health").DecreaseStat(aiData.damage);
            Debug.Log("Attack");
        }
        
    }
}

