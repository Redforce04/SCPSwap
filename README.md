# SCPSwap

Allows SCP players to request to swap roles with one another at the beginning of the round if both players agree.

# Installation

**[EXILED](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "SCPswap.dll" file in your Plugins folder.

# Usage
SCPs can type `.scpswap scpnumberhere` within a time period from the beginning of the round to request to swap with whatever player is playing the specified role. If that player accepts, your roles will be swapped.
Examples: `.scpswap 173`, `.scpswap peanut`

*Note: As shown above, common aliases for SCPs can be used in place of numbers. A full list of these aliases ican be found [here](https://github.com/Cyanox62/SCPSwap/wiki/SCP-Role-IDs).*

# Configs
```yaml
scp_swap:
  is_enabled: true
  display_start_message: true
  swap_allow_new_scps: false
  swap_timeout: 60
  swap_request_timeout: 20
  start_message_time: 15
  display_message_text: <color=yellow><b>Did you know you can swap classes with other SCP's?</b></color> Simply type <color=orange>.scpswap (role number)</color> in your in-game console (not RA) to swap!
  swap_blacklist:
  - 10
```

