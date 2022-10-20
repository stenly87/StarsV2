
using StarsV2.Model;
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
        void ClearObjects();

        int Width { get; set; }
        int Height { get; set; }

        void SetDrawObjectAction(Action<IGameObject> drawObject);
        void SetClearDrawObjectAction(Action<IGameObject> clearDrawObject);
    }
}