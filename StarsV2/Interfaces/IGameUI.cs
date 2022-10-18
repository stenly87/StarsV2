using System;

namespace StarsV2.Interfaces
{
    internal interface IGameUI
    {
        event EventHandler Ready;
        event EventHandler<int> OnLevelChanged;

        void SetLevel(int level);
        void Init(IGameController controller, IGameField gameField, IGameScoreManager gameScoreManager);
        void ShowGameOver();
    }
}