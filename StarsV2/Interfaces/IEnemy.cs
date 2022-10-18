using StarsV2.Model;

namespace StarsV2.Interfaces
{
    internal interface IEnemy : IGameObject
    {
        string ImagePath { get; }
        int GetDamageValue();
        int GetScore();
    }
}