using StarsV2.Interfaces;

namespace StarsV2.Model
{
    internal class BulletFactory : GameObjectFactory
    {
        protected override IGameObject CreateEnemy()
        {
            return new Bullet(5, 20);
        }
    }
}