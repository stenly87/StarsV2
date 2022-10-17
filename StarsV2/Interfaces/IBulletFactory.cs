namespace StarsV2.Interfaces
{
    internal interface IBulletFactory
    {
        IBullet MakeBullet(IPlayer player);
    }
}