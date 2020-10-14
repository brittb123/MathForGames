﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Math_Library;

namespace MathForGames
{
    class Game
    {
        private Scene _scene;
       
        private static bool _gameOver = false;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        

        public static ConsoleKey GetNextKey()
        {
            if (!Console.KeyAvailable)
            {
                return 0;
            }
            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;
            _scene = new Scene();
            Actor actor = new Actor(0, 0, '■', ConsoleColor.DarkBlue);
            actor.Velocity.X = 1;
            Player player = new Player(0, 1, '@', ConsoleColor.Red);
            Ball ball = new Ball(10, 1, '■');
            _scene.AddActor(actor);
            _scene.AddActor(player);
            _scene.AddActor(ball);
        }


        //Called every frame.
        public void Update()
        {
            _scene.Update();
            
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
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
