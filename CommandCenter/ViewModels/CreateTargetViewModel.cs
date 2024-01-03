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
            WeakReferenceMessenger.Default.Register<RobotListMessage>(this, (r, m) =>
            {
                RobotList = m.Value;
            });
        }

        [RelayCommand]
        void CreateTargetwithRobot()
        {
            if (selectedRobot == null)
                return;

            WeakReferenceMessenger.Default.Send(new TargetDetailsMessage(new TargetDetails(Name, SelectedRobot.Item ?? null)));
            WeakReferenceMessenger.Default.Send(this);
        }

    }
}
