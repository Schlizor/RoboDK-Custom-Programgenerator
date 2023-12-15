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

namespace CommandCenter
{
    internal partial class MainViewModel : ObservableObject
    {
        public RoboDK activeStation;

        [ObservableProperty]
        private List<Targets> targets = new();


        public MainViewModel() 
        { 
            activeStation = new RoboDK();

            getTargets();
        }

        [RelayCommand]
        void CreateTarget()
        {
            IItem newtarget = activeStation.AddTarget("Test");
            Targets.Add(new Targets(newtarget));
        }


        void getTargets()
        {
            foreach (IItem item in activeStation.GetItemList())
            {
                if(item.GetItemType() == ItemType.Target)
                {
                    Targets.Add(new Targets(item));
                    //.Add(new Targets(item));
                }
            }
        }
    }


}
