using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.Consul.Discovery
{
    public interface IServiceSubscriberFactory
    {
        IPollingServiceSubscriber CreateSubscriber(string serviceName);
    }
    public class ServiceSubscriberFactory : IServiceSubscriberFactory
    {
        public IPollingServiceSubscriber CreateSubscriber(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}
