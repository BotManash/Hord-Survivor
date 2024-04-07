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
        [SerializeField] private Transform bulletPoint;

        private float _currentTime;

        
        public SimpleWeapon(WeaponData weaponDataRef)
        {
            weaponData = weaponDataRef;
        }

        private void Start()
        {
            _currentTime = 60f / weaponData.fireRate;
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
            },weaponData.bulletSpeed);
            
            _currentTime = 0;
        }

        private void GetCurrentFireRate()
        {
            if (_currentTime < 60f / weaponData.fireRate)
            {
                _currentTime += Time.deltaTime;
            }
        }

        private void Shoot(Action callback,int bulletSpeed)
        {
            var tempBullet = Instantiate(bullet, bulletPoint);
            tempBullet.transform.position = bulletPoint.position;
            tempBullet.transform.rotation=Quaternion.Euler(Vector2.zero);
            tempBullet.transform.SetParent(null);
            tempBullet.gameObject.SetActive(true);
            tempBullet.Shoot(bulletSpeed);
            callback?.Invoke();
        }

       
    }

    [Serializable]
    public class WeaponData
    {
        public int weaponId;
        public float fireRate;
        public int bulletSpeed;
    }
}

