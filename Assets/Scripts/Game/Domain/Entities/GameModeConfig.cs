using System;

namespace Game.Domain.Entities
{
    [Serializable]
    public class GameModeConfig
    {
        public GameMode gameMode;
        public int rowCount;
        public int columnCount;

        public GameMode Mode
        {
            get => gameMode;
            set => gameMode = value;
        }

        public int RowCount
        {
            get => rowCount;
            set => rowCount = value;
        }

        public int ColumnCount
        {
            get => columnCount;
            set => columnCount = value;
        }

        public GameModeConfig(GameMode mode, int rowCount, int columnCount)
        {
            Mode = mode;
            RowCount = rowCount;
            ColumnCount = columnCount;
        }
    }
}