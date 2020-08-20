using ArcMoviesUnity.Droid;
using System.Runtime.Serialization;

namespace ArcMoviesUnity.Models
{
    [Preserve]
    [DataContract]
    public struct Country
    {
        [DataMember(Name = "iso_3166_1")]
        public string Iso3166Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}