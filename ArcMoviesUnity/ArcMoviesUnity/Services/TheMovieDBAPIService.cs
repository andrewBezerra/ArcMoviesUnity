using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Helpers;
using ArcMoviesUnity.Models;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    [Preserve]
    public sealed class TheMovieDBAPIService : ITheMovieDBAPIService
    {
        private readonly IHttpRequest _request;

        public TheMovieDBAPIService(IHttpRequest request)
        {
            _request = request;
        }

        public async Task<SearchResponse<Movie>> GetUpcomingMoviesAsync(int pageNumber = 1, string language = "en")
        {

            var url = $"{AppSettings.ApiBaseUrl}movie/" +
                    $"upcoming?api_key={AppSettings.ApiKey}" +
                    $"&language={language}" +
                    $"&page={pageNumber}";

           return await _request.GetAsync<SearchResponse<Movie>>(url).ConfigureAwait(false);

           

        }
       
        public async Task<Movie> FindByIdAsync(int movieId, string language = "en")
        {
            string url = $"{AppSettings.ApiBaseUrl}movie/{movieId}?api_key={AppSettings.ApiKey}&language={language}";

           return await _request.GetAsync<Movie>(url);

           
        }
    }
}
