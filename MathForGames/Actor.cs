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
        private Vector2 _velocity = new Vector2();
        protected ConsoleColor _color;
        protected Color _rayColor;
        private Vector2 _facing;
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localtransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotate = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        private Sprite _sprite;
        protected Actor _parent;
        private float _rotateangel;
        protected Actor[] _children = new Actor[0];
        protected float _collideradius;
        private Vector2 accelration = new Vector2();
        private float _maxSpeed = 5;
        public bool Started { get; private set; }
        //Gets the foward direction of the player as well as sets and checks if the player is looking in a direction
        public Vector2 Forward
        {
            get { return new Vector2(_localtransform.m11, _localtransform.m21); }
            set
            {
                Vector2 lookPosition = localPosition + value.Normalized;
                LookAt(lookPosition);
            }
        }

        // The players and other actors location that differs from the world scene position!

        public Vector2 localPosition
        {
            get
            {
                return new Vector2(_localtransform.m13, _localtransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }

        // The world position of each scene that holds actors

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

        protected Vector2 Accelration { get => accelration; set => accelration = value; }
        public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }

        public Actor()
        {
            _position = new Vector2();
            _velocity = new Vector2();
        }
        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red)
        {
            _rayColor = Color.RED;
            _icon = icon;
            localPosition = new Vector2(x, y);
            _color = color;
            _velocity = new Vector2();
            _localtransform = new Matrix3();
        
        }

        public Actor(float x, float y, Color _raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : this(x, y, icon, color)
        {
            _rayColor = Color.BLUE;
            _localtransform = new Matrix3();
            localPosition = new Vector2(x, y);
            
        }

        // Adds a child to a parent ogbject as well as set the object as a parent of the intended child

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

        // Removes a child from the parent as well as sets the objects parent status to null
        public bool RemoveChild(Actor Child)
        {
            bool ChildRemoved = false;
            if (Child == null)
                return false;

            Actor[] temparray = new Actor[_children.Length - 1];
            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (Child != _children[i])
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

        /// <summary>
        /// The three functions here set any actor's translation, rotation, and scaler using
        /// a different matrix for each operation. The last function muliplies all together and
        /// combines all of the transformations then returns the new value.

        /// </summary>
        /// <param name="position"></param>
        public void SetTranslate(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotate = Matrix3.CreateRotation(radians);

        }

        public void Rotate(float radians)
        {
            _rotate *= Matrix3.CreateRotation(radians);
        }

        // Gets the player direction they are looking at and calculates if an enemy is in the angled area
        public void LookAt(Vector2 position)
        {
            Vector2 direction = (position - localPosition).Normalized;

            float dotprod = Vector2.DotProduct(Forward, direction);

            if (Math.Abs(dotprod) > 1)
                return;

            float angle = (float)Math.Acos(dotprod);

            Vector2 perp = new Vector2(direction.Y, -direction.X);

            float perpdot = Vector2.DotProduct(perp, Forward);

            if (perpdot != 0)
                angle *= -perpdot / Math.Abs(perpdot);

            Rotate(angle);
        }

        //Checks to see if actor is colliding with the player, another actor, or an object that has a collision
        //public bool CheckCollision(Actor other)
        //{
        //    if (this._collideradius + other._collideradius <)
        //    {
        //        OnCollision(other);
        //        return true;
        //    }
        //    return false;
        //}

        //This function is the action the collision takes once an actor collides with another object
        public virtual void OnCollision(Actor other)
        {
            
                SetScale(20, 20);
            
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        /// <summary>
        /// Updates transform function to combine a rotation, translation, and a scaler for the
        /// matrix.
        /// </summary>
        public void UpdateTransform()
        {
            _localtransform = _translation * _rotate * _scale;
        }



        //Updates player direction to be facing in a certain direction
        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;
        }

       

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            UpdateFacing();
           

            Velocity += Accelration;

            if (Velocity.Magnitude > MaxSpeed)
            {
                Velocity = Velocity.Normalized * MaxSpeed;
            }

            localPosition += _velocity * deltaTime;

        }

        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_localtransform);

            Raylib.DrawLine(
                (int)(WorldPosition.X * 32),
                (int)(WorldPosition.Y * 32),
                (int)((WorldPosition.X + Forward.X) * 32),
                (int)((WorldPosition.Y + Forward.Y) * 32),
                Color.RED
                );

            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {

                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
                Console.Write(_icon);
            }

            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }
    }
}