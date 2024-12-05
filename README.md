# Legend of Chips

# How to Run
* Player Controls:
  - W/UP ARROW: Link Moves Up
  - S/DOWN ARROW: Link Moves Down
  - A/LEFT ARROW: Link Moves Left
  - D/RIGHT ARROW: Link Moves Right
  - ENTER: Start/Action Button
  - Z: Link Melee/Sword Attack
  - N: Uses selected PROJECTILE
  - NUMBER KEYS (SELECT PROJECTILES):
     * 1: Bomb
     * 2: Arrow
     * 3: Boomerang
  - E: Link Enters Damage State (knockback from his facing direction)
       
* Other
  - Q: Quit/Close Program
  - R: Resets Program
  - M: Mutes/Unmutes Background Music
  - Mouse Right Click: Move to next level
  - Mouse Left Click: Move to previous level
      * Cannot cylce since it would be confusing for if levels are new are not
  - DEBUG TOOLS:
     * H: Gives Link the MAX NUMBER OF HEARTS/HEALTH
     * C: Draws all collidables (*not all collision boxes)

# Code Insight
* Sadly, in terms of full functionality, we're lacking in most departments. However, we believe that most of our changes exist in changing the structure of the code, which hopefully accounts for the lack of functionality. If not, we still did decently with the state we we're in with Sprint 4. 
* Mainly writing this as a sendoff/insight into how we felt about the project, even without a letter grade being assigned to it. Overall, even in our final crunch, we are proud of our attempts at this code and our remake of Legend of Zelda, even with it's flaws.

# Known Bugs (in levels of necessity)
1) Some bugs with collision of large boxes and small boxes - for example, the boss enemy with a large hitbox quickly moving into Link can give him a significant amount of speed.
2) General small details that we used hard code to fix, so there is most likely some bugs that will pop up (mainly with state transitions in Game1.cs)

# Credits
* Sprites
  - https://www.spriters-resource.com/nes/legendofzelda/
  - Sprite Editor: Rolina Qu, Evan Csuhran
* Audio
  - https://www.sounds-resource.com/nes/legendofzelda/
  - Audio Editor: Evan Csuhran
* Command and Keyboard Interfaces
  - Hongxiang Wang
  - Mayank Karnati
  - Evan Csuhran
* Link/Player Movement and Sprite Animations
  - Mayank Karnati
  - Rolina Qu
  - Evan Csuhran
* Renderer Stuff
  - Evan Csuhran
  - Specifically Concrete Classes using Renderer/RendererLists
      * Evan Csuhran
      * Jiaqing Guan
      * Gary Zhu
  - Projectile Classes
      * Rolina Qu
      * Jiaqing Guan
      * Gary Zhu
      * Mayank Karnati
      * Evan Csuhran
* Collision
  - Rolina Qu
  - Hongxiang Wang
  - Evan Csuhran
* Environment Loading
  - Mayank Karnati
  - Evan Csuhran
* Transistions/Game States
  - Evan Csuhran
  - Jiaqing Guan
  - Hongxiang Wang
* NOTE: Code Reviews/Sprint Reflections are in the Code Reflections and Reviews folder

