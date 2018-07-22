using Consul;
using Skyline.Core.Consul.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.Consul.Registry
{
    public interface IRegistryHost: IManageServiceInstances, IManageHealthChecks, IResolveServiceInstances
    {


    }
   public class RegistryHost:IRegistryHost
    {
        private const string VERSION_PREFIX = "version-";
        private readonly RegistryHostConfiguration _configuration;
        private readonly ConsulClient _consul;
        public RegistryHost(RegistryHostConfiguration configuration=null)
        {
            _configuration = configuration;
            _consul = new ConsulClient(config=> {
                config.Address = new Uri(_configuration.HttpEndpoint);
                if (!string.IsNullOrEmpty(_configuration.Datacenter))
                {
                    config.Datacenter = _configuration.Datacenter;
                }
            });
        }





    }
}
