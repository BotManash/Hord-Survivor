using System;
using Scripts.Global;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private SpeedCalculator speedCalculator=>GetComponent<SpeedCalculator>();
        [SerializeField] private Animator anim;

        private void Update()
        {
            anim.SetFloat(ConstantKey.PlayerMovementAnimatorVariable,speedCalculator.speed);
        }
    }
}


