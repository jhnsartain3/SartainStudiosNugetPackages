using Httwrap;
using Httwrap.Interface;
using Microsoft.Extensions.Configuration;
using Sartain_Studios_Common.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Sartain_Studios_Common.HttpRestApiCalls
{
    public interface IHttpClientBase<TEntity> { }

    public class HttpClientBase<TEntity>
    {
        private IHttwrapClient _httwrapClient;
        protected ILoggerWrapper _loggerWrapper;

        public HttpClientBase(IConfiguration configuration, ILoggerWrapper loggerWrapper)
        {
            _loggerWrapper = loggerWrapper;

            var baseUrl = configuration["ConnectionStrings:MainApi"];

            CheckExceptions(async () => SetupHttpConnection(baseUrl));
        }

        protected async Task<IHttwrapResponse> GetAllAsync(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> GetAllByIdAsync(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> GetAllByIdAsync<T>(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> GetByIdAsync(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> GetByIdAsync<T>(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> PutAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.PutAsync(urlExtension, model, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> PostAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.PostAsync(urlExtension, model, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> PostWithResultAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.PostAsync(urlExtension, model, null, token != null ? GetCustomHeaders(token) : null));

        protected async Task<IHttwrapResponse> DeleteAsync(string urlExtension, string token = null) =>
            await CheckExceptions(async () => await _httwrapClient.DeleteAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null));

        private void SetupHttpConnection(string baseUrl)
        {
            if (!UriIncludesHttpPrefex(baseUrl) && !UriIncludesHttpsPrefex(baseUrl))
            {
                var errorMessage = $"URI is invalid because http(s) was not included in ${baseUrl}";
                _loggerWrapper.LogInformation(errorMessage, GetType().Name, nameof(SetupHttpConnection), null);
                throw new ArgumentException(errorMessage, nameof(baseUrl));
            }

            _loggerWrapper.LogInformation("Setting up http connection with base url of " + baseUrl, GetType().Name, nameof(SetupHttpConnection) + "()", null);

            IHttwrapConfiguration httwrapConfiguration = new HttwrapConfiguration(baseUrl);
            _httwrapClient = new HttwrapClient(httwrapConfiguration);
        }

        private bool UriIncludesHttpPrefex(string uri) => uri.ToLower().Contains("http://");
        private bool UriIncludesHttpsPrefex(string uri) => uri.ToLower().Contains("https://");

        private T CheckExceptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (SocketException socketException)
            {
                _loggerWrapper.LogError(nameof(SocketException) + socketException.Message, GetType().Name, nameof(CheckExceptions), null);

                throw new HttpRequestException("Could not connect to datasource, socket exception", socketException);
            }
            catch (HttpRequestException httpRequestException)
            {
                _loggerWrapper.LogError(nameof(HttpRequestException) + httpRequestException.Message, GetType().Name, nameof(CheckExceptions), null);

                throw new HttpRequestException("Could not connect to datasource, http request exception", httpRequestException);
            }
            catch (HttwrapException httpwrapException)
            {
                _loggerWrapper.LogError(nameof(HttwrapException) + httpwrapException.Message, GetType().Name, nameof(CheckExceptions), null);

                throw new HttpRequestException("Could not connect to datasource, httwrap exception", httpwrapException);
            }
        }

        private Dictionary<string, string> GetCustomHeaders(string token)
        {
            _loggerWrapper.LogInformation("authorization: Bearer " + token, GetType().Name, nameof(GetCustomHeaders), null);

            return new Dictionary<string, string> { { "authorization", "Bearer " + token } };
        }
    }
}