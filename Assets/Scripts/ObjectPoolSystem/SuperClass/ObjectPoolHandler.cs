using System.Collections.Generic;
using Scripts.Extras;
using UnityEngine;

namespace Scripts.ObjectPoolSystem
{
    //base for handling all Pool 
    public class ObjectPoolHandler : SingletonObjects<ObjectPoolHandler>
    {
        private Dictionary<string, Pool> _mappedObjectPoolList;

        private void Start()
        {
            InitializeDictionary();
        }
       
        private void InitializeDictionary()
        {
            _mappedObjectPoolList = new Dictionary<string, Pool>();
            var pools = FindObjectsOfType<Pool>();
            Debug.LogWarning($"Found {pools.Length} amount of pool Objects");
            foreach (var pool in pools)
            {
                _mappedObjectPoolList.Add(pool.poolName, pool);
                Debug.LogWarning($"Adding {pool.gameObject.name} ");
            }
            
        }

        public GameObject GetPoolItem(string poolName)
        {
            return _mappedObjectPoolList[poolName].GetPoolItem();
        }
    }
}