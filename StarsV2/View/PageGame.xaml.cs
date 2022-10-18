﻿using System;
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
        private readonly GameUI gameUI;

        internal PageGame(GameUI gameUI)
        {
            InitializeComponent();
            this.gameUI = gameUI;

            gameUI.SetCanvas(mainCanvas);
        }
    }
}
