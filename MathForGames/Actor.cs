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
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotate = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        private Sprite _sprite = new Sprite("Images/Enemy.png");
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        protected Matrix3 _globalTransform;
        public bool Started { get; private set; }
        public Vector2 Forward
        {
            get { return new Vector2(_localTransform.m11, _localTransform.m21); }

        }
        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }

        public Vector2 WorldPosition
        {
            get
            {
               return new Vector2(_globalTransform.m13, _globalTransform.m23);
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

        public void AddChild(Actor Child)
        {
            Actor[] temparray = new Actor[_children.Length + 1];
            for (int i = 0; i < _children.Length; i++)
            {
                temparray[i] = _children[i];
            }
            temparray[_children.Length] = Child;
            _children = temparray;
            Child._parent = this;
        }

        public bool RemoveChild(Actor Child)
        {
            bool ChildRemoved = false;
            if (Child == null)
                return false;

            Actor[] temparray = new Actor[_children.Length - 1];
            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if(Child != _children[i])
                {
                    temparray[j] = _children[i];
                    j++;
                }
                else
                {
                    ChildRemoved = true;
                }
            }
            _children = temparray;
            Child._parent = null;
            return ChildRemoved;
        }

        public void SetTranslate(Vector2 position)
        {
            _translation.m13 = position.X;
            _translation.m23 = position.Y;
        }

        public void SetRotation(float radians)
        {
            _rotate.m11 = (float)Math.Cos(radians);
            _rotate.m12 = (float)Math.Sin(radians);
            _rotate.m21 = -(float)Math.Sin(radians);
            _rotate.m22 = (float)Math.Cos(radians);
        }

        public void SetScale(float X, float Y)
        {
            _scale.m11 = X;
         
            _scale.m22 = Y;
            
        }

        public void UpdateTransform()
        {

            _localTransform = _translation * _rotate * _scale;
            
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

            UpdateTransform();

            LocalPosition += Velocity * deltaTime;

        }

        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_localTransform);



            Raylib.DrawText(_icon.ToString(), (int)(_position.X * 32), (int)(_position.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(LocalPosition.X * 32),
                (int)(LocalPosition.Y * 32),
                (int)((LocalPosition.X + Forward.X) * 32),
                (int)((LocalPosition.Y + Forward.Y) * 32),
                Color.RED
                );
            if (LocalPosition.X >= 0 && LocalPosition.X < Console.WindowWidth - 1
                && LocalPosition.Y >= 0 && LocalPosition.Y > Console.WindowHeight - 1)
            {
              
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
