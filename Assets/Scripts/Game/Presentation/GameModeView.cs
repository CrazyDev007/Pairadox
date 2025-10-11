using System;
using System.Linq;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using Game.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Presentation
{
    public class GameModeView
    {
        private ISaveService _saveService;
        private Button _btnEasy, _btnEasyMedium, _btnMedium, _btnMediumHard, _btnHard;

        // Define game modes and their configs (adjust row/column as needed)
        private readonly (GameMode mode, int rows, int cols)[] _modes = new[]
        {
            (GameMode.Easy, 3, 2),
            (GameMode.EasyMedium, 4, 3),
            (GameMode.Medium, 4, 4),
            (GameMode.MediumHard, 5, 4),
            (GameMode.Hard, 6, 4)
        };

        public void Init(ISaveService saveService) => _saveService = saveService;

        public void Setup(VisualElement screen)
        {
            // get reference of all 5 buttons
            _btnEasy = screen.Q<Button>("easy");
            _btnEasyMedium = screen.Q<Button>("easyMedium");
            _btnMedium = screen.Q<Button>("medium");
            _btnMediumHard = screen.Q<Button>("mediumHard");
            _btnHard = screen.Q<Button>("hard");

            // clear all button texts
            _btnEasy.text = "";
            _btnEasyMedium.text = "";
            _btnMedium.text = "";
            _btnMediumHard.text = "";
            _btnHard.text = "";

            // load current game mode
            var currentConfig = _saveService.LoadGameMode();

            // set text based on mode
            UpdateButtonText(currentConfig.gameMode);

            // add click event to each button
            _btnEasy.clicked += () => OnClickBtnMode(GameMode.Easy);
            _btnEasyMedium.clicked += () => OnClickBtnMode(GameMode.EasyMedium);
            _btnMedium.clicked += () => OnClickBtnMode(GameMode.Medium);
            _btnMediumHard.clicked += () => OnClickBtnMode(GameMode.MediumHard);
            _btnHard.clicked += () => OnClickBtnMode(GameMode.Hard);

        }

        private void UpdateButtonText(GameMode selectedMode)
        {
            // clear all
            _btnEasy.text = "";
            _btnEasyMedium.text = "";
            _btnMedium.text = "";
            _btnMediumHard.text = "";
            _btnHard.text = "";

            // set selected
            switch (selectedMode)
            {
                case GameMode.Easy:
                    _btnEasy.text = "#";
                    break;
                case GameMode.EasyMedium:
                    _btnEasyMedium.text = "#";
                    break;
                case GameMode.Medium:
                    _btnMedium.text = "#";
                    break;
                case GameMode.MediumHard:
                    _btnMediumHard.text = "#";
                    break;
                case GameMode.Hard:
                    _btnHard.text = "#";
                    break;
            }
        }

        private void OnClickBtnMode(GameMode mode)
        {
            var modeData = _modes.First(m => m.mode == mode);
            _saveService.SaveGameMode(new GameModeConfig(mode, modeData.rows, modeData.cols));
            UpdateButtonText(mode);
        }

        public GameModeConfig GetCurrentGameMode()
        {
            var currentConfig = _saveService.LoadGameMode();
            return currentConfig;
        }
    }
}