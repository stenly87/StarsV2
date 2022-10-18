using System;

namespace StarsV2.Interfaces
{
    internal interface IGameScoreManager
    {
        event EventHandler OnScoreChanged;
        int CurrentScores { get; } 
        void AddScore(int value);
        void Clear();
    }
}