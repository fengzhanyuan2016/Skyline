using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Skyline.Core.Consul.Registry;

namespace Skyline.Core.Consul.LoadBalancer
{
    public class RandomLoadBalancer : ILoadBalancer
    {
        public Task<RegistryInformation> Endpoint(CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
