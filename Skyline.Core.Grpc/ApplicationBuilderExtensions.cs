using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skyline.Core.GRpc.Server;
using Skyline.Core.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.GRpc
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGRpcServer(this IApplicationBuilder app)
        {
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            var option = app.ApplicationServices.GetRequiredService<IConfiguration>().GetValue<Options>("GRPC");
            
            var server= GRpcServerRunner.InitializeGRpcServer(option.Host,option.Port);
            lifetime.ApplicationStopping.Register(() =>
            {
                server.ShutdownAsync().Wait();//服务停止时取消注册 }); return app;
            });
            return app;
        }
    }
}
