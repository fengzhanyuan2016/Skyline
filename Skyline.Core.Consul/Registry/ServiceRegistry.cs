using Skyline.Core.Consul.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.Consul.Registry
{
    public class ServiceRegistry : IManageServiceInstances, IManageHealthChecks
    {
        private IRegistryHost _registryHost;
        public ServiceRegistry(IRegistryHost registryHost)
        {
            _registryHost = registryHost;
        }


    }
}
