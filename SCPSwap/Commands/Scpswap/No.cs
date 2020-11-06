using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;
using System.Linq;

namespace ScpSwap.Commands.ScpSwapCommand
{
    public class No : ICommand
    {
        public string Command { get; } = "no";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = "Rejects the swap request your were sent.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(((CommandSender)sender).Nickname);
			Player swap = EventHandlers.ongoingReqs.FirstOrDefault(x => x.Value == ply).Key;
			if (swap != null)
			{
				response = "Swap request denied.";
				swap.ReferenceHub.characterClassManager.TargetConsolePrint(swap.ReferenceHub.scp079PlayerScript.connectionToClient, "Your swap request has been denied.", "red");
				Timing.KillCoroutines(EventHandlers.reqCoroutines[swap]);
				EventHandlers.reqCoroutines.Remove(swap);
				EventHandlers.ongoingReqs.Remove(swap);
				return true;
			}
			response = "You do not have a swap reqest.";
			return false;
		}
    }
}
