# Eventual Harmony
A small musical experiment made with Unity3D.

![Screenshot of the application](https://github.com/ivankarez/EventualHarmony/blob/main/Images/eh_printscreen.png?raw=true)

__Demo video:__  [Youtube](https://youtu.be/DhzbadYq344)

## What is it?
It's zero player game with the aim of creating something musical out of chaos.

## How it works?
It initially creates 30 agents represented by small colored circles on screen. Every agent assigned to a musical note. Those agents are randomly wandering on the screen, and when they collide they play the notes assigned to them. If the interval between the notes are one of the "preferred" intervals they both gain energy. If it's an interval to avoid, they loose energy. When an agent run out of energy it dies, and a slightly mutated offspring will be created on a random location. As an agent loses energy, it became visually smaller on the screen and the sound it makes on collisison will be more quiet.

In theory, these rules will cause all the notes that makes "bad" sounds with others disappear, and keep the notes that sounds "right".

## UI
On top of the screen there is a "Musicality" indicator. It simply shows what was the ratio between the preferred and avoided intervals in the last 5 seconds.

At the bottom center of the screen, there is a piano keyboard view of what happens on the screen. Here you can see what notes are playing currently, and the key's highlight color is the same as the agent's color.

At the bottom right corner, there is a simple table of how many agents are alive for a note currently. Initally here you can see that the distribution of notes is random, and after some time, it starts to form a "chord" with the preferred intervals.

At the bottom left corner, there is a list of the musical intervals. You can change if an interval is "preferred" or "avoided" by clicking the button. The highlights of the button shows which intervals are currently played. The color of the highlight is depends on if its a good or bad interval. Red for bed, green for good.

On the whole screen, a colored circle animation happens when two or more agents collide. It helps you visualize the notes that made a bed or good interval.