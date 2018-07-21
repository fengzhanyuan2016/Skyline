using Grpc.Core;
using MagicOnion;
using MagicOnion.Client;
using Skyline.Core.Consul;
using Skyline.Core.Consul.Discovery;
using Skyline.Core.Consul.LoadBalancer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.Core.GRpc.Client
{
    public interface IGRpcRemoteServiceFactory
    {
        Task<TService> GetRemoteService<TService>(string serviceName) where TService : IService<TService>;
    }
    public class GRpcRemoteServiceFactory : IGRpcRemoteServiceFactory
    {
        private IGRpcChannelFactory _rpcChannelFactory;
        private IServiceSubscriberFactory _subscriberFactory;

        public GRpcRemoteServiceFactory(IGRpcChannelFactory rpcChannelFactory, IServiceSubscriberFactory serviceSubscriberFactory)
        {
            this._rpcChannelFactory = rpcChannelFactory;
            this._subscriberFactory = serviceSubscriberFactory;
        }

        public async Task<TService> GetRemoteService<TService>(string serviceName) where TService : IService<TService>
        {
           var serviceSubscriber= _subscriberFactory.CreateSubscriber(serviceName);
           await serviceSubscriber.StartSubscription();
           serviceSubscriber.EndpointsChanged+= async(sender, eventArgs) =>
           {
               var endpoints = await serviceSubscriber.Endpoints();
               var servicesInfo = string.Join(",", endpoints);
           };
           ILoadBalancer balancer= new RoundRobinLoadBalancer(serviceSubscriber);
            var endPoint = await balancer.Endpoint();
            var channel = _rpcChannelFactory.Get(endPoint.Address, endPoint.Port);
            return MagicOnionClient.Create<TService>(channel);
        }

    }
}
