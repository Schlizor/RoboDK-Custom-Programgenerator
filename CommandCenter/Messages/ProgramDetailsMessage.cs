using CommandCenter.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using RoboDk.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Messages
{
    internal class ProgramDetailsMessage : ValueChangedMessage<ProgramDetails>
    {
        public ProgramDetailsMessage(ProgramDetails value) : base(value)
        {
        }
    }
}
