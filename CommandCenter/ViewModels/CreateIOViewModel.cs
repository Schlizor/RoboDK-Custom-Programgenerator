using CommandCenter.Messages;
using CommandCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RoboDk.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandCenter.ViewModels
{
    internal partial class CreateIOViewModel : ObservableObject
    {
        [ObservableProperty]
        IO.IOType selectedIOType;

        [ObservableProperty]
        bool buttonisEnabled = false;

        [ObservableProperty]
        string ioName;

        [ObservableProperty]
        string ioValue;

        [ObservableProperty]
        string timeout;

        public Array iotypes { get; }

        public CreateIOViewModel()
        {
            iotypes = Enum.GetValues(typeof(IO.IOType));
            SelectedIOType = IO.IOType.DO;
          
        }

        [RelayCommand]
        private void ConfirmInput()
        {
            

            if (SelectedIOType == IO.IOType.DO || SelectedIOType == IO.IOType.AO)
            {
                var temp = new IO(SelectedIOType, IoName, IoValue);
                WeakReferenceMessenger.Default.Send<IODetailsMessage>(new IODetailsMessage(temp));
                WeakReferenceMessenger.Default.Send<CreateIOViewModel>(this);
            }
            else
            {
                try
                {
                    var temp = new IO(SelectedIOType, IoName, IoValue, Convert.ToDouble(Timeout));
                    WeakReferenceMessenger.Default.Send<IODetailsMessage>(new IODetailsMessage(temp));
                    WeakReferenceMessenger.Default.Send<CreateIOViewModel>(this);
                }
                catch 
                {
                    MessageBox.Show("Timeout was not in the correct input format. Only Digits are allowed");
                }
            }
        }

        partial void OnIoValueChanged(string oldValue, string newValue) => CheckInput();

        partial void OnIoNameChanged(string oldValue, string newValue) => CheckInput();

        private void CheckInput()
        {
            if ( IoName != null && IoValue != null )
            {
                ButtonisEnabled = true;
            }

 
        }




    }
}
