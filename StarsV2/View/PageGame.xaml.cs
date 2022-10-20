using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarsV2.View
{
    /// <summary>
    /// Логика взаимодействия для PageGame.xaml
    /// </summary>
    public partial class PageGame : Page
    {
        private readonly GameUIWPF gameUI;

        internal PageGame(GameUIWPF gameUI)
        {
            InitializeComponent();
            this.gameUI = gameUI;

            gameUI.SetCanvas(mainCanvas);
            mainCanvas.Focus();
        }

        private void GameUI_OnMessage(object sender, string e)
        {
            message.Text = e;
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            gameUI.PressKey(e.Key, false);
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            gameUI.PressKey(e.Key, true);
        }

        private void onMouseClick(object sender, MouseButtonEventArgs e)
        {
            gameUI.PressKey(Key.Space, true);
        }
    }
}
