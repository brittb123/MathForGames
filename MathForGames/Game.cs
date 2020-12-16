using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Math_Library;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static int _currentScene;
        
        private static Scene[] _scenes;
        private static bool _gameOver = false;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Green;
        

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        //Add a scene into an array of scenes for actors to use
        public static int AddScenes(Scene scene)
        {
            Scene[] temparray = new Scene[_scenes.Length + 1];
            for(int i = 0; i < _scenes.Length; i++)
            {
                temparray[i] = _scenes[i];
            }
            temparray[_scenes.Length] = scene;
            _scenes = temparray;
            int index = _scenes.Length;
            return index;
        }

        // Removes the scene chosen while keep the other scenes in order
        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] temparray = new Scene[_scenes.Length + 1];
            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {

                if(temparray[j] != scene)
                {
                    temparray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                        return removed;
                }
            
            } 
            return removed;
        }

        public static Scene GetScenes(int index)
        {
            return _scenes[index];
        }

        public static void SetCurrentScene(int index)
        {
            if(index >= _scenes.Length || index < 0) 
                return;
            if (_scenes[_currentScene].Started)
                _scenes[_currentScene].End();
            _currentScene = index;
            
        }

      public static bool GetKeyDown(int key)
        {
            bool testbool = true;
            int test = Convert.ToInt32(testbool);
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.SetTargetFPS(60);
            Raylib.InitWindow(820, 720, "Math For Games");
            
            Console.CursorVisible = false;
            
            Scene scene1 = new Scene();
          
            
          


            Actor actor = new Actor(0, 0, Color.DARKBLUE, '*', ConsoleColor.DarkBlue);
            actor.Velocity.X = 1;
            
            Player player = new Player(1, 20, Color.YELLOW, 'A', ConsoleColor.Yellow);

            Enemy enemy = new Enemy(2, 1, Color.MAROON, ' ', ConsoleColor.Green);
            Enemy enemy2 = new Enemy(5, 1, Color.MAROON, ' ', ConsoleColor.Green);
            Enemy enemy3 = new Enemy(9, 1, Color.MAROON, ' ', ConsoleColor.Green);
           



            //scene.AddActor(actor);
            scene1.AddActor(player);

            scene1.AddActor(enemy);
            scene1.AddActor(enemy2);



            //enemy.SetTranslate(new Vector2(4, 5));
            enemy.SetScale(3, 3);
            enemy.Velocity.Y = 6;
            
            player.SetScale(1, 1);
            enemy.Target = player;
            enemy.AddChild(enemy2);

            //player.SetTranslate(new Vector2 (10, 5));


            int startingSceneIndex = 0;
            startingSceneIndex = AddScenes(scene1);


            SetCurrentScene(startingSceneIndex);


        }


        //Called every frame.
        public void Update(float deltaTime)
        {
            

            if (!_scenes[_currentScene].Started) 
                _scenes[_currentScene].Start();

            _scenes[_currentScene].Update(deltaTime);
            
            

        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.BLACK);
            _scenes[_currentScene].Draw();
            
            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            
            if (_scenes[_currentScene].Started)
                _scenes[_currentScene].End();

          
          
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();
            

            while (!_gameOver && !Raylib.WindowShouldClose()) 
            {
                float deltaTime = Raylib.GetFrameTime();
               
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable) 
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
