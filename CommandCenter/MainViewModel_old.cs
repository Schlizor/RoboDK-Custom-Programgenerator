using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboDk;
using RoboDk.API;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommandCenter.Models;
using RoboDk.API.Model;
using CommandCenter.View;
using System.Collections.ObjectModel;

namespace CommandCenter
{
    internal class MainViewModel_old : ObservableObject
    {
        private RoboDK robodk;

        public ViewWrapper data;

        
        private ObservableCollection<Targets> targets = new ObservableCollection<Targets>();


        public MainViewModel_old() 
        {
            robodk = new RoboDK();

            IItem test = robodk.GetActiveStation();

            data = new ViewWrapper(GetFramesfromRoboDK(robodk),
                                   GetTargetsfromRoboDK(robodk),
                                   GetRobotsfromRoboDK(robodk));

            foreach (Targets target in GetTargetsfromRoboDK(robodk))
            { targets.Add(new Targets(target.Target)); }
            
        }

        private List<Frames> GetFramesfromRoboDK(RoboDK activeStation)
        {
            List <Frames> frames = new List <Frames>();
            List<IItem> items = activeStation.GetItemList();

            foreach(IItem item in items)
            {
                if (item.GetItemType() == ItemType.Frame)
                {
                    frames.Add(new Frames(item));
                }
            }

            return frames;
        }

        private List<Targets> GetTargetsfromRoboDK(RoboDK activeStation)
        {
            List<Targets> targets = new List<Targets>();
            List<IItem> items = activeStation.GetItemList();

            foreach (IItem item in items)
            {
                if (item.GetItemType() == ItemType.Frame)
                {
                    targets.Add(new Targets(item));
                }
            }

            return targets;
        }

        private List<Robots> GetRobotsfromRoboDK(RoboDK activeStation)
        {
            List<Robots> robots = new List<Robots>();
            List<IItem> items = activeStation.GetItemList();

            foreach (IItem item in items)
            {
                if (item.GetItemType() == ItemType.Robot)
                {
                    robots.Add(new Robots(item));
                }
            }

            return robots;
        }

    }
}
