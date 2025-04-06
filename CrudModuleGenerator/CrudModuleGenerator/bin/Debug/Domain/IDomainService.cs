using $ProjectName$.Core.Api.Pagination;
using $ProjectName$.Domain.Entities;

namespace $ProjectName$.Domain.Interfaces.Services
{
    public interface I$EntityName$DomainService
    {
        Task AddAsync($EntityName$ entity);
        Task<$EntityName$?> GetByIdAsync(Guid id, bool includeDeleted = false);
        Task UpdateAsync($EntityName$ entity);
        Task DeleteAsync($EntityName$ entity);
        Task<IEnumerable<$EntityName$>> GetPagedAsync(PagedQuery queryParameters);
    }
}