using System;
using Game.Domain.Entities;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Infrastructure.Views
{
    public class ToggleView : MonoBehaviour, IToggleView
    {
        [SerializeField] private GameMode mode;
        private Toggle _toggle;

        public GameMode GameMode => mode;
        public bool IsOn => _toggle.isOn;
        public int rowCount;
        public int columnCount;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        public void SetToggleAction(Action action)
        {
            _toggle.onValueChanged.AddListener(isOn => action());
        }
    }
}