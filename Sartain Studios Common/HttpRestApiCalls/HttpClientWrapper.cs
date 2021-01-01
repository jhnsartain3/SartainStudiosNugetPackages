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
    public class HttpClientWrapper<TEntity> : IHttpClientWrapper<TEntity>
    {
        private IHttwrapClient _httwrapClient;
        private ILoggerWrapper _loggerWrapper;

        public HttpClientWrapper(IConfiguration configuration, ILoggerWrapper loggerWrapper)
        {
            _loggerWrapper = loggerWrapper;

            var baseUrl = configuration["ConnectionStrings:MainApi"];

            CheckExceptions(async () => SetupHttpConnection(baseUrl));
        }

        public async Task<List<TEntity>> GetAllAsync(string urlExtension, string token = null)
        {
            _loggerWrapper.LogInformation($"Get {urlExtension} {token}", this.GetType().Name, nameof(GetAllAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.GetAsync(urlExtension, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<List<TEntity>>());
        }

        public async Task<List<TEntity>> GetAllByIdAsync(string urlExtension, string itemId, string token = null)
        {
            _loggerWrapper.LogInformation($"Get {urlExtension} {token}", this.GetType().Name, nameof(GetAllByIdAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.GetAsync(urlExtension + "/" + itemId, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<List<TEntity>>());
        }

        public async Task<List<T>> GetAllByIdAsync<T>(string urlExtension, string id, string token = null)
        {
            _loggerWrapper.LogInformation($"Get {urlExtension} {id} {token}", this.GetType().Name, nameof(GetAllByIdAsync) + "<T>()", null);

            return await CheckExceptions(async () => (await _httwrapClient.GetAsync(urlExtension + "/" + id, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<List<T>>());
        }

        public async Task<TEntity> GetByIdAsync(string urlExtension, string id, string token = null)
        {
            _loggerWrapper.LogInformation($"Get {urlExtension} {id} {token}", this.GetType().Name, nameof(GetByIdAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.GetAsync(urlExtension + "/" + id, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<TEntity>());
        }

        public async Task<T> GetByIdAsync<T>(string urlExtension, string id, string token = null)
        {
            _loggerWrapper.LogInformation($"Get {urlExtension} {id} {token}", this.GetType().Name, nameof(GetByIdAsync) + "<T>()", null);

            return await CheckExceptions(async () => (await _httwrapClient.GetAsync(urlExtension + "/" + id, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<T>());
        }

        public async Task<bool> PutAsync(string urlExtension, string id, TEntity model, string token = null)
        {
            _loggerWrapper.LogInformation($"Put {urlExtension} {id} {nameof(model)} {token}", this.GetType().Name, nameof(PutAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.PutAsync(urlExtension + "/" + id, model, null, token != null ? GetCustomHeaders(token) : null)).Success);
        }

        public async Task<bool> PostAsync(string urlExtension, TEntity model, string token = null)
        {
            _loggerWrapper.LogInformation($"Post {urlExtension} {nameof(model)} {token}", this.GetType().Name, nameof(PostAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.PostAsync(urlExtension, model, null, token != null ? GetCustomHeaders(token) : null)).Success);
        }

        public async Task<string> PostWithResultAsync(string urlExtension, TEntity model, string token = null)
        {
            _loggerWrapper.LogInformation($"Post {urlExtension} {nameof(model)} {token}", this.GetType().Name, nameof(PostWithResultAsync) + "()", null);

            return (await _httwrapClient.PostAsync(urlExtension, model, null, token != null ? GetCustomHeaders(token) : null)).ReadAs<string>();
        }

        public async Task<bool> DeleteAsync(string urlExtension, string id, string token = null)
        {
            _loggerWrapper.LogInformation($"Delete {urlExtension} {id} {token}", GetType().Name, nameof(DeleteAsync) + "()", null);

            return await CheckExceptions(async () => (await _httwrapClient.DeleteAsync(urlExtension + "/" + id, null, token != null ? GetCustomHeaders(token) : null)).Success);
        }

        private void SetupHttpConnection(string baseUrl)
        {
            if (baseUrl.ToLower().Contains("http://") || baseUrl.ToLower().Contains("https://"))
            {
                _loggerWrapper.LogInformation("Setting up http connection with base url of " + baseUrl, this.GetType().Name, nameof(SetupHttpConnection) + "()", null);

                IHttwrapConfiguration httwrapConfiguration = new HttwrapConfiguration(baseUrl);
                _httwrapClient = new HttwrapClient(httwrapConfiguration);
            }
            else
            {
                _loggerWrapper.LogInformation("Failed to setup http connection with base url of " + baseUrl + " because http or https was missing", this.GetType().Name, nameof(SetupHttpConnection) + "()", null);
                throw new Exception(baseUrl + " is invalid. You must include http or https");
            }
        }

        public void UpdateBaseUrl(string newBaseUrl) => SetupHttpConnection(newBaseUrl);

        private T CheckExceptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (SocketException socketException)
            {
                _loggerWrapper.LogError(nameof(SocketException) + "Could not connect to datasource", GetType().Name, nameof(CheckExceptions) + "()", null);
                _loggerWrapper.LogError(nameof(SocketException) + socketException.Message, GetType().Name, nameof(CheckExceptions) + "()", null);

                throw new HttpRequestException("Could not connect to datasource, socket exception", socketException);
            }
            catch (HttpRequestException httpRequestException)
            {
                _loggerWrapper.LogError(nameof(HttpRequestException) + "Could not connect to datasource", GetType().Name, nameof(CheckExceptions) + "()", null);
                _loggerWrapper.LogError(nameof(HttpRequestException) + httpRequestException.Message, GetType().Name, nameof(CheckExceptions) + "()", null);

                throw new HttpRequestException("Could not connect to datasource, http request exception", httpRequestException);
            }
            catch (HttwrapException httpwrapException)
            {
                _loggerWrapper.LogError(nameof(HttwrapException) + "Could not connect to datasource", GetType().Name, nameof(CheckExceptions) + "()", null);
                _loggerWrapper.LogError(nameof(HttwrapException) + httpwrapException.Message, GetType().Name, nameof(CheckExceptions) + "()", null);

                throw new HttpRequestException("Could not connect to datasource, httwrap exception", httpwrapException);
            }
        }

        private Dictionary<string, string> GetCustomHeaders(string token)
        {
            _loggerWrapper.LogInformation("authorization: Bearer " + token, GetType().Name, nameof(GetCustomHeaders) + "()", null);

            return new Dictionary<string, string> { { "authorization", "Bearer " + token } };
        }
    }
}