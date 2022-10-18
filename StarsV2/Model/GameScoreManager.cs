using StarsV2.Interfaces;
using System;

namespace StarsV2
{
    internal class GameScoreManager : IGameScoreManager
    {
        private int currentScores;

        public int CurrentScores
        {
            get => currentScores;
            private set
            {
                currentScores = value;
                OnScoreChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler OnScoreChanged;

        public void AddScore(int value)
        {
            CurrentScores += value;
        }

        public void Clear()
        {
            CurrentScores = 0;
        }
    }
}