using StarsV2.Interfaces;
using System;

namespace StarsV2
{
    internal class GameField : IGameField
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public event EventHandler<(IGameObject, IGameObject)> OnIntersect;

        public void AddObject(IGameObject bullet)
        {
        }

        public void ClearObjects()
        {
        }

        public int CountEnemies()
        {
            return 0;
        }

        public void Init()
        {
        }

        public void MoveObjects()
        {
         
        }

        public void RemoveObject(IGameObject enemy)
        {
        }
    }
}