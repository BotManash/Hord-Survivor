using System;
using Scripts.StatSystem.SuperClass;
using TMPro;
using UnityEngine;

namespace Script.StatSystem.Stats
{
    public enum ETextType
    {
        Currency,
        PureString,
        FixedPoint
    }
    public class StatPresenterOfTextView : StatPresenter
    {
        [SerializeField] private ETextType textType;
        [SerializeField] private TextMeshProUGUI statTextMesh;

        private string _currentStat;
        protected override void Start()
        {
            base.Start();
            SingleCallUpdateView();
        }
        protected override void SingleCallUpdateView()
        {
            switch (textType)
            {
                case ETextType.Currency:
                    _currentStat = statModel.pCurrentStat.ToString("C0");
                    break;
                case ETextType.PureString:
                    _currentStat = statModel.pCurrentStat.ToString("N0");
                    break;
                case ETextType.FixedPoint:
                    _currentStat = statModel.pCurrentStat.ToString("F1");
                    break;
                default:
                    break;
            }
            statTextMesh.text = _currentStat;
            
            
        }

        protected override void LoopCallUpdateView()
        {
            
        }
    }
}