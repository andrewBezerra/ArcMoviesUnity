using Flurl.Http;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    public class FlurlHttpService : IHttpRequest
    {
    
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            return await uri.GetJsonAsync<TResult>();
        }
    }
}
