using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class Ratings
    {
        [DataMember(Name = "critics_rating")]
        public string CriticsRating { get; set; }

        [DataMember(Name = "critics_score")]
        public int CriticsScore { get; set; }

        [DataMember(Name = "audience_rating")]
        public string AudienceRating { get; set; }

        [DataMember(Name = "audience_score")]
        public int AudienceScore { get; set; }
    }
}
