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
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        private readonly LevelSelector ls;

        internal PageMenu(LevelSelector ls)
        {
            InitializeComponent();
            this.ls = ls;
        }

        private void buttonBaseLevel(object sender, RoutedEventArgs e)
        {
            ls.Level = 1;
        }

        private void buttonBonusLevel(object sender, RoutedEventArgs e)
        {
            ls.Level = 2;
        }
    }
}
