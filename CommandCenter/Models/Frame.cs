using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboDk;
using RoboDk.API;
using RoboDk.API.Model;

namespace CommandCenter.Models
{
    internal class Frame

    {
        private IItem _frame;



        public string Name
        {
            get
            {
                return _frame.Name();
            }
        }

        public Mat pose { get { return _frame.Pose(); } } 

        public IItem FrameItem { 
            get { return _frame; }
            private set { _frame = value; }
        }

        public long ItemId => throw new NotImplementedException();


        /// <summary>
        /// Object which represents a Frame.
        /// </summary>
        /// <param name="frame"></param>
        /// <exception cref="ArgumentException"></exception>
        public Frame(IItem frame)
        { 
                _frame = frame;

            
        }

        public override string ToString()
        {
            return $"{Name} ; {pose}" ;
        }

       
    }
}
