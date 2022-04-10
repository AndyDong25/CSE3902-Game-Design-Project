# CSE3902
Group project for CSE3902

By Team Random Forest: Andy Dong, Alex Zhang, Devan Mallory, Tianle Chen, Lianxi Li


Idea: Bomberman - a clone of the popular 2D game Bomberman, a multiplayer game where 2-4 players compete against each other inside a small explosive arena to be the last one standing. Players compete by dropping bombs that will eliminate other players if they get too close to the radius. In addition, players can gain a competitive advantage by collecting certain items that are spawned when blocks in the arena are destroyed by nearby bombs.


# Running the Game
Requirements: Visual Studio, with Dotnet compiling tools and Monogame. 


To run this game, open the .sln file with Visual Studio, and press "Start without Debugging" in the Debug tab. Additionally, you can also double click the exe file after compiling.  

# Controls

General:

  Q: Quit the Game
  
  R: Reset the Game

  Change Map: Right Mouse Click

Player 1: 

  Move Up: W
  
  Move Left: A
  
  Move Right: D
  
  Move Down: S

  Drop Bomb: Space

  Auto Death: G

  Use Item1: D1
  
  Use Item2: D2
  
  Use Item3: D3

Player 2:

  Move Up: Up Arrow Key
  
  Move Left: Left Arrow Key
  
  Move Right: Right Arrow Key
  
  Move Down: Down Arrow Key

  Drop Bomb: Enter

  Auto Death: L

  Use Item1: D0
  
  Use Item2: D9
  
  Use Item3: D8
  
Testing Controls:
  
  // unused - key bound to GameOver sound effect currently
  Change Character1: E
  // unused - key bound to GameOver sound effect currently
  Change Character2: P

How to Play:

  See Bubble Arena and other similar games for Reference: (https://www.youtube.com/watch?v=O2RPyNrL9Xg&ab_channel=HyperXshadow). The goal of the game is to eliminate all other players and AI by dropping bombs on them, all while avoiding enemies and explosions.  
  Destroy crates and collect items to increase stats or obtain special abilities, but watch out for enemy bombs and AI, who can kill you if they touch you! Last player alive wins the game!
  
	
Special Items: 
	Bomb Item: Allows you to drop more bombs at a time
	Shoe Item: Gives you a slight speed boost
	Potion Item: Gives a larger explosion radius to bomb 
	Goblin: Transform to Goblin Character - bomb explosion has radius of 10
	Knight: Transform to Knight Character - super speed
	Ghost: Transform to Ghost Character - reversed movement and better stats
	Ninja Star: Usable item stored in inventory - triggers bomb explosion on contact
	Torpedo: Usable item stored in inventory - kills player upon contact


Bugs/Notes:
	-Most everything should work accordingly
	-Occasional collision issues
	-Some functionality not fully implemented for sprint4 yet - coin collection, mine cart, traps, game state.
	-Map4 is used for testing purposes (coin spawner, all items available, etc,.)
	

Other:
    
  Sprint Reflection is in the CodeReview folder of the project.
  
  Team responsibility spreadsheet: https://docs.google.com/spreadsheets/d/1C56Z-13CeJ7uicKJGbocY6O8JArwAjoMr41DtI3Xig4/edit#gid=0
  
  
  
  
