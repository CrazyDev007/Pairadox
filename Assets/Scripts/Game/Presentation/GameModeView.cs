using Game.Application.Interfaces;
using Game.Domain.Entities;
using Game.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation
{
    public class GameModeView : MonoBehaviour
    {
        [SerializeField] private ToggleGroup toggleGroup;
        private ISaveService _saveService;


        public void Init(ISaveService saveService) => _saveService = saveService;

        private void Start()
        {
            var toggles = toggleGroup.GetComponentsInChildren<Toggle>(true);
            var gameModeConfig = _saveService.LoadGameMode();
            foreach (var toggle in toggles)
            {
                var toggleView = toggle.GetComponent<ToggleView>();
                if (toggleView.GameMode == gameModeConfig.gameMode)
                {
                    toggle.isOn = true;
                }
            }
        }

        public void OnClickToggle(ToggleView toggleView)
        {
            if (toggleView.IsOn)
            {
                _saveService.SaveGameMode(new GameModeConfig(toggleView.GameMode, toggleView.rowCount,
                    toggleView.columnCount));
            }
        }
    }
}