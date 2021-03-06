﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.Core.Consul.Configurations
{
    public class ConfigInfo
    {
        /// <summary>
        /// 初始化会话超时为20秒的consul配置信息。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        /// <param name="commandPath">服务命令配置路径</param>
        /// <param name="routePath">路由路径配置路径</param>
        /// <param name="subscriberPath">订阅者配置路径</param>
        /// <param name="cachePath">缓存中心配置路径</param>
        public ConfigInfo(string connectionString,string routePath = "services/serviceRoutes/",
             string subscriberPath = "services/serviceSubscribers/",
            string commandPath = "services/serviceCommands/",
            string cachePath="services/serviceCaches/") :
            this(connectionString, TimeSpan.FromSeconds(20), routePath, subscriberPath,commandPath, cachePath)
        {
        }

        /// <summary>
        /// 初始化consul配置信息。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        /// <param name="sessionTimeout">会话超时时间。</param>
        /// <param name="commandPath">服务命令配置命令。</param>
        /// <param name="subscriberPath">订阅者配置命令。</param>
        /// <param name="routePath">路由路径配置路径</param>
        /// <param name="cachePath">缓存中心配置路径</param>
        public ConfigInfo(string connectionString, TimeSpan sessionTimeout,
            string routePath = "services/serviceRoutes/",
             string subscriberPath = "services/serviceSubscribers/",
            string commandPath = "services/serviceCommands/",
            string cachePath= "services/serviceCaches/")
        {
            CachePath = cachePath;
            SessionTimeout = sessionTimeout;
            RoutePath = routePath;
            SubscriberPath = subscriberPath;
            CommandPath = commandPath;
            var  address= connectionString.Split(":");
            if(address.Length>1)
            {
                int port;
                int.TryParse(address[1], out port);
                Host = address[0];
                Port = port;
            }
        }

        public ConfigInfo(string host, int port) : this(host, port, TimeSpan.FromSeconds(20))
        {
        }

        public ConfigInfo(string host, int port, TimeSpan sessionTimeout)
        {
            SessionTimeout = sessionTimeout;
            Host = host;
            Port = port;
        }

        /// <summary>
        /// watch 时间间隔
        /// </summary>
        public int WatchInterval { get; set; } = 60;

        /// <summary>
        /// 命令配置路径
        /// </summary>
        public string CommandPath { get; set; }

        /// <summary>
        /// 订阅者配置路径
        /// </summary>
        public string SubscriberPath { get; set; }

        /// <summary>
        /// 路由配置路径。
        /// </summary>
        public string RoutePath { get; set; }

        /// <summary>
        /// 缓存中心配置中心
        /// </summary>
        public string CachePath { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        /// <summary>
        /// 会话超时时间。
        /// </summary>
        public TimeSpan SessionTimeout { get; set; }

    }
}
