using System;
using UnityEngine;

namespace Scripts.Weapon.Extras
{
    public class WeaponDetection : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask;
        [SerializeField] private Transform hitPoint;
        [SerializeField] private SpriteRenderer laser;
        private RaycastHit2D hit { get; set; }

        public bool HasDetectedEnemy;

        private void Start()
        {
            hit = new RaycastHit2D();
        }

        private void Update()
        {
            hit = Physics2D.Raycast(hitPoint.transform.position,
                hitPoint.right,Mathf.Infinity,hitMask);
            if (hit)
            {
                //laser.color = Color.blue;
                HasDetectedEnemy = true;
            }
            else
            {
                //laser.color=Color.green;
                HasDetectedEnemy = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(hitPoint.transform.position, hitPoint.right*100f);
        }
    }
}

