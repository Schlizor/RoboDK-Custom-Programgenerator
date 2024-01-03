using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Models
{
    internal class IO
    {
        public enum IOType
        {
            DO,
            AO,
            WaitDI
        }

        public IOType iotype;

        public string Name;

        public string Value;

        public double Timeout;

        public IO(IOType io, string name, string value)
        {
            Name = name;
            Value = value;
            iotype = io;
            Timeout = 100;
        }

        public IO(IOType iotype, string name, string value, Double timeout) : this(iotype, name, value)
        {
            Timeout = timeout;
        }

        public override string ToString()
        {
            return $" {iotype}; Name: {Name}  ; Value: {Value}";
        }
    }
}
