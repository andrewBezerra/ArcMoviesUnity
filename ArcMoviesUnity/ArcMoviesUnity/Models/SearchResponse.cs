using ArcMoviesUnity.Droid;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ArcMoviesUnity.Models
{
    [Preserve]
    [DataContract]
    public class SearchResponse<T>:IDisposable
    {
        [DataMember(Name = "results")]
        public IReadOnlyList<T> Results { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; private set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; private set; }

        public void Dispose()
        {
            Results = null;
            GC.SuppressFinalize(this);
            
        }
    }
}
