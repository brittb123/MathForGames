# MathForGames Section:
## Getting Started:

### Important Classes:
The firest important thing for this game is to have the essential classes. 
These consist of Player, Enemy, Actor, Scene for the MathforGames section. A piece 
equally as important is the Math Library, which is consists of 2 Matrix classes, 
Matrix3 and Matrix4, and 3 Vector classes which are Vector2, Vector3, and Vector4.

## Input Controls and How to play:

### How To Play:

This game has a very simple and basic idea behind it which is, SURVIVE! Enemies will be 
coming down like rain and the player must avoid each with extreme precision! If the player
is hit then the game will end!

### Input Controls:

#### Keyboard Key W:
This key will move the player up the screen!

#### Keyboard Key S:
Moves the player downwards to avoind enemies from the top!

#### Keyboard Key A:
Makes the player move to the left to avoid enemies!

#### Keyboard Key D:
Moves the player to the right to avoid and enemies coming to close from the left!

### Important MathForGames Functions
This section will break down the functions all used in every class not including Math Library which 
is further down the documentation! Each function will show the type, visibility, paramaters, and a
description. Overloaded functions will be printed with the extra parameters!

### Game Class:

+ SetGameOver(bool value)  
Type: Static Void, Visibility: Public,  
Description: This function is to set the gameover variable without needing a instance of game
class, for easier access as well as making a winning screen!  

+ AddScene(Scene scene)  
Type: Static Int, Visibility: Public,  
Description: This function uses a for loop and a temporary array to take the value placed in the parameter 
to add the scene created in the array of the scenes to switch in between scenes later if needed! The
scene wanting to be added is added to the temporary array which is set to equal the scene array to add
that scene to it!

+ RemoveScene(Scene scene)  
Type: Static bool, Visibility: Public,  
Description: A function that is similiar to the AddScene function, but removes instead of adding. A
if statement is plcaed to check if the scene wanting to be rmeoved is null, if so the function ends.
A temp array is made with an if statement to check the index of the temp array with the scene wanting to
be removed! If the scene and index match the scene is removed and returns true at the end of the function
and is set to equal the scene array.

+ GetScene(int index)  
Type: Static Scene, Visibity: Public,   
Description: A very simple function that calls a certain index of the scenes array and returns the spceific
scene!

+ SetCurrentScene(int index)  
 Type: Static Void, Visibility: Public,  
 Description: A function that takes the index and sets the scene that is displayed to the ccertain index.
 The for loop goes checks if every index of the scene array matches the index of the scene wanted.
 The scene is also ended before being switched to the next scene!

+ GetKeyDown(int key)  
 Type: Static Bool, Visibility: Public,  
 Description: This function is to check if a key is being currently pressed, if so the function returns
the certain key pressed.

+ GetKeyPressed(int key)  
 Type: Static Bool, Visibility: Public,  
 Description: A simple function that checks if the player presses a key then returns the certain key pressed.

+ Update(float deltatime)
 Type: Void, Visibility: Public,  
 Description: A very important function that updates every actor and scene within the arrays.

+ Draw()
 Type: Void, Visibility: Public,  
 Description: A function that draws the scenes and tells every actor to draw that is included in that
scene, as well as displaying other information needed.

+ End()
 Type: Void, Visibility: Public,  
 Descripition: This function is called at the end of the game which finished and ends any stary bits
of code and displays an ending message upon victory or defeat!

+ Run()
 Type: Void, Visbility: Public,  
 Description: The function that loops the update function after Start is called and loops until 
the window is closed or if gameover is set to true.

## Class Actor Functions:

+ AddChild(Actor child)
 Type: Void, Visibility: Public,  
 Description: A complicated function that takes the wanted actor and makes the actor a child of matrix
hierarchy aswell as adds the actor calling this function as its Parent actor. The child is then added to the
array that keeps all child actors.

+ RemoveChild(Actor child)  
 Type: Bool, Visibility: Public,  
 Description: This function is similiar to the add child function except it tests every child to the 
to input of the parameter. If the child is null or non existant the function will return false, otherwise
the function will remove the child and the calling actor's parent status by setting it to null.

+ SetTranslate(Vector position)  
 Type: Void, Visibility: Public,  
