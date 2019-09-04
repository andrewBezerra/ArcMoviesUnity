using ArcMoviesUnity.Droid;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ArcMoviesUnity.Services
{
    [Preserve]
    public sealed class HttpRequest : IHttpRequest
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly JsonSerializerSettings _serializerSettings;

        public HttpRequest()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);         

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }
        //private HttpClient CreateHttpClient()
        //{
        //    httpClient.DefaultRequestHeaders.Clear();

        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    return httpClient;
        //}

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }

                throw new HttpRequestException(content);
            }
        }
    }
}
