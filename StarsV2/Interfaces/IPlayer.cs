using System;

namespace StarsV2.Interfaces
{
    internal interface IPlayer : IGameObject
    {
        string ImagePath { get; }
        int Health { get; }
        void ChangeMoveDirection(MoveDirection e);
        void AddDamage(int dmg);

        event EventHandler OnDeath;

        void Init();
    }
}