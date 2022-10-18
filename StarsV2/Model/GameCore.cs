using StarsV2.Interfaces;
using System;

namespace StarsV2.Model
{
    internal class GameCore : IGameCore
    {
        private IGameController controller;
        private IGameUI ui;
        private IGameField gameField;
        private IGameObjectFactory gameEnemyFactory;
        private IGameObjectFactory bulletFactory;
        private IGameTimer timer;
        private IGameSound sound;
        IPlayer player;
        private IGameScoreManager gameScoreManager;

        public GameCore(IGameController controller, IGameUI ui, IGameField gameField, IGameObjectFactory gameEnemyFactory, IGameObjectFactory bulletFactory, IGameTimer timer, IGameSound sound, IPlayer player, IGameScoreManager gameScoreManager)
        {
            this.controller = controller;
            this.ui = ui;
            this.gameField = gameField;
            this.gameEnemyFactory = gameEnemyFactory;
            this.bulletFactory = bulletFactory;
            this.timer = timer;
            this.sound = sound;
            this.player = player;
            this.gameScoreManager = gameScoreManager;

            player.OnDeath += Player_OnDeath;
            gameField.OnIntersect += GameField_OnIntersect;
            controller.OnShoot += MakeBullet;
            controller.OnDirectionChanged += Controller_OnDirectionChanged;
        }

        private void Player_OnDeath(object sender, EventArgs e)
        {
            timer.Stop();
            ui.ShowGameOver();
            gameScoreManager.Clear();
            gameField.ClearObjects();
            sound.StopBackground();
            sound.PlayLose();
        }

        private void GameField_OnIntersect(object sender, (IGameObject, IGameObject) e)
        {
            if (e.Item2 is IEnemy enemy)
            {
                if (e.Item1 == player)
                {
                    player.AddDamage(enemy.GetDamageValue());
                }
                else if (e.Item1 is IBullet bullet)
                {
                    gameScoreManager.AddScore(enemy.GetScore());
                    gameField.RemoveObject(bullet);
                }
                gameField.RemoveObject(enemy);
            }
        }

        private void Controller_OnDirectionChanged(object sender, MoveDirection e)
        {
            player.ChangeMoveDirection(e);
        }

        private void MakeBullet(object sender, EventArgs e)
        {
            sound.ShootPlay();
            Point bulletPosition = new Point
            {
                X = player.Position.X + player.Width / 2,
                Y = player.Position.Y
            };
            IGameObject bullet = bulletFactory.CreateObject();
            bullet.Position = bulletPosition;
            gameField.AddObject(bullet);
        }

        public void Start()
        {
            ui.Ready += Ui_Ready;
            ui.Init(controller, gameField, gameScoreManager);
        }

        private void Ui_Ready(object sender, EventArgs e)
        {
            sound.StartBackground();
            timer.Init(GameLoop);
            timer.Start();
            gameField.Init();
            player.Init();
            gameField.AddObject(player);
        }

        int countTick = 0;
        private void GameLoop()
        {
            gameField.MoveObjects();
            if (gameField.CountEnemies() < 20 && ++countTick % 5 == 0)
            {
                gameField.AddObject(gameEnemyFactory.CreateObject());
                countTick = 0;
            }
        }
    }
}