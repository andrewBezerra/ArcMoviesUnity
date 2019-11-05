using Flurl;
using Flurl.Http;
using Flurl.Http.Content;
using System;
using System.Collections.Generic;
using System.Text;
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
