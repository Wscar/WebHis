﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public class ClientCorsOrigin
    {
        public int Id { get; set; }
        public string Origin { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
