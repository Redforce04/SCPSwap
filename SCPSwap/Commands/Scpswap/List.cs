using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using NorthwoodLib.Pools;
using System.Text;
using System.Collections.Generic;

namespace ScpSwap.Commands.ScpSwapCommand
{
    public class List : ICommand
    {
        public string Command { get; } = "list";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = "List all SCP's available to swap to.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
			StringBuilderPool sp = new StringBuilderPool();
			StringBuilder listBuilder = sp.Rent();
			listBuilder.AppendLine("Here are the available SCPs to swap (Some may be blacklisted):");
			foreach (KeyValuePair<string, RoleType> kvp in EventHandlers.valid)
			{
				listBuilder.Append(kvp.Key);
				listBuilder.Append(" (");
				listBuilder.Append((int)kvp.Value);
				listBuilder.AppendLine(")");
			}
			
			string message = listBuilder.ToString();
			listBuilder.Clear();

			sp.Return(listBuilder);
			response = message;
			return true;
		}
    }
}
