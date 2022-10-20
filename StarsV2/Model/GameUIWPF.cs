using StarsV2.Interfaces;
using StarsV2.Model;
using StarsV2.View;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StarsV2
{
    internal class GameUIWPF : IGameUI
    {
        public event EventHandler Ready;
        public event EventHandler<int> OnLevelChanged;

        IGameController controller;
        IGameField gameField;
        IGameScoreManager gameScoreManager;
        Win window;
        Canvas mainCanvas;
        TextBlock scoresBlock;
        TextBlock healthBlock;

        public void Init(IGameController controller, IGameField gameField, IGameScoreManager gameScoreManager)
        {
            this.controller = controller;
            this.gameField = gameField;
            this.gameScoreManager = gameScoreManager;

            gameField.SetDrawObjectAction(DrawObject);
            gameField.SetClearDrawObjectAction(ClearDrawObject);

            gameScoreManager.OnScoreChanged += GameScoreManager_OnScoreChanged;
            window = new Win(this);
            window.Show();
        }

        Dictionary<IGameObject, Rectangle> objects = new Dictionary<IGameObject, Rectangle>();
        
        void ClearDrawObject(IGameObject target)
        {
            target.IsOnField = false;
            if (objects.ContainsKey(target))
                mainCanvas.Children.Remove(objects[target]);
        }

        internal void DrawInit()
        {
            string path = Environment.CurrentDirectory + "/Sprites/Karta_kosmo.png";
            mainCanvas.Background = new ImageBrush(new BitmapImage(new Uri(path)));

            scoresBlock = new TextBlock();
            scoresBlock.FontSize = 20;
            scoresBlock.Foreground = Brushes.Green;
            scoresBlock.Text = "0";

            healthBlock = new TextBlock();
            healthBlock.FontSize = 20;
            healthBlock.Foreground = Brushes.Red;
            healthBlock.Text = "100";

            mainCanvas.Children.Add(scoresBlock);
            mainCanvas.Children.Add(healthBlock);
            Canvas.SetLeft(healthBlock, gameField.Width / 2);
        }
        bool костыль = false;
        IPlayer player;
        void DrawObject(IGameObject target)
        {
            if (!костыль && target is IPlayer pl)
            {
                костыль = true;
                pl.OnDamaged += Pl_OnDamaged;
                player = pl;
            }
            if (!target.IsOnField)
            {
                target.IsOnField = true;

                if (!objects.ContainsKey(target))
                {
                    var control = DrawControl(target);
                    objects.Add(target, control);
                }
                mainCanvas.Children.Add(objects[target]);
                Canvas.SetLeft(objects[target], target.Position.X);
                Canvas.SetTop(objects[target], target.Position.Y);
            }
            else
            {
                Canvas.SetLeft(objects[target], target.Position.X);
                Canvas.SetTop(objects[target], target.Position.Y);
            }
        }

        private void Pl_OnDamaged(object sender, EventArgs e)
        {
            healthBlock.Text = player.Health.ToString();
        }

        private Rectangle DrawControl(IGameObject target)
        {
            Rectangle rectangle = new Rectangle { Width = target.Width, Height = target.Height };
            if (target is IBullet bullet)
            {
                rectangle.Fill = Brushes.White;
                rectangle.Stroke = Brushes.Red;
            }
            else if (target is IHasImage objImage)
            {
                rectangle.Fill = GetBrush(objImage.ImagePath);
            }
            return rectangle;
        }

        Dictionary<string, ImageBrush> brushes = new Dictionary<string, ImageBrush>();

        private Brush GetBrush(string imagePath)
        {
            if (!brushes.ContainsKey(imagePath))
                brushes.Add(imagePath, new ImageBrush(new BitmapImage(new Uri(imagePath))));
            return brushes[imagePath];
        }

        private void GameScoreManager_OnScoreChanged(object sender, EventArgs e)
        {
            scoresBlock.Text = gameScoreManager.CurrentScores.ToString();
        }

        public void ShowGameOver()
        {

        }

        public void SetCanvas(Canvas mainCanvas)
        {
            this.mainCanvas = mainCanvas;            
        }

        public void SetLevel(int level)
        {
            OnLevelChanged?.Invoke(this, level);
            Ready?.Invoke(this, new EventArgs());
        }

        internal void SetFieldSize(Size newSize)
        {
            gameField.Width = (int)newSize.Width;
            gameField.Height = (int)newSize.Height;
            gameField.Init();
        }

        public void PressKey(Key key, bool pressed)
        {
            controller.KeyPressed(key, pressed);
        }
    }
}