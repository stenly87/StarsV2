using StarsV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using draw = System.Drawing;

namespace StarsV2
{
    internal class GameField : IGameField
    {
        Random random = new Random();
        public int Width { get; set; }
        public int Height { get; set; }
        Action<IGameObject> drawObject;
        Action<IGameObject> clearDrawObject;

        List<IGameObject> gameObjects = new List<IGameObject>();
        public event EventHandler<(IGameObject, IGameObject)> OnIntersect;

        public void AddObject(IGameObject target)
        {
            if (!gameObjects.Contains(target))
                gameObjects.Add(target);
            if (target is IEnemy)
                target.Position = new Vector2(random.Next(0, Width - target.Width + 1), 0);
            else if (target is IPlayer)
            {
                target.Position = new Vector2(Width / 2 + target.Width / 2, Height - target.Height);
            }
            drawObject(target);
        }

        public void ClearObjects()
        {
            gameObjects.ForEach(s => RemoveObject(s));
            gameObjects.Clear();
        }

        public int CountEnemies()
        {
            return gameObjects.Count;
        }

        public void Init()
        {

        }

        public void MoveObjects()
        {
            foreach (var obj in gameObjects)
            {
                if (obj.IsOnField)
                {
                    if (obj is IPlayer)
                    {
                        var nextPos = obj.Position + obj.Speed;
                        if (nextPos.X >= 0 && nextPos.X < Width - obj.Width)
                            obj.Position += obj.Speed;
                    }
                    else
                        obj.Position += obj.Speed;
                    if (obj.Position.X < 0 || obj.Position.Y < 0 ||
                        obj.Position.X > Width || obj.Position.Y > Height)
                        RemoveObject(obj);
                    else
                        drawObject(obj);
                }
            }
            var player = gameObjects.FirstOrDefault(s => s is IPlayer);
            CheckIntersect(player);
        }

        private void CheckIntersect(IGameObject player)
        {
            draw.RectangleF playerHitBox = new draw.RectangleF(player.Position.X, player.Position.Y, player.Width, player.Height);
            var bullets = gameObjects.Where(s => s is IBullet);
            Stack<(IGameObject, IGameObject)> stack = new Stack<(IGameObject, IGameObject)>();
            foreach (var obj in gameObjects)
            {
                if (obj is IEnemy enemy)
                {
                    draw.RectangleF enemyHitBox = new draw.RectangleF(obj.Position.X, obj.Position.Y, obj.Width, obj.Height);
                    if (enemyHitBox.IntersectsWith(playerHitBox))
                    {
                        stack.Push((player, obj));
                        continue;
                        //OnIntersect?.Invoke(this, (player, obj));
                    }
                    foreach (var bullet in bullets)
                    {
                        draw.RectangleF bulletHitBox = new draw.RectangleF(bullet.Position.X, bullet.Position.Y, bullet.Width, bullet.Height);
                        if (bulletHitBox.IntersectsWith(enemyHitBox))
                        {
                            stack.Push((bullet, enemy));
                            continue;
                            //OnIntersect?.Invoke(this, (bullet, enemy));
                        }
                    }
                }
            }
            while (stack.Count > 0)
            {
                OnIntersect?.Invoke(this, stack.Pop());
            }
        }

        public void RemoveObject(IGameObject obj)
        {
            clearDrawObject(obj);
        }

        public void SetDrawObjectAction(Action<IGameObject> drawObject)
        {
            this.drawObject = drawObject;
        }

        public void SetClearDrawObjectAction(Action<IGameObject> clearDrawObject)
        {
            this.clearDrawObject = clearDrawObject;
        }
    }
}