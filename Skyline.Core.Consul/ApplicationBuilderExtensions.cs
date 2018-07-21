using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.Consul
{
   public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRegisterConsul(this IApplicationBuilder app)
        {

            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
            string serviceName = configuration["ServiceDiscovery:Service:Name"];
            string consulHost = configuration["ServiceDiscovery:Consul:HttpEndpoint"];
            string healthCheckUrl = configuration["ServiceDiscovery:Service:HealthCheckUrl"];
            int timeOut = Convert.ToInt32(configuration["ServiceDiscovery:Service:TimeOut"]);
            string IP = configuration["ServiceDiscovery:Service:IP"];
            int port = Convert.ToInt32(configuration["ServiceDiscovery:Service:Port"]);
            string Version = configuration["ServiceDiscovery:Service:Version"];


            var consulClient = new ConsulClient(x => x.Address = new Uri(consulHost));//请求注册的 Consul 地址
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = healthCheckUrl,//健康检查地址
                Timeout = TimeSpan.FromSeconds(timeOut)
            };            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = serviceName,
                Address = IP,
                Port = port,
                Tags = new[] { $"{Version}-/{serviceName}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别 };
            };

            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册 }); return app;
            });
            return app;
        }

    }
}
