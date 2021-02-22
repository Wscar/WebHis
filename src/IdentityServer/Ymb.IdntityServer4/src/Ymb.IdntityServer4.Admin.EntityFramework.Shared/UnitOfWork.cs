using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EntityFramework.Shared
{
    public class UnitOfWork : IUnitOfWork<DbContext>
    {
        private readonly DbContext _dbContext;
        public UnitOfWork( DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int Commit()
        {
           return  this._dbContext.SaveChanges();
        }

        public async Task<int> CommitAsnyc()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void CommitTransaction()
        {   
          
            this._dbContext.Database.CommitTransaction();
        }

        public Task CommitTransactionAsync()
        {
            this._dbContext.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public void RollBackTransaction()
        {
            this._dbContext.Database.RollbackTransaction();
        }      
    }
}
