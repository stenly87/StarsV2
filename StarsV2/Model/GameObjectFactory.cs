using StarsV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsV2.Model
{
    internal abstract class GameObjectFactory : IGameObjectFactory
    {
        List<IGameObject> objects = new List<IGameObject>();

        protected abstract IGameObject CreateEnemy();

        public IGameObject CreateObject()
        {
            var enemy = objects.FirstOrDefault(s => !s.IsOnField);
            if (enemy != null)
                return enemy;

            enemy = CreateEnemy();
            objects.Add(enemy);
            return enemy;
        }
    }
}
