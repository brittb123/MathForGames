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
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

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
            _scenes[_currentScene].End();
            _currentScene = index;
            _scenes[_currentScene].Start();
        }

        public static ConsoleKey GetNextKey()
        {
            if (!Console.KeyAvailable)
            {
                return 0;
            }
            return Console.ReadKey(true).Key;
        }

        public Game()
        {
            _scenes = new Scene[0];
        }
        //Called when the game begins. Use this for initialization.

        public void Start()
        {
            Raylib.SetTargetFPS(0);
            Raylib.InitWindow(1024, 760, "Math For Games");
            
            Console.CursorVisible = false;
            
            Scene scene = new Scene();
            Scene scene2 = new Scene();
            scene = new Scene();
            
            Actor actor = new Actor(0, 0, Color.WHITE, '♦', ConsoleColor.DarkBlue);
            actor.Velocity.X = 1;
            
            Player player = new Player(0, 1, '@', ConsoleColor.Red);
            Ball ball = new Ball(10, 1, '■');
            
            scene.AddActor(actor);
            scene.AddActor(player);
            scene.AddActor(ball);

            int startingSceneIndex = 0;

            startingSceneIndex = AddScenes(scene);
            
            AddScenes(scene2);

            SetCurrentScene(startingSceneIndex);
        }


        //Called every frame.
        public void Update()
        {
            _scenes[_currentScene].Update();
            
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.WHITE);
            _scenes[_currentScene].Draw();
            
            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose()) 
            {
                Update();
                Draw();
                while (Console.KeyAvailable) 
                    Console.ReadKey(true);
                Thread.Sleep(150);
            }

            End();
        }
    }
}
