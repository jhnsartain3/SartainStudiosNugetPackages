using Newtonsoft.Json;
using Sartain_Studios_Common.Http_Functions.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sartain_Studios_Common.Http_Functions
{
    public class HttpFunctions : IHttpFunctions
    {
        public async Task<T> Get<T>(string baseUri, string port, string url)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                };

                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(baseUri + port);
                    var response = await client.GetAsync(url);
                    var resultContentString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(resultContentString);
                }
            }
        }

        public async Task Put<T>(string baseUri, string url, T stringValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8,
                    "application/json");
                var result = await client.PutAsync(url, content);
            }
        }

        public async Task<dynamic> Post<T>(string baseUri, string url, T contentValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8,
                    "application/json");
                var result = await client.PostAsync(url, content);

                if (!result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<HttpResponseModel>(await result.Content.ReadAsStringAsync());

                var resultContentString = await result.Content.ReadAsStringAsync();
                var resultContent = JsonConvert.DeserializeObject<T>(resultContentString);

                return resultContent;
            }
        }

        public async Task Delete(string baseUri, string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var result = await client.DeleteAsync(url);
            }
        }
    }
}