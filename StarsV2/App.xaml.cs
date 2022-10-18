using StarsV2.Interfaces;
using StarsV2.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StarsV2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IGameUI ui = new GameUI();
            IGameField gameField = new GameField();
            IGameTimer timer = new GameTimer();
            IGameSound sound = new GameSound();               
            IGameController controller = new GameController();
            IGameObjectFactory gameEnemyFactory = new GameEnemyFactory();
            IGameObjectFactory bulletFactory = new BulletFactory();
            IPlayer player = new Player();
            IGameScoreManager gameScoreManager = new GameScoreManager();
            
            IGameCore core = new GameCore(
                controller, 
                ui,
                gameField,
                gameEnemyFactory,
                bulletFactory,
                timer,
                sound,
                player,
                gameScoreManager);

            core.Start();
        }
    }
}
