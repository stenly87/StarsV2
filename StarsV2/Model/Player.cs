using StarsV2.Interfaces;
using System;
using System.Numerics;

namespace StarsV2.Model
{
    internal class Player : IPlayer
    {
        private Vector2 speed = new Vector2(10, 0);

        public Vector2 Position { get; set; }

        public int Width => 100;

        public int Height => 70;

        public int Health { get; private set; }

        public string ImagePath { get; private set; }

        public MoveDirection Direction { get; set; }
        public bool IsOnField { get; set; }

        public Vector2 Speed {
            get 
            {
                switch (Direction)
                {
                    case MoveDirection.MoveLeft:
                        return -speed;
                    case MoveDirection.MoveRight:
                        return speed;
                    default:
                        return Vector2.Zero;
                }
            }
            private set => speed = value;
        }
        public event EventHandler OnDeath;
        public event EventHandler OnDamaged;

        public Player()
        {
            ImagePath = $"{Environment.CurrentDirectory}/Sprites/korabl.png";
        }

        public void AddDamage(int dmg)
        {
            Health -= dmg;
            if (Health < 0)
                OnDeath?.Invoke(this, EventArgs.Empty);
            else
                OnDamaged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeMoveDirection(MoveDirection e)
        {
            Direction = e;
        }

        public void Init()
        {
            Health = 100;
        }
    }
}