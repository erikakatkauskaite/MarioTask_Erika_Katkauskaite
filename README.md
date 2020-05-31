# MarioTask_Erika_Katkauskaite

1.	Fix the errors in the Console window
  a.	Enter the Play mode to see them
  To fix them I needed to add rigidbody to the Player game object; indicate the main camera object; In the PlayerController script I moved the methods that were in the inside of the Update() method;    
  b.	Explore how the game behaves in different scenarios (for ex. what happens when you collect a certain amount of points)
  I found out that after I collect more than 2000 points Unity crashes, to make it stop it was needed to get rid of the code that was causing it.
2.	Finish the Level
  a.	Use Tilemap to fill in the missing parts
  Missing parts were filled by using Tile Palette, for the castle tower I created the second Tilemap.
  b.	Make sure that “BrickBreak” GameObjects are destroyed when they are no longer used to produce the Brick Block breaking effect
  Firstly, I created the Brick Block breaking effect prefab. DestroyBrick() function creates new game object which is going to be the prefab that was created earlier and will inherit the brick's position. I did it in this way so the particle clone object can be destroyed when it's needed.
3.	Create the Hidden Block (https://www.mariowiki.com/Hidden_Block)
a.	You shouldn’t be able to jump on the block while it’s invisible, use one of the 2D components to achieve that
I created the MagicalBox game object prefab which has the 2D collider which is trigger and the IvisibleBlock script. InvisibleBlock script has OnTriggerEnter2D function which is checking if the MagicalBox game object collider is triggering with the Player collider. If it is triggering and the player is below the game object, then trigger object is destroyed and QuestionBlockVisual prefab is instantiated in the same position.
  I saw that there is a game object called "Invisible" under the QuestionBoxes in the hierarchy. If it would be needed to use the exact game object from the hierarchy then we wouldn't instantiate but would make this object not active and once triggered then it would be set to active. But I think it's smarter to use QuestionBlockVisual prefab in case we need the same effect multiple times.
4.	Make the Goal Pole animation using Timeline for the core parts (https://www.mariowiki.com/Goal_Pole)
This task took me the longest because I have never used the Timeline sequencing. I had to think where the animation should start and where to end.
a.	Mario should slide down the pole and walk to the castle
b.	There should be flag coming out of the castle and the fireworks around it
Once the player collides with the flag pole the playable director which holds animations for the flag sliding down the pole, fireworks and little flag comming out from behind the castle animations is set to play. Meanwhile, the player doesn't start it's animation yet but it's movement control is not working so it has the slide down the pole effect. Once the player hits the block which is at the bottom of the pole then the player Timeline starts playing. If powered up it uses the BigMario Timeline and if it is not powered up than it uses regular mario Timeline.

5.	Create the UI of the game and arrange it according to the image 
a.	There is an object called “ScoreManagerObj” which has a Script “ScoreManager” that tracks time, score and coins count
I created the UI() method which sets score, coins, time and world text. I created the currentLevelIndex variable so if there would be more than one level, after finishing current level it would load the further scene. For now, since we have only one scene it restarts the same scene. 
b.	Target the UI for Standalone (512x512) resolution but make sure it scales well for different resolutions too
To achieve this I set the canvas Render Mode to Screen-Space Owerlay and UI Scale Mode to Scale with screen size. Also, I pinned the Canvas elements to the specific corners so it doesn't make a mess once the resolution is changed.

About the task itself. Since I have never worked with the Unity 2D environment this task was very usefull. I learned how to work with the Tilemap and slice the sprite sheets for further usage. Also, I was always curious about the Timeline animations but I have never tried it before so this is one more thing I learned by doing this task. Very good practice! :)




 
