using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class Review
    {
        [DataMember(Name = "critic")]
        public string Critic { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "freshness")]
        public string Freshness { get; set; }

        [DataMember(Name = "publication")]
        public string Publication { get; set; }

        [DataMember(Name = "quote")]
        public string Quote { get; set; }

        [DataMember(Name = "links")]
        public ReviewLink Link { get; set; }
    }
}
