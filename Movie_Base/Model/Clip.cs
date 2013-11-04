using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class Clip
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "duration")]
        public string Duration { get; set; }

        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }

        [DataMember(Name = "links")]
        public PreviewLinks Links { get; set; }
    }
}
