using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.Service
{
    public  class PagedList<T> where T:class
    {
         public PagedList()
        {
            this.Data = new List<T>();
        }
        public List<T> Data { get;  set; }

        public int PageSize { get; set; }
        public int TotalCount { get;  set; }
    }
}
