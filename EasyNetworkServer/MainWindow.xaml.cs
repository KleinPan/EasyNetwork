﻿using System;
using System.Threading.Tasks;
using System.Windows;

using EasyNetworkServer.ViewModels;
using EasyNetworkServer.Views;

namespace EasyNetworkServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        protected override void OnContentRendered(EventArgs e)
        {

            base.OnContentRendered(e);

            NonClientAreaContent = new SettingUc();

            MainContenUc mainContenUc = new MainContenUc();

            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.mainWindow = this;

            mainContenUc.DataContext = mainViewModel;

            ControlMain.Content = mainContenUc;
            mainViewModel.Init();


        }

    }
}
