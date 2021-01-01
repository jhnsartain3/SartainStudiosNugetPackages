using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sartain_Studios_Common.HttpRestApiCalls
{
    public interface IHttpClientWrapper<TEntity>
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
        void UpdateBaseUrl(string newBaseUrl);
    }
}