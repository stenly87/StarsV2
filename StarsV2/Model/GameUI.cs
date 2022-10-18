using StarsV2.Interfaces;
using StarsV2.View;
using System;
using System.Windows.Controls;

namespace StarsV2
{
    internal class GameUI : IGameUI
    {
        public event EventHandler Ready;
        public event EventHandler<int> OnLevelChanged;

        IGameController controller;
        IGameField gameField;
        IGameScoreManager gameScoreManager;
        Win window;
        Canvas mainCanvas;

        public void Init(IGameController controller, IGameField gameField, IGameScoreManager gameScoreManager)
        {
            this.controller = controller;
            this.gameField = gameField;
            this.gameScoreManager = gameScoreManager;
            window = new Win(this);
            window.Show();
        }

        public void ShowGameOver()
        {

        }

        public void SetCanvas(Canvas mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            gameField.Width = (int)mainCanvas.ActualWidth;
            gameField.Height = (int)mainCanvas.ActualHeight;
        }

        public void SetLevel(int level)
        {
            OnLevelChanged?.Invoke(this, level);
            Ready?.Invoke(this, new EventArgs());
        }
    }
}