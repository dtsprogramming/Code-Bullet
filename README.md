# Code-Bullet
 A laser wall environment to shred 3D AI Agents. Created with the hope that Code Bullet would reproduce his method for training 2D agents to walk forward. Get them 3D boys moving in the right direction!

 ## Scene: BuildTheWall<br/>
 The "Wall Unit" is king! Check the prefab.
 
 ### Laser Render (Script):
  - Start and End point arrays to control how the lasers render
  - Laser start and end width values
  - Max ray distance: The distance between your walls before things start breaking. Each ray checks for endpoint render distance and laser fodder
  - Left and Right Walls can be moved in "Scene", during Play, to adjust lasers

 ### Conveyor Trap (Script): 
  - Move Speed: Moves the wall unit assembly, camera, lights, and spawn points by the specified value

 ### Audio Source:
  - Added for background music

 ## Spawn Points (Child of Wall Unit)
 ### Zombie Spawner (Script):
  - Spawn Object: Game Object to spawn in
  - Platform Transform: Sets the parent transform for each spawn
  - Spawners Array: Add all the spawn points. Spawns instantiate at a random spawn point from the array
  - Spawn Delay: Delay time between each spawn

 ## Zombie
 ### Dissolve Controller (Script):
  - VFX Graph: Added to Zombie Prefab. Controls dissolve and ash effects
  - Refresh/Dissolve Rate: Used to adjust dissolve rate
  - Anim: Allows controller to set death anim during dissolve
  - Zombie Scream: Audio clip for death sound
  - Zombie Audio: Audio source for scream
