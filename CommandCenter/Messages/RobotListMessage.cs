using CommandCenter.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Messages
{
    internal class RobotListMessage : ValueChangedMessage<List<Robot>>
    {
        public RobotListMessage(List<Robot> value) : base(value)
        {
        }
    }
}
