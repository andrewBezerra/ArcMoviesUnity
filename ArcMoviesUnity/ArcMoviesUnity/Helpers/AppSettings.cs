using ArcMoviesUnity.Droid;

namespace ArcMoviesUnity.Helpers
{
    [Preserve]
    public sealed class AppSettings
    {
        public static string PosterImageBaseUrl = "http://image.tmdb.org/t/p/w185/";
        public static string BackdropImageBaseUrl = "http://image.tmdb.org/t/p/w500/";
        public static string ApiBaseUrl = "https://api.themoviedb.org/3/";
        public static string ApiKey = APIKEY.Secret; // REMOVA ISSO E COLOQUE SUA KEY AQUI
        
    }
}
