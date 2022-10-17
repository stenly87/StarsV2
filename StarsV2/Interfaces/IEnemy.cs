namespace StarsV2.Interfaces
{
    internal interface IEnemy : IGameObject
    {
        int GetDamageValue();
        int GetScore();
    }
}