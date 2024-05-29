using System;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using static ServerSwitcher.Models.Servers;

namespace ServerSwitcher.Commands
{
    [Command("servers")]
    [CommandAlias("svs")]
    public class CommandServers : OpenMod.Core.Commands.Command
    {
        private readonly ServerSwitcher m_plugin;
        private readonly IStringLocalizer m_StringLocalizer;

        public CommandServers(IStringLocalizer stringLocalizer, ServerSwitcher plugin, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_StringLocalizer = stringLocalizer;
        }

        protected override async Task OnExecuteAsync()
        {
            if (m_plugin.Servers?.ServerList == null || !m_plugin.Servers.ServerList.Any())
            {
                await Context.Actor.PrintMessageAsync(m_StringLocalizer["commands:servers:no_servers"]);
                return;
            }

            string serverNames = string.Join(", ", m_plugin.Servers.ServerList.Select(s => s.name));
            await Context.Actor.PrintMessageAsync(m_StringLocalizer["commands:servers:servers", new { servers = serverNames }]);

            await UniTask.CompletedTask;
        }
    }
}
