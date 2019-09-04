using ArcMoviesUnity.Droid;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    [Preserve(AllMembers = true)]
    public interface IHttpRequest
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
