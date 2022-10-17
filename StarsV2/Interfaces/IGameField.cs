
using System;

namespace StarsV2.Interfaces
{
    internal interface IGameField
    {
        void Init();
        void AddObject(IGameObject bullet);
        void MoveObjects();
        int CountEnemies();

        event EventHandler<(IGameObject, IGameObject)> OnIntersect;

        void RemoveObject(IGameObject enemy);
    }
}