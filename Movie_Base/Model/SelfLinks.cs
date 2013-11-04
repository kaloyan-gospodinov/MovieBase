using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class SelfLinks
    {
        [DataMember(Name = "self")]
        public string Self { get; set; }

        [DataMember(Name = "next", IsRequired = false)]
        public string Next { get; set; }

        [DataMember(Name = "alternate")]
        public string Alternate { get; set; }

        [DataMember(Name = "rel", IsRequired = false)]
        public string Rel { get; set; }
    }
}
