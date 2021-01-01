using DatabaseInteraction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseInteraction.Interfaces
{
    public interface IDatabaseAccessWithoutUserId<TEntity> where TEntity : EntityBaseWithoutUserId
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task UpdateAsync(string id, TEntity entity);
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(string id);
    }
}