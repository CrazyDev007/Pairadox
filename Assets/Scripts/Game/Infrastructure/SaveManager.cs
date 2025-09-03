using Game.Application.Interfaces;
using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class SaveManager : ISaveService
    {
        private static SaveManager _instance;
        private static readonly object Lock = new object();
        private const string GameModeKey = "GameConfigKey";

        public static SaveManager Singleton
        {
            get
            {
                lock (Lock)
                {
                    return _instance ??= new SaveManager();
                }
            }
        }

        public void SaveGameMode(GameModeConfig gameConfigToSave)
        {
            var saveGameData = JsonUtility.ToJson(gameConfigToSave);
            Debug.Log(">>>>> " + saveGameData);
            PlayerPrefs.SetString(GameModeKey, saveGameData);
            PlayerPrefs.Save();
        }

        public GameModeConfig LoadGameMode()
        {
            var savedGameConfig = PlayerPrefs.GetString(GameModeKey, null);
            return string.IsNullOrEmpty(savedGameConfig)
                ? new GameModeConfig(GameMode.Easy, 3, 2)
                : JsonUtility.FromJson<GameModeConfig>(savedGameConfig);
        }
    }
}