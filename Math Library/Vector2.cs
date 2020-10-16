﻿using System;

namespace Math_Library
{
    public class Vector2
    {
        private float _x;
        private float _y;

        
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }

        }
        public float Y
        {
            get
            {
                return _y;

            }
            set
            {
                _y = value;
            }
        }

      public Vector2()
        {
            _x = 0;
            _y = 0;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        //Overloads operator for adding to vectors together.
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            float x = lhs.X + rhs.X;
            float y = lhs.Y + rhs.Y;

            return new Vector2(x, y);


        }
        public static Vector2 operator *(Vector2 lhs, float scaler)
        {
            return new Vector2(lhs.X * scaler, lhs.Y * scaler);
        }
        public float GetMagnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
    }
}
