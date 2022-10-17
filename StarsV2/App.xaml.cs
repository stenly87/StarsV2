using StarsV2.Interfaces;
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

            IGameUI ui = null;
            IGameTimer timer = null;
            IGameSound sound = null;
            IGameController controller = null;
            IGameField gameField = null;
            IGameEnemyFactory gameEnemyFactory = null;
            IBulletFactory bulletFactory = null;
            IPlayer player = null;
            IGameScoreManager gameScoreManager = null;
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
