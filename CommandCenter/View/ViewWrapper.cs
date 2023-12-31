using CommandCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using RoboDk.API;
using RoboDk.API.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.View
{
    internal partial class ViewWrapper : ObservableObject
    {
        private RoboDK? activeStation = null;

        [ObservableProperty]
        public List<Frames> frames = new();

        [ObservableProperty]
        public List<Targets> targets = new();

        [ObservableProperty]
        public List<Robots> robots = new ();

        [ObservableProperty]
        public List<object> objectlist = new();



        public ViewWrapper(RoboDK activeStation)
        {
              this.activeStation = activeStation;

            if(activeStation != null)
            {
                Targets = getTargets();
                Frames = getFrames();
                Robots = getRobots();
            }
        }

        public void Update()
        {

            if (activeStation != null)
            {
                Targets = getTargets();
                Frames = getFrames();
                Robots = getRobots();
            }
        }


        List <Targets> getTargets()
        {

            List<Targets> targetstemp = new List<Targets>();    

            foreach (IItem item in activeStation.GetItemList())
            {
                if (item.GetItemType() == ItemType.Target)
                {
                    
                    targetstemp.Add(new Targets(item));
                    //.Add(new Targets(item));
                }
            }

            return targetstemp;
        }

        List<Frames> getFrames()
        {

            List<Frames> temp = new List<Frames>();

            foreach (IItem item in activeStation.GetItemList())
            {
                if (item.GetItemType() == ItemType.Frame)
                {
                    temp.Add(new Frames(item));
                    //.Add(new Targets(item));
                }
            }

            return temp;
        }

        List<Robots> getRobots()
        {

            List<Robots> temp = new List<Robots>();

            foreach (IItem item in activeStation.GetItemList())
            {
                if (item.GetItemType() == ItemType.Robot)
                {
                    temp.Add(new Robots(item));
                    //.Add(new Targets(item));
                }
            }

            return temp;
        }


    }
}
