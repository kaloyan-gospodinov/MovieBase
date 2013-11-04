using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class PreviewLinks
    {
        [DataMember(Name = "alternate")]
        public string Alternate { get; set; }
    }
}
