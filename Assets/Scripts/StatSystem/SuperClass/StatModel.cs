using System;
using UnityEngine;


namespace Scripts.StatSystem.SuperClass
{
    public class StatModel : MonoBehaviour

    {
        public event Action StatModifier;

        [SerializeField] private float minStat;
        [SerializeField] private float maxStat;
        [SerializeField] private float currentStat;

        public float pMinStat
        {
            get => minStat;
            set => minStat = value;
        }

        public float pMaxStat
        {
            get => maxStat;
            set => maxStat = value;
        }

        public float pCurrentStat
        {
            get => currentStat;
            private set => currentStat = value;
        }

        public void IncreaseMaxStat(float newMax)
        {
            maxStat = newMax;
            currentStat = newMax;
            StatModifier?.Invoke();
        }


        public void IncreaseStat(float increment)
        {
            pCurrentStat += increment;
            pCurrentStat = Mathf.Clamp(pCurrentStat, pMinStat, pMaxStat);
            StatModifier?.Invoke();
        }

        public void DecreaseStat(float increment)
        {
            pCurrentStat -= increment;
            pCurrentStat = Mathf.Clamp(pCurrentStat, pMinStat, pMaxStat);
            StatModifier?.Invoke();
        }

        public void RestoreStat()
        {
            pCurrentStat = pMaxStat;
            StatModifier?.Invoke();
        }
    }
}