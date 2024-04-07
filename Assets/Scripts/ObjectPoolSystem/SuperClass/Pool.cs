using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.ObjectPoolSystem
{
    
    //base for handling all object in the pool
    public class Pool : MonoBehaviour 
    {
        public string poolName;
        [SerializeField] private int numberOfObjectsToAddInPool;
        [SerializeField] private PoolObjectProfile poolObjectProfile;

        [SerializeField]private Stack<GameObject> pool;

        private void Start()
        {
            pool = new Stack<GameObject>();
            CreatePool();
        }

        private void CreatePool()
        {
            for (var i = 0; i < numberOfObjectsToAddInPool; i++)
            {
                var tempPoolObject = Instantiate(poolObjectProfile.referenceInstanceObject, this.transform);
                tempPoolObject.transform.localPosition = new Vector3(0, 0, 0);
                tempPoolObject.transform.localRotation=Quaternion.Euler(Vector3.zero);
                pool.Push(tempPoolObject.gameObject);
                try
                {
                    tempPoolObject.GetComponent<PoolObject>().myPool = this;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                tempPoolObject.SetActive(false);
            }
            Debug.Log($"No of Pool Object in {poolName}:{pool.Count}");
        }

        public GameObject GetPoolItem()
        {
            //only if pool has not been created
            if (pool.Count == 0)
            {
                Debug.LogError("No Pool Object Detected Creating new Pool Object ...");
                var tempPoolObject = Instantiate(poolObjectProfile.referenceInstanceObject, this.transform, true);
                tempPoolObject.GetComponent<PoolObject>().myPool = this;
                tempPoolObject.transform.position = new Vector3(0, 0, 0);
                tempPoolObject.transform.rotation=Quaternion.Euler(Vector3.zero);
                tempPoolObject.SetActive(true);
                Debug.LogWarning($"Has created new Pool Object with name {tempPoolObject.gameObject.name}");
                return tempPoolObject;
               
            }
            var tempGetPoolObject = pool.Pop();
            tempGetPoolObject.SetActive(true);
            return tempGetPoolObject;
           
        }

        public void ReturnObjectToPool(GameObject poolObject)
        {
            poolObject.transform.SetParent(this.transform);
            poolObject.transform.localPosition = Vector3.zero;
            poolObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            pool.Push(poolObject);
            poolObject.SetActive(false);
        }
        private void OnDestroy()
        {
            pool.Clear();
        }
    }

    
}

