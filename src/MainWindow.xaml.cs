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

namespace gtaOnlineManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<oneInDelay> lcasino = new List<oneInDelay>();
        public MainWindow()
        {
            InitializeComponent();

            lcasino.Add(new oneInDelay("Casino Lucky Wheel", new TimeSpan(1, 0, 0, 0)));

            initCasino();
        }

        public void initCasino()
        {
            foreach (oneInDelay line in lcasino)
            {
                Casino.Children.Add(line.panel);
            }
        }

        private void Drag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnTop_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        private void OnTop_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }
    }
}
