using StarsV2.Interfaces;
using System;

namespace StarsV2.Model
{
    internal class Player : IPlayer
    {
        public Point Position { get; set; }

        public int Width => 100;

        public int Heigth => 70;

        public bool IsOnField => true;

        public int Health { get; private set; }

        public string ImagePath { get; private set; }

        public event EventHandler OnDeath;

        public Player()
        {
            ImagePath = $"{Environment.CurrentDirectory}/Sprites/korabl.png";
        }

        public void AddDamage(int dmg)
        {
            
        }

        public void ChangeMoveDirection(MoveDirection e)
        {
            
        }

        public void Init()
        {
            Health = 100;
        }
    }
}