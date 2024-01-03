using CommandCenter.Messages;
using CommandCenter.Models;
using CommandCenter.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
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
using System.Windows.Shapes;

namespace CommandCenter.View
{
    /// <summary>
    /// Interaktionslogik für CreateProgramWindow.xaml
    /// </summary>
    partial class CreateProgramWindow : Window
    {
        public CreateProgramWindow()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<CreateProgramViewModel>(this, (r, m) =>
            {
                this.Close();
            });

        }

        private void RobotList_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void RobotList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RobotList_Selected != null)
            {
                CreateProgramwithRobot.IsEnabled = true;
            }
            else { CreateProgramwithRobot.IsEnabled = false; }
        }
    }
}
