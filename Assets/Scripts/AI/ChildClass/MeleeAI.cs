using System.Collections;
using Scripts.AI.SuperClass;
using UnityEngine;

namespace Scripts.AI.ChildClass
{
    public class MeleeAI : SimpleAI
    {
        
        protected override void Attack()
        {
            Debug.Log("Attack");
        }
        
    }
}

