using $ProjectName$.Application.Interfaces;
using $ProjectName$.Application.ViewModels;
using $ProjectName$.Core.Api.FeatureFlag;
using $ProjectName$.Core.Api.Pagination;
using $ProjectName$.Core.Controller;
using Microsoft.AspNetCore.Mvc;

namespace $ProjectName$.API.Controllers
{
    public sealed class $EntityName$Controller(I$EntityName$ServiceApp $LowerCaseEntityName$ServiceApp) : ApiController
    {
        [HttpGet("{id}")]
        public async Task<$EntityName$ViewModel?> GetByIdAsync(Guid id) => await $LowerCaseEntityName$ServiceApp.GetByIdAsync(id);

        [HttpPost]
        [CustomFeatureGate("$EntityName$_Add_Enable")]
        public async Task AddAsync([FromBody] Add$EntityName$ViewModel model) => await $LowerCaseEntityName$ServiceApp.AddAsync(model);

        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, [FromBody] Update$EntityName$ViewModel model) => await $LowerCaseEntityName$ServiceApp.UpdateAsync(id, model);

        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(Guid id) => await $LowerCaseEntityName$ServiceApp.DeleteAsync(id);

        [HttpGet]
        public async Task<IEnumerable<$EntityName$ViewModel>> GetPagedAsync([FromQuery] PagedQuery queryParameters) => await $LowerCaseEntityName$ServiceApp.GetPagedAsync(queryParameters);
    }
}