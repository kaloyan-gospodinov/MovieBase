using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class ReviewLink
    {
        [DataMember(Name = "review")]
        public string Review { get; set; }
    }
}
