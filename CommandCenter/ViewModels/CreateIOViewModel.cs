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

namespace CommandCenter.ViewModels
{
    internal partial class CreateIOViewModel : ObservableObject
    {
        [ObservableProperty]
        public IO.IOType selectedIOType;

        [ObservableProperty]
        public bool buttonisEnabled = false;

        [ObservableProperty]
        public string ioName;

        [ObservableProperty]
        public string ioValue;

        public Array iotypes { get; }

        public CreateIOViewModel()
        {
            iotypes = Enum.GetValues(typeof(IO.IOType));
            SelectedIOType = IO.IOType.DO;
          
        }

        [RelayCommand]
        private void ConfirmInput()
        {
            var temp = new IO(SelectedIOType, IoName, IoValue);

            WeakReferenceMessenger.Default.Send<IODetailsMessage>(new IODetailsMessage(temp));
            WeakReferenceMessenger.Default.Send<CreateIOViewModel>(this);

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
