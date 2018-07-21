using Skyline.Core.Consul.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skyline.Core.Consul.Discovery
{
    public interface IServiceSubscriber:IDisposable
    {
        Task<List<RegistryInformation>> Endpoints(CancellationToken ct = default(CancellationToken));
    }
}
