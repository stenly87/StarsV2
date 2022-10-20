
using StarsV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarsV2.Model
{
    internal class GameEnemyFactory : GameObjectFactory
    {
        Random random = new Random();

        protected override IGameObject CreateEnemy()
        {
            int indexImage = random.Next(1, 6);
            string imagePath = $"{Environment.CurrentDirectory}/Sprites/met{indexImage}.png";
            int damageScore = random.Next(1, 2);
            return new GameEnemy(damageScore, damageScore, imagePath);
        }
    }
}