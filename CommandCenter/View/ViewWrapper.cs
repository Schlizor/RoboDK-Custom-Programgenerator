using CommandCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.View
{
    internal class ViewWrapper : ObservableObject
    {


        public ObservableCollection<Frames> ListFrames = new ObservableCollection<Frames>();
        public ObservableCollection<Targets> ListTargets = new ObservableCollection<Targets>();
        public ObservableCollection<Robots> ListRobots = new ObservableCollection<Robots>();    



        public ViewWrapper(List<Frames> frames, List<Targets> targets, List<Robots> robots)
        {
            if (frames != null)
            {
                ListFrames = new ObservableCollection<Frames>(frames);
            }

            if (targets != null)
            {
                ListTargets = new ObservableCollection<Targets>(targets);
            }

            if (robots != null)
            {
                ListRobots = new ObservableCollection<Robots>(robots);
            }
        }
    }
}
