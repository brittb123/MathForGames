using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
        protected Color _rayColor;
        private Vector2 _facing;
        public bool Started { get; private set; }
        public Vector2 Forward
        {
            get { return _facing; }
            set { _facing = value; }
        }
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
            _rayColor = Color.RED;
            _icon = icon;
            _position = new Vector2(x, y);
            _color = color;
            _velocity = new Vector2();

            Forward = new Vector2(1, 0);
        }

        public Actor(float x, float y, Color _raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : this(x, y, icon, color)
        {
            _rayColor = Color.BLUE;

        }

       

        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            _facing = Velocity.Normalized;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            float magnitude = _velocity.GetMagnitude();
            _position += _velocity * deltaTime;
            
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight-1);

        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(_position.X * 32), (int)(_position.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(Position.X * 32),
                (int)(Position.Y * 32),
                (int)((Position.X + Forward.X) * 32),
                (int)((Position.Y + Forward.Y) * 32),
                Color.RED
                );
            if(Position.X >= 0 && Position.X < Console.WindowWidth - 1
                && Position.Y >= 0 && Position.Y >Console.WindowHeight - 1)
            {
                Position.X = 1;
                Position.Y = 0;
                Console.SetCursorPosition((int)_position.X, (int)_position.Y);
                Console.Write(_icon);
            }
            Console.ForegroundColor = _color;
         
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
