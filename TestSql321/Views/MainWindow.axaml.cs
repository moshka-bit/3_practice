using Avalonia.Controls;
using Avalonia.Interactivity;
using Azure;
using System;
using TestSql321.Data;
using TestSql321.Models;
using TestSql321.ViewModels;

namespace TestSql321.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object? sender, RoutedEventArgs e)
        {
            MainControl.Content = new UserControl_User();
        }

        private void Button_Click2(object? sender, RoutedEventArgs e)
        {
            MainControl.Content = new UserControl_Item();
        }

        private void Button_Click3(object? sender, RoutedEventArgs e)
        {
            MainControl.Content = new UserControl_Basket();
        }


    }
}