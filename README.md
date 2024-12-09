# But Worse Mini-Project 🎮

## Overview
This game is part of a course called "PI3DW" (Programming Interactive 3D Worlds). The Unity project is based on the idea of making a "ButWorse" game. We were tasked with recreating a game that we knew and liked. This could have been anything we wanted, and I bounced ideas around for months before settling on this project. The game I chose to recreate was **Call of Duty: Black Ops Zombies**, where the player needs to survive rounds that increase in difficulty as more and more zombies are spawned each round. There isn't really an end goal; it's just about surviving as many rounds as possible.

For my game, I also wanted to implement some "Zombies" who chase after the player. This was accomplished with a NavMesh and some chasing mechanics within the Unity engine. The player can sprint, crouch, jump, aim, and shoot as many times as they want. The game increments the number of zombies by 2 for each round the player survives. This is something that will show up on a UI, that also shows the player, how many bullets they have left, how much life they have left, the round they are on and also how many zombies that are left on the map.

### Game mechanics:
- **Player** – Controlled with WASD. The player can crouch using left-ctrl, sprint using left shift, look around with the mouse, and shoot with "Fire1" (the left mouse button).
- **Zombies** – They use a simple "AI" script and Unity's NavMesh to determine where they are allowed to walk. They will chase the player relentlessly until they are killed.
- **Map** – The map is an implemented version of the package listed below called "RPG/FPS Game Assets for PC/Mobile (Industrial Set v3.0)." It's a closed-off area where the player needs to survive.
- **Lives** – The player has only one life, so make it count.

## Concept
The basics of the game:
- The player controls a first-person shooter.
- They are tasked with surviving as many rounds as they can by shooting zombies.
- The number of zombies increases by 2 per round.
- The player only has 30 bullets per magazine, and it takes 2 seconds to reload.
- The player starts with 100 HP and takes 10 damage each time a zombie touches them (per second).

## Video Link
- [Youtube link for the video of the game](https://youtu.be/h6RT9G8d1Yc)

## Scripts Made and Used
- **Enemy.cs** – Controls what can be shot by the Weapon.cs script.
- **Weapon.cs** – Controls the weapon the player uses, including damage, muzzle flash, and raycasting to the point where the player is aiming.
- **MoveCamera.cs** – Moves the camera relative to the player's position.
- **PlayerCam.cs** – Controls where the player is looking.
- **PlayerHealth.cs** – Controls the player's remaining health.
- **PlayerMovement.cs** – The main script, controlling player movement (jumping, crouching, sprinting...).
- **UIManager.cs** – Controls the information displayed on the screen (bullets, health, rounds, and the number of zombies remaining).
- **ZombieAI.cs** – The main script for the zombies, allowing them to chase the player.
- **ZombieSpawner.cs** – Spawns zombie prefabs based on the round the player has reached.

## How to Run It
1. Download Unity -> 6000.0.30f1
2. Clone or download the project from the GitHub repository.
3. Open the project and hit play.
4. The game requires a mouse and keyboard.

## Time Table 🕒
Below is a time log of the hours spent on different aspects of the project. This will help track the progress and time allocation for each task.

| **Task**                | **Time Spent**  | **Total Time**  |
|-------------------------|-----------------|-----------------|
| **Initial Setup**       | 0.75 hours      | 0.75 hours      |
| **Scripting**           | 4.42 hours      | 5.17 hours      |
| **Level Design**        | 1.58 hours      | 6.75 hours      |
| **UI Design**           | 1 hour          | 7.75 hours      |
| **Final Adjustments**   | 1 hour          | 8.75 hours      |

## Tutorials Used
- [FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial - Dave / GameDevelopment](https://www.youtube.com/watch?v=f473C43s8nE)
- [SLOPE MOVEMENT, SPRINTING & CROUCHING - Unity Tutorial - Dave / GameDevelopment](https://www.youtube.com/watch?v=xCxSjgYTw9c)
- [Shooting with Raycasts - Unity Tutorial - Brackeys](https://www.youtube.com/watch?v=THnivyG0Mvo)
- [A guide on using the new AI Navigation package in Unity 2022 LTS and above](https://discussions.unity.com/t/a-guide-on-using-the-new-ai-navigation-package-in-unity-2022-lts-and-above/371872)

## AI Engines Used
- ChatGPT - Used for script creation and bug fixes.
- GitHub Copilot - Used for bug fixes, and small implementations here and there.

## Packages Used
- [RPG/FPS Game Assets for PC/Mobile (Industrial Set v3.0)](https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v3-0-101429)
- [Modern Weapons Pack](https://assetstore.unity.com/packages/3d/props/guns/modern-weapons-pack-14233)
- [Particle Pack](https://assetstore.unity.com/packages/vfx/particles/particle-pack-127325)

## Future Work
- I wanted to fix some small errors, like when I crouch inside the game, it somehow activates my shoot method, causing the character to shoot. I can't figure out why this happens.
- I also wanted to implement bullet hit effects, but creating my own would take too much time, as I haven't really used this system before, and I couldn't find any tutorials that provided the exact result I wanted.
- Perhaps adding a small animation to show that the gun is reloading, but as it's not intended for anyone else to play, I was fine with it only being displayed in the console.
- I also tried to implement that when the player died, it would have a "YOU DIED" UI overlay like Dark Souls 3 and Elden Ring, but I couldn't make it work.

## GitHub link
- [ButWorseProject](https://github.com/Nesstark/ButWorseProject)

## Word count
- 808 words
