using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboDk;
using RoboDk.API;

namespace CommandCenter
{
    internal class MainViewModel
    {
        private RoboDK robodk;

        public MainViewModel() 
        {
             robodk = new RoboDK();
        
        }
    }
}
