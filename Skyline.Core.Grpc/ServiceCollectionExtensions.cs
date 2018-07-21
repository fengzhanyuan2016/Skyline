using Microsoft.Extensions.DependencyInjection;
using Skyline.Core.GRpc.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.GRpc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGRpc(this IServiceCollection services)
        {
            services.AddSingleton<IGRpcRemoteServiceFactory, GRpcRemoteServiceFactory>();
            services.AddSingleton<IGRpcChannelFactory, GRpcChannelFactory>();
            return services;
        }

    }
}
