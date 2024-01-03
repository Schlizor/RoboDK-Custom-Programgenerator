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
    /// Interaktionslogik für CreateIOWindow.xaml
    /// </summary>
    public partial class CreateIOWindow : Window
    {
        public CreateIOWindow()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<CreateIOViewModel>(this, (r, m) =>
            {
                this.Close();
            });
        }
    }
}
