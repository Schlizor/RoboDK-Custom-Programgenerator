using RoboDk.API.Model;
using RoboDk.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Models
{
    internal class Targets
    {
        private IItem _target;

        public string Name
        {
            get
            {
                return _target.Name();
            }
        }

        public Mat pose { get { return _target.Pose(); } }

        public IItem Target
        {
            get { return _target; }
            private set { _target = value; }
        }


        /// <summary>
        /// Object which represents a Frame.
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="ArgumentException"></exception>
        public Targets(IItem target)
        {
                _target = target;
        }

        public override string ToString()
        {
            return $"{Name} ; {pose}";
        }


    }
}
