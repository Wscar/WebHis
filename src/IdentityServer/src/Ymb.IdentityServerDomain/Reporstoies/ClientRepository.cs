using Microsoft.Extensions.Logging;
using SmartSql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ymb.Infrastructure;
namespace Ymb.IdentityServerDomain
{
    public class ClientRepository : IClientRepository
    {     
        public readonly ISqlMapper _sqlMapper;
        public ILogger<ClientRepository> _logger;
        public ClientRepository(ISqlMapper sqlMapper, ILogger<ClientRepository> logger)
        {
           
            this._sqlMapper = sqlMapper;
            this._logger = logger;
        }
        public void ExcuteNoQuery(RequestContext request)
        {
            var result = this._sqlMapper.Execute(request);
            if (result <= 0)
            {
                this.ThrownException(request.SqlId, result);
            }
        }

        public async Task ExcuteNoQueryAsync(RequestContext request)
        {
            var result = await this._sqlMapper.ExecuteAsync(request);
            if (result <= 0)
            {
                this.ThrownException(request.SqlId, result);
            }
        }

        public Task InserAsync<T>(T enity)
        {
            throw new NotImplementedException();
        }

        public void Insert(RequestContext request)
        {
           var result= this._sqlMapper.Execute(request);
            if (result <= 0)
            {
                this.ThrownException(request.SqlId, result);
            }
        }

        public void Insert<T>(T entity)
        {
            var result= this._sqlMapper.Insert(entity);
            if (result <= 0)
            {
                this.ThrownException(this.GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, result);
            }
        }

        public async Task InsertAsync(RequestContext request)
        {
            var result= await this._sqlMapper.ExecuteAsync(request);
            if (result <= 0)
            {
                this.ThrownException(request.SqlId,result);
            }
        }

        public IEnumerable<T> QueryAll<T>(RequestContext request)
        {
            return this._sqlMapper.Query<T>(request);
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

         private void ThrownException(string sqlId,int count)
        {
            throw new Exception($"执行 sqlId={sqlId}的语句，返回的受影响的行数小于=0，实际值：{count}");
        }
        private void ThrownException( string className,  string menthodName, int count)
        {
            throw new Exception($"执行{className}类的{menthodName}的方法，返回的受影响的行数小于=0，实际值：{count}");
        }
    }
}
