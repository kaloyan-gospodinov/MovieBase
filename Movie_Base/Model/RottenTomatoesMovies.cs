using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class RottenTomatoesMovies
    {
        [DataMember(Name = "total", IsRequired = false)]
        public int Total { get; set; }

        [DataMember(Name = "movies")]
        public Movie[] Movies { get; set; }

        [DataMember(Name = "links")]
        public SelfLinks SelfLinks { get; set; }

        [DataMember(Name = "link_template")]
        public string LinkTemplate { get; set; }
    }
}