using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;
using System.Linq;

namespace ScpSwap.Commands.ScpSwapCommand
{
    public class Yes : ICommand
    {
        public string Command { get; } = "yes";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = "Accepts your current swap request.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
			Player ply = Player.Get(((CommandSender)sender).Nickname);
			Player swap = EventHandlers.ongoingReqs.FirstOrDefault(x => x.Value == ply).Key;
			if (swap != null)
			{
				EventHandlers.PerformSwap(swap, ply);
				response = "Swap successful!";
				Timing.KillCoroutines(EventHandlers.reqCoroutines[swap]);
				EventHandlers.reqCoroutines.Remove(swap);
				return true;
			}
			response = "You do not have a swap request.";
			return false;
		}
    }
}
