/*
Copyright (c) 2006 - 2008 The Open Toolkit library.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenToolkit.Mathematics
{
    /// <summary>
    /// Represents a 3D vector using three double-precision floating-point numbers.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3d : IEquatable<Vector3d>
    {
        /// <summary>
        /// The X component of the Vector3.
        /// </summary>
        public double X;

        /// <summary>
        /// The Y component of the Vector3.
        /// </summary>
        public double Y;

        /// <summary>
        /// The Z component of the Vector3.
        /// </summary>
        public double Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3d(double value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector3.</param>
        /// <param name="y">The y component of the Vector3.</param>
        /// <param name="z">The z component of the Vector3.</param>
        public Vector3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector3d(Vector2d v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector3d(Vector3d v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector3d(Vector4d v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        /// <param name="index">The index of the component from the Vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 2.</exception>
        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return X;
                }

                if (index == 1)
                {
                    return Y;
                }

                if (index == 2)
                {
                    return Z;
                }

                throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
            }

            set
            {
                if (index == 0)
                {
                    X = value;
                }
                else if (index == 1)
                {
                    Y = value;
                }
                else if (index == 2)
                {
                    Z = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
                }
            }
        }

        /// <summary>
        /// Gets the length (magnitude) of the vector.
        /// </summary>
        /// <see cref="LengthFast"/>
        /// <seealso cref="LengthSquared"/>
        public double Length => Math.Sqrt((X * X) + (Y * Y) + (Z * Z));

        /// <summary>
        /// Gets an approximation of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property uses an approximation of the square root function to calculate vector magnitude, with
        /// an upper error bound of 0.001.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthSquared"/>
        public double LengthFast => 1.0 / MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z));

        /// <summary>
        /// Gets the square of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
        /// for comparisons.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthFast"/>
        public double LengthSquared => (X * X) + (Y * Y) + (Z * Z);

        /// <summary>
        /// Returns a copy of the Vector3d scaled to unit length.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public Vector3d Normalized()
        {
            var v = this;
            v.Normalize();
            return v;
        }

        /// <summary>
        /// Scales the Vector3d to unit length.
        /// </summary>
        public void Normalize()
        {
            var scale = 1.0 / Length;
            X *= scale;
            Y *= scale;
            Z *= scale;
        }

        /// <summary>
        /// Scales the Vector3d to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            var scale = MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z));
            X *= scale;
            Y *= scale;
            Z *= scale;
        }

        /// <summary>
        /// Defines a unit-length Vector3d that points towards the X-axis.
        /// </summary>
        public static readonly Vector3d UnitX = new Vector3d(1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector3d that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3d UnitY = new Vector3d(0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector3d that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3d UnitZ = new Vector3d(0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector3.
        /// </summary>
        public static readonly Vector3d Zero = new Vector3d(0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector3d One = new Vector3d(1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector3d struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector3d>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector3d Add(Vector3d a, Vector3d b)
        {
            Add(ref a, ref b, out a);
            return a;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <param name="result">Result of operation.</param>
        public static void Add(ref Vector3d a, ref Vector3d b, out Vector3d result)
        {
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
            result.Z = a.Z + b.Z;
        }

        /// <summary>
        /// Subtract one Vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>Result of subtraction.</returns>
        [Pure]
        public static Vector3d Subtract(Vector3d a, Vector3d b)
        {
            Subtract(ref a, ref b, out a);
            return a;
        }

        /// <summary>
        /// Subtract one Vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">Result of subtraction.</param>
        public static void Subtract(ref Vector3d a, ref Vector3d b, out Vector3d result)
        {
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
            result.Z = a.Z - b.Z;
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3d Multiply(Vector3d vector, double scale)
        {
            Multiply(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector3d vector, double scale, out Vector3d result)
        {
            result.X = vector.X * scale;
            result.Y = vector.Y * scale;
            result.Z = vector.Z * scale;
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3d Multiply(Vector3d vector, Vector3d scale)
        {
            Multiply(ref vector, ref scale, out vector);
            return vector;
        }

        /// <summary>
        /// Multiplies a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
        {
            result.X = vector.X * scale.X;
            result.Y = vector.Y * scale.Y;
            result.Z = vector.Z * scale.Z;
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3d Divide(Vector3d vector, double scale)
        {
            Divide(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector3d vector, double scale, out Vector3d result)
        {
            result.X = vector.X / scale;
            result.Y = vector.Y / scale;
            result.Z = vector.Z / scale;
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3d Divide(Vector3d vector, Vector3d scale)
        {
            Divide(ref vector, ref scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divide a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
        {
            result.X = vector.X / scale.X;
            result.Y = vector.Y / scale.Y;
            result.Z = vector.Z / scale.Z;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector3d ComponentMin(Vector3d a, Vector3d b)
        {
            a.X = a.X < b.X ? a.X : b.X;
            a.Y = a.Y < b.Y ? a.Y : b.Y;
            a.Z = a.Z < b.Z ? a.Z : b.Z;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector3d a, ref Vector3d b, out Vector3d result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
            result.Z = a.Z < b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector3d ComponentMax(Vector3d a, Vector3d b)
        {
            a.X = a.X > b.X ? a.X : b.X;
            a.Y = a.Y > b.Y ? a.Y : b.Y;
            a.Z = a.Z > b.Z ? a.Z : b.Z;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector3d a, ref Vector3d b, out Vector3d result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Returns the Vector3d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector3d.</returns>
        [Pure]
        public static Vector3d MagnitudeMin(Vector3d left, Vector3d right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise minimum.</param>
        public static void MagnitudeMin(ref Vector3d left, ref Vector3d right, out Vector3d result)
        {
            result = left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector3d.</returns>
        [Pure]
        public static Vector3d MagnitudeMax(Vector3d left, Vector3d right)
        {
            return left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3d with the maximum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise maximum.</param>
        public static void MagnitudeMax(ref Vector3d left, ref Vector3d right, out Vector3d result)
        {
            result = left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <returns>The clamped vector.</returns>
        [Pure]
        public static Vector3d Clamp(Vector3d vec, Vector3d min, Vector3d max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            vec.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <param name="result">The clamped vector.</param>
        public static void Clamp(ref Vector3d vec, ref Vector3d min, ref Vector3d max, out Vector3d result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
        }

        /// <summary>
        /// Compute the euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The distance.</returns>
        [Pure]
        public static double Distance(Vector3d vec1, Vector3d vec2)
        {
            Distance(ref vec1, ref vec2, out double result);
            return result;
        }

        /// <summary>
        /// Compute the euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <param name="result">The distance.</param>
        public static void Distance(ref Vector3d vec1, ref Vector3d vec2, out double result)
        {
            result = Math.Sqrt(((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                               ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)));
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The squared distance.</returns>
        [Pure]
        public static double DistanceSquared(Vector3d vec1, Vector3d vec2)
        {
            DistanceSquared(ref vec1, ref vec2, out double result);
            return result;
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <param name="result">The squared distance.</param>
        public static void DistanceSquared(ref Vector3d vec1, ref Vector3d vec2, out double result)
        {
            result = ((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                     ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z));
        }

        /// <summary>
        /// Scale a vector to unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Vector3d Normalize(Vector3d vec)
        {
            var scale = 1.0 / vec.Length;
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <param name="result">The normalized vector.</param>
        public static void Normalize(ref Vector3d vec, out Vector3d result)
        {
            var scale = 1.0 / vec.Length;
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
        }

        /// <summary>
        /// Scale a vector to approximately unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Vector3d NormalizeFast(Vector3d vec)
        {
            var scale = MathHelper.InverseSqrtFast((vec.X * vec.X) + (vec.Y * vec.Y) + (vec.Z * vec.Z));
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to approximately unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <param name="result">The normalized vector.</param>
        public static void NormalizeFast(ref Vector3d vec, out Vector3d result)
        {
            var scale = MathHelper.InverseSqrtFast((vec.X * vec.X) + (vec.Y * vec.Y) + (vec.Z * vec.Z));
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>The dot product of the two inputs.</returns>
        [Pure]
        public static double Dot(Vector3d left, Vector3d right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <param name="result">The dot product of the two inputs.</param>
        public static void Dot(ref Vector3d left, ref Vector3d right, out double result)
        {
            result = (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);
        }

        /// <summary>
        /// Caclulate the cross (vector) product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>The cross product of the two inputs.</returns>
        [Pure]
        public static Vector3d Cross(Vector3d left, Vector3d right)
        {
            Cross(ref left, ref right, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Caclulate the cross (vector) product of two vectors.
        /// </summary>
        /// <remarks>
        /// It is incorrect to call this method passing the same variable for
        ///  <paramref name="result"/> as for <paramref name="left"/> or
        ///  <paramref name="right"/>.
        /// </remarks>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <param name="result">The cross product of the two inputs.</param>
        public static void Cross(ref Vector3d left, ref Vector3d right, out Vector3d result)
        {
            result.X = (left.Y * right.Z) - (left.Z * right.Y);
            result.Y = (left.Z * right.X) - (left.X * right.Z);
            result.Z = (left.X * right.Y) - (left.Y * right.X);
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise.</returns>
        [Pure]
        public static Vector3d Lerp(Vector3d a, Vector3d b, double blend)
        {
            a.X = (blend * (b.X - a.X)) + a.X;
            a.Y = (blend * (b.Y - a.Y)) + a.Y;
            a.Z = (blend * (b.Z - a.Z)) + a.Z;
            return a;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise.</param>
        public static void Lerp(ref Vector3d a, ref Vector3d b, double blend, out Vector3d result)
        {
            result.X = (blend * (b.X - a.X)) + a.X;
            result.Y = (blend * (b.Y - a.Y)) + a.Y;
            result.Z = (blend * (b.Z - a.Z)) + a.Z;
        }

        /// <summary>
        /// Interpolate 3 Vectors using Barycentric coordinates.
        /// </summary>
        /// <param name="a">First input Vector.</param>
        /// <param name="b">Second input Vector.</param>
        /// <param name="c">Third input Vector.</param>
        /// <param name="u">First Barycentric Coordinate.</param>
        /// <param name="v">Second Barycentric Coordinate.</param>
        /// <returns>a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise.</returns>
        [Pure]
        public static Vector3d BaryCentric(Vector3d a, Vector3d b, Vector3d c, double u, double v)
        {
            return a + (u * (b - a)) + (v * (c - a));
        }

        /// <summary>
        /// Interpolate 3 Vectors using Barycentric coordinates.
        /// </summary>
        /// <param name="a">First input Vector.</param>
        /// <param name="b">Second input Vector.</param>
        /// <param name="c">Third input Vector.</param>
        /// <param name="u">First Barycentric Coordinate.</param>
        /// <param name="v">Second Barycentric Coordinate.</param>
        /// <param name="result">
        /// Output Vector. a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c
        /// otherwise.
        /// </param>
        [Pure]
        public static void BaryCentric
        (
            ref Vector3d a,
            ref Vector3d b,
            ref Vector3d c,
            double u,
            double v,
            out Vector3d result
        )
        {
            result = a; // copy

            var temp = b; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, u, out temp);
            Add(ref result, ref temp, out result);

            temp = c; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, v, out temp);
            Add(ref result, ref temp, out result);
        }

        /// <summary>
        /// Transform a direction vector by the given Matrix.
        /// Assumes the matrix has a bottom row of (0,0,0,1), that is the translation part is ignored.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3d TransformVector(Vector3d vec, Matrix4d mat)
        {
            TransformVector(ref vec, ref mat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transform a direction vector by the given Matrix.
        /// Assumes the matrix has a bottom row of (0,0,0,1), that is the translation part is ignored.
        /// </summary>
        /// <remarks>
        /// It is incorrect to call this method passing the same variable for
        ///  <paramref name="result"/> as for <paramref name="vec"/>.
        /// </remarks>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void TransformVector(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
        {
            result.X = (vec.X * mat.Row0.X) +
                       (vec.Y * mat.Row1.X) +
                       (vec.Z * mat.Row2.X);

            result.Y = (vec.X * mat.Row0.Y) +
                       (vec.Y * mat.Row1.Y) +
                       (vec.Z * mat.Row2.Y);

            result.Z = (vec.X * mat.Row0.Z) +
                       (vec.Y * mat.Row1.Z) +
                       (vec.Z * mat.Row2.Z);
        }

        /// <summary>
        /// Transform a Normal by the given Matrix.
        /// </summary>
        /// <remarks>
        /// This calculates the inverse of the given matrix, use TransformNormalInverse if you
        /// already have the inverse to avoid this extra calculation.
        /// </remarks>
        /// <param name="norm">The normal to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed normal.</returns>
        [Pure]
        public static Vector3d TransformNormal(Vector3d norm, Matrix4d mat)
        {
            mat.Invert();
            return TransformNormalInverse(norm, mat);
        }

        /// <summary>
        /// Transform a Normal by the given Matrix.
        /// </summary>
        /// <remarks>
        /// This calculates the inverse of the given matrix, use TransformNormalInverse if you
        /// already have the inverse to avoid this extra calculation.
        /// </remarks>
        /// <param name="norm">The normal to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed normal.</param>
        public static void TransformNormal(ref Vector3d norm, ref Matrix4d mat, out Vector3d result)
        {
            var inverse = Matrix4d.Invert(mat);
            TransformNormalInverse(ref norm, ref inverse, out result);
        }

        /// <summary>
        /// Transform a Normal by the (transpose of the) given Matrix.
        /// </summary>
        /// <remarks>
        /// This version doesn't calculate the inverse matrix.
        /// Use this version if you already have the inverse of the desired transform to hand.
        /// </remarks>
        /// <param name="norm">The normal to transform.</param>
        /// <param name="invMat">The inverse of the desired transformation.</param>
        /// <returns>The transformed normal.</returns>
        [Pure]
        public static Vector3d TransformNormalInverse(Vector3d norm, Matrix4d invMat)
        {
            TransformNormalInverse(ref norm, ref invMat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transform a Normal by the (transpose of the) given Matrix.
        /// </summary>
        /// <remarks>
        /// This version doesn't calculate the inverse matrix.
        /// Use this version if you already have the inverse of the desired transform to hand.
        /// </remarks>
        /// <param name="norm">The normal to transform.</param>
        /// <param name="invMat">The inverse of the desired transformation.</param>
        /// <param name="result">The transformed normal.</param>
        public static void TransformNormalInverse(ref Vector3d norm, ref Matrix4d invMat, out Vector3d result)
        {
            result.X = (norm.X * invMat.Row0.X) +
                       (norm.Y * invMat.Row0.Y) +
                       (norm.Z * invMat.Row0.Z);

            result.Y = (norm.X * invMat.Row1.X) +
                       (norm.Y * invMat.Row1.Y) +
                       (norm.Z * invMat.Row1.Z);

            result.Z = (norm.X * invMat.Row2.X) +
                       (norm.Y * invMat.Row2.Y) +
                       (norm.Z * invMat.Row2.Z);
        }

        /// <summary>
        /// Transform a Position by the given Matrix.
        /// </summary>
        /// <param name="pos">The position to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed position.</returns>
        [Pure]
        public static Vector3d TransformPosition(Vector3d pos, Matrix4d mat)
        {
            TransformPosition(ref pos, ref mat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transform a Position by the given Matrix.
        /// </summary>
        /// <param name="pos">The position to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed position.</param>
        public static void TransformPosition(ref Vector3d pos, ref Matrix4d mat, out Vector3d result)
        {
            result.X = (pos.X * mat.Row0.X) +
                       (pos.Y * mat.Row1.X) +
                       (pos.Z * mat.Row2.X) +
                       mat.Row3.X;

            result.Y = (pos.X * mat.Row0.Y) +
                       (pos.Y * mat.Row1.Y) +
                       (pos.Z * mat.Row2.Y) +
                       mat.Row3.Y;

            result.Z = (pos.X * mat.Row0.Z) +
                       (pos.Y * mat.Row1.Z) +
                       (pos.Z * mat.Row2.Z) +
                       mat.Row3.Z;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3d Transform(Vector3d vec, Matrix4d mat)
        {
            Transform(ref vec, ref mat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <remarks>
        /// It is incorrect to call this method passing the same variable for
        ///  <paramref name="result"/> as for <paramref name="vec"/> or
        ///  <paramref name="result"/>.
        /// </remarks>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
        {
            var v4 = new Vector4d(vec.X, vec.Y, vec.Z, 1.0);
            Vector4d.Transform(ref v4, ref mat, out v4);
            result.X = v4.X;
            result.Y = v4.Y;
            result.Z = v4.Z;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        [Pure]
        public static Vector3d Transform(Vector3d vec, Quaterniond quat)
        {
            Transform(ref vec, ref quat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector3d vec, ref Quaterniond quat, out Vector3d result)
        {
            // Since vec.W == 0, we can optimize quat * vec * quat^-1 as follows:
            // vec + 2.0 * cross(quat.xyz, cross(quat.xyz, vec) + quat.w * vec)
            Vector3d xyz = quat.Xyz;
            Cross(ref xyz, ref vec, out Vector3d temp);
            Multiply(ref vec, quat.W, out Vector3d temp2);
            Add(ref temp, ref temp2, out temp);
            Cross(ref xyz, ref temp, out temp2);
            Multiply(ref temp2, 2f, out temp2);
            Add(ref vec, ref temp2, out result);
        }

        /// <summary>
        /// Transform a Vector3d by the given Matrix, and project the resulting Vector4 back to a Vector3.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3d TransformPerspective(Vector3d vec, Matrix4d mat)
        {
            TransformPerspective(ref vec, ref mat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Transform a Vector3d by the given Matrix, and project the resulting Vector4d back to a Vector3d.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void TransformPerspective(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
        {
            var v = new Vector4d(vec.X, vec.Y, vec.Z, 1);
            Vector4d.Transform(ref v, ref mat, out v);
            result.X = v.X / v.W;
            result.Y = v.Y / v.W;
            result.Z = v.Z / v.W;
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <returns>Angle (in radians) between the vectors.</returns>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        [Pure]
        public static double CalculateAngle(Vector3d first, Vector3d second)
        {
            CalculateAngle(ref first, ref second, out double result);
            return result;
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <param name="result">Angle (in radians) between the vectors.</param>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public static void CalculateAngle(ref Vector3d first, ref Vector3d second, out double result)
        {
            Dot(ref first, ref second, out double temp);
            result = Math.Acos(MathHelper.Clamp(temp / (first.Length * second.Length), -1.0, 1.0));
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Xy
        {
            get => Unsafe.As<Vector3d, Vector2d>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Xz
        {
            get => new Vector2d(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Yx
        {
            get => new Vector2d(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Yz
        {
            get => new Vector2d(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Zx
        {
            get => new Vector2d(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2d"/> with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Zy
        {
            get => new Vector2d(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3d"/> with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xzy
        {
            get => new Vector3d(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3d"/> with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Yxz
        {
            get => new Vector3d(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3d"/> with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Yzx
        {
            get => new Vector3d(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3d"/> with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zxy
        {
            get => new Vector3d(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3d"/> with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zyx
        {
            get => new Vector3d(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        #region Coords: x, y, z
        [XmlIgnore]
        public double x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public double y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public double z
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2d xx
        {
            get => new Vector2d(X, X);
        }

        [XmlIgnore]
        public Vector2d xy
        {
            get => new Vector2d(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d xz
        {
            get => new Vector2d(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d yx
        {
            get => new Vector2d(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d yy
        {
            get => new Vector2d(Y, Y);
        }

        [XmlIgnore]
        public Vector2d yz
        {
            get => new Vector2d(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d zx
        {
            get => new Vector2d(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d zy
        {
            get => new Vector2d(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d zz
        {
            get => new Vector2d(Z, Z);
        }

        [XmlIgnore]
        public Vector3d xxx
        {
            get => new Vector3d(X, X, X);
        }

        [XmlIgnore]
        public Vector3d xxy
        {
            get => new Vector3d(X, X, Y);
        }

        [XmlIgnore]
        public Vector3d xxz
        {
            get => new Vector3d(X, X, Z);
        }

        [XmlIgnore]
        public Vector3d xyx
        {
            get => new Vector3d(X, Y, X);
        }

        [XmlIgnore]
        public Vector3d xyy
        {
            get => new Vector3d(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3d xyz
        {
            get => new Vector3d(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d xzx
        {
            get => new Vector3d(X, Z, X);
        }

        [XmlIgnore]
        public Vector3d xzy
        {
            get => new Vector3d(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d xzz
        {
            get => new Vector3d(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3d yxx
        {
            get => new Vector3d(Y, X, X);
        }

        [XmlIgnore]
        public Vector3d yxy
        {
            get => new Vector3d(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3d yxz
        {
            get => new Vector3d(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d yyx
        {
            get => new Vector3d(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3d yyy
        {
            get => new Vector3d(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3d yyz
        {
            get => new Vector3d(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3d yzx
        {
            get => new Vector3d(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d yzy
        {
            get => new Vector3d(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3d yzz
        {
            get => new Vector3d(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3d zxx
        {
            get => new Vector3d(Z, X, X);
        }

        [XmlIgnore]
        public Vector3d zxy
        {
            get => new Vector3d(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d zxz
        {
            get => new Vector3d(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3d zyx
        {
            get => new Vector3d(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d zyy
        {
            get => new Vector3d(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3d zyz
        {
            get => new Vector3d(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3d zzx
        {
            get => new Vector3d(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3d zzy
        {
            get => new Vector3d(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3d zzz
        {
            get => new Vector3d(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d xxxx
        {
            get => new Vector4d(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4d xxxy
        {
            get => new Vector4d(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d xxxz
        {
            get => new Vector4d(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d xxyx
        {
            get => new Vector4d(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d xxyy
        {
            get => new Vector4d(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d xxyz
        {
            get => new Vector4d(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d xxzx
        {
            get => new Vector4d(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d xxzy
        {
            get => new Vector4d(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d xxzz
        {
            get => new Vector4d(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d xyxx
        {
            get => new Vector4d(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d xyxy
        {
            get => new Vector4d(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d xyxz
        {
            get => new Vector4d(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d xyyx
        {
            get => new Vector4d(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d xyyy
        {
            get => new Vector4d(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d xyyz
        {
            get => new Vector4d(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d xyzx
        {
            get => new Vector4d(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d xyzy
        {
            get => new Vector4d(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d xyzz
        {
            get => new Vector4d(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d xzxx
        {
            get => new Vector4d(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d xzxy
        {
            get => new Vector4d(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d xzxz
        {
            get => new Vector4d(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d xzyx
        {
            get => new Vector4d(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d xzyy
        {
            get => new Vector4d(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d xzyz
        {
            get => new Vector4d(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d xzzx
        {
            get => new Vector4d(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d xzzy
        {
            get => new Vector4d(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d xzzz
        {
            get => new Vector4d(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d yxxx
        {
            get => new Vector4d(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4d yxxy
        {
            get => new Vector4d(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d yxxz
        {
            get => new Vector4d(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d yxyx
        {
            get => new Vector4d(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d yxyy
        {
            get => new Vector4d(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d yxyz
        {
            get => new Vector4d(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d yxzx
        {
            get => new Vector4d(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d yxzy
        {
            get => new Vector4d(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d yxzz
        {
            get => new Vector4d(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d yyxx
        {
            get => new Vector4d(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d yyxy
        {
            get => new Vector4d(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d yyxz
        {
            get => new Vector4d(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d yyyx
        {
            get => new Vector4d(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d yyyy
        {
            get => new Vector4d(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d yyyz
        {
            get => new Vector4d(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d yyzx
        {
            get => new Vector4d(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d yyzy
        {
            get => new Vector4d(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d yyzz
        {
            get => new Vector4d(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d yzxx
        {
            get => new Vector4d(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d yzxy
        {
            get => new Vector4d(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d yzxz
        {
            get => new Vector4d(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d yzyx
        {
            get => new Vector4d(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d yzyy
        {
            get => new Vector4d(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d yzyz
        {
            get => new Vector4d(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d yzzx
        {
            get => new Vector4d(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d yzzy
        {
            get => new Vector4d(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d yzzz
        {
            get => new Vector4d(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d zxxx
        {
            get => new Vector4d(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4d zxxy
        {
            get => new Vector4d(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d zxxz
        {
            get => new Vector4d(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d zxyx
        {
            get => new Vector4d(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d zxyy
        {
            get => new Vector4d(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d zxyz
        {
            get => new Vector4d(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d zxzx
        {
            get => new Vector4d(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d zxzy
        {
            get => new Vector4d(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d zxzz
        {
            get => new Vector4d(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d zyxx
        {
            get => new Vector4d(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d zyxy
        {
            get => new Vector4d(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d zyxz
        {
            get => new Vector4d(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d zyyx
        {
            get => new Vector4d(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d zyyy
        {
            get => new Vector4d(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d zyyz
        {
            get => new Vector4d(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d zyzx
        {
            get => new Vector4d(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d zyzy
        {
            get => new Vector4d(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d zyzz
        {
            get => new Vector4d(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d zzxx
        {
            get => new Vector4d(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d zzxy
        {
            get => new Vector4d(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d zzxz
        {
            get => new Vector4d(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d zzyx
        {
            get => new Vector4d(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d zzyy
        {
            get => new Vector4d(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d zzyz
        {
            get => new Vector4d(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d zzzx
        {
            get => new Vector4d(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d zzzy
        {
            get => new Vector4d(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d zzzz
        {
            get => new Vector4d(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: r, g, b
        [XmlIgnore]
        public double r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public double g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public double b
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2d rr
        {
            get => new Vector2d(X, X);
        }

        [XmlIgnore]
        public Vector2d rg
        {
            get => new Vector2d(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d rb
        {
            get => new Vector2d(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d gr
        {
            get => new Vector2d(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d gg
        {
            get => new Vector2d(Y, Y);
        }

        [XmlIgnore]
        public Vector2d gb
        {
            get => new Vector2d(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d br
        {
            get => new Vector2d(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d bg
        {
            get => new Vector2d(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d bb
        {
            get => new Vector2d(Z, Z);
        }

        [XmlIgnore]
        public Vector3d rrr
        {
            get => new Vector3d(X, X, X);
        }

        [XmlIgnore]
        public Vector3d rrg
        {
            get => new Vector3d(X, X, Y);
        }

        [XmlIgnore]
        public Vector3d rrb
        {
            get => new Vector3d(X, X, Z);
        }

        [XmlIgnore]
        public Vector3d rgr
        {
            get => new Vector3d(X, Y, X);
        }

        [XmlIgnore]
        public Vector3d rgg
        {
            get => new Vector3d(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3d rgb
        {
            get => new Vector3d(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d rbr
        {
            get => new Vector3d(X, Z, X);
        }

        [XmlIgnore]
        public Vector3d rbg
        {
            get => new Vector3d(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d rbb
        {
            get => new Vector3d(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3d grr
        {
            get => new Vector3d(Y, X, X);
        }

        [XmlIgnore]
        public Vector3d grg
        {
            get => new Vector3d(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3d grb
        {
            get => new Vector3d(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d ggr
        {
            get => new Vector3d(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3d ggg
        {
            get => new Vector3d(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3d ggb
        {
            get => new Vector3d(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3d gbr
        {
            get => new Vector3d(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d gbg
        {
            get => new Vector3d(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3d gbb
        {
            get => new Vector3d(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3d brr
        {
            get => new Vector3d(Z, X, X);
        }

        [XmlIgnore]
        public Vector3d brg
        {
            get => new Vector3d(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d brb
        {
            get => new Vector3d(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3d bgr
        {
            get => new Vector3d(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d bgg
        {
            get => new Vector3d(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3d bgb
        {
            get => new Vector3d(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3d bbr
        {
            get => new Vector3d(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3d bbg
        {
            get => new Vector3d(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3d bbb
        {
            get => new Vector3d(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d rrrr
        {
            get => new Vector4d(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4d rrrg
        {
            get => new Vector4d(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d rrrb
        {
            get => new Vector4d(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d rrgr
        {
            get => new Vector4d(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d rrgg
        {
            get => new Vector4d(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d rrgb
        {
            get => new Vector4d(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d rrbr
        {
            get => new Vector4d(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d rrbg
        {
            get => new Vector4d(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d rrbb
        {
            get => new Vector4d(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d rgrr
        {
            get => new Vector4d(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d rgrg
        {
            get => new Vector4d(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d rgrb
        {
            get => new Vector4d(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d rggr
        {
            get => new Vector4d(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d rggg
        {
            get => new Vector4d(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d rggb
        {
            get => new Vector4d(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d rgbr
        {
            get => new Vector4d(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d rgbg
        {
            get => new Vector4d(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d rgbb
        {
            get => new Vector4d(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d rbrr
        {
            get => new Vector4d(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d rbrg
        {
            get => new Vector4d(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d rbrb
        {
            get => new Vector4d(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d rbgr
        {
            get => new Vector4d(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d rbgg
        {
            get => new Vector4d(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d rbgb
        {
            get => new Vector4d(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d rbbr
        {
            get => new Vector4d(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d rbbg
        {
            get => new Vector4d(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d rbbb
        {
            get => new Vector4d(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d grrr
        {
            get => new Vector4d(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4d grrg
        {
            get => new Vector4d(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d grrb
        {
            get => new Vector4d(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d grgr
        {
            get => new Vector4d(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d grgg
        {
            get => new Vector4d(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d grgb
        {
            get => new Vector4d(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d grbr
        {
            get => new Vector4d(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d grbg
        {
            get => new Vector4d(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d grbb
        {
            get => new Vector4d(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ggrr
        {
            get => new Vector4d(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d ggrg
        {
            get => new Vector4d(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d ggrb
        {
            get => new Vector4d(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d gggr
        {
            get => new Vector4d(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d gggg
        {
            get => new Vector4d(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d gggb
        {
            get => new Vector4d(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ggbr
        {
            get => new Vector4d(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d ggbg
        {
            get => new Vector4d(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d ggbb
        {
            get => new Vector4d(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d gbrr
        {
            get => new Vector4d(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d gbrg
        {
            get => new Vector4d(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d gbrb
        {
            get => new Vector4d(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d gbgr
        {
            get => new Vector4d(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d gbgg
        {
            get => new Vector4d(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d gbgb
        {
            get => new Vector4d(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d gbbr
        {
            get => new Vector4d(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d gbbg
        {
            get => new Vector4d(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d gbbb
        {
            get => new Vector4d(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d brrr
        {
            get => new Vector4d(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4d brrg
        {
            get => new Vector4d(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d brrb
        {
            get => new Vector4d(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d brgr
        {
            get => new Vector4d(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d brgg
        {
            get => new Vector4d(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d brgb
        {
            get => new Vector4d(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d brbr
        {
            get => new Vector4d(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d brbg
        {
            get => new Vector4d(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d brbb
        {
            get => new Vector4d(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d bgrr
        {
            get => new Vector4d(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d bgrg
        {
            get => new Vector4d(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d bgrb
        {
            get => new Vector4d(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d bggr
        {
            get => new Vector4d(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d bggg
        {
            get => new Vector4d(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d bggb
        {
            get => new Vector4d(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d bgbr
        {
            get => new Vector4d(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d bgbg
        {
            get => new Vector4d(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d bgbb
        {
            get => new Vector4d(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d bbrr
        {
            get => new Vector4d(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d bbrg
        {
            get => new Vector4d(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d bbrb
        {
            get => new Vector4d(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d bbgr
        {
            get => new Vector4d(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d bbgg
        {
            get => new Vector4d(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d bbgb
        {
            get => new Vector4d(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d bbbr
        {
            get => new Vector4d(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d bbbg
        {
            get => new Vector4d(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d bbbb
        {
            get => new Vector4d(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: s, t, p
        [XmlIgnore]
        public double s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public double t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public double p
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2d ss
        {
            get => new Vector2d(X, X);
        }

        [XmlIgnore]
        public Vector2d st
        {
            get => new Vector2d(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d sp
        {
            get => new Vector2d(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ts
        {
            get => new Vector2d(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d tt
        {
            get => new Vector2d(Y, Y);
        }

        [XmlIgnore]
        public Vector2d tp
        {
            get => new Vector2d(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ps
        {
            get => new Vector2d(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d pt
        {
            get => new Vector2d(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d pp
        {
            get => new Vector2d(Z, Z);
        }

        [XmlIgnore]
        public Vector3d sss
        {
            get => new Vector3d(X, X, X);
        }

        [XmlIgnore]
        public Vector3d sst
        {
            get => new Vector3d(X, X, Y);
        }

        [XmlIgnore]
        public Vector3d ssp
        {
            get => new Vector3d(X, X, Z);
        }

        [XmlIgnore]
        public Vector3d sts
        {
            get => new Vector3d(X, Y, X);
        }

        [XmlIgnore]
        public Vector3d stt
        {
            get => new Vector3d(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3d stp
        {
            get => new Vector3d(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d sps
        {
            get => new Vector3d(X, Z, X);
        }

        [XmlIgnore]
        public Vector3d spt
        {
            get => new Vector3d(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d spp
        {
            get => new Vector3d(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3d tss
        {
            get => new Vector3d(Y, X, X);
        }

        [XmlIgnore]
        public Vector3d tst
        {
            get => new Vector3d(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3d tsp
        {
            get => new Vector3d(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d tts
        {
            get => new Vector3d(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3d ttt
        {
            get => new Vector3d(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3d ttp
        {
            get => new Vector3d(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3d tps
        {
            get => new Vector3d(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d tpt
        {
            get => new Vector3d(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3d tpp
        {
            get => new Vector3d(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3d pss
        {
            get => new Vector3d(Z, X, X);
        }

        [XmlIgnore]
        public Vector3d pst
        {
            get => new Vector3d(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d psp
        {
            get => new Vector3d(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3d pts
        {
            get => new Vector3d(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d ptt
        {
            get => new Vector3d(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3d ptp
        {
            get => new Vector3d(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3d pps
        {
            get => new Vector3d(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3d ppt
        {
            get => new Vector3d(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3d ppp
        {
            get => new Vector3d(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ssss
        {
            get => new Vector4d(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4d ssst
        {
            get => new Vector4d(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d sssp
        {
            get => new Vector4d(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d ssts
        {
            get => new Vector4d(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d sstt
        {
            get => new Vector4d(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d sstp
        {
            get => new Vector4d(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ssps
        {
            get => new Vector4d(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d sspt
        {
            get => new Vector4d(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d sspp
        {
            get => new Vector4d(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d stss
        {
            get => new Vector4d(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d stst
        {
            get => new Vector4d(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d stsp
        {
            get => new Vector4d(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d stts
        {
            get => new Vector4d(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d sttt
        {
            get => new Vector4d(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d sttp
        {
            get => new Vector4d(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d stps
        {
            get => new Vector4d(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d stpt
        {
            get => new Vector4d(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d stpp
        {
            get => new Vector4d(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d spss
        {
            get => new Vector4d(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d spst
        {
            get => new Vector4d(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d spsp
        {
            get => new Vector4d(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d spts
        {
            get => new Vector4d(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d sptt
        {
            get => new Vector4d(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d sptp
        {
            get => new Vector4d(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d spps
        {
            get => new Vector4d(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d sppt
        {
            get => new Vector4d(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d sppp
        {
            get => new Vector4d(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d tsss
        {
            get => new Vector4d(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4d tsst
        {
            get => new Vector4d(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d tssp
        {
            get => new Vector4d(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d tsts
        {
            get => new Vector4d(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d tstt
        {
            get => new Vector4d(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d tstp
        {
            get => new Vector4d(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d tsps
        {
            get => new Vector4d(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d tspt
        {
            get => new Vector4d(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d tspp
        {
            get => new Vector4d(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ttss
        {
            get => new Vector4d(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d ttst
        {
            get => new Vector4d(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d ttsp
        {
            get => new Vector4d(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d ttts
        {
            get => new Vector4d(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d tttt
        {
            get => new Vector4d(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d tttp
        {
            get => new Vector4d(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ttps
        {
            get => new Vector4d(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d ttpt
        {
            get => new Vector4d(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d ttpp
        {
            get => new Vector4d(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d tpss
        {
            get => new Vector4d(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d tpst
        {
            get => new Vector4d(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d tpsp
        {
            get => new Vector4d(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d tpts
        {
            get => new Vector4d(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d tptt
        {
            get => new Vector4d(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d tptp
        {
            get => new Vector4d(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d tpps
        {
            get => new Vector4d(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d tppt
        {
            get => new Vector4d(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d tppp
        {
            get => new Vector4d(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d psss
        {
            get => new Vector4d(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4d psst
        {
            get => new Vector4d(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d pssp
        {
            get => new Vector4d(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d psts
        {
            get => new Vector4d(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d pstt
        {
            get => new Vector4d(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d pstp
        {
            get => new Vector4d(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4d psps
        {
            get => new Vector4d(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d pspt
        {
            get => new Vector4d(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4d pspp
        {
            get => new Vector4d(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ptss
        {
            get => new Vector4d(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d ptst
        {
            get => new Vector4d(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d ptsp
        {
            get => new Vector4d(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4d ptts
        {
            get => new Vector4d(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d pttt
        {
            get => new Vector4d(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d pttp
        {
            get => new Vector4d(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ptps
        {
            get => new Vector4d(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4d ptpt
        {
            get => new Vector4d(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d ptpp
        {
            get => new Vector4d(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ppss
        {
            get => new Vector4d(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d ppst
        {
            get => new Vector4d(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4d ppsp
        {
            get => new Vector4d(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d ppts
        {
            get => new Vector4d(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4d pptt
        {
            get => new Vector4d(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d pptp
        {
            get => new Vector4d(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ppps
        {
            get => new Vector4d(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d pppt
        {
            get => new Vector4d(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d pppp
        {
            get => new Vector4d(Z, Z, Z, Z);
        }
        #endregion

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator +(Vector3d left, Vector3d right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
            return left;
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator -(Vector3d left, Vector3d right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            return left;
        }

        /// <summary>
        /// Negates an instance.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator -(Vector3d vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator *(Vector3d vec, double scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator *(double scale, Vector3d vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Component-wise multiplication between the specified instance by a scale vector.
        /// </summary>
        /// <param name="scale">Left operand.</param>
        /// <param name="vec">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector3d operator *(Vector3d vec, Vector3d scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            return vec;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3d operator *(Quaterniond quat, Vector3d vec)
        {
            Transform(ref vec, ref quat, out Vector3d result);
            return result;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3d operator /(Vector3d vec, double scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            vec.Z /= scale;
            return vec;
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector3d left, Vector3d right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equa lright; false otherwise.</returns>
        [Pure]
        public static bool operator !=(Vector3d left, Vector3d right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts OpenTK.Vector3 to OpenTK.Vector3d.
        /// </summary>
        /// <param name="v3">The Vector3 to convert.</param>
        /// <returns>The resulting Vector3d.</returns>
        [Pure]
        public static explicit operator Vector3d(Vector3 v3)
        {
            return new Vector3d(v3.X, v3.Y, v3.Z);
        }

        /// <summary>
        /// Converts OpenTK.Vector3d to OpenTK.Vector3.
        /// </summary>
        /// <param name="v3d">The Vector3d to convert.</param>
        /// <returns>The resulting Vector3.</returns>
        [Pure]
        public static explicit operator Vector3(Vector3d v3d)
        {
            return new Vector3((float)v3d.X, (float)v3d.Y, (float)v3d.Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3d"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3d"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3d((double X, double Y, double Z) values)
        {
            return new Vector3d(values.X, values.Y, values.Z);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("({0}{3} {1}{3} {2})", X, Y, Z, ListSeparator);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3d))
            {
                return false;
            }

            return Equals((Vector3d)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector3d other)
        {
            return
                X == other.X &&
                Y == other.Y &&
                Z == other.Z;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        [Pure]
        public void Deconstruct(out double x, out double y, out double z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}