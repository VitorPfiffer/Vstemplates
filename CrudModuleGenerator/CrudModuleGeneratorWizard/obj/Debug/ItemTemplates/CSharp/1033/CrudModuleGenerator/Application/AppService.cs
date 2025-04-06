using AutoMapper;
using $ProjectName$.Application.Interfaces;
using $ProjectName$.Application.ViewModels;
using $ProjectName$.Core.Api.Pagination;
using $ProjectName$.Core.Application;
using $ProjectName$.Core.NotificationManager;
using $ProjectName$.Domain.Entities;
using $ProjectName$.Domain.Interfaces.Services;
using $ProjectName$.Domain.Interfaces.UnitOfWork;

namespace $ProjectName$.Application.Services
{
    public class $EntityName$ServiceApp : ApplicationService, I$EntityName$ServiceApp
    {
        private readonly I$EntityName$DomainService _$LowerCaseEntityName$DomainService;
        private readonly I$ProjectName$UnitOfWork _unitOfWork;

        public $EntityName$ServiceApp(INotificationManager notificationManager, IMapper mapper, I$EntityName$DomainService $LowerCaseEntityName$DomainService, I$ProjectName$UnitOfWork unitOfWork) : base(notificationManager, mapper)
        {
            _$LowerCaseEntityName$DomainService = $LowerCaseEntityName$DomainService;
            _unitOfWork = unitOfWork;
        }

        public async Task<$EntityName$ViewModel?> GetByIdAsync(Guid id)
        {
            var $LowerCaseEntityName$ = await _$LowerCaseEntityName$DomainService.GetByIdAsync(id);

            var viewModel = _mapper.Map<$EntityName$ViewModel>($LowerCaseEntityName$);

            return viewModel;
        }

        public async Task AddAsync(Add$EntityName$ViewModel model)
        {
            var $LowerCaseEntityName$ = _mapper.Map<$EntityName$>(model);

            await _$LowerCaseEntityName$DomainService.AddAsync($LowerCaseEntityName$);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, Update$EntityName$ViewModel model)
        {
            var $LowerCaseEntityName$ = _mapper.Map<$EntityName$>(model);
            $LowerCaseEntityName$.SetId(id);

            await _$LowerCaseEntityName$DomainService.UpdateAsync($LowerCaseEntityName$);
        }
        public async Task DeleteAsync(Guid Id)
        {
            var $LowerCaseEntityName$ = await _$LowerCaseEntityName$DomainService.GetByIdAsync(Id);

            if ($LowerCaseEntityName$ == null) return;
            await _$LowerCaseEntityName$DomainService.DeleteAsync($LowerCaseEntityName$);

        }
        public async Task<IEnumerable<$EntityName$ViewModel>> GetPagedAsync(PagedQuery queryParameters)
        {
            var $LowerCaseEntityName$List = await _$LowerCaseEntityName$DomainService.GetPagedAsync(queryParameters);

            return _mapper.Map<IEnumerable<$EntityName$ViewModel>>($LowerCaseEntityName$List);
        }
    }
}