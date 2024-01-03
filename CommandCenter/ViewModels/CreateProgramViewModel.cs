using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandCenter.Messages;
using CommandCenter.Models;
using CommandCenter.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RoboDk.API;

namespace CommandCenter.ViewModels
{
    internal partial class CreateProgramViewModel : ObservableObject
    {

        [ObservableProperty]
        public List<Robot> robotList;

        [ObservableProperty]
        public string? programName;

        [ObservableProperty]
        public Robot selectedRobot;

        public CreateProgramViewModel() 
        {
            WeakReferenceMessenger.Default.Register<RobotListMessage>(this, (r, m) =>
            {
                RobotList = m.Value;
            });
        }

        [RelayCommand]
        void CreateProgramwithoutRobot()
        {
            var temp = new ProgramDetails(null, ProgramName ?? "Default");

            WeakReferenceMessenger.Default.Send(new ProgramDetailsMessage(temp));
            WeakReferenceMessenger.Default.Send(this);
        }

        [RelayCommand]
        void CreateProgramwithRobot()
        {
            var temp = new ProgramDetails(SelectedRobot.Item, ProgramName ?? "Default");

            WeakReferenceMessenger.Default.Send(new ProgramDetailsMessage(temp));
            WeakReferenceMessenger.Default.Send(this);

        }



    }
}
