using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.ObjectPoolSystem
{
   [CreateAssetMenu(menuName = "ObjectPool/PoolProfile")]
    //profile containing all required object
    public  class PoolObjectProfile: ScriptableObject
    {
        public string objectName;
        public GameObject referenceInstanceObject;
    }
}