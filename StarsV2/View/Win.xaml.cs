using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StarsV2.View
{
    /// <summary>
    /// Логика взаимодействия для Win.xaml
    /// </summary>
    public partial class Win : Window, INotifyPropertyChanged
    {
        private Page currentPage;
        private GameUI gameUI;

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();
            }
        }
        
        internal Win(GameUI gameUI)
        {
            InitializeComponent();
            LevelSelector ls = new LevelSelector();
            ls.OnLevelSelected += Ls_OnLevelSelected;
            CurrentPage = new PageMenu(ls);
            DataContext = this;
            this.gameUI = gameUI;
        }

        private void Ls_OnLevelSelected(object sender, int level)
        {
            CurrentPage = new PageGame(gameUI);
            gameUI.SetLevel(level);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void SignalChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

}
