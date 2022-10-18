﻿using StarsV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsV2.Model
{
    internal class Bullet : IBullet
    {
        public bool IsOnField { get; set; }

        public Point Position { get; set; }

        public int Width { get; private set; }

        public int Heigth { get; private set; }

        public Bullet(int width, int heigth)
        {
            Width = width;
            Heigth = heigth;
        }
    }
}
