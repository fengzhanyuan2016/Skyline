﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skyline.Core.Consul.Discovery
{
    public interface IPollingServiceSubscriber: IServiceSubscriber
    {
        Task StartSubscription(CancellationToken ct = default(CancellationToken));
        event EventHandler EndpointsChanged;
    }

}