Description:  A function that uses a matrix to translate the actor to a different area of the screen,
as well as allows movement of the player and enemies.

+ SetRotation(float radians)  
 Type: Void, Visibility: Public,  
Description: Similiar to the translate function, this function uses a matrix to rotate any enemy or player
to a certain amount of rotation as well as use to rotater the player when turning!

+ CheckCollision(Actor other)  
 Type: Bool, Visibility: Public,  
 Description: A function that uses two actors positions with the distance formula to get a set distance and
checks if the distance is less than the collide radius added. If so, the function is returned true otherwise
the function will return false.

+ OnCollision(Actor other)  
 Type: Virtual Void, Visibility: Public,  
 Description: This function uses an if statement to check if the check collision function returned true,
then sets the scale of the player and enemy to 0 which makes both disappear to indicate the player has died and lost
the game.

+ SetScale(float x, float y)  
 Type: Void, Visibility: Public,  
Description: A simple function that allows any actor to change the size of the actor calling it.

+ UpdateTransform()  
 Type: Void, Visibility: Public,
 Description: This function combines the rotation, scale, and translation of the actor to show
all without any bugs!

+ UpdateFacing()  
 Type: Void, Visibility: Private,  
 Description: A very simplistic function that always will keep the player facing in the direction of
which way it moves!

+ Update(float deltatime)  
Type: Void, Visibility: Public,  
Description: This update function is only for the actors which will update their position in code and
on screen, as well as always calculate the velocity and acceleration.

+ Draw()  
Type: Virtual Void, Visibility: Public,  
Description: This function is for drawing the sprite as the position is currently updates as well as
keeping the player on the screen. It also allows a raylib window to be made and work with any actor displayed
on the current scene!

## Class Enemy Functions:
+ CheckTargetInSight(float angle, float maxDistance)  
Type: Bool, Visibility: Private,  
Description: A function that uses a player distance from the enemy and the angle of the enemy and player
using dot product, to check if the enemy is in sight! If so the function returns true, otherwise it will return
false!

+ Update(float deltatime)  
Type: Overrided Void, Visibility: Public,  
Description: Another update function in the enemy class to call the actor's draw function, as well as 
consistantly checks whether the player is in or actor is in the line of sight! It will call the basic
actor Update function!

## Player Class Functions:
+ Update(float deltatime)  
Type: Overrided Void Visiblity: Public  
Description: The player's update maintains the player's direction and which way to move and also calculates the
acceleration and velocity of the player! This also will call the basic actor update function to move the sprite as well as
the other maintaining of what is needed in the update!

+ Draw()  
Type: Void, Visiblity: Public,  
Description: This will draw the basic sprite at the current position from the player then call
the basic actor draw function!

## Sprite Class Functions:
+ AddActor(Actor actor)  
Type: Void, Visiblity: Public,  
Description: This function will make a temp array and set the actor array equal the temp array. 
This will then move through each index to make sure each is added to the temp array with a for loop.
The value of the actor is then added to the end of the actor array and then returned if the actor was added
correctly!

+ RemoveActor(int index)  
Type: Void, Visiblity: Public,  
Description: The functions checks to make sure the index is in the bounds of the array then makes
a temp array for the actors array. The temp array is then cycled through with a for loop then removes the selected
actor! The temp array is then set to equal the actor array thus removing the actor!

+ CheckCollision()  
Type: Void, Visiblity: Private,   
Description: A function that is different than the check collision of the actors version, two for loops
are made to check if any actor is colliding with each actor if the index of the array is surpassed the function
calls a break! If so the collsion is called for the actor to collide with the other!

+ Update(float deltatime)  
Type: Void, Visiblity: Public,  
Description: The function is similar to the others, it will go through every actor in the scene and
call their update function as well as checking if there is any collisions of the actors!

+ Draw()  
Type: Void, Visiblity: Public,  
Description: Similiar to the update function, the scenes array will be looped through a for loop
of each index then draw the sprit, as well as the location of where to draw!

+ End()  
Type: Void, Visiblity: Public,  
Description: The function will check what actors have been started then end all remaining actors.

# Math Library
This part will cover the Math Library function neccessary to run the code properly!

## Vector2 Class Fucntions:
+ DotProduct(Vector2 lhs, Vector2 rhs)  
Type: Static Float Visiblity: Public,  
Description: This functions allows quick access to the dotproduct of two vectors by multiplying by 
vectors x's and y's then adding them, which returns a new vector2!

+ Operator +(Vector2 lhs, Vector2 rhs) 
Type: Static Vector2, Visiblity: Public,  
Description: This overloads the + operator to easily add two vectors by adding the x's and y's of each
then returning a new vector with the sums of each!

+ Normalize(Vector2 Vector)
Type: Static Vector2, Visiblity: Public,  
Description: A simple function that divides the given vector by the magnitude of the vector to set the 
magnitude to 1 then returns!

+ Operator -(Vector2 lhs, Vector2 rhs)  
Type: Static Vector3, Visiblity: Public,  
Description: Similiar to the + operator, this has been overloaded to easily subtract two vectors then return 
a new vector with the two differences!

+ Operator *(Vector2 lhs, Scalar)  
Type: Static Vector2, Visiblity: Public,  
Description: This function overloads the * operator to allow a vector2 to be multipled by a certain
scalar of whats needed!

+ Operator /(Vector2 lhs, Scalar)  
Type: Static Vector2, Visiblity: Public,  
Description: Opposite of the * operator overload, this function takes and divides the Vector2
by the scalar and returns the new vector2 by dividing both of the coordinates.

+ GetMagnitude()  
Type: Float, Visiblity: Public,  
Description: The function gets the magnitude by squaring both the X and the Y then taking the square
root of the result then returns the magnitude!

## Vector3 Class Functions:
+ DotProduct(Vector3 lhs, Vector3 rhs)  
Type: Static Float Visiblity: Public,  
Description: This functions allows quick access to the dotproduct of two vectors by multiplying by 
vectors x's, y's, and z's then adding them, which returns a new vector2!

+ Operator +(Vector3 lhs, Vector3 rhs) 
Type: Static Vector3, Visiblity: Public,  
Description: This overloads the + operator to easily add two vectors by adding the x's,y's, and z's of each
then returning a new vector with the sums of each!

+ Normalize(Vector3 Vector)
Type: Static Vector3, Visiblity: Public,  
Description: A simple function that divides the given vector by the magnitude of the vector to set the 
magnitude to 1 then returns!

+ Operator -(Vector3 lhs, Vector3 rhs)  
Type: Static Vector3, Visiblity: Public,  
Description: Similiar to the + operator, this has been overloaded to easily subtract two vectors then return 
a new vector with the two differences!

+ Operator *(Vector3 lhs, Scalar)  
Type: Static Vector3, Visiblity: Public,  
Description: This function overloads the * operator to allow a vector3 to be multipled by a certain
scalar of whats needed!

+ Operator *(Scalar, Vector3)  
Type: Static Vector3, Visiblity: Public,  
Description: This function overloads the * operator to allow a vector3 to be multipled by a certain
scalar of whats needed! Similiar to the one above but allows to use in any order!

+ Operator /(Vector3 lhs, Scalar)  
Type: Static Vector3, Visiblity: Public,  
Description: Opposite of the * operator overload, this function takes and divides the Vector2
by the scalar and returns the new vector3 by dividing both of the coordinates.

+ GetMagnitude()  
Type: Float, Visiblity: Public,  
Description: The function gets the magnitude by squaring both the X and the Y then taking the square
root of the result then returns the magnitude!

+ CrossProduct(Vector3 lhs, Vector3 rhs)  
Type: Static Vector3, Visibility: Public,  
Description: This allows very easy acces to crossproduct of two vectors and returns a new vector 3 of the 
cross product!

## Vector4 Class Functions

+ DotProduct(Vector4 lhs, Vector4 rhs)  
Type: Static Float Visiblity: Public,  
Description: Like the other vector classes, this functions allows quick access to the dotproduct of two vectors by multiplying by 
vectors x's, y's, z's, and w's then adding them, which returns a new vector4!

+ Operator +(Vector4 lhs, Vector4 rhs) 
Type: Static Vector4, Visiblity: Public,  
Description: This overloads the + operator to easily add two vectors by adding the x's, y's, z's, and w's of each
then returning a new vector with the sums of each!

+ Normalize(Vector4 Vector)
Type: Static Vector4, Visiblity: Public,  
Description: Like each normalize function this functiondivides the given vector by the magnitude of the vector to set the 
magnitude to 1 then returns!

+ Operator -(Vector4 lhs, Vector4 rhs)  
Type: Static Vector4, Visiblity: Public,  
Description: Similiar to the other + operator, this has been overloaded to easily subtract two vectors then return 
a new vector with the two differences!

+ Operator *(Vector4 lhs, Scalar)  
Type: Static Vector4, Visiblity: Public,  
Description: Very similar to the other Vectors, this function overloads the * operator to allow a vector4 to be multipled by a certain
scalar of whats needed!

+ Operator *(Scalar, Vector4)  
Type: Static Vector4, Visiblity: Public,  
Description: This function overloads the * operator to allow a vector4 to be multipled by a certain
scalar of whats needed! Similiar to the one above but allows to use in any order like the others above!

+ Operator /(Vector4 lhs, Scalar)  
Type: Static Vector4, Visiblity: Public,  
Description: Opposite of the * operator overload, this function takes and divides the Vector4
by the scalar and returns the new vector4 by dividing both of the coordinates.

+ GetMagnitude()  
Type: Float, Visiblity: Public,  
Description: The function gets the magnitude by squaring the X, Y, Z, and W then taking the square
root of the result then returns the magnitude!

+ CrossProduct(Vector4 lhs, Vector4 rhs)  
Type: Static Vector4, Visibility: Public,  
Description: This allows, like the other vectors above, to use crossproduct of two vectors and returns a new vector 4 of the 
cross product!

## Matrix3 Class Functions:

+ Operator +(Matrix3 lhs, Matrix3 rhs)  
Type: Matrix3, Visibility: Public  
Description: This makes it simple to add two matrices to together and return the new Matrix3.

+ Operator -(Matrix 3 lhs, Matrix3 rhs)  
Type: Matrix3, Visibility: Public  
Description: Simliar to the vector classes this allows matrices to be subtracted with ease and returns
a matrix with the difference!

+ Operator *(Matrix3 lhs, Matrix3 rhs)  
Type: Matrix3, Visibility: Public 
Description: Unlike the vectors, this overload allows two matrices to be multiplied and return a new
matrix with the product of both matrices!

+ CreatRotation(float Radians)   
Type: Matrix3, Visibility: Public 
Description: This is the basic setup for any actor to allow rotation using sine and cosine with a matrix!

+ CreateTranslation(Vector2 Position)   
Type: Matrix3, Visibility: Public  
Description: This is a basic setup for any translation that a actor would use by allowing the 
x and y to change while keeping the rest of the matrix the same!

+ CreateScale(Vector2 scale)   
Type: Matrix3, Visibility: Public  
Description: Allows the base of scaling for every actor to allow size change by stretching or shrinking the
actor!

+ Operator *(Matrix3 rhs, Vector3 lhs)   
Type: Matrix3, Visibility: Public 
Description: Unlike the other operator overload, This allows the Matrix to be multipled to a vector for quick use
and returns a new vector3 of the multplication product! 

## Matrix4 Class Functions:

+ Operator +(Matrix4 lhs, Matrix4 rhs)  
Type: Matrix3, Visibility: Public  
Description: Like Matrix3, this makes it simple to add two matrices to together and return the new Matrix3.

+ Operator -(Matrix 4 lhs, Matrix4 rhs)  
Type: Matrix3, Visibility: Public  
Description: Simliar to the Matrix3 this allows matrices to be subtracted with ease and returns
a matrix with the difference!

+ Operator *(Matrix4 lhs, Matrix4 rhs)  
Type: Matrix4, Visibility: Public 
Description: Unlike the vectors, but simliar to the Matrix3 class this overload allows two matrices to be multiplied and return a new
matrix with the product of both matrices!

+ CreatRotationX(float Radians)   
Type: Matrix4, Visibility: Public 
Description: This is a more advanced rotation for the vector4 class but still allows any actor to rotate on the X using sine and cosine with a matrix!

+ CreatRotationY(float Radians)   
Type: Matrix4, Visibility: Public 
Description: This is a more advanced rotation for the vector4 class but still allows any actor to rotate on the Y using sine and cosine with a matrix!

