using ArcMoviesUnity.Droid;
using System.Runtime.Serialization;

namespace ArcMoviesUnity.Models
{
    [Preserve]
    [DataContract]
    public sealed class Language
    {
        [DataMember(Name = "iso_639_1")]
        public string Iso639Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}