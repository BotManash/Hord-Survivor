using UnityEngine;

namespace Scripts.Extras
{
    public  abstract class SingletonObjects<TDerive> : MonoBehaviour where TDerive : Component
    {
        private static TDerive _instance;
        public static TDerive getInstance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = FindObjectOfType<TDerive>();
                if (_instance == null)
                {
                    Debug.LogError($"No instance with {typeof(TDerive).Name} found in scene ");
                    Debug.LogWarning("Generating new instance");
                    var obj = new GameObject(typeof(TDerive).Name);
                    _instance = obj.AddComponent<TDerive>();
                    obj.SetActive(true);
                    Debug.Log("Instance Generated");
                    DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            RemoveMultipleInstance();
        }

        private void RemoveMultipleInstance()
        {
            if (_instance== null)
            {
                _instance = this as TDerive;
                DontDestroyOnLoad(this.gameObject);
            }
            else 
            {
                Debug.LogError($"Multiple Instance found of this Type {typeof(TDerive).Name}");
                Destroy(this.gameObject);
            }
        }

    }
}
