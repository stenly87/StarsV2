using System;

namespace StarsV2.Interfaces
{
    internal interface IGameTimer
    {
        void Init(Action action);
        void Start();
        void Stop();
    }
}