using System;
using System.Linq;

namespace Movie_Base.Services
{
    public class Event : EventArgs
    {
        public Status Status { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public object Object { get; set; }
    }
}