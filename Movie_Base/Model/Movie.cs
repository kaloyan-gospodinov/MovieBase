using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class Movie
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "mpaa_rating")]
        public string MPAARating { get; set; }

        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "critics_concensus")]
        public string CriticsConsensus { get; set; }

        [DataMember(Name = "releasedates")]
        public ReleaseDates ReleaseDates { get; set; }

        [DataMember(Name = "ratings")]
        public Ratings Ratings { get; set; }

        [DataMember(Name = "synopsis")]
        public string Synopsis { get; set; }

        [DataMember(Name = "posters")]
        public Posters Posters { get; set; }

        [DataMember(Name = "abridged_cast")]
        public CastMember[] AbridgedCast { get; set; }

        [DataMember(Name = "alternate_ids")]
        public AlternateIds AlternateIds { get; set; }

        [DataMember(Name = "links")]
        public MovieLinks Links { get; set; }
    }
}
