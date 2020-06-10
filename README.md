# DyDCS

Goals:
- Dynamic DCS provides a modern, clean single player/co-op campaign system that immerses players in a rich player driven narrative.
- Missions are cohesive and fit a broader narrative
- Users can introspect into their fleet, keep track of pilots, and see their influence on the broader campaign map
- Long term goals would be a single theater where players can upload their single player missions into a persistent server for a broad, asynchronous battlespace
- Users should have a sleek GUI to modify mission briefing before generating

Why do current dynamic campaigns fail?
- Heavy scripting requirements (DCE)
- Old and broken interfaces
- Fucking JANKY BRUH



Technical:
- Main user interface is a sleek, modern electron app
- Missions are generated using PyDCS?

- Mission Scripting Tools (MST): Database of standard lua functions for common scripts
https://github.com/mrSkortch/MissionScriptingTools

https://wiki.hoggitworld.com/view/Scripting_Engine_Introduction
https://wiki.hoggitworld.com/view/Simulator_Scripting_Engine_Documentation
https://jboecker.github.io/dcs-witchcraft/

## Order of Precedence for scripts

1. Initialization Script
2. Group Spawn Condition
3. Trigger: Mission Start
4. Group Waypoint 1 Scripts
5. Trigger: Once Time Less than 1 (anything that is true with no time elapsed)
6. Trigger: Once Time More than 0 (anything that is true once time has elapsed)
7. Group Waypoint 2+ Scripts

Triggers are evaluated top to bottom. This means that if multiple triggers will execute at the same time, the game will start at the top and work its way down. The same is true for conditions and actions. It is safe to have a trigger like the following if script C relies on B, and B relies on A:

Once> Time More than 3> Do Script File(A.lua) AND Do Script File(B.lua) AND Do Script File(C.lua)
