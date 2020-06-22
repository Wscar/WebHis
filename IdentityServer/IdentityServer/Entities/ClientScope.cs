﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Entities
{
    public class ClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
