using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Helpers;
using ArcMoviesUnity.Models;
using System;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    [Preserve]
    public sealed class TheMovieDBAPIService : ITheMovieDBAPIService
    {
        private readonly Lazy<FlurlHttpService> _request;

        public TheMovieDBAPIService()
        {
            _request = new Lazy<FlurlHttpService>();
        }

        public async Task<SearchResponse<MovieListMainPageViewModel>> GetUpcomingMoviesAsync(int pageNumber = 1, string language = "en")
        {

            var url = $"{AppSettings.ApiBaseUrl}movie/" +
                    $"upcoming?api_key={AppSettings.ApiKey}" +
                    $"&language={language}" +
                    $"&page={pageNumber}";

           return await _request.Value.GetAsync<SearchResponse<MovieListMainPageViewModel>>(url).ConfigureAwait(false);

           

        }
       
        public async Task<Movie> FindByIdAsync(int movieId, string language = "en")
        {
            string url = $"{AppSettings.ApiBaseUrl}movie/{movieId}?api_key={AppSettings.ApiKey}&language={language}";

           return await _request.Value.GetAsync<Movie>(url);

           
        }
    }
}
