using StarsV2.Interfaces;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace StarsV2.Model
{
    internal class GameController : IGameController
    {
        public event EventHandler OnShoot;
        public event EventHandler<MoveDirection> OnDirectionChanged;

        long lastInputTime = 0;
        public void KeyPressed(Key key, bool pressed)
        {
            if (pressed)
            {
                long currentTime = Stopwatch.GetTimestamp();
                if (currentTime - lastInputTime < 2500000)
                    return;
                lastInputTime = currentTime;
            }
            switch (key)
            {
                case Key.Left:

                    OnDirectionChanged?.Invoke(this,
                        pressed ? 
                        MoveDirection.MoveLeft :
                        MoveDirection.Stay);
                    break;
                case Key.Right:
                    OnDirectionChanged?.Invoke(this,
                        pressed ?
                        MoveDirection.MoveRight :
                        MoveDirection.Stay);
                    break;
                case Key.Space:
                    OnShoot?.Invoke(this, new EventArgs());
                    break;
            }
        }
    }
}