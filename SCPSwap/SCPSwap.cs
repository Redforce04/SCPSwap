using System;
using Exiled.API.Features;
using Handlers = Exiled.Events.Handlers;

namespace ScpSwap
{
    public class ScpSwap : Plugin<Config>
	{
		public EventHandlers Handler { get; private set; }
		public override string Name => nameof(ScpSwap);
		public override string Author => "Originally written by Cyanox, modifications by KoukoCocoa & Thomasjosif, updated to Exiled 3.0.0 by Redforce04";
		public override Version Version { get; } = new Version(1, 4, 0);
		public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

		public ScpSwap() { }

		public override void OnEnabled()
		{
			Handler = new EventHandlers(this);
			Handlers.Server.WaitingForPlayers += Handler.OnWaitingForPlayers;
			Handlers.Server.RoundStarted += Handler.OnRoundStart;
			Handlers.Server.RoundEnded += Handler.OnRoundEnd;
			Handlers.Server.RestartingRound += Handler.OnRoundRestart;
		}

		public override void OnDisabled()
		{
			Handlers.Server.WaitingForPlayers -= Handler.OnWaitingForPlayers;
			Handlers.Server.RoundStarted -= Handler.OnRoundStart;
			Handlers.Server.RoundEnded -= Handler.OnRoundEnd;
			Handlers.Server.RestartingRound -= Handler.OnRoundRestart;
			Handler = null;
		}

		public override void OnReloaded() { }
	}
}
