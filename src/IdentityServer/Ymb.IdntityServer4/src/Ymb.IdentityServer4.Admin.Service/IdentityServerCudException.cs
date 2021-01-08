using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.Service
{
   public  class IdentityServerCudException:Exception
    {
        public IdentityServerCudException(string message):base(message)
        {

        }
        public IdentityServerCudException(string message,Exception innerException) : base(message, innerException)
        {

        }
       
    }
}
