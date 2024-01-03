using RoboDk.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Models
{
    internal class ProgramDetails
    {
        public IItem LinkedRobot;

        public string ProgramName;

        public ProgramDetails(IItem linkedRobot, string programName)
        {
            LinkedRobot = linkedRobot;
            ProgramName = programName;
        }
    }
}
