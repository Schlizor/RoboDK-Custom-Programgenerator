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
using System.Windows.Documents;

namespace CommandCenter.View
{
    internal partial class ViewWrapper : ObservableObject
    {
        private RoboDK? activeStation = null;

        public List<IO> iOs = new();

        public List<Frame> Frames;

        public List<Robot> Robots;

        [ObservableProperty]
        public List<Target> targets;

        [ObservableProperty]
        private ObservableCollection<object> program;

        public List<IItem> programlistRoboDK;


        public ViewWrapper(RoboDK activeStation)
        {
              this.activeStation = activeStation;

            if(activeStation != null)
            {
                Targets = getTargets();
                Frames = getFrames();
                Robots = getRobots();
                programlistRoboDK = GetPrograms();
            }

            Program = new();

        }

        public void Update()
        {

            if (activeStation == null)
                return;

            Targets = getTargets();
            Frames = getFrames();
            Robots = getRobots();
 
        }




        #region GetData
        List<IItem> GetPrograms()
        {
            return (from IItem item in activeStation.GetItemList()
                    where item.GetItemType() == ItemType.Program
                    select item)
                    .ToList();
        }


        List <Target> getTargets()
        {
            return (from IItem item in activeStation.GetItemList()
                    where item.GetItemType() == ItemType.Target
                    select new Target(item))
                    .ToList();
        }

        List<Frame> getFrames()
        {
            return (from IItem item in activeStation.GetItemList()
                    where item.GetItemType() == ItemType.Frame
                    select new Frame(item))
                    .ToList();
        }

        List<Robot> getRobots()
        {
            return (from IItem item in activeStation.GetItemList()
                    where item.GetItemType() == ItemType.Robot
                    select new Robot(item))
                    .ToList();
        }

        #endregion

    }
}
