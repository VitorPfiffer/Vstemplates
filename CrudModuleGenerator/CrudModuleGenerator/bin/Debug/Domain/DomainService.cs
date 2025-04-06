using $ProjectName$.Core.Api.Pagination;
using $ProjectName$.Core.Domain.Services;
using $ProjectName$.Core.FluentValidator.ValidatorManager;
using $ProjectName$.Core.NotificationManager;
using $ProjectName$.Domain.Entities;
using $ProjectName$.Domain.Interfaces.Repositories;
using $ProjectName$.Domain.Interfaces.Services;

namespace $ProjectName$.Domain.Services
{
    public sealed class $EntityName$DomainService : DomainService, I$EntityName$DomainService
    {
        private readonly I$EntityName$Repository _$LowerCaseEntityName$Repository;

        public $EntityName$DomainService(INotificationManager notificationManager, IValidatorManager validationManager, I$EntityName$Repository $LowerCaseEntityName$Repository) : base(notificationManager, validationManager)
        {
            _$LowerCaseEntityName$Repository = $LowerCaseEntityName$Repository;
        }

        public async Task AddAsync($EntityName$ entity)
        {

            await _$LowerCaseEntityName$Repository.AddAsync(entity);
        }

        public async Task DeleteAsync($EntityName$ entity)
        {
            await _$LowerCaseEntityName$Repository.DeleteAsync(entity);
        }

        public async Task<$EntityName$?> GetByIdAsync(Guid id, bool includeDeleted = false)
        {
            var $LowerCaseEntityName$ = await _$LowerCaseEntityName$Repository.GetByIdAsync(id, includeDeleted);
            if ($LowerCaseEntityName$ == null)
                NotifyError("$LowerCaseEntityName$_not_found");

            return $LowerCaseEntityName$;
        }

        public async Task UpdateAsync($EntityName$ entity)
        {
            await _$LowerCaseEntityName$Repository.UpdateAsync(entity);
        }
        public async Task<IEnumerable<$EntityName$>> GetPagedAsync(PagedQuery queryParameters)
        {
            return await _$LowerCaseEntityName$Repository.GetPagedAsync(queryParameters);
        }
    }
}