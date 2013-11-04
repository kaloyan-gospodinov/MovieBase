using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class Posters
    {
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }

        [DataMember(Name = "profile")]
        public string Profile { get; set; }

        [DataMember(Name = "detailed")]
        public string Detailed { get; set; }

        [DataMember(Name = "original")]
        public string Original { get; set; }
    }
}
