using $ProjectName$.Application.ViewModels;
using $ProjectName$.Core.Api.Pagination;

namespace $ProjectName$.Application.Interfaces
{
    public interface I$EntityName$ServiceApp
    {
        Task AddAsync(Add$EntityName$ViewModel model);
        Task<$EntityName$ViewModel?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid Id);
        Task UpdateAsync(Guid id, Update$EntityName$ViewModel model);
        Task<IEnumerable<$EntityName$ViewModel>> GetPagedAsync(PagedQuery queryParameters);

    }
}