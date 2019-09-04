using ArcMoviesUnity.Droid;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ArcMoviesUnity.Models
{
    [Preserve]
    [DataContract]
    public sealed class MovieVideo
    {
        [DataMember(Name = "id")]
        public int MovieId { get; set; }

        [DataMember(Name = "results")]
        public IList<MovieVideoItem> Videos { get; set; }
    }
}