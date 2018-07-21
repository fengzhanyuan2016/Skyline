using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.GRpc.Client
{
    //获取Channel
    public interface IGRpcChannelFactory
    {
        Channel Get(string host, int port);
    }
    public class GRpcChannelFactory : IGRpcChannelFactory
    {
        private ConcurrentDictionary<string, Channel> servers;
        public GRpcChannelFactory()
        {
            servers = new ConcurrentDictionary<string, Channel>();
        }
        //创建缓存的连接池
        public Channel Get(string host, int port)
        {
            Channel channel = null;
            string key = $"{host}:{port}";
            if (!servers.ContainsKey(key))
            {
                channel = new Channel(host, port, ChannelCredentials.Insecure);
                servers.TryAdd(key, channel);
            }
            else
            {
                channel = servers[key];
            }
            return channel;
        }
    }
}
