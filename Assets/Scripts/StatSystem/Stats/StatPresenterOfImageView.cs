using System.Globalization;
using Scripts.StatSystem.SuperClass;
using UnityEngine;
using UnityEngine.UI;

namespace Script.StatSystem.Stats
{
    public class StatPresenterOfImageView : StatPresenter
    {
        [SerializeField] private Image statImageIconSlider;
        
        protected override void SingleCallUpdateView()
        {
            statImageIconSlider.fillAmount = statModel.pCurrentStat / statModel.pMaxStat;
        }

        protected override void LoopCallUpdateView()
        {
        }
    }
}