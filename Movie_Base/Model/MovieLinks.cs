using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class MovieLinks
    {
        [DataMember(Name = "self")]
        public string Self { get; set; }

        [DataMember(Name = "alternate")]
        public string Alternate { get; set; }

        [DataMember(Name = "cast")]
        public string Cast { get; set; }

        [DataMember(Name = "clips")]
        public string Clips { get; set; }

        [DataMember(Name = "reviews")]
        public string Reviews { get; set; }

        [DataMember(Name = "similar")]
        public string Similar { get; set; }
    }
}
