using $ProjectName$.Core.Infrastructure.Repository;
using $ProjectName$.Domain.Entities;
using $ProjectName$.Domain.Interfaces.Repositories;
using $ProjectName$.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace $ProjectName$.Infrastructure.Repositories
{
    public sealed class $EntityName$Repository($ProjectName$Context context) : Repository<$EntityName$>(context), I$EntityName$Repository
    {

        public override async Task<$EntityName$?> GetByIdAsync(Guid id, bool includeDeleted = false)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}