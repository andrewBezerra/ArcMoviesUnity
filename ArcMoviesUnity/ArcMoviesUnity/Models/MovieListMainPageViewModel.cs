using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ArcMoviesUnity.Models
{
    [DataContract]
    public class MovieListMainPageViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }
        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }
        [DataMember(Name = "release_date")]
        public DateTime ReleaseDate { get; set; }
        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }
    }
}
