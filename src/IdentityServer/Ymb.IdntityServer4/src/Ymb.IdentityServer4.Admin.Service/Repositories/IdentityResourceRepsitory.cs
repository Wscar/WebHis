using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServer4.Admin.EntityFramework.Shared;
using Ymb.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

namespace Ymb.IdentityServer4.Admin.Service.Repositories
{
    public class IdentityResourceRepsitory : IIdentityResourceRepository
    {
        public readonly IdentityServerConfigurationDbContext _dbContext;
        public readonly ILogger<IdentityResourceRepsitory> _logger;
        private readonly IUnitOfWork<IdentityServerConfigurationDbContext> _unitOfWork;
        public IdentityResourceRepsitory(IdentityServerConfigurationDbContext dbContext, ILogger<IdentityResourceRepsitory> logger, IUnitOfWork<IdentityServerConfigurationDbContext> unitOfWork)
        {
            this._dbContext = dbContext;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> AddIdentityResourceAsync(IdentityResource identityResource)
        {
            await this._dbContext.IdentityResources.AddAsync(identityResource);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<int> AddIdentityResourcePropertyAsync(int identityResourceId, IdentityResourceProperty identityResourceProperty)
        {
            var idenResource = this._dbContext.IdentityResources.SingleOrDefaultAsync(x => x.Id == identityResourceId);
            if (idenResource == null)
            {
                var message = $"方法AddIdentityResourcePropertyAsync无法找到id为{identityResourceId}的identityResource";
                var exception = new IdentityServerCudException(message);
                this._logger.LogError(message, exception);
                throw exception;
            }
            else
            {
                await this._dbContext.IdentityResourceProperties.AddAsync(identityResourceProperty);
                return await this._unitOfWork.CommitAsnyc();
            }
        }

        public async Task<int> DeleteIdentityResourceAsync(IdentityResource identityResource)
        {
            this._dbContext.IdentityResources.Remove(identityResource);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<int> DeleteIdentityResourcePropertyAsync(IdentityResourceProperty identityResourceProperty)
        {
            this._dbContext.IdentityResourceProperties.Remove(identityResourceProperty);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<PagedList<IdentityResource>> GetIdentityResourceAsync(string search, int page, int pageSize = 10)
        {
            var pageList = new PagedList<IdentityResource>();
            if (string.IsNullOrEmpty(search))
            {
               var idResources=  await this._dbContext.IdentityResources.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageList.Data = idResources;
                pageList.PageSize = idResources.Count;
            }
            else
            {
                var idResources = await this._dbContext.IdentityResources.Where(x=>x.Name.Contains(search)).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageList.Data = idResources;
                pageList.PageSize = idResources.Count;
            }
            return pageList;
        }

        public async Task<IdentityResource> GetIdentityResourceAsync(int identityResourceId)
        {
            var idResource = await this._dbContext.IdentityResources.SingleOrDefaultAsync(x => x.Id == identityResourceId);
            return idResource;
        }

        public async Task<PagedList<IdentityResourceProperty>> GetIdentityResourcePropertiesAsync(int identityResourceId, int page = 1, int pageSize = 10)
        {
            var pageList = new PagedList<IdentityResourceProperty>();
            var props =  await this._dbContext.IdentityResourceProperties.Where(x => x.IdentityResourceId == identityResourceId).ToListAsync();
            pageList.Data = props;
            pageList.PageSize = props.Count;
            return pageList;
        }

        public async Task<IdentityResourceProperty> GetIdentityResourcePropertyAsync(int identityResourcePropertyId)
        {
           var  idenResourceProp=  await  this._dbContext.IdentityResourceProperties.SingleOrDefaultAsync(x => x.Id == identityResourcePropertyId);
            return idenResourceProp;
        }

        public async Task<int> UpdateIdentityResourceAsync(IdentityResource identityResource)
        {
            this._dbContext.IdentityResources.Update(identityResource);
            return await this._unitOfWork.CommitAsnyc();
        }
        private int LoggerError(string message)
        {

            var curdException = new IdentityServerCudException(message);
            this._logger.LogError(curdException, message);
            return CudOperationCommitStatus.FAIL;
        }
    }
}
