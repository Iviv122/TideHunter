# TideHunter radar maintaince game

The game itself is pretty boring and uninteresitng but there are some things to say about code.

## Dependecies
- VContainer
- Serialize Interfaces!

## Code idea and where it failed
The initiall idea was to put all services in container/plain C# and gameplay into scriptable objects. But as happend it is horrible idea. Scriptable objects can't make use of DI container and some problems comes from their lifecycle as well as usage with Tick/Start methods
