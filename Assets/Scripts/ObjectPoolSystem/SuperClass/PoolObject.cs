using System;
using UnityEngine;

namespace Scripts.ObjectPoolSystem
{
    
    public class PoolObject : MonoBehaviour
    {
        public Pool myPool { get; set; }
        
        public void ResetPoolObject()
        {
            myPool.ReturnObjectToPool(this.gameObject);
        }
    }
}