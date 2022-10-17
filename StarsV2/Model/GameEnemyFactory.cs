
using StarsV2.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StarsV2.Model
{
    internal class GameEnemyFactory : IGameEnemyFactory
    {
        List<IEnemy> enemies = new List<IEnemy>();

        public IEnemy CreateEnemy()
        {
            var enemy  = enemies.FirstOrDefault(s => !s.IsOnField);
            if (enemy != null)
                return enemy;
            enemy = new GameEnemy();
            enemies.Add(enemy);
            return enemy;
        }
    }
}