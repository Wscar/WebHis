﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public abstract class Property
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
