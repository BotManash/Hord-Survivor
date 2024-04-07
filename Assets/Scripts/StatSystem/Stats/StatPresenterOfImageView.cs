using System.Globalization;
using Scripts.StatSystem.SuperClass;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.StatSystem.Stats
{
    public class StatPresenterOfImageView : StatPresenter
    {
        [SerializeField] private Image statImageIconSlider;
        
        protected override void SingleCallUpdateView()
        {
           
        }

        protected override void LoopCallUpdateView()
        {
            var currentFillAmount = statImageIconSlider.fillAmount;
            statImageIconSlider.fillAmount = Mathf.Lerp(currentFillAmount,
                statModel.pCurrentStat / statModel.pMaxStat, Time.fixedDeltaTime*5f);
        }
    }
}