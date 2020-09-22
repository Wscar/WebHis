using Microsoft.Extensions.Logging;
using SmartSql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public class ApiResourceRepository : IApiResourceRepository
    {
        public readonly ISqlMapper _sqlMapper;
        public ILogger<ApiResourceRepository> _logger;
        public ApiResourceRepository(ISqlMapper sqlMapper, ILogger<ApiResourceRepository> logger)
        {
            this._sqlMapper = sqlMapper;
            this._logger = logger;
        }
        public void ExcuteNoQuery(RequestContext request)
        {
            this._sqlMapper.Execute(request);
        }

        public async Task ExcuteNoQueryAsync(RequestContext request)
        {
            await this._sqlMapper.ExecuteAsync(request);
        }

        public Task InserAsync<T>(T enity)
        {
            throw new NotImplementedException();
        }

        public void Insert(RequestContext request)
        {
            this._sqlMapper.Execute(request);
        }

        public void Insert<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(RequestContext request)
        {
            await this._sqlMapper.ExecuteAsync(request);
        }

        public IEnumerable<T> QueryAll<T>(RequestContext request)
        {
            return  this._sqlMapper.Query<T>(request);
        }

        public async Task<IEnumerable<T>> QueryAllAsync<T>(RequestContext request)
        {
            return await this._sqlMapper.QueryAsync<T>(request);
        }

        public T QuerySingle<T>(RequestContext request)
        {
            return this._sqlMapper.QuerySingle<T>(request);
        }

        public async Task<T> QuerySingleAsync<T>(RequestContext request)
        {
            return await this._sqlMapper.QuerySingleAsync<T>(request);
        }
    }
}
