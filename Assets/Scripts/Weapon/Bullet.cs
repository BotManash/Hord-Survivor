using System;
using Scripts.AI.ChildClass;
using Scripts.Global;
using Scripts.ObjectPoolSystem;
using Scripts.StatSystem.SuperClass;
using UnityEngine;

namespace Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData bulletData;
        [SerializeField] private Rigidbody2D rb;

        private PoolObject poolObject => GetComponent<PoolObject>();
        

        public void Shoot(int bulletSpeed)
        {
            rb.AddForce(Vector2.right * bulletSpeed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(ConstantKey.EnemyTag))
            {
                return;
            }

            if (other.TryGetComponent(out IDamage damage))
            {
                damage.GetDamage(bulletData.bulletDamage);
            }
            poolObject.ResetPoolObject();
        }
    }

    [Serializable]
    public class BulletData
    {
        public int bulletId;
        public int bulletDamage;
    }
}