using Skyline.Core.Consul.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skyline.Core.Consul.LoadBalancer
{
  public interface ILoadBalancer
    {
        Task<RegistryInformation> Endpoint(CancellationToken ct = default(CancellationToken));
    }
}
