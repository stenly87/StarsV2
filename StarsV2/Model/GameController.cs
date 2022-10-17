using StarsV2.Interfaces;
using System;
using System.Windows.Input;

namespace StarsV2.Model
{
    internal class GameController : IGameController
    {
        public event EventHandler OnShoot;
        public event EventHandler<MoveDirection> OnDirectionChanged;

        public void KeyPressed(Key key, bool pressed)
        {
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