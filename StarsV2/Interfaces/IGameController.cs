using System;
using System.Windows.Input;

namespace StarsV2.Interfaces
{
    internal interface IGameController
    {
        event EventHandler OnShoot;
        event EventHandler<MoveDirection> OnDirectionChanged;

        void KeyPressed(Key key, bool pressed);
    }
}