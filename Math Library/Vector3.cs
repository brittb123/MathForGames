﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
   public class Vector3
   {
        private float _x;
        private float _y;
        private float _z;

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

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }

        }
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        // Adds three vectors together to return a new vector of the combination!
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            float x = lhs.X + rhs.X;
            float y = lhs.Y + rhs.Y;
            float z = lhs.Z + rhs.Z;

            return new Vector3(x, y, z);
        }

        // Divides the vector by the magnitude to normalize and set the magnitude to 1
        public static Vector3 Normalize(Vector3 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector3();

           return vector / vector.Magnitude;
        }

        // A function that gets the dot product of two vectors
        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        // Allows the - operator to subtract two vectors and return a new vector
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        // Overloads the * operator that multiplies the vector by a scalar
        public static Vector3 operator *(Vector3 lhs, float scaler)
        {
            return new Vector3(lhs.X * scaler, lhs.Y * scaler, lhs.Z * scaler);
        }

        // Overloads the * operator that multiplies the vector by a scalar
        public static Vector3 operator *(float scaler, Vector3 lhs)
        {
            return new Vector3(lhs.X * scaler, lhs.Y * scaler, lhs.Z * scaler);
        }

        // Overloads the / operator and divides the vector by the scalar 
        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }

        // Performs the cross product of two vectors returning a new vector of product
        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.Y * rhs.Z - lhs.Z * rhs.Y, lhs.Z * rhs.X - lhs.X * rhs.Z, lhs.X * rhs.Y - lhs.Y * rhs.X);
        }



    }

}
