using StarsV2.Interfaces;

namespace StarsV2.Model
{
    internal class GameEnemy : IEnemy
    {
        private readonly int damageValue;
        private readonly int scoreValue;
        public string ImagePath { get; private set; }

        public bool IsOnField { get; set; }

        public Point Position { get; set; }

        public int Width { get; private set; }

        public int Heigth { get; private set; }

        public GameEnemy(int damageValue, int scoreValue, string imagePath, int width = 56, int heigth = 50)
        {
            this.damageValue = damageValue;
            this.scoreValue = scoreValue;
            ImagePath = imagePath;
            Width = width;
            Heigth = heigth;
        }

        public int GetDamageValue() => damageValue;

        public int GetScore() => scoreValue;
    }
}