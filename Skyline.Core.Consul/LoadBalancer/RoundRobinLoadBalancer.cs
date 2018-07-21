using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Skyline.Core.Consul.Discovery;
using Skyline.Core.Consul.Registry;

namespace Skyline.Core.Consul.LoadBalancer
{

    public class RoundRobinLoadBalancer : ILoadBalancer
    {
        private readonly IServiceSubscriber _subscriber;
        public RoundRobinLoadBalancer(IServiceSubscriber subscriber)
        {
            _subscriber = subscriber;
        }
        public Task<RegistryInformation> Endpoint(CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
