using System;

namespace StarsV2.Interfaces
{
    internal interface IGameUI
    {
        event EventHandler Ready;

        void Init(IGameController controller, IPlayer player, IGameField gameField, IGameScoreManager gameScoreManager);
        void ShowGameOver();
    }
}