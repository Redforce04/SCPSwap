using System;
using System.Collections.Generic;
using System.IO;
using Exiled.API.Features;
using Handlers = Exiled.Events.Handlers;
using UnityEngine;

namespace ScpSwap
{
	public class ScpSwap : Plugin<Config>
	{
		public EventHandlers Handler { get; private set; }
		public override string Name => nameof(ScpSwap);
		public override string Author => "Originally written by Cyanox, modifications by KoukoCocoa & Thomasjosif";
		public override Version Version { get; } = new Version(1, 3, 0);

		public ScpSwap() { }

		public override void OnEnabled()
		{
			Handler = new EventHandlers(this);
			Handlers.Server.WaitingForPlayers += Handler.OnWaitingForPlayers;
			Handlers.Server.RoundStarted += Handler.OnRoundStart;
			Handlers.Server.RoundEnded += Handler.OnRoundEnd;
			Handlers.Server.RestartingRound += Handler.OnRoundRestart;
			Handlers.Server.SendingConsoleCommand += Handler.OnConsoleCommand;
		}

		public override void OnDisabled()
		{
			Handlers.Server.WaitingForPlayers -= Handler.OnWaitingForPlayers;
			Handlers.Server.RoundStarted -= Handler.OnRoundStart;
			Handlers.Server.RoundEnded -= Handler.OnRoundEnd;
			Handlers.Server.RestartingRound -= Handler.OnRoundRestart;
			Handlers.Server.SendingConsoleCommand -= Handler.OnConsoleCommand;
			Handler = null;
		}

		public override void OnReloaded() { }
	}
}
