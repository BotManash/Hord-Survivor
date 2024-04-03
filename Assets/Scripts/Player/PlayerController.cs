using System;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private Vector2 minMaxXPos;
        [SerializeField] private Vector2 minMaxYPos;

        private Vector2 _dir;


        private void Update()
        {
            GetInput();
        }

        private void LateUpdate()
        {
            Movement();
        }

        private void GetInput()
        {
#if UNITY_EDITOR
            _dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
#endif
        }

        private void Movement()
        {
            var movePos = _dir * (playerSpeed * Time.deltaTime);

            var currentPosition = transform.position;

            var newPosition = new Vector2(Mathf.Clamp(currentPosition.x + movePos.x, minMaxXPos.x, minMaxXPos.y)
                , Mathf.Clamp(currentPosition.y + movePos.y, minMaxYPos.x, minMaxYPos.y));
            transform.position = newPosition;
        }
    }
}