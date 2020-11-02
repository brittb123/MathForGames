using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace MathForGames
{
    public class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
        protected Color _rayColor;
        private Vector2 _facing;
        protected Matrix3 _transform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotate = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        private Sprite _sprite = new Sprite("Images/player.png");
        public bool Started { get; private set; }
        public Vector2 Forward
        {
            get { return new Vector2(_transform.m11, _transform.m21); }
            
        }
        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.m13, _transform.m23);
            }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
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

            //Forward = new Vector2(1, 0);
        }

        public Actor(float x, float y, Color _raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : this(x, y, icon, color)
        {
            _rayColor = Color.BLUE;

        }

        public void SetTranslate(Vector2 position)
        {
            _translation.m31 += position.X;
            _translation.m32 += position.Y;
        }

        public void SetRotation(float radians)
        {
            _rotate.m11 = (float)Math.Cos(radians);
            _rotate.m12 = (float)Math.Sin(radians);
            _rotate.m21 = (float)-(Math.Sin(radians));
            _rotate.m22 = (float)Math.Cos(radians);
        }

        public void SetScale(float X, float Y)
        {
            _scale.m11 += X;
         
            _scale.m22 += Y;
            
        }

        public void UpdateTransform()
        {

            _transform *= _translation * _rotate;
            _transform *=_scale;
        }


        //private void UpdateFacing()
        //{
        //    if (_velocity.Magnitude <= 0)
        //        return;

        //    _facing = Velocity.Normalized;
        //}

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
            if (_sprite != null)
                _sprite.Draw(_transform);

            ;

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
