using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Users;
using SDG.Unturned;

namespace ServerSwitcher.Commands
{
    [Command("server")]
    [CommandAlias("sv")]
    public class CommandServer : OpenMod.Core.Commands.Command
    {
        private readonly ServerSwitcher m_plugin;
        private readonly IStringLocalizer m_StringLocalizer;
        public CommandServer(IStringLocalizer stringLocalizer, ServerSwitcher plugin, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_StringLocalizer = stringLocalizer;
        }

        protected override async Task OnExecuteAsync()
        {
            if (Context.Parameters.Count == 0)
            {
                string serverNames = string.Join(", ", m_plugin.Servers.ServerList.Select(s => s.name));
                await Context.Actor.PrintMessageAsync(m_StringLocalizer["commands:servers:servers", new { servers = serverNames }]);
                return;
            };
            var serverName = await Context.Parameters.GetAsync<string>(0);

            var server = m_plugin.Servers.ServerList.FirstOrDefault(s => s.name.Equals(serverName, StringComparison.OrdinalIgnoreCase));



            if (server == null)
            {
                await Context.Actor.PrintMessageAsync(m_StringLocalizer["commands:server:not_found", new {name = serverName }]);
            }
            else
            {
                UnturnedUser user = (UnturnedUser)Context.Actor;
                await Context.Actor.PrintMessageAsync(m_StringLocalizer["commands:server:sending", new { name = server.name }]);
                await UniTask.SwitchToMainThread();
                user.Player.Player.sendRelayToServer(server.ipUint,
                    server.port,
                    server.password,
                    false);
            }

            await UniTask.CompletedTask;
        }
    }
}
