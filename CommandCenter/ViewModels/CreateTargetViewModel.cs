using CommandCenter.Messages;
using CommandCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RoboDk.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.ViewModels
{
    /// <summary>
    /// Contains the UI Logic to enter a few Data for the target which will be created after. 
    /// Receives and sends Data from/to MainPageViewModel (MainPage)
    /// </summary>
    internal partial class CreateTargetViewModel : ObservableObject
    {
        [ObservableProperty]
        string? name;

        [ObservableProperty]
        public List<Robot>? robotList;

        [ObservableProperty]
        Robot? selectedRobot;

        public CreateTargetViewModel()
        {
            //Register Messenger service to receive RobotList from MainPageViewModel
            WeakReferenceMessenger.Default.Register<RobotListMessage>(this, (r, m) =>
            {
                RobotList = m.Value;
            });
        }

        [RelayCommand]
        void CreateTargetwithRobot()
        {
            if (SelectedRobot == null)
                return;

            //Send Message to MainPageViewModel with the name of the Target and the choosen robot
            WeakReferenceMessenger.Default.Send(new TargetDetailsMessage(new TargetDetails(Name, SelectedRobot.Item ?? null)));
            //Send Message to close CreateTargetWindow
            WeakReferenceMessenger.Default.Send(this);
        }

    }
}
