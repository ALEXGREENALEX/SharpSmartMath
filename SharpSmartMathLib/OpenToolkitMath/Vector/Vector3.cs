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
    /// Represents a 3D vector using three single-precision floating-point numbers.
    /// </summary>
    /// <remarks>
    /// The Vector3 structure is suitable for interoperation with unmanaged code requiring three consecutive floats.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>
    {
        /// <summary>
        /// The X component of the Vector3.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y component of the Vector3.
        /// </summary>
        public float Y;

        /// <summary>
        /// The Z component of the Vector3.
        /// </summary>
        public float Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector3.</param>
        /// <param name="y">The y component of the Vector3.</param>
        /// <param name="z">The z component of the Vector3.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="v">The Vector2 to copy components from.</param>
        public Vector3(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="v">The Vector3 to copy components from.</param>
        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="v">The Vector4 to copy components from.</param>
        public Vector3(Vector4 v)
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
        public float this[int index]
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
        public float Length => (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));

        /// <summary>
        /// Gets an approximation of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property uses an approximation of the square root function to calculate vector magnitude, with
        /// an upper error bound of 0.001.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthSquared"/>
        public float LengthFast => 1.0f / MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z));

        /// <summary>
        /// Gets the square of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
        /// for comparisons.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthFast"/>
        public float LengthSquared => (X * X) + (Y * Y) + (Z * Z);

        /// <summary>
        /// Returns a copy of the Vector3 scaled to unit length.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public Vector3 Normalized()
        {
            var v = this;
            v.Normalize();
            return v;
        }

        /// <summary>
        /// Scales the Vector3 to unit length.
        /// </summary>
        public void Normalize()
        {
            var scale = 1.0f / Length;
            X *= scale;
            Y *= scale;
            Z *= scale;
        }

        /// <summary>
        /// Scales the Vector3 to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            var scale = MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z));
            X *= scale;
            Y *= scale;
            Z *= scale;
        }

        /// <summary>
        /// Defines a unit-length Vector3 that points towards the X-axis.
        /// </summary>
        public static readonly Vector3 UnitX = new Vector3(1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector3 that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3 UnitY = new Vector3(0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector3 that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3 UnitZ = new Vector3(0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector3.
        /// </summary>
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector3 struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector3>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector3 Add(Vector3 a, Vector3 b)
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
        public static void Add(ref Vector3 a, ref Vector3 b, out Vector3 result)
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
        public static Vector3 Subtract(Vector3 a, Vector3 b)
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
        public static void Subtract(ref Vector3 a, ref Vector3 b, out Vector3 result)
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
        public static Vector3 Multiply(Vector3 vector, float scale)
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
        public static void Multiply(ref Vector3 vector, float scale, out Vector3 result)
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
        public static Vector3 Multiply(Vector3 vector, Vector3 scale)
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
        public static void Multiply(ref Vector3 vector, ref Vector3 scale, out Vector3 result)
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
        public static Vector3 Divide(Vector3 vector, float scale)
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
        public static void Divide(ref Vector3 vector, float scale, out Vector3 result)
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
        public static Vector3 Divide(Vector3 vector, Vector3 scale)
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
        public static void Divide(ref Vector3 vector, ref Vector3 scale, out Vector3 result)
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
        public static Vector3 ComponentMin(Vector3 a, Vector3 b)
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
        public static void ComponentMin(ref Vector3 a, ref Vector3 b, out Vector3 result)
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
        public static Vector3 ComponentMax(Vector3 a, Vector3 b)
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
        public static void ComponentMax(ref Vector3 a, ref Vector3 b, out Vector3 result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Returns the Vector3 with the minimum magnitude. If the magnitudes are equal, the second vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector3.</returns>
        [Pure]
        public static Vector3 MagnitudeMin(Vector3 left, Vector3 right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3 with the minimum magnitude. If the magnitudes are equal, the second vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise minimum.</param>
        public static void MagnitudeMin(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3 with the maximum magnitude. If the magnitudes are equal, the first vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The maximum Vector3.</returns>
        [Pure]
        public static Vector3 MagnitudeMax(Vector3 left, Vector3 right)
        {
            return left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3 with the maximum magnitude. If the magnitudes are equal, the first vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise maximum.</param>
        public static void MagnitudeMax(ref Vector3 left, ref Vector3 right, out Vector3 result)
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
        public static Vector3 Clamp(Vector3 vec, Vector3 min, Vector3 max)
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
        public static void Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result)
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
        public static float Distance(Vector3 vec1, Vector3 vec2)
        {
            Distance(ref vec1, ref vec2, out float result);
            return result;
        }

        /// <summary>
        /// Compute the euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <param name="result">The distance.</param>
        public static void Distance(ref Vector3 vec1, ref Vector3 vec2, out float result)
        {
            result = (float)Math.Sqrt(((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                                      ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)));
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The squared distance.</returns>
        [Pure]
        public static float DistanceSquared(Vector3 vec1, Vector3 vec2)
        {
            DistanceSquared(ref vec1, ref vec2, out float result);
            return result;
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <param name="result">The squared distance.</param>
        public static void DistanceSquared(ref Vector3 vec1, ref Vector3 vec2, out float result)
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
        public static Vector3 Normalize(Vector3 vec)
        {
            var scale = 1.0f / vec.Length;
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
        public static void Normalize(ref Vector3 vec, out Vector3 result)
        {
            var scale = 1.0f / vec.Length;
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
        public static Vector3 NormalizeFast(Vector3 vec)
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
        public static void NormalizeFast(ref Vector3 vec, out Vector3 result)
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
        public static float Dot(Vector3 left, Vector3 right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <param name="result">The dot product of the two inputs.</param>
        public static void Dot(ref Vector3 left, ref Vector3 right, out float result)
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
        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Cross(ref left, ref right, out Vector3 result);
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
        public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
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
        public static Vector3 Lerp(Vector3 a, Vector3 b, float blend)
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
        public static void Lerp(ref Vector3 a, ref Vector3 b, float blend, out Vector3 result)
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
        public static Vector3 BaryCentric(Vector3 a, Vector3 b, Vector3 c, float u, float v)
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
            ref Vector3 a,
            ref Vector3 b,
            ref Vector3 c,
            float u,
            float v,
            out Vector3 result
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
        public static Vector3 TransformVector(Vector3 vec, Matrix4 mat)
        {
            TransformVector(ref vec, ref mat, out Vector3 result);
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
        public static void TransformVector(ref Vector3 vec, ref Matrix4 mat, out Vector3 result)
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
        public static Vector3 TransformNormal(Vector3 norm, Matrix4 mat)
        {
            TransformNormal(ref norm, ref mat, out Vector3 result);
            return result;
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
        public static void TransformNormal(ref Vector3 norm, ref Matrix4 mat, out Vector3 result)
        {
            var inverse = Matrix4.Invert(mat);
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
        public static Vector3 TransformNormalInverse(Vector3 norm, Matrix4 invMat)
        {
            TransformNormalInverse(ref norm, ref invMat, out Vector3 result);
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
        public static void TransformNormalInverse(ref Vector3 norm, ref Matrix4 invMat, out Vector3 result)
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
        public static Vector3 TransformPosition(Vector3 pos, Matrix4 mat)
        {
            TransformPosition(ref pos, ref mat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transform a Position by the given Matrix.
        /// </summary>
        /// <param name="pos">The position to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed position.</param>
        public static void TransformPosition(ref Vector3 pos, ref Matrix4 mat, out Vector3 result)
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
        public static Vector3 Transform(Vector3 vec, Matrix3 mat)
        {
            Transform(ref vec, ref mat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Vector3 vec, ref Matrix3 mat, out Vector3 result)
        {
            result.X = (vec.X * mat.Row0.X) + (vec.Y * mat.Row1.X) + (vec.Z * mat.Row2.X);
            result.Y = (vec.X * mat.Row0.Y) + (vec.Y * mat.Row1.Y) + (vec.Z * mat.Row2.Y);
            result.Z = (vec.X * mat.Row0.Z) + (vec.Y * mat.Row1.Z) + (vec.Z * mat.Row2.Z);
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        [Pure]
        public static Vector3 Transform(Vector3 vec, Quaternion quat)
        {
            Transform(ref vec, ref quat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector3 vec, ref Quaternion quat, out Vector3 result)
        {
            // Since vec.W == 0, we can optimize quat * vec * quat^-1 as follows:
            // vec + 2.0 * cross(quat.xyz, cross(quat.xyz, vec) + quat.w * vec)
            Vector3 xyz = quat.Xyz;
            Cross(ref xyz, ref vec, out Vector3 temp);
            Multiply(ref vec, quat.W, out Vector3 temp2);
            Add(ref temp, ref temp2, out temp);
            Cross(ref xyz, ref temp, out temp2);
            Multiply(ref temp2, 2f, out temp2);
            Add(ref vec, ref temp2, out result);
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3 Transform(Matrix3 mat, Vector3 vec)
        {
            Transform(ref vec, ref mat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Matrix3 mat, ref Vector3 vec, out Vector3 result)
        {
            result.X = (mat.Row0.X * vec.X) + (mat.Row0.Y * vec.Y) + (mat.Row0.Z * vec.Z);
            result.Y = (mat.Row1.X * vec.X) + (mat.Row1.Y * vec.Y) + (mat.Row1.Z * vec.Z);
            result.Z = (mat.Row2.X * vec.X) + (mat.Row2.Y * vec.Y) + (mat.Row2.Z * vec.Z);
        }

        /// <summary>
        /// Transform a Vector3 by the given Matrix, and project the resulting Vector4 back to a Vector3.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3 TransformPerspective(Vector3 vec, Matrix4 mat)
        {
            TransformPerspective(ref vec, ref mat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector3 by the given Matrix, and project the resulting Vector4 back to a Vector3.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void TransformPerspective(ref Vector3 vec, ref Matrix4 mat, out Vector3 result)
        {
            var v = new Vector4(vec.X, vec.Y, vec.Z, 1);
            Vector4.Transform(ref v, ref mat, out v);
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
        public static float CalculateAngle(Vector3 first, Vector3 second)
        {
            CalculateAngle(ref first, ref second, out float result);
            return result;
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <param name="result">Angle (in radians) between the vectors.</param>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public static void CalculateAngle(ref Vector3 first, ref Vector3 second, out float result)
        {
            Dot(ref first, ref second, out float temp);
            result = (float)Math.Acos(MathHelper.Clamp(temp / (first.Length * second.Length), -1.0, 1.0));
        }

        /// <summary>
        /// Projects a vector from object space into screen space.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="x">The X coordinate of the viewport.</param>
        /// <param name="y">The Y coordinate of the viewport.</param>
        /// <param name="width">The width of the viewport.</param>
        /// <param name="height">The height of the viewport.</param>
        /// <param name="minZ">The minimum depth of the viewport.</param>
        /// <param name="maxZ">The maximum depth of the viewport.</param>
        /// <param name="worldViewProjection">The world-view-projection matrix.</param>
        /// <returns>The vector in screen space.</returns>
        /// <remarks>
        /// To project to normalized device coordinates (NDC) use the following parameters:
        /// Project(vector, -1, -1, 2, 2, -1, 1, worldViewProjection).
        /// </remarks>
        [Pure]
        public static Vector3 Project
        (
            Vector3 vector,
            float x,
            float y,
            float width,
            float height,
            float minZ,
            float maxZ,
            Matrix4 worldViewProjection
        )
        {
            Vector4 result;

            result.X =
                (vector.X * worldViewProjection.M11) +
                (vector.Y * worldViewProjection.M21) +
                (vector.Z * worldViewProjection.M31) +
                worldViewProjection.M41;

            result.Y =
                (vector.X * worldViewProjection.M12) +
                (vector.Y * worldViewProjection.M22) +
                (vector.Z * worldViewProjection.M32) +
                worldViewProjection.M42;

            result.Z =
                (vector.X * worldViewProjection.M13) +
                (vector.Y * worldViewProjection.M23) +
                (vector.Z * worldViewProjection.M33) +
                worldViewProjection.M43;

            result.W =
                (vector.X * worldViewProjection.M14) +
                (vector.Y * worldViewProjection.M24) +
                (vector.Z * worldViewProjection.M34) +
                worldViewProjection.M44;

            result /= result.W;

            result.X = x + (width * ((result.X + 1.0f) / 2.0f));
            result.Y = y + (height * ((result.Y + 1.0f) / 2.0f));
            result.Z = minZ + ((maxZ - minZ) * ((result.Z + 1.0f) / 2.0f));

            return new Vector3(result.X, result.Y, result.Z);
        }

        /// <summary>
        /// Projects a vector from screen space into object space.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="x">The X coordinate of the viewport.</param>
        /// <param name="y">The Y coordinate of the viewport.</param>
        /// <param name="width">The width of the viewport.</param>
        /// <param name="height">The height of the viewport.</param>
        /// <param name="minZ">The minimum depth of the viewport.</param>
        /// <param name="maxZ">The maximum depth of the viewport.</param>
        /// <param name="inverseWorldViewProjection">The inverse of the world-view-projection matrix.</param>
        /// <returns>The vector in object space.</returns>
        /// <remarks>
        /// To project from normalized device coordinates (NDC) use the following parameters:
        /// Project(vector, -1, -1, 2, 2, -1, 1, inverseWorldViewProjection).
        /// </remarks>
        [Pure]
        public static Vector3 Unproject
        (
            Vector3 vector,
            float x,
            float y,
            float width,
            float height,
            float minZ,
            float maxZ,
            Matrix4 inverseWorldViewProjection
        )
        {
            Vector4 result;

            result.X = ((vector.X - x) / width * 2.0f) - 1.0f;
            result.Y = ((vector.Y - y) / height * 2.0f) - 1.0f;
            result.Z = (vector.Z / (maxZ - minZ) * 2.0f) - 1.0f;

            result.X =
                (result.X * inverseWorldViewProjection.M11) +
                (result.Y * inverseWorldViewProjection.M21) +
                (result.Z * inverseWorldViewProjection.M31) +
                inverseWorldViewProjection.M41;

            result.Y =
                (result.X * inverseWorldViewProjection.M12) +
                (result.Y * inverseWorldViewProjection.M22) +
                (result.Z * inverseWorldViewProjection.M32) +
                inverseWorldViewProjection.M42;

            result.Z =
                (result.X * inverseWorldViewProjection.M13) +
                (result.Y * inverseWorldViewProjection.M23) +
                (result.Z * inverseWorldViewProjection.M33) +
                inverseWorldViewProjection.M43;

            result.W =
                (result.X * inverseWorldViewProjection.M14) +
                (result.Y * inverseWorldViewProjection.M24) +
                (result.Z * inverseWorldViewProjection.M34) +
                inverseWorldViewProjection.M44;

            result /= result.W;

            return new Vector3(result.X, result.Y, result.Z);
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Xy
        {
            get => Unsafe.As<Vector3, Vector2>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Xz
        {
            get => new Vector2(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Yx
        {
            get => new Vector2(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Yz
        {
            get => new Vector2(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Zx
        {
            get => new Vector2(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Zy
        {
            get => new Vector2(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xzy
        {
            get => new Vector3(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Yxz
        {
            get => new Vector3(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Yzx
        {
            get => new Vector3(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zxy
        {
            get => new Vector3(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zyx
        {
            get => new Vector3(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        #region Coords: x, y, z
        [XmlIgnore]
        public float x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public float y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public float z
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2 xx
        {
            get => new Vector2(X, X);
        }

        [XmlIgnore]
        public Vector2 xy
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 xz
        {
            get => new Vector2(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 yx
        {
            get => new Vector2(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 yy
        {
            get => new Vector2(Y, Y);
        }

        [XmlIgnore]
        public Vector2 yz
        {
            get => new Vector2(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 zx
        {
            get => new Vector2(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 zy
        {
            get => new Vector2(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 zz
        {
            get => new Vector2(Z, Z);
        }

        [XmlIgnore]
        public Vector3 xxx
        {
            get => new Vector3(X, X, X);
        }

        [XmlIgnore]
        public Vector3 xxy
        {
            get => new Vector3(X, X, Y);
        }

        [XmlIgnore]
        public Vector3 xxz
        {
            get => new Vector3(X, X, Z);
        }

        [XmlIgnore]
        public Vector3 xyx
        {
            get => new Vector3(X, Y, X);
        }

        [XmlIgnore]
        public Vector3 xyy
        {
            get => new Vector3(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3 xyz
        {
            get => new Vector3(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 xzx
        {
            get => new Vector3(X, Z, X);
        }

        [XmlIgnore]
        public Vector3 xzy
        {
            get => new Vector3(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 xzz
        {
            get => new Vector3(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3 yxx
        {
            get => new Vector3(Y, X, X);
        }

        [XmlIgnore]
        public Vector3 yxy
        {
            get => new Vector3(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3 yxz
        {
            get => new Vector3(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 yyx
        {
            get => new Vector3(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3 yyy
        {
            get => new Vector3(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3 yyz
        {
            get => new Vector3(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3 yzx
        {
            get => new Vector3(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 yzy
        {
            get => new Vector3(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3 yzz
        {
            get => new Vector3(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3 zxx
        {
            get => new Vector3(Z, X, X);
        }

        [XmlIgnore]
        public Vector3 zxy
        {
            get => new Vector3(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 zxz
        {
            get => new Vector3(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3 zyx
        {
            get => new Vector3(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 zyy
        {
            get => new Vector3(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3 zyz
        {
            get => new Vector3(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3 zzx
        {
            get => new Vector3(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3 zzy
        {
            get => new Vector3(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3 zzz
        {
            get => new Vector3(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 xxxx
        {
            get => new Vector4(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4 xxxy
        {
            get => new Vector4(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 xxxz
        {
            get => new Vector4(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 xxyx
        {
            get => new Vector4(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 xxyy
        {
            get => new Vector4(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 xxyz
        {
            get => new Vector4(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 xxzx
        {
            get => new Vector4(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 xxzy
        {
            get => new Vector4(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 xxzz
        {
            get => new Vector4(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 xyxx
        {
            get => new Vector4(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 xyxy
        {
            get => new Vector4(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 xyxz
        {
            get => new Vector4(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 xyyx
        {
            get => new Vector4(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 xyyy
        {
            get => new Vector4(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 xyyz
        {
            get => new Vector4(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 xyzx
        {
            get => new Vector4(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 xyzy
        {
            get => new Vector4(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 xyzz
        {
            get => new Vector4(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 xzxx
        {
            get => new Vector4(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 xzxy
        {
            get => new Vector4(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 xzxz
        {
            get => new Vector4(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 xzyx
        {
            get => new Vector4(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 xzyy
        {
            get => new Vector4(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 xzyz
        {
            get => new Vector4(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 xzzx
        {
            get => new Vector4(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 xzzy
        {
            get => new Vector4(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 xzzz
        {
            get => new Vector4(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 yxxx
        {
            get => new Vector4(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4 yxxy
        {
            get => new Vector4(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 yxxz
        {
            get => new Vector4(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 yxyx
        {
            get => new Vector4(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 yxyy
        {
            get => new Vector4(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 yxyz
        {
            get => new Vector4(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 yxzx
        {
            get => new Vector4(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 yxzy
        {
            get => new Vector4(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 yxzz
        {
            get => new Vector4(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 yyxx
        {
            get => new Vector4(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 yyxy
        {
            get => new Vector4(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 yyxz
        {
            get => new Vector4(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 yyyx
        {
            get => new Vector4(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 yyyy
        {
            get => new Vector4(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 yyyz
        {
            get => new Vector4(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 yyzx
        {
            get => new Vector4(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 yyzy
        {
            get => new Vector4(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 yyzz
        {
            get => new Vector4(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 yzxx
        {
            get => new Vector4(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 yzxy
        {
            get => new Vector4(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 yzxz
        {
            get => new Vector4(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 yzyx
        {
            get => new Vector4(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 yzyy
        {
            get => new Vector4(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 yzyz
        {
            get => new Vector4(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 yzzx
        {
            get => new Vector4(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 yzzy
        {
            get => new Vector4(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 yzzz
        {
            get => new Vector4(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 zxxx
        {
            get => new Vector4(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4 zxxy
        {
            get => new Vector4(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 zxxz
        {
            get => new Vector4(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 zxyx
        {
            get => new Vector4(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 zxyy
        {
            get => new Vector4(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 zxyz
        {
            get => new Vector4(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 zxzx
        {
            get => new Vector4(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 zxzy
        {
            get => new Vector4(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 zxzz
        {
            get => new Vector4(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 zyxx
        {
            get => new Vector4(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 zyxy
        {
            get => new Vector4(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 zyxz
        {
            get => new Vector4(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 zyyx
        {
            get => new Vector4(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 zyyy
        {
            get => new Vector4(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 zyyz
        {
            get => new Vector4(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 zyzx
        {
            get => new Vector4(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 zyzy
        {
            get => new Vector4(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 zyzz
        {
            get => new Vector4(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 zzxx
        {
            get => new Vector4(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 zzxy
        {
            get => new Vector4(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 zzxz
        {
            get => new Vector4(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 zzyx
        {
            get => new Vector4(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 zzyy
        {
            get => new Vector4(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 zzyz
        {
            get => new Vector4(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 zzzx
        {
            get => new Vector4(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 zzzy
        {
            get => new Vector4(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 zzzz
        {
            get => new Vector4(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: r, g, b
        [XmlIgnore]
        public float r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public float g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public float b
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2 rr
        {
            get => new Vector2(X, X);
        }

        [XmlIgnore]
        public Vector2 rg
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 rb
        {
            get => new Vector2(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 gr
        {
            get => new Vector2(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 gg
        {
            get => new Vector2(Y, Y);
        }

        [XmlIgnore]
        public Vector2 gb
        {
            get => new Vector2(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 br
        {
            get => new Vector2(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 bg
        {
            get => new Vector2(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 bb
        {
            get => new Vector2(Z, Z);
        }

        [XmlIgnore]
        public Vector3 rrr
        {
            get => new Vector3(X, X, X);
        }

        [XmlIgnore]
        public Vector3 rrg
        {
            get => new Vector3(X, X, Y);
        }

        [XmlIgnore]
        public Vector3 rrb
        {
            get => new Vector3(X, X, Z);
        }

        [XmlIgnore]
        public Vector3 rgr
        {
            get => new Vector3(X, Y, X);
        }

        [XmlIgnore]
        public Vector3 rgg
        {
            get => new Vector3(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3 rgb
        {
            get => new Vector3(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 rbr
        {
            get => new Vector3(X, Z, X);
        }

        [XmlIgnore]
        public Vector3 rbg
        {
            get => new Vector3(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 rbb
        {
            get => new Vector3(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3 grr
        {
            get => new Vector3(Y, X, X);
        }

        [XmlIgnore]
        public Vector3 grg
        {
            get => new Vector3(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3 grb
        {
            get => new Vector3(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 ggr
        {
            get => new Vector3(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3 ggg
        {
            get => new Vector3(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3 ggb
        {
            get => new Vector3(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3 gbr
        {
            get => new Vector3(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 gbg
        {
            get => new Vector3(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3 gbb
        {
            get => new Vector3(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3 brr
        {
            get => new Vector3(Z, X, X);
        }

        [XmlIgnore]
        public Vector3 brg
        {
            get => new Vector3(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 brb
        {
            get => new Vector3(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3 bgr
        {
            get => new Vector3(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 bgg
        {
            get => new Vector3(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3 bgb
        {
            get => new Vector3(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3 bbr
        {
            get => new Vector3(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3 bbg
        {
            get => new Vector3(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3 bbb
        {
            get => new Vector3(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 rrrr
        {
            get => new Vector4(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4 rrrg
        {
            get => new Vector4(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 rrrb
        {
            get => new Vector4(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 rrgr
        {
            get => new Vector4(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 rrgg
        {
            get => new Vector4(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 rrgb
        {
            get => new Vector4(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 rrbr
        {
            get => new Vector4(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 rrbg
        {
            get => new Vector4(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 rrbb
        {
            get => new Vector4(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 rgrr
        {
            get => new Vector4(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 rgrg
        {
            get => new Vector4(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 rgrb
        {
            get => new Vector4(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 rggr
        {
            get => new Vector4(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 rggg
        {
            get => new Vector4(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 rggb
        {
            get => new Vector4(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 rgbr
        {
            get => new Vector4(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 rgbg
        {
            get => new Vector4(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 rgbb
        {
            get => new Vector4(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 rbrr
        {
            get => new Vector4(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 rbrg
        {
            get => new Vector4(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 rbrb
        {
            get => new Vector4(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 rbgr
        {
            get => new Vector4(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 rbgg
        {
            get => new Vector4(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 rbgb
        {
            get => new Vector4(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 rbbr
        {
            get => new Vector4(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 rbbg
        {
            get => new Vector4(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 rbbb
        {
            get => new Vector4(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 grrr
        {
            get => new Vector4(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4 grrg
        {
            get => new Vector4(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 grrb
        {
            get => new Vector4(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 grgr
        {
            get => new Vector4(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 grgg
        {
            get => new Vector4(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 grgb
        {
            get => new Vector4(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 grbr
        {
            get => new Vector4(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 grbg
        {
            get => new Vector4(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 grbb
        {
            get => new Vector4(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ggrr
        {
            get => new Vector4(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 ggrg
        {
            get => new Vector4(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 ggrb
        {
            get => new Vector4(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 gggr
        {
            get => new Vector4(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 gggg
        {
            get => new Vector4(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 gggb
        {
            get => new Vector4(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ggbr
        {
            get => new Vector4(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 ggbg
        {
            get => new Vector4(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 ggbb
        {
            get => new Vector4(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 gbrr
        {
            get => new Vector4(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 gbrg
        {
            get => new Vector4(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 gbrb
        {
            get => new Vector4(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 gbgr
        {
            get => new Vector4(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 gbgg
        {
            get => new Vector4(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 gbgb
        {
            get => new Vector4(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 gbbr
        {
            get => new Vector4(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 gbbg
        {
            get => new Vector4(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 gbbb
        {
            get => new Vector4(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 brrr
        {
            get => new Vector4(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4 brrg
        {
            get => new Vector4(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 brrb
        {
            get => new Vector4(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 brgr
        {
            get => new Vector4(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 brgg
        {
            get => new Vector4(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 brgb
        {
            get => new Vector4(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 brbr
        {
            get => new Vector4(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 brbg
        {
            get => new Vector4(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 brbb
        {
            get => new Vector4(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 bgrr
        {
            get => new Vector4(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 bgrg
        {
            get => new Vector4(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 bgrb
        {
            get => new Vector4(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 bggr
        {
            get => new Vector4(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 bggg
        {
            get => new Vector4(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 bggb
        {
            get => new Vector4(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 bgbr
        {
            get => new Vector4(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 bgbg
        {
            get => new Vector4(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 bgbb
        {
            get => new Vector4(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 bbrr
        {
            get => new Vector4(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 bbrg
        {
            get => new Vector4(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 bbrb
        {
            get => new Vector4(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 bbgr
        {
            get => new Vector4(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 bbgg
        {
            get => new Vector4(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 bbgb
        {
            get => new Vector4(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 bbbr
        {
            get => new Vector4(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 bbbg
        {
            get => new Vector4(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 bbbb
        {
            get => new Vector4(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: s, t, p
        [XmlIgnore]
        public float s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public float t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public float p
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Vector2 ss
        {
            get => new Vector2(X, X);
        }

        [XmlIgnore]
        public Vector2 st
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 sp
        {
            get => new Vector2(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ts
        {
            get => new Vector2(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 tt
        {
            get => new Vector2(Y, Y);
        }

        [XmlIgnore]
        public Vector2 tp
        {
            get => new Vector2(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ps
        {
            get => new Vector2(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 pt
        {
            get => new Vector2(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 pp
        {
            get => new Vector2(Z, Z);
        }

        [XmlIgnore]
        public Vector3 sss
        {
            get => new Vector3(X, X, X);
        }

        [XmlIgnore]
        public Vector3 sst
        {
            get => new Vector3(X, X, Y);
        }

        [XmlIgnore]
        public Vector3 ssp
        {
            get => new Vector3(X, X, Z);
        }

        [XmlIgnore]
        public Vector3 sts
        {
            get => new Vector3(X, Y, X);
        }

        [XmlIgnore]
        public Vector3 stt
        {
            get => new Vector3(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3 stp
        {
            get => new Vector3(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 sps
        {
            get => new Vector3(X, Z, X);
        }

        [XmlIgnore]
        public Vector3 spt
        {
            get => new Vector3(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 spp
        {
            get => new Vector3(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3 tss
        {
            get => new Vector3(Y, X, X);
        }

        [XmlIgnore]
        public Vector3 tst
        {
            get => new Vector3(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3 tsp
        {
            get => new Vector3(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 tts
        {
            get => new Vector3(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3 ttt
        {
            get => new Vector3(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3 ttp
        {
            get => new Vector3(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3 tps
        {
            get => new Vector3(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 tpt
        {
            get => new Vector3(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3 tpp
        {
            get => new Vector3(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3 pss
        {
            get => new Vector3(Z, X, X);
        }

        [XmlIgnore]
        public Vector3 pst
        {
            get => new Vector3(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 psp
        {
            get => new Vector3(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3 pts
        {
            get => new Vector3(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 ptt
        {
            get => new Vector3(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3 ptp
        {
            get => new Vector3(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3 pps
        {
            get => new Vector3(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3 ppt
        {
            get => new Vector3(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3 ppp
        {
            get => new Vector3(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ssss
        {
            get => new Vector4(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4 ssst
        {
            get => new Vector4(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 sssp
        {
            get => new Vector4(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 ssts
        {
            get => new Vector4(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 sstt
        {
            get => new Vector4(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 sstp
        {
            get => new Vector4(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ssps
        {
            get => new Vector4(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 sspt
        {
            get => new Vector4(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 sspp
        {
            get => new Vector4(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 stss
        {
            get => new Vector4(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 stst
        {
            get => new Vector4(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 stsp
        {
            get => new Vector4(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 stts
        {
            get => new Vector4(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 sttt
        {
            get => new Vector4(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 sttp
        {
            get => new Vector4(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 stps
        {
            get => new Vector4(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 stpt
        {
            get => new Vector4(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 stpp
        {
            get => new Vector4(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 spss
        {
            get => new Vector4(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 spst
        {
            get => new Vector4(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 spsp
        {
            get => new Vector4(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 spts
        {
            get => new Vector4(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 sptt
        {
            get => new Vector4(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 sptp
        {
            get => new Vector4(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 spps
        {
            get => new Vector4(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 sppt
        {
            get => new Vector4(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 sppp
        {
            get => new Vector4(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 tsss
        {
            get => new Vector4(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4 tsst
        {
            get => new Vector4(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 tssp
        {
            get => new Vector4(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 tsts
        {
            get => new Vector4(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 tstt
        {
            get => new Vector4(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 tstp
        {
            get => new Vector4(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 tsps
        {
            get => new Vector4(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 tspt
        {
            get => new Vector4(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 tspp
        {
            get => new Vector4(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ttss
        {
            get => new Vector4(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 ttst
        {
            get => new Vector4(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 ttsp
        {
            get => new Vector4(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 ttts
        {
            get => new Vector4(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 tttt
        {
            get => new Vector4(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 tttp
        {
            get => new Vector4(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ttps
        {
            get => new Vector4(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 ttpt
        {
            get => new Vector4(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 ttpp
        {
            get => new Vector4(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 tpss
        {
            get => new Vector4(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 tpst
        {
            get => new Vector4(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 tpsp
        {
            get => new Vector4(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 tpts
        {
            get => new Vector4(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 tptt
        {
            get => new Vector4(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 tptp
        {
            get => new Vector4(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 tpps
        {
            get => new Vector4(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 tppt
        {
            get => new Vector4(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 tppp
        {
            get => new Vector4(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 psss
        {
            get => new Vector4(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4 psst
        {
            get => new Vector4(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 pssp
        {
            get => new Vector4(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 psts
        {
            get => new Vector4(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 pstt
        {
            get => new Vector4(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 pstp
        {
            get => new Vector4(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4 psps
        {
            get => new Vector4(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 pspt
        {
            get => new Vector4(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4 pspp
        {
            get => new Vector4(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ptss
        {
            get => new Vector4(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 ptst
        {
            get => new Vector4(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 ptsp
        {
            get => new Vector4(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4 ptts
        {
            get => new Vector4(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 pttt
        {
            get => new Vector4(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 pttp
        {
            get => new Vector4(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ptps
        {
            get => new Vector4(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4 ptpt
        {
            get => new Vector4(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 ptpp
        {
            get => new Vector4(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ppss
        {
            get => new Vector4(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 ppst
        {
            get => new Vector4(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4 ppsp
        {
            get => new Vector4(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 ppts
        {
            get => new Vector4(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4 pptt
        {
            get => new Vector4(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 pptp
        {
            get => new Vector4(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ppps
        {
            get => new Vector4(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 pppt
        {
            get => new Vector4(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 pppp
        {
            get => new Vector4(Z, Z, Z, Z);
        }
        #endregion

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3 operator +(Vector3 left, Vector3 right)
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
        public static Vector3 operator -(Vector3 left, Vector3 right)
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
        public static Vector3 operator -(Vector3 vec)
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
        public static Vector3 operator *(Vector3 vec, float scale)
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
        public static Vector3 operator *(float scale, Vector3 vec)
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
        public static Vector3 operator *(Vector3 vec, Vector3 scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            return vec;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3 operator *(Vector3 vec, Matrix3 mat)
        {
            Transform(ref vec, ref mat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector3 operator *(Matrix3 mat, Vector3 vec)
        {
            Transform(ref mat, ref vec, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The multiplied vector.</returns>
        [Pure]
        public static Vector3 operator *(Quaternion quat, Vector3 vec)
        {
            Transform(ref vec, ref quat, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3 operator /(Vector3 vec, float scale)
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
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        [Pure]
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3((float X, float Y, float Z) values)
        {
            return new Vector3(values.X, values.Y, values.Z);
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
            if (!(obj is Vector3))
            {
                return false;
            }

            return Equals((Vector3)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector3 other)
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
        public void Deconstruct(out float x, out float y, out float z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}