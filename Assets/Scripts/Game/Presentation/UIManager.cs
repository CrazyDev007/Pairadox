using System;
using System.Collections.Generic;
using Game.Infrastructure;
using UnityEngine;

namespace Game.Presentation
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<UIScreenMapping> screenMappings;

        private readonly Dictionary<UIScreenType, UIScreen> _screens = new Dictionary<UIScreenType, UIScreen>();

        private UIScreen _activeScreen;

        private void Awake()
        {
            foreach (var mapping in screenMappings)
            {
                if (mapping.screen != null && !_screens.ContainsKey(mapping.type))
                {
                    var uiScreen = mapping.screen;
                    uiScreen.UiManager = this;
                    _screens.Add(mapping.type, uiScreen);
                    if (mapping.isDefault)
                    {
                        ShowScreen(mapping.type);
                    }
                    else
                    {
                        HideScreen(mapping.type);
                    }
                }
            }
        }

        public void ShowScreen(UIScreenType screenType)
        {
            if (_screens.TryGetValue(screenType, out var screen))
            {
                screen.Show();
            }
            else
            {
                Debug.LogError($"Screen of type {screenType} not found.");
            }
        }

        public void HideScreen(UIScreenType screenType)
        {
            if (_screens.TryGetValue(screenType, out var screen))
            {
                screen.Hide();
            }
            else
            {
                Debug.LogError($"Screen of type {screenType} not found.");
            }
        }
    }

    public enum UIScreenType
    {
        Lobby,
        Setting,
        Gameplay,
        GameEnd,
    }


    [Serializable]
    public struct UIScreenMapping
    {
        public UIScreenType type;
        public UIScreen screen;
        public bool isDefault;
    }
}