using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EF
{
    public class UnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }
    }
}
