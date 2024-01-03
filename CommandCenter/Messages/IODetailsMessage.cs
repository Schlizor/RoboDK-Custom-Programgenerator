﻿using CommandCenter.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Messages
{
    internal class IODetailsMessage : ValueChangedMessage<IO>
    {
        public IODetailsMessage(IO value) : base(value)
        {
        }
    }
}
