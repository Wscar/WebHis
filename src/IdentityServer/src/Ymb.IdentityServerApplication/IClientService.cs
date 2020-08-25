using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServerDomain;
namespace Ymb.IdentityServerApplication
{
    public interface IClientService
    {
        #region 同步方法
        /// <summary>
        /// 添加Client
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client);

        /// <summary>
        /// 更新Client
        /// </summary>
        /// <param name="client"></param>
        public void UpdateClient(Client client);

        /// <summary>
        /// 删除Client
        /// </summary>
        /// <param name="clientId"></param>
        public void DeleteClient(string clientId);

        /// <summary>
        /// 查询Client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Client QuerySingle(string clientId);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="indexPage"></param>
        /// <param name="skipPageCount"></param>
        /// <returns></returns>
        public IEnumerable<Client> QueryPage(int indexPage, int skipPageCount);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<Client> QueryAll(params object[] parameters);
        #endregion
        #region 异步方法
        public Task AddClientAsync(Client client);
        public Task UpdateClientAsync(Client client);
        public Task DeleteClientAsync(string clientId);

        public Task< Client> QuerySingleAsync(string clientId);

        public Task<IEnumerable<Client>> QueryPageAsync(int indexPage, int skipPageCount);

        public Task< IEnumerable<Client>> QueryAllAsync(params object[] parameters);
        #endregion
    }
}
