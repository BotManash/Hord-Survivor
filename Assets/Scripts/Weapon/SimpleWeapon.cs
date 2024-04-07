using System;
using Scripts.Weapon.Extras;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Weapon
{
    public class SimpleWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private WeaponDetection weaponDetection;
        [SerializeField] private UnityEvent onBulletFire;
        [SerializeField] private Bullet bullet;

        private float _currentTime;

        
        public SimpleWeapon(WeaponData weaponDataRef)
        {
            weaponData = weaponDataRef;
        }

        private void Update()
        {
            GetCurrentFireRate();
            if (!weaponDetection.HasDetectedEnemy)
            {
                return;
            }

            if (_currentTime < 60f / weaponData.fireRate)
            {
                return;
            }
            Shoot(() =>
            {
                onBulletFire?.Invoke();
                _currentTime = 0;
            });
            
        }

        private void GetCurrentFireRate()
        {
            if (_currentTime < 60f / weaponData.fireRate)
            {
                _currentTime += Time.deltaTime;
            }
        }

        private void Shoot(Action callback)
        {
            var tempBullet = Instantiate(bullet, null);
            
        }

       
    }

    [Serializable]
    public class WeaponData
    {
        public int weaponId;
        public int damage;
        public float fireRate;
        public int numberOfShots;
        public int speed;
    }
}

