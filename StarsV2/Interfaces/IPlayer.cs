using System;

namespace StarsV2.Interfaces
{
    internal interface IPlayer : IGameObject
    {
        void ChangeMoveDirection(MoveDirection e);
        void AddDamage(int dmg);

        event EventHandler OnDeath;
    }
}