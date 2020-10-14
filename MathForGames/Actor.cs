using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Math_Library;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }


        public Actor()
        {
            _position = new Vector2();
            _velocity = new Vector2();
        }
        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red)
        {
            _icon = icon;
            _position = new Vector2(x, y);
            _color = color;
            _velocity = new Vector2();
        }




        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            Math.Clamp(_position.X, 1, Console.WindowWidth-1);
            Math.Clamp(_position.Y, 1, Console.WindowHeight-1);

        }
        public virtual void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {

        }
    }
}
