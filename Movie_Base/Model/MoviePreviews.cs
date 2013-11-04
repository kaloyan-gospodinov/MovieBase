using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class MoviePreviews
    {
        [DataMember]
        public Clip[] Clips { get; set; }

        [DataMember(Name = "links")]
        public SelfLinks Links { get; set; }
    }
}