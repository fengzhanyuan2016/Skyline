using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.Consul.Registry
{
   public class RegistryHostConfiguration
    {
        public string HttpEndpoint { get; set; }
        public string Datacenter { get; set; }
    }
}
