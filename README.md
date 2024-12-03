# Legend of Chips

# How to Run
* Player Controls:
  - W/UP ARROW: Link Moves Up
  - S/DOWN ARROW: Link Moves Down
  - A/LEFT ARROW: Link Moves Left
  - D/RIGHT ARROW: Link Moves Right
  - Z: Link Melee/Sword Attack
  - 1, 2, 3: Selects Blue Arrow, Blue Boomerang, and Bomb 
  - N: Uses selected item
  - E: Link takes damage
  - M: Mutes/Unmutes Background Music
* Other
  - Q: Quit/Close Program
  - R: Resets Program
  - Mouse Right Click: Move to next level
  - Mouse Left Click: Move to previous level
      * Cannot cylce since it would be confusing for if levels are new are not

# Known Bugs (in levels of necessity)
1) Opens a CMD window when launching the game for some reason
2) Collision
  * Link can get stuck in collision blocks, can't move up or down when on a collision when being pressed against it (corner cases)
3) Link Stuff (gotta refactor Link)
  * Link moves faster moving diagonally than moving horizontally or vertically
  * Link can attack by spamming (apart of refactoring Link)
  * Link's attack animation is cut off prematurely when C is released (kind of in general)
  * Link forms a double when attacking and pressing 'e' (damaged state) at the same time

# Some Tasks before Sprint 4 Work
* Implement:
  - Add/implement more blocks/items/enemies and some levels
      * create a boss enemy
      * add more projectiles for enemy
      * need to refactor enemy/link/projectile heavily
  - Complete collision interactions (items, damage, etc.)
      * loading levels needs a unload for collisions and a reload (refactor again)
      * also need to work on having different collision reactions
      * link sword seperate collision
* LOTS OF REFACTORING (getting correct sprite locations, commenting and much more)
* In general, have a better form of seperating work and communication

# Credits
* Sprites
  - https://www.spriters-resource.com/nes/legendofzelda/
  - Sprite Editor: Rolina Qu
* Audio
  - https://www.sounds-resource.com/nes/legendofzelda/
  - 
* Command and Keyboard Interfaces
  - Hongxiang Wang
* Link/Player Movement and Sprite Animations
  - Mayank Karnati
  - Rolina Qu
* Renderer Stuff
  - Evan Csuhran
  - Specifically Concrete Classes using Renderer
      * Evan Csuhran
      * Jiaqing Guan
      * Gary Zhu
* Projectile Classes
  - Rolina Qu
  - Mayank Karnati
* Collision
  - Rolina Qu
  - Hongxiang Wang
* Environment Loading
  - Mayank Karnati
  - Evan Csuhran
* NOTE: Code Reviews/Sprint Reflections are in the Sprint 3 folder in the Code Reflections and Reviews folder

