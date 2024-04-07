using UnityEngine;

namespace Scripts.StatSystem.SuperClass
{
    public abstract class StatPresenter : MonoBehaviour 
    {
        [SerializeField] protected StatModel statModel;
        [SerializeField] protected internal string statName;

        protected virtual void Start()
        {
            statModel.StatModifier += OnStatChange;
        }
        protected virtual void OnDestroy()
        {
            statModel.StatModifier -= OnStatChange;
        }
        

        private void FixedUpdate()
        {
            LoopCallUpdateView();
        }

        protected abstract void SingleCallUpdateView();
        protected abstract void LoopCallUpdateView();

        public void SetMaxStat(float newMax)
        {
            statModel.IncreaseMaxStat(newMax);
        }

        public float GetCurrentStat()
        {
            return statModel.pCurrentStat;
        }
        public void DecreaseStat(float amount)
        {
            statModel.DecreaseStat(amount);
        }
        
        public void IncreaseStat(float amount)
        {
            statModel.IncreaseStat(amount);
        }
        
        public void RestoreStat()
        {
            statModel.RestoreStat();
        }

        private void OnStatChange()
        {
            SingleCallUpdateView();
        }

        #region Test

        
        public void DecreaseCertainStat()
        {
            statModel.DecreaseStat(5f);
        }
        
        public void IncreaseCertainStat()
        {
            statModel.IncreaseStat(5f);
        }
        
        public void RestoreCertainStat()
        {
            statModel.RestoreStat();
        }
        
        public void SetCertainMaxStat()
        {
            statModel.IncreaseMaxStat(30);
        }
        

        #endregion
        


    }
}