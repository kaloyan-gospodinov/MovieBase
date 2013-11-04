using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class ReleaseDates
    {
        [DataMember(Name = "theater")]
        public string Theater { get; set; }
    }
}
