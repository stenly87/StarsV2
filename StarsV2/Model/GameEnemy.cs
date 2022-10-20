using StarsV2.Interfaces;
using System.Numerics;

namespace StarsV2.Model
{
    internal class GameEnemy : IEnemy, IHasImage
    {
        private readonly int damageValue;
        private readonly int scoreValue;
        public string ImagePath { get; private set; }

        public bool IsOnField { get; set; }

        public Vector2 Position { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }
        public MoveDirection Direction { get; set; } = MoveDirection.MoveDown;

        public Vector2 Speed { get; private set; } = new Vector2(0, 20);

        public GameEnemy(int damageValue, int scoreValue, string imagePath, int width = 56, int heigth = 50)
        {
            this.damageValue = damageValue;
            this.scoreValue = scoreValue;
            ImagePath = imagePath;
            Width = width;
            Height = heigth;
        }

        public int GetDamageValue() => damageValue;

        public int GetScore() => scoreValue;
    }
}