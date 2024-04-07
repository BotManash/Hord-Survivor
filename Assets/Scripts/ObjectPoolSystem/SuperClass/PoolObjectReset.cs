using System.Collections;
using UnityEngine;

namespace Scripts.ObjectPoolSystem
{
    public class PoolObjectReset : MonoBehaviour
    {
        [SerializeField] private float delayResetTime = 3f;
        private PoolObject poolObject=>GetComponent<PoolObject>();
        private Coroutine _cDelayReset;

        private void OnEnable()
        {
            _cDelayReset = _cDelayReset != null ? null : StartCoroutine(EDelayReset());
        }

        private void OnDisable()
        {
            if (_cDelayReset != null)
            {
                StopCoroutine(_cDelayReset);
                _cDelayReset = null;
            }
        }
        private void ResetPoolObject()
        {
            poolObject.myPool.ReturnObjectToPool(this.gameObject);
        }

        private IEnumerator EDelayReset()
        {
            yield return new WaitForSeconds(delayResetTime);
            ResetPoolObject();
        }
    }
}