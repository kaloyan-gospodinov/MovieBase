using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Movie_Base.Model
{
    [DataContract]
    public class CastMember
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "characters", IsRequired = false)]
        public string[] Characters { get; set; }
    }
}
