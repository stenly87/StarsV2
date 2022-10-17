using System;

namespace StarsV2.Interfaces
{
    internal interface IGameController
    {
        event EventHandler OnShoot;
        event EventHandler<MoveDirection> OnDirectionChanged;
    }
}