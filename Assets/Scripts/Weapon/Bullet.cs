using System;
using UnityEngine;

namespace Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData bulletData;
        [SerializeField] private Rigidbody2D rb;
        
        public void Shoot(int bulletSpeed)
        {
            rb.AddForce(Vector2.right * bulletSpeed);
        }
    }

    [Serializable]
    public class BulletData
    {
        public int bulletId;
        public int bulletDamage;
    }
}