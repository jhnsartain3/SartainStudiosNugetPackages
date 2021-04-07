using DatabaseInteraction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseInteraction.Interfaces
{
    public interface IUserSpecificDatabaseAccess<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string userId);
        Task<TEntity> GetByIdAsync(string userId, string id);
        Task UpdateAsync(string userId, string id, TEntity entity);
        Task<string> CreateAsync(string userId, TEntity entity);
        Task DeleteAsync(string userId, string id);
        void SetupConnectionAsync(ConnectionModel connectionModel);
    }
}