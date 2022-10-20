using StarsV2.Interfaces;
using System;
using System.Windows.Threading;

namespace StarsV2.Model
{
    internal class GameTimer : IGameTimer
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        public void Init(Action action)
        {
            gameTimer.Interval = TimeSpan.FromMilliseconds(50);
            gameTimer.Tick += (o,e) => action();
        }

        public void Start()
        {
            gameTimer.Start();
        }

        public void Stop()
        {
            gameTimer.Stop();
        }
    }
}