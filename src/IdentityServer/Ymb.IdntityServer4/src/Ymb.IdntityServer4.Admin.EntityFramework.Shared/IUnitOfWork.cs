using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EntityFramework.Shared
{
    public interface IUnitOfWork
    {

        int Commit();
        void CommitTransaction();
       
        void RollBackTransaction();

        Task<int> CommitAsnyc();
        Task CommitTransactionAsync();
     
    }
    public interface IUnitOfWork<T>:IUnitOfWork where T:DbContext
    {

         
    }
}
