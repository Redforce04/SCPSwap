using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using System;
using System.Linq;

namespace ScpSwap.Commands.ScpSwapCommand
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ScpSwapCommand : ParentCommand
    {
        public ScpSwapCommand() => LoadGeneratedCommands();

        public override string Command { get; } = "scpswap";

        public override string[] Aliases { get; } = { "scpsw" };

        public override string Description { get; } = "SCPSwap base command";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new List());
            RegisterCommand(new Cancel());
            RegisterCommand(new No());
            RegisterCommand(new Yes());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
			if(arguments.Count < 1)
			{
				response = "Usage: .scpswap [SCP Number]";
				return false;
			}
			if (!EventHandlers.valid.ContainsKey(arguments.At(0)))
			{
				response = "Invalid SCP.";
				return false;
			}

			Player ply = Player.Get(((CommandSender)sender).Nickname);
			if (EventHandlers.ongoingReqs.ContainsKey(ply))
			{
				response = "You already have a request pending!";
				return false;
			}

			RoleType role = EventHandlers.valid[arguments.At(0)];
			if (EventHandlers.plugin.Config.SwapBlacklist.Contains((int)role))
			{
				response = "That SCP is blacklisted.";
				return false;
			}

			if (ply.Role == role)
			{
				response = "You cannot swap with your own role.";
				return false;
			}

			Player swap = Player.List.FirstOrDefault(x => role == RoleType.Scp93953 ? x.Role == role || x.Role == RoleType.Scp93989 : x.Role == role);
			if (swap != null)
			{
				EventHandlers.reqCoroutines.Add(ply, Timing.RunCoroutine(EventHandlers.SendRequest(ply, swap)));
				response = "Swap request sent!";
				return false;
			}
			if (EventHandlers.plugin.Config.SwapAllowNewScps)
			{
				ply.ReferenceHub.characterClassManager.SetPlayersClass(role, ply.ReferenceHub.gameObject);
				response = "Could not find a player to swap with, you have been made the specified SCP.";
				return false;
			}
			response = "No players found to swap with.";
            return false;
        }
    }
}
