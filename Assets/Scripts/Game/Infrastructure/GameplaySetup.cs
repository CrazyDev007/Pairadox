using System;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class GameplaySetup : IGameInitializer
    {
        public void Initialize(GameModeConfig config)
        {
            switch (config.Mode)
            {
                case GameMode.Easy:
                    Debug.Log("Easy");
                    //SaveManager.SaveGameMode(GameMode.Easy);
                    break;
                case GameMode.EasyMedium:
                    Debug.Log("EasyMedium");
                    //SaveManager.SaveGameMode(GameMode.EasyMedium);
                    break;
                case GameMode.Medium:
                    Debug.Log("Medium");
                    //SaveManager.SaveGameMode(GameMode.Medium);
                    break;
                case GameMode.MediumHard:
                    Debug.Log("MediumHard");
                    //SaveManager.SaveGameMode(GameMode.MediumHard);
                    break;
                case GameMode.Hard:
                    Debug.Log("Hard");
                    //SaveManager.SaveGameMode(GameMode.Hard);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(config.Mode), config.Mode, null);
            }
        }
    }
}