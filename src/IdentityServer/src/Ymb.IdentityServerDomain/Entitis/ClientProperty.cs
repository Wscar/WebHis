﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public class ClientProperty:Property
    {
         public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
