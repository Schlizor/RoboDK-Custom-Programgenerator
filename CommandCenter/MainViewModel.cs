using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandCenter.Models;
using RoboDk.API;
using RoboDk.API.Model;
using CommandCenter.View;

namespace CommandCenter
{
    internal partial class MainViewModel : ObservableObject
    {
        public RoboDK activeStation;

        [ObservableProperty]
        public ViewWrapper wrapper;

        public MainViewModel() 
        { 
            activeStation = new RoboDK();
            wrapper = new ViewWrapper(activeStation);



        }

        [RelayCommand]
        void CreateTarget()
        {
            IItem newtarget = activeStation.AddTarget("Test");
            Wrapper.Update();
        }

        [RelayCommand]
        void Update()
        {
            Wrapper.Update();
        }

        [RelayCommand]
        void AddTargetToProgram()
        { 
        }

        [RelayCommand]
        void AddFrameToProgram()
        {

        }


    }


}
