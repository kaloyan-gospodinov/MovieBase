using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class MovieReviews
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "reviews")]
        public Review[] Reviews { get; set; }
    }
}
