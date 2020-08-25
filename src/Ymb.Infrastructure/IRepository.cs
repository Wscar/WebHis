using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartSql;
namespace Ymb.Infrastructure
{
    public interface IRepository
    {
        void ExcuteNoQuery(RequestContext request);
        IEnumerable<T> QueryAll<T>(RequestContext request);
        T QuerySingle<T>(RequestContext request);
        void Insert(RequestContext request);
        void Insert<T>(T entity);
        Task InserAsync<T>(T enity);
        Task InsertAsync(RequestContext request);
        Task ExcuteNoQueryAsync(RequestContext request);
        Task<T> QuerySingleAsync<T>(RequestContext request);
        Task<IEnumerable<T>> QueryAllAsync<T>(RequestContext request);

    }
}
