﻿using System;
using Scripts.Global;
using Scripts.StatSystem.SuperClass;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(ConstantKey.EnemyTag))
            {
                return;
            }
            other.GetComponent<StatManager>().GetStatPresenter("Health").
                DecreaseStat(bulletData.bulletDamage);
            Destroy(this.gameObject);
        }
    }

    [Serializable]
    public class BulletData
    {
        public int bulletId;
        public int bulletDamage;
    }
}