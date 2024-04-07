using System;
using UnityEngine;

namespace Scripts.Weapon.Extras
{
    public class WeaponDetection : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask;
        [SerializeField] private Transform hitPoint;
        [SerializeField] private SpriteRenderer laser;
        [SerializeField] private bool useLaser;
        private RaycastHit2D hit { get; set; }

        public bool HasDetectedEnemy;

        private void Start()
        {
            hit = new RaycastHit2D();
            if (useLaser)
            {
                laser.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            hit = Physics2D.Raycast(hitPoint.transform.position,
                hitPoint.right,Mathf.Infinity,hitMask);
            HasDetectedEnemy = hit;
            
            if (useLaser)
            {
                laser.color = hit ? Color.blue : Color.green;
            }
           
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(hitPoint.transform.position, hitPoint.right*100f);
        }
    }
}

