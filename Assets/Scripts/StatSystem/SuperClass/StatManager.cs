using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StatSystem.SuperClass
{
    public class StatManager : MonoBehaviour,IStatManager
    {
        [SerializeField] private List<StatPresenter> statPresenter;

        private Dictionary<string, StatPresenter> _mappedStatPresent;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            _mappedStatPresent = new Dictionary<string, StatPresenter>();
            foreach (var stat in statPresenter)
            {
                _mappedStatPresent.Add(stat.statName, stat);
            }
        }
        public StatPresenter GetStatPresenter(string statName)
        {
            return _mappedStatPresent[statName];
        }
    }

    public interface IStatManager
    {
        public StatPresenter GetStatPresenter(string statName);

    }
}
