using Grpc.Core;
using MagicOnion.Server;
using Skyline.Core.System;
using System;
using System.Collections.Generic;
using System.Text;
namespace Skyline.Core.GRpc.Server
{
    public static class GRpcServerRunner
    {
        public static Grpc.Core.Server InitializeGRpcServer(string host,int port)
        {
            var server = new Grpc.Core.Server
            {
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) },
                Services =
                {
                    MagicOnionEngine.BuildServerServiceDefinition()
                }
            };
            server.Start();
            return server;
        }



    }
}
