using System;

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

        //Gets the magnitude and makes it easily obtainable!
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y); 
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

        public Vector2 Normalized
        {
            get
            {
                return Normalize(this);
            }

        }
        

        //Overloads operator for adding to vectors together.

        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        
        //Overloads the operator + to add both x's and y's
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            float x = lhs.X + rhs.X;
            float y = lhs.Y + rhs.Y;

            return new Vector2(x, y);


        }

        // Divides the vector by its magnitude and normalizes the vector
        public static Vector2 Normalize(Vector2 vector2)
        {
            if (vector2.Magnitude == 0)
                return new Vector2();

            return vector2 / vector2.Magnitude;
        }

        // Allows the - operator to subtract two vectors and return a new vector
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        // Overloads the * operator that multiplies the vector by a scalar
        public static Vector2 operator *(Vector2 lhs, float scaler)
        {
            return new Vector2(lhs.X * scaler, lhs.Y * scaler);
        }

        // Overloads the / operator and divides the vector by the scalar 
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X / scalar, lhs.Y / scalar);
        }

        // Gets the Magnitude of a vector
        public float GetMagnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
    }
}
