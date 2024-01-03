using RoboDk.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Models
{
    internal class TargetDetails
    {
        public string? Name;

        public IItem? linkedrobot;

        public TargetDetails(string? name, IItem? linkedrobot)
        {
            Name = name;
            this.linkedrobot = linkedrobot;
        }
    }
}
