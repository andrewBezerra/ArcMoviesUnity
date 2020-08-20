using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Models;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    [Preserve]
    public interface ITheMovieDBAPIService
    {
        Task<SearchResponse<MovieListMainPageViewModel>> GetUpcomingMoviesAsync(int pageNumber = 1, string language = "en");
        Task<Movie> FindByIdAsync(int movieId, string language = "en");
    }
}
