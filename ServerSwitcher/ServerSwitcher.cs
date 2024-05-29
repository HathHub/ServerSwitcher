using System;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;
using ServerSwitcher.Models;

[assembly: PluginMetadata("ServerSwitcher", DisplayName = "ServerSwitcher", Author = "Hath.")]

namespace ServerSwitcher
{
    public class ServerSwitcher : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<ServerSwitcher> m_Logger;
        public Servers Servers { get; set; }

        public ServerSwitcher(
            IConfiguration configuration,
            IStringLocalizer stringLocalizer,
            ILogger<ServerSwitcher> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {
            m_Logger.LogInformation("Hello World!");
            Servers = new Servers();
            m_Configuration.GetSection("Servers").Bind(Servers);

            foreach (var server in Servers.ServerList)
            {
                server.ipUint = IpConverter.IpToUint(server.ip);
            }
            m_Logger.LogInformation($"Loaded {Servers.ServerList.Count} servers!");
        }

        protected override async UniTask OnUnloadAsync()
        {
            m_Logger.LogInformation(m_StringLocalizer["plugin_events:plugin_stop"]);
        }
    }
}