+ CreatRotationZ(float Radians)   
Type: Matrix4, Visibility: Public 
Description: This is the final advanced rotation for the vector4 class that allows any actor to rotate on the Z axis using sine and cosine with a matrix!


+ CreateTranslation(Vector3 Position)   
Type: Matrix3, Visibility: Public  
Description: This is a basic setup for any translation that a actor would use in a vector3 by allowing the 
x and y to change while keeping the rest of the matrix the same with extra coordinates because of the extra row from the matrix4!

+ CreateScale(Vector3 scale)   
Type: Matrix3, Visibility: Public  
Description: Similiar but not exactly the same as Matrix3, this allows the base of scaling of any vector3 for every actor to allow size change by stretching or shrinking the
actor!

+ Operator *(Matrix4 rhs, Vector4 lhs)   
Type: Matrix3, Visibility: Public 
Description: Unlike the other operator overload and similiar the the last in Matrix3, This allows the Matrix to be multipled to a vector for quick use
and returns a new vector4 of the multplication product! 

## All Important Variables:

This will combine all classes and list the important variables used in the game!

+ _currentScene  
Type: int, Visibility: Private,  
Description: This is the index of the current scene used!

+ _gameOver  
Type: Bool, Visibility: Private,   
Description: A bool that indicates whether the game is over whether through winning or losing!

+ DefaultColor    
Type: Static ConsoleColor, Visibility: Public,  
Description: This indicates the basic color of the console not that essential but a nice touch!

+ Started    
Type: Bool, Visibility: Public,  
Description: This is to check if the actors and scenes have been started!

+ World   
Type: Matrix3, Visibility: Public,  
Description: This is the basic world grid and matrix for all scenes to take place on!

+ _icon    
Type: static Char, Visibility: Protected,  
Description: The Icon that is displayed on console to represent the actor, but not in raylib window!

+ _position   
Type: Vector2, Visibility: Protected,  
Description: This is to set and keep track of the actor's position.

+ _facing  
Type: Vector2, Visibility: Private,  
Description: A variable that keeps the direction of where the actors face!

+ _gloablTransform   
Type: Matrix3, Visibility: Protected,  
Description: This variable is to hold on to any information of where the actor is in 3d of the world!

+ _localtransform   
Type: Matrix3, Visibility: Protected,  
Description: This is to hold all information for the transforms and position of actors in a 2d platform!

+ _translation   
Type: Matrix3, Visibility: Protected,  
Description: This is to hold the translation of actors for the function UpdateTransform!

+ _rotate   
Type: Matrix3, Visibility: Protected,  
Description: This is to hold information of actors rotation to use in the UpdateTransform!

+ _scale   
Type: Matrix3, Visibility: Protected,  
Description: This variable will keep all information of scaling of a actor to use in the update transform function

+ _sprite   
Type: Sprite, Visibility: Protected,  
Description: This is to save the file location of the sprite image of any actor, player, or enemy!

+ _parent 
Type: Actor, Visibility: Protected,  
Description: This is a variable of a parent in a matrix Hierarchy when given a child through the addchild function.

+ _collideradius   
Type: float, Visibility: Protected,  
Description: A important piece of collision that sets a range of how far the colliding radius of an actor is!

+ acceleration  
Type: Vector2, Visibility: Protected,  
Description: Allows the actors, enemy, and or player to have an accleration upon moving!

+ _maxSpeed
Type: float, Visibility: Private,  
Description: This sets a max speed of how much accelaration the actors have!

+ localPosition   
Type: Vector2, Visibility: Protected,  
Description: This is the basic holder of any actor position in a 2d scale!

+ WorldPosition   
Type: Vector2, Visibility: Protected,  
Description:  This is simialr to local position but used with matrix hierarchy and 3d style games!

+ Velocity  
Type: Vector2, Visibility: Public,  
Description: This allows any object to move at a constant speed on a chozen axis!

+ _speed  
Type: float, Visibility: private,  
Description: This sets a base speed of any object not counting acceleration.

+ Player 
Type: Player, Visibility: Private,  
Description: This allows the enemy class to have a base player in need for testing!

+ _target
Type: Actor, Visibility: Private,  
Description: This is the enemy's target system base, a player or actor can be set as the target!
