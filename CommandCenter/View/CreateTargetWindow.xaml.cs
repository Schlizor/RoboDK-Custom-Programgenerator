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
    /// Interaktionslogik für CreateTargetWindow.xaml
    /// </summary>
    public partial class CreateTargetWindow : Window
    {
        public CreateTargetWindow()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<CreateTargetViewModel>(this, (r, m) =>
            {
                this.Close();
            });
        }
    }
}
