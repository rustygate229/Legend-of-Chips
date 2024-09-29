# Legend of Chips

# How to Run
* Player Controls:
  - W/UP ARROW: Link Moves Up
  - S/DOWN ARROW: Link Moves Down
  - A/LEFT ARROW: Link Moves Left
  - D/RIGHT ARROW: Link Moves Right
  - Z: Link Melee/Sword Attack
  - 1,2, 3: Selects Blue Arrow, Blue Boomerang, and Bomb 
  - N: Uses selected item
  - E: Link takes damage
* Block/Obstacle Controls
  - T: Cycles Previous Block in List
  - Y: Cycles Next Block in List
* Item Controls
  - U: Cycles Previous Item in List
  - I: Cycles Next Item in List
* Enemy/NPC Controls
  - O: Cycles Previous Enemy in List
  - P: Cycles Next Enemy in List
* Other
  - Q: Quit/Close Program
  - R: Resets Program

# Current Bugs
* Link moves faster moving diagonally than moving horizontally or vertically
* Link cannot attack more than once while holding down a movement key
* Holding U and Y at the same time cycles through both block and items very quickly
* Link's attack animation is cut off prematurely when C is released
* Cannot cycle items or blocks when Link is moving

# Current Tasks Left
* Implement:
  - Add more items and enemies
  - Refactor and add comments and documentation
  - Create renderer class for animations

# Credits
* Sprites
  - https://www.spriters-resource.com/nes/legendofzelda/
  - Sprite Editor: Rolina Qu
* Command and Keyboard Interfaces
  - Hongxiang Wang
* Link/Player Movement and Sprite Animations
  - Mayank Karnati
  - Rolina Qu
* Block Classes
  - Evan Csuhran
  - Gary Zhu
* Item Classes
  - Evan Csuhran
  - Gary Zhu
* Enemy Classes
  - Jiaqing Guan
  - Gary Zhu
* Projectile Classes
  - Rolina Qu
