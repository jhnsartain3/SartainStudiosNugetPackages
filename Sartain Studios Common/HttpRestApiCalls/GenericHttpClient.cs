using Httwrap;
using Microsoft.Extensions.Configuration;
using Sartain_Studios_Common.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sartain_Studios_Common.HttpRestApiCalls
{
    public interface IGenericHttpClient<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(string urlExtension, string token = null);
        Task<List<TEntity>> GetAllByIdAsync(string urlExtension, string id, string token = null);
        Task<List<T>> GetAllByIdAsync<T>(string urlExtension, string id, string token = null);
        Task<TEntity> GetByIdAsync(string urlExtension, string id, string token = null);
        Task<T> GetByIdAsync<T>(string urlExtension, string id, string token = null);
        Task<bool> PutAsync(string urlExtension, string id, TEntity model, string token = null);
        Task<bool> PostAsync(string urlExtension, TEntity model, string token = null);
        Task<string> PostWithResultAsync(string urlExtension, TEntity model, string token = null);
        Task<bool> DeleteAsync(string urlExtension, string id, string token = null);
    }

    public class GenericHttpClient<TEntity> : HttpClientBase<TEntity>, IGenericHttpClient<TEntity>
    {
        public GenericHttpClient(IConfiguration configuration, ILoggerWrapper loggerWrapper) : base(configuration, loggerWrapper) { }

        public new async Task<List<TEntity>> GetAllAsync(string urlExtension, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllAsync(urlExtension, token)).ReadAs<List<TEntity>>());

        public new async Task<List<TEntity>> GetAllByIdAsync(string urlExtension, string itemId, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllByIdAsync(urlExtension + "/" + itemId, token)).ReadAs<List<TEntity>>());

        public new async Task<List<T>> GetAllByIdAsync<T>(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllByIdAsync<T>(urlExtension + "/" + id, token)).ReadAs<List<T>>());

        public new async Task<TEntity> GetByIdAsync(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllByIdAsync(urlExtension + "/" + id, token)).ReadAs<TEntity>());

        public new async Task<T> GetByIdAsync<T>(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetByIdAsync<T>(urlExtension + "/" + id, token)).ReadAs<T>());

        public new async Task<bool> PutAsync(string urlExtension, string id, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PutAsync(urlExtension + "/" + id, model, token)).Success);

        public new async Task<bool> PostAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PostAsync(urlExtension, model, token)).Success);

        public new async Task<string> PostWithResultAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PostWithResultAsync(urlExtension, model, token)).ReadAs<string>());

        public new async Task<bool> DeleteAsync(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.DeleteAsync(urlExtension + "/" + id, token)).Success);

        private T CheckResponseExceptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                // TODO Handle exceptions here when expected exceptions are known
                throw new Exception("Rethrown", exception);
            }
        }
    }
}