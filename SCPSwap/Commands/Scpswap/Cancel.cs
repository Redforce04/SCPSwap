using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;

namespace ScpSwap.Commands.ScpSwapCommand
{
    public class Cancel : ICommand
    {
        public string Command { get; } = "cancel";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = "Cancels your current swap request.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(((CommandSender)sender).Nickname);
			if (EventHandlers.ongoingReqs.ContainsKey(ply))
			{
				Player dest = EventHandlers.ongoingReqs[ply];
				dest.ReferenceHub.characterClassManager.TargetConsolePrint(dest.ReferenceHub.scp079PlayerScript.connectionToClient, "Your swap request has been cancelled.", "red");
				Timing.KillCoroutines(EventHandlers.reqCoroutines[ply]);
				EventHandlers.reqCoroutines.Remove(ply);
				EventHandlers.ongoingReqs.Remove(ply);
				response = "You have cancelled your swap request.";
				return true;
			}
			response = "You do not have an outgoing swap request.";
			return false;
		}
    }
}
