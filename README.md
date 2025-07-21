# TideHunter radar maintaince game

The game itself is pretty boring and uninteresitng but there are some things to say about code and dev process  

### Disclamer : my brain don't want to work rn so readme is written poorly.

## Dependecies
- VContainer
- Serialize Interfaces!

## Gameplay
In order to win you need to make this ‘radar’ work for 5 minutes. Internal battery can work for 20 seconds without power while balancing power and heat.
I was heavily inspired by FNAF series. Why it is bad here?
- Everything is too predictable
- No dynamics
- While idea with smooth translation of power and heat is great. You can win by staring into moduls or spamming turn on/off button on radar
- It is impossible die to heat. Ofc i could increase temperature over time but it won't solve that problem because the most optimal strategy is gen -> acc + garbage -> win.

## DIContainer and Scale issue
By the most part it was excessive. Most of problems could be solved by scriptable objects or singletons. Yes current code is easy for me to maintain and work, as well as add any kind of ideas in it. But let's be honest
- This is small game and code base as well
- In game development it is important to develop and finish games. Technical debt may be a problem, but you should keep in mind project scale and adapt
- VContainer is a good tool. However it feels better in cases where you need to hold data outside of gameObjects and translate between scenes. In case where you can place everything on scene it will cause more problems than actual use
- Initially i though about much bigger game with many floors interactives and sounds etc. But ended up procrastinating and making much smaller game for 'scalable' structure which took much more time to work with than actual game

## Why ScriptableObjects?
I was inspired by Barotrauma xml thing as well as fact that SO are greate for event busses. They <i>would</i> be great in case of bigger game but with end scale it was excessive and gave additional troubles to work with. They would be amazing in case of many same objects which were initially planned. Like 3 gens and some light branches. But in end result it is realistically better to use SingleTone which simplify the whole process for such small game. 

## Patterns used
- Strategy Pattern for operation like add or multiply
- Observer or simply ``` public event Action eventNamel ``` sadly no example with interface
- Chain of Responsobility for Stats. We have querry class which responsible for stat operations
- Mediator pattern. It is bery handy for stats. You can see example in StatsMediator