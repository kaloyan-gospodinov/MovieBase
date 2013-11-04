using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{

    [DataContract]
    public class AlternateIds
    {
        [DataMember(Name = "imdb")]
        public string Imdb { get; set; }
    }
}
