using StarsV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StarsV2.Model
{
    internal class Bullet : IBullet
    {
        public bool IsOnField { get; set; }

        public Vector2 Position { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }
        public MoveDirection Direction { get; set; } = MoveDirection.MoveUp;

        public Vector2 Speed { get; private set; } = new Vector2(0, -20);

        public Bullet(int width, int heigth)
        {
            Width = width;
            Height = heigth;
        }
    }
}
