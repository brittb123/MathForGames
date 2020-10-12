using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Actor
    {
        private char _icon = 'k';
        private int _x = 0; 
        public void Start()
        {

        }

        public void Update()
        {
            if (Game.CheckKey(ConsoleKey.D))
            {
                _x++;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, _x);
            Console.Write(_icon);
        }

        public void End()
        {

        }
    }
}
