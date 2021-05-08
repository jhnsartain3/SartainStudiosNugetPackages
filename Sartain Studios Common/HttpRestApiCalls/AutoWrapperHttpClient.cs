using Httwrap;
using Microsoft.Extensions.Configuration;
using Sartain_Studios_Common.Logging;
using Sartain_Studios_Common.SharedModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sartain_Studios_Common.HttpRestApiCalls
{
    public interface IAutoWrapperHttpClient<TEntity>
    {
        Task<List<AutoWrapperResponseModel<TEntity>>> GetAllAsync(string urlExtension, string token = null);
        Task<List<AutoWrapperResponseModel<TEntity>>> GetAllByIdAsync(string urlExtension, string id, string token = null);
        Task<List<AutoWrapperResponseModel<T>>> GetAllByIdAsync<T>(string urlExtension, string id, string token = null);
        Task<AutoWrapperResponseModel<TEntity>> GetByIdAsync(string urlExtension, string id, string token = null);
        Task<AutoWrapperResponseModel<T>> GetByIdAsync<T>(string urlExtension, string id, string token = null);
        Task<bool> PutAsync(string urlExtension, string id, TEntity model, string token = null);
        Task<bool> PostAsync(string urlExtension, TEntity model, string token = null);
        Task<AutoWrapperResponseModel<string>> PostWithResultAsync(string urlExtension, TEntity model, string token = null);
        Task<bool> DeleteAsync(string urlExtension, string id, string token = null);
    }

    public class AutoWrapperHttpClient<TEntity> : HttpClientBase<TEntity>, IAutoWrapperHttpClient<TEntity>
    {
        public AutoWrapperHttpClient(IConfiguration configuration, ILoggerWrapper loggerWrapper) : base(configuration, loggerWrapper) { }

        public new async Task<List<AutoWrapperResponseModel<TEntity>>> GetAllAsync(string urlExtension, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllAsync(urlExtension, token)).ReadAs<List<AutoWrapperResponseModel<TEntity>>>());

        public new async Task<List<AutoWrapperResponseModel<TEntity>>> GetAllByIdAsync(string urlExtension, string itemId, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllByIdAsync(urlExtension + "/" + itemId, token)).ReadAs<List<AutoWrapperResponseModel<TEntity>>>());

        public new async Task<List<AutoWrapperResponseModel<T>>> GetAllByIdAsync<T>(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetAllByIdAsync<T>(urlExtension + "/" + id, token)).ReadAs<List<AutoWrapperResponseModel<T>>>());

        public new async Task<AutoWrapperResponseModel<TEntity>> GetByIdAsync(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetByIdAsync(urlExtension + "/" + id, token)).ReadAs<AutoWrapperResponseModel<TEntity>>());

        public new async Task<AutoWrapperResponseModel<T>> GetByIdAsync<T>(string urlExtension, string id, string token = null) =>
            await CheckResponseExceptions(async () => (await base.GetByIdAsync<T>(urlExtension + "/" + id, token)).ReadAs<AutoWrapperResponseModel<T>>());

        public new async Task<bool> PutAsync(string urlExtension, string id, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PutAsync(urlExtension + "/" + id, model, token)).Success);

        public new async Task<bool> PostAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PostAsync(urlExtension, model, token)).Success);

        public new async Task<AutoWrapperResponseModel<string>> PostWithResultAsync(string urlExtension, TEntity model, string token = null) =>
            await CheckResponseExceptions(async () => (await base.PostWithResultAsync(urlExtension, model, token)).ReadAs<AutoWrapperResponseModel<string>>());

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