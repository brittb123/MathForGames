using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
   public class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;


        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }

        public Matrix3(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)

        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        //Operator that adds two matricies to together
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                (
                lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13,
                lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23,
                lhs.m31 + rhs.m31, lhs.m32 + lhs.m32, lhs.m33 + rhs.m33
                );
        }

        //Operator that subtracts two matrices and returns the new matrix
        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                (
                lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13,
                lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23,
                lhs.m31 - rhs.m31, lhs.m32 - lhs.m32, lhs.m33 - rhs.m33
                );
        }

        //The operator that multplies the two matrices together and returns a new matrix
        //with the newly obtained values
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                (
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,

                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,

                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
                );
        }
            
        //The entity is rotates using the matrix and rotates the object
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3(
                (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1
                 );
        }
      
        // The object is tranlated across to a specific point using this matrix
        public static Matrix3 CreateTranslation(Vector2 position)
        {
            return new Matrix3
                (
                  1, 0, position.X,
                  0, 1, position.Y,
                  0, 0, 1
                );
        }

        // An object's X and Y is scaled to a chosen number and streched or shrunk to the size
        public static Matrix3 CreateScale(Vector2 scale)
        {
            return new Matrix3
                (
                scale.X, 0, 0,
                0, scale.Y, 0,
                0, 0, 1
                );
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            float a = lhs.m11 * rhs.X + lhs.m12 * rhs.Y + lhs.m13 * rhs.Z;
            float b = lhs.m21 * rhs.X + lhs.m22 * rhs.Y + lhs.m23 * rhs.Z;
            float c = lhs.m31 * rhs.X + lhs.m32 * rhs.Y + lhs.m33 * rhs.Z;
            return new Vector3(a, b, c); 
        }
    }
    
}
