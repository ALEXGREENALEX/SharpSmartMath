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
    /// Represents a 4D vector using four single-precision floating-point numbers.
    /// </summary>
    /// <remarks>
    /// The Vector4 structure is suitable for interoperation with unmanaged code requiring four consecutive floats.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4 : IEquatable<Vector4>
    {
        /// <summary>
        /// The X component of the Vector4.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y component of the Vector4.
        /// </summary>
        public float Y;

        /// <summary>
        /// The Z component of the Vector4.
        /// </summary>
        public float Z;

        /// <summary>
        /// The W component of the Vector4.
        /// </summary>
        public float W;

        /// <summary>
        /// Defines a unit-length Vector4 that points towards the X-axis.
        /// </summary>
        public static readonly Vector4 UnitX = new Vector4(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4 that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4 UnitY = new Vector4(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4 that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4 UnitZ = new Vector4(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector4 that points towards the W-axis.
        /// </summary>
        public static readonly Vector4 UnitW = new Vector4(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector4.
        /// </summary>
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector4 struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector4>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector4.</param>
        /// <param name="y">The y component of the Vector4.</param>
        /// <param name="z">The z component of the Vector4.</param>
        /// <param name="w">The w component of the Vector4.</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="v">The Vector2 to copy components from.</param>
        public Vector4(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0.0f;
            W = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="v">The Vector3 to copy components from.</param>
        /// <remarks>
        ///  .<seealso cref="Vector4(Vector3, float)"/>
        /// </remarks>
        public Vector4(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="v">The Vector3 to copy components from.</param>
        /// <param name="w">The w component of the new Vector4.</param>
        public Vector4(Vector3 v, float w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="v">The Vector4 to copy components from.</param>
        public Vector4(Vector4 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        /// <param name="index">The index of the component from the Vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 3.</exception>
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

                if (index == 3)
                {
                    return W;
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
                else if (index == 3)
                {
                    W = value;
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
        public float Length => (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));

        /// <summary>
        /// Gets an approximation of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property uses an approximation of the square root function to calculate vector magnitude, with
        /// an upper error bound of 0.001.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthSquared"/>
        public float LengthFast => 1.0f / MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z) + (W * W));

        /// <summary>
        /// Gets the square of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
        /// for comparisons.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthFast"/>
        public float LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);

        /// <summary>
        /// Compute the euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The distance.</returns>
        [Pure]
        public static float Distance(Vector4 vec1, Vector4 vec2)
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
        public static void Distance(ref Vector4 vec1, ref Vector4 vec2, out float result)
        {
            result = (float)Math.Sqrt(((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                                      ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)) + ((vec2.W - vec1.W) * (vec2.W - vec1.W)));
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The squared distance.</returns>
        [Pure]
        public static float DistanceSquared(Vector4 vec1, Vector4 vec2)
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
        public static void DistanceSquared(ref Vector4 vec1, ref Vector4 vec2, out float result)
        {
            result = ((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                     ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)) + ((vec2.W - vec1.W) * (vec2.W - vec1.W));
        }

        /// <summary>
        /// Returns a copy of the Vector4 scaled to unit length.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public Vector4 Normalized()
        {
            var v = this;
            v.Normalize();
            return v;
        }

        /// <summary>
        /// Scales the Vector4 to unit length.
        /// </summary>
        public void Normalize()
        {
            var scale = 1.0f / Length;
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// Scales the Vector4 to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            var scale = MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z) + (W * W));
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector4 Add(Vector4 a, Vector4 b)
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
        public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 result)
        {
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
            result.Z = a.Z + b.Z;
            result.W = a.W + b.W;
        }

        /// <summary>
        /// Subtract one Vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>Result of subtraction.</returns>
        [Pure]
        public static Vector4 Subtract(Vector4 a, Vector4 b)
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
        public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 result)
        {
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
            result.Z = a.Z - b.Z;
            result.W = a.W - b.W;
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4 Multiply(Vector4 vector, float scale)
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
        public static void Multiply(ref Vector4 vector, float scale, out Vector4 result)
        {
            result.X = vector.X * scale;
            result.Y = vector.Y * scale;
            result.Z = vector.Z * scale;
            result.W = vector.W * scale;
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4 Multiply(Vector4 vector, Vector4 scale)
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
        public static void Multiply(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
        {
            result.X = vector.X * scale.X;
            result.Y = vector.Y * scale.Y;
            result.Z = vector.Z * scale.Z;
            result.W = vector.W * scale.W;
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4 Divide(Vector4 vector, float scale)
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
        public static void Divide(ref Vector4 vector, float scale, out Vector4 result)
        {
            result.X = vector.X / scale;
            result.Y = vector.Y / scale;
            result.Z = vector.Z / scale;
            result.W = vector.W / scale;
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4 Divide(Vector4 vector, Vector4 scale)
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
        public static void Divide(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
        {
            result.X = vector.X / scale.X;
            result.Y = vector.Y / scale.Y;
            result.Z = vector.Z / scale.Z;
            result.W = vector.W / scale.W;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector4 ComponentMin(Vector4 a, Vector4 b)
        {
            a.X = a.X < b.X ? a.X : b.X;
            a.Y = a.Y < b.Y ? a.Y : b.Y;
            a.Z = a.Z < b.Z ? a.Z : b.Z;
            a.W = a.W < b.W ? a.W : b.W;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector4 a, ref Vector4 b, out Vector4 result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
            result.Z = a.Z < b.Z ? a.Z : b.Z;
            result.W = a.W < b.W ? a.W : b.W;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector4 ComponentMax(Vector4 a, Vector4 b)
        {
            a.X = a.X > b.X ? a.X : b.X;
            a.Y = a.Y > b.Y ? a.Y : b.Y;
            a.Z = a.Z > b.Z ? a.Z : b.Z;
            a.W = a.W > b.W ? a.W : b.W;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector4 a, ref Vector4 b, out Vector4 result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
            result.W = a.W > b.W ? a.W : b.W;
        }

        /// <summary>
        /// Returns the Vector4 with the minimum magnitude. If the magnitudes are equal, the second vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector4.</returns>
        [Pure]
        public static Vector4 MagnitudeMin(Vector4 left, Vector4 right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4 with the minimum magnitude. If the magnitudes are equal, the second vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise minimum.</param>
        public static void MagnitudeMin(ref Vector4 left, ref Vector4 right, out Vector4 result)
        {
            result = left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4 with the maximum magnitude. If the magnitudes are equal, the first vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The maximum Vector4.</returns>
        [Pure]
        public static Vector4 MagnitudeMax(Vector4 left, Vector4 right)
        {
            return left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4 with the maximum magnitude. If the magnitudes are equal, the first vector
        /// is selected.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise maximum.</param>
        public static void MagnitudeMax(ref Vector4 left, ref Vector4 right, out Vector4 result)
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
        public static Vector4 Clamp(Vector4 vec, Vector4 min, Vector4 max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            vec.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            vec.W = vec.W < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <param name="result">The clamped vector.</param>
        public static void Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.W < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        /// <summary>
        /// Scale a vector to unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Vector4 Normalize(Vector4 vec)
        {
            var scale = 1.0f / vec.Length;
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <param name="result">The normalized vector.</param>
        public static void Normalize(ref Vector4 vec, out Vector4 result)
        {
            var scale = 1.0f / vec.Length;
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
            result.W = vec.W * scale;
        }

        /// <summary>
        /// Scale a vector to approximately unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Vector4 NormalizeFast(Vector4 vec)
        {
            var scale = MathHelper.InverseSqrtFast((vec.X * vec.X) + (vec.Y * vec.Y) + (vec.Z * vec.Z) + (vec.W * vec.W));
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to approximately unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <param name="result">The normalized copy.</param>
        public static void NormalizeFast(ref Vector4 vec, out Vector4 result)
        {
            var scale = MathHelper.InverseSqrtFast((vec.X * vec.X) + (vec.Y * vec.Y) + (vec.Z * vec.Z) + (vec.W * vec.W));
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
            result.W = vec.W * scale;
        }

        /// <summary>
        /// Calculate the dot product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>The dot product of the two inputs.</returns>
        [Pure]
        public static float Dot(Vector4 left, Vector4 right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }

        /// <summary>
        /// Calculate the dot product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <param name="result">The dot product of the two inputs.</param>
        public static void Dot(ref Vector4 left, ref Vector4 right, out float result)
        {
            result = (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise.</returns>
        [Pure]
        public static Vector4 Lerp(Vector4 a, Vector4 b, float blend)
        {
            a.X = (blend * (b.X - a.X)) + a.X;
            a.Y = (blend * (b.Y - a.Y)) + a.Y;
            a.Z = (blend * (b.Z - a.Z)) + a.Z;
            a.W = (blend * (b.W - a.W)) + a.W;
            return a;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise.</param>
        public static void Lerp(ref Vector4 a, ref Vector4 b, float blend, out Vector4 result)
        {
            result.X = (blend * (b.X - a.X)) + a.X;
            result.Y = (blend * (b.Y - a.Y)) + a.Y;
            result.Z = (blend * (b.Z - a.Z)) + a.Z;
            result.W = (blend * (b.W - a.W)) + a.W;
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
        public static Vector4 BaryCentric(Vector4 a, Vector4 b, Vector4 c, float u, float v)
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
        public static void BaryCentric
        (
            ref Vector4 a,
            ref Vector4 b,
            ref Vector4 c,
            float u,
            float v,
            out Vector4 result
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
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4 Transform(Vector4 vec, Matrix4 mat)
        {
            Transform(ref vec, ref mat, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Vector4 vec, ref Matrix4 mat, out Vector4 result)
        {
            result = new Vector4(
                (vec.X * mat.Row0.X) + (vec.Y * mat.Row1.X) + (vec.Z * mat.Row2.X) + (vec.W * mat.Row3.X),
                (vec.X * mat.Row0.Y) + (vec.Y * mat.Row1.Y) + (vec.Z * mat.Row2.Y) + (vec.W * mat.Row3.Y),
                (vec.X * mat.Row0.Z) + (vec.Y * mat.Row1.Z) + (vec.Z * mat.Row2.Z) + (vec.W * mat.Row3.Z),
                (vec.X * mat.Row0.W) + (vec.Y * mat.Row1.W) + (vec.Z * mat.Row2.W) + (vec.W * mat.Row3.W));
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        [Pure]
        public static Vector4 Transform(Vector4 vec, Quaternion quat)
        {
            Transform(ref vec, ref quat, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector4 vec, ref Quaternion quat, out Vector4 result)
        {
            Quaternion v = new Quaternion(vec.X, vec.Y, vec.Z, vec.W);
            Quaternion.Invert(ref quat, out Quaternion i);
            Quaternion.Multiply(ref quat, ref v, out Quaternion t);
            Quaternion.Multiply(ref t, ref i, out v);

            result.X = v.X;
            result.Y = v.Y;
            result.Z = v.Z;
            result.W = v.W;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4 Transform(Matrix4 mat, Vector4 vec)
        {
            Transform(ref mat, ref vec, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Matrix4 mat, ref Vector4 vec, out Vector4 result)
        {
            result = new Vector4(
                (mat.Row0.X * vec.X) + (mat.Row0.Y * vec.Y) + (mat.Row0.Z * vec.Z) + (mat.Row0.W * vec.W),
                (mat.Row1.X * vec.X) + (mat.Row1.Y * vec.Y) + (mat.Row1.Z * vec.Z) + (mat.Row1.W * vec.W),
                (mat.Row2.X * vec.X) + (mat.Row2.Y * vec.Y) + (mat.Row2.Z * vec.Z) + (mat.Row2.W * vec.W),
                (mat.Row3.X * vec.X) + (mat.Row3.Y * vec.Y) + (mat.Row3.Z * vec.Z) + (mat.Row3.W * vec.W));
        }

        #region Components
        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Xy
        {
            get => Unsafe.As<Vector4, Vector2>(ref this);
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
        /// Gets or sets an OpenToolkit.Vector2 with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Xw
        {
            get => new Vector2(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        /// Gets or sets an OpenToolkit.Vector2 with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Yw
        {
            get => new Vector2(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        /// Gets or sets an OpenToolkit.Vector2 with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Zw
        {
            get => new Vector2(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Wx
        {
            get => new Vector2(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Wy
        {
            get => new Vector2(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2 with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2 Wz
        {
            get => new Vector2(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xyz
        {
            get => Unsafe.As<Vector4, Vector3>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xyw
        {
            get => new Vector3(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        /// Gets or sets an OpenToolkit.Vector3 with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xzw
        {
            get => new Vector3(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xwy
        {
            get => new Vector3(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Xwz
        {
            get => new Vector3(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets an OpenToolkit.Vector3 with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Yxw
        {
            get => new Vector3(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        /// Gets or sets an OpenToolkit.Vector3 with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Yzw
        {
            get => new Vector3(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Ywx
        {
            get => new Vector3(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Ywz
        {
            get => new Vector3(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets an OpenToolkit.Vector3 with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zxw
        {
            get => new Vector3(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
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

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zyw
        {
            get => new Vector3(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zwx
        {
            get => new Vector3(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Zwy
        {
            get => new Vector3(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wxy
        {
            get => new Vector3(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wxz
        {
            get => new Vector3(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wyx
        {
            get => new Vector3(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wyz
        {
            get => new Vector3(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wzx
        {
            get => new Vector3(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3 with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3 Wzy
        {
            get => new Vector3(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Xywz
        {
            get => new Vector4(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Xzyw
        {
            get => new Vector4(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Xzwy
        {
            get => new Vector4(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Xwyz
        {
            get => new Vector4(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Xwzy
        {
            get => new Vector4(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yxzw
        {
            get => new Vector4(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yxwz
        {
            get => new Vector4(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yyzw
        {
            get => new Vector4(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yywz
        {
            get => new Vector4(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yzxw
        {
            get => new Vector4(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Yzwx
        {
            get => new Vector4(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Ywxz
        {
            get => new Vector4(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Ywzx
        {
            get => new Vector4(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zxyw
        {
            get => new Vector4(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zxwy
        {
            get => new Vector4(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zyxw
        {
            get => new Vector4(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zywx
        {
            get => new Vector4(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zwxy
        {
            get => new Vector4(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zwyx
        {
            get => new Vector4(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Zwzy
        {
            get => new Vector4(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wxyz
        {
            get => new Vector4(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wxzy
        {
            get => new Vector4(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wyxz
        {
            get => new Vector4(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wyzx
        {
            get => new Vector4(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wzxy
        {
            get => new Vector4(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wzyx
        {
            get => new Vector4(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4 with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4 Wzyw
        {
            get => new Vector4(W, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }
        #endregion

        #region Coords: x, y, z, w
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
        public float w
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2 xw
        {
            get => new Vector2(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2 yw
        {
            get => new Vector2(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2 zw
        {
            get => new Vector2(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 wx
        {
            get => new Vector2(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 wy
        {
            get => new Vector2(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 wz
        {
            get => new Vector2(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ww
        {
            get => new Vector2(W, W);
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
        public Vector3 xxw
        {
            get => new Vector3(X, X, W);
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
        public Vector3 xyw
        {
            get => new Vector3(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3 xzw
        {
            get => new Vector3(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 xwx
        {
            get => new Vector3(X, W, X);
        }

        [XmlIgnore]
        public Vector3 xwy
        {
            get => new Vector3(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 xwz
        {
            get => new Vector3(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 xww
        {
            get => new Vector3(X, W, W);
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
        public Vector3 yxw
        {
            get => new Vector3(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3 yyw
        {
            get => new Vector3(Y, Y, W);
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
        public Vector3 yzw
        {
            get => new Vector3(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 ywx
        {
            get => new Vector3(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 ywy
        {
            get => new Vector3(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3 ywz
        {
            get => new Vector3(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 yww
        {
            get => new Vector3(Y, W, W);
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
        public Vector3 zxw
        {
            get => new Vector3(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3 zyw
        {
            get => new Vector3(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3 zzw
        {
            get => new Vector3(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3 zwx
        {
            get => new Vector3(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 zwy
        {
            get => new Vector3(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 zwz
        {
            get => new Vector3(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3 zww
        {
            get => new Vector3(Z, W, W);
        }

        [XmlIgnore]
        public Vector3 wxx
        {
            get => new Vector3(W, X, X);
        }

        [XmlIgnore]
        public Vector3 wxy
        {
            get => new Vector3(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wxz
        {
            get => new Vector3(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wxw
        {
            get => new Vector3(W, X, W);
        }

        [XmlIgnore]
        public Vector3 wyx
        {
            get => new Vector3(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wyy
        {
            get => new Vector3(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3 wyz
        {
            get => new Vector3(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wyw
        {
            get => new Vector3(W, Y, W);
        }

        [XmlIgnore]
        public Vector3 wzx
        {
            get => new Vector3(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wzy
        {
            get => new Vector3(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 wzz
        {
            get => new Vector3(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3 wzw
        {
            get => new Vector3(W, Z, W);
        }

        [XmlIgnore]
        public Vector3 wwx
        {
            get => new Vector3(W, W, X);
        }

        [XmlIgnore]
        public Vector3 wwy
        {
            get => new Vector3(W, W, Y);
        }

        [XmlIgnore]
        public Vector3 wwz
        {
            get => new Vector3(W, W, Z);
        }

        [XmlIgnore]
        public Vector3 www
        {
            get => new Vector3(W, W, W);
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
        public Vector4 xxxw
        {
            get => new Vector4(X, X, X, W);
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
        public Vector4 xxyw
        {
            get => new Vector4(X, X, Y, W);
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
        public Vector4 xxzw
        {
            get => new Vector4(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 xxwx
        {
            get => new Vector4(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4 xxwy
        {
            get => new Vector4(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 xxwz
        {
            get => new Vector4(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 xxww
        {
            get => new Vector4(X, X, W, W);
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
        public Vector4 xyxw
        {
            get => new Vector4(X, Y, X, W);
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
        public Vector4 xyyw
        {
            get => new Vector4(X, Y, Y, W);
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
        public Vector4 xyzw
        {
            get => new Vector4(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 xywx
        {
            get => new Vector4(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 xywy
        {
            get => new Vector4(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 xywz
        {
            get => new Vector4(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 xyww
        {
            get => new Vector4(X, Y, W, W);
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
        public Vector4 xzxw
        {
            get => new Vector4(X, Z, X, W);
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
        public Vector4 xzyw
        {
            get => new Vector4(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 xzzw
        {
            get => new Vector4(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 xzwx
        {
            get => new Vector4(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 xzwy
        {
            get => new Vector4(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 xzwz
        {
            get => new Vector4(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 xzww
        {
            get => new Vector4(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 xwxx
        {
            get => new Vector4(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4 xwxy
        {
            get => new Vector4(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 xwxz
        {
            get => new Vector4(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 xwxw
        {
            get => new Vector4(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4 xwyx
        {
            get => new Vector4(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 xwyy
        {
            get => new Vector4(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 xwyz
        {
            get => new Vector4(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 xwyw
        {
            get => new Vector4(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 xwzx
        {
            get => new Vector4(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 xwzy
        {
            get => new Vector4(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 xwzz
        {
            get => new Vector4(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 xwzw
        {
            get => new Vector4(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 xwwx
        {
            get => new Vector4(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4 xwwy
        {
            get => new Vector4(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 xwwz
        {
            get => new Vector4(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 xwww
        {
            get => new Vector4(X, W, W, W);
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
        public Vector4 yxxw
        {
            get => new Vector4(Y, X, X, W);
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
        public Vector4 yxyw
        {
            get => new Vector4(Y, X, Y, W);
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
        public Vector4 yxzw
        {
            get => new Vector4(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 yxwx
        {
            get => new Vector4(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4 yxwy
        {
            get => new Vector4(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 yxwz
        {
            get => new Vector4(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 yxww
        {
            get => new Vector4(Y, X, W, W);
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
        public Vector4 yyxw
        {
            get => new Vector4(Y, Y, X, W);
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
        public Vector4 yyyw
        {
            get => new Vector4(Y, Y, Y, W);
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
        public Vector4 yyzw
        {
            get => new Vector4(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 yywx
        {
            get => new Vector4(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 yywy
        {
            get => new Vector4(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 yywz
        {
            get => new Vector4(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 yyww
        {
            get => new Vector4(Y, Y, W, W);
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
        public Vector4 yzxw
        {
            get => new Vector4(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 yzyw
        {
            get => new Vector4(Y, Z, Y, W);
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
        public Vector4 yzzw
        {
            get => new Vector4(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 yzwx
        {
            get => new Vector4(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 yzwy
        {
            get => new Vector4(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 yzwz
        {
            get => new Vector4(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 yzww
        {
            get => new Vector4(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 ywxx
        {
            get => new Vector4(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4 ywxy
        {
            get => new Vector4(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 ywxz
        {
            get => new Vector4(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 ywxw
        {
            get => new Vector4(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4 ywyx
        {
            get => new Vector4(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 ywyy
        {
            get => new Vector4(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 ywyz
        {
            get => new Vector4(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 ywyw
        {
            get => new Vector4(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 ywzx
        {
            get => new Vector4(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 ywzy
        {
            get => new Vector4(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 ywzz
        {
            get => new Vector4(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 ywzw
        {
            get => new Vector4(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 ywwx
        {
            get => new Vector4(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4 ywwy
        {
            get => new Vector4(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 ywwz
        {
            get => new Vector4(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 ywww
        {
            get => new Vector4(Y, W, W, W);
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
        public Vector4 zxxw
        {
            get => new Vector4(Z, X, X, W);
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
        public Vector4 zxyw
        {
            get => new Vector4(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 zxzw
        {
            get => new Vector4(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 zxwx
        {
            get => new Vector4(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4 zxwy
        {
            get => new Vector4(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 zxwz
        {
            get => new Vector4(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 zxww
        {
            get => new Vector4(Z, X, W, W);
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
        public Vector4 zyxw
        {
            get => new Vector4(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 zyyw
        {
            get => new Vector4(Z, Y, Y, W);
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
        public Vector4 zyzw
        {
            get => new Vector4(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 zywx
        {
            get => new Vector4(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 zywy
        {
            get => new Vector4(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 zywz
        {
            get => new Vector4(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 zyww
        {
            get => new Vector4(Z, Y, W, W);
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
        public Vector4 zzxw
        {
            get => new Vector4(Z, Z, X, W);
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
        public Vector4 zzyw
        {
            get => new Vector4(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4 zzzw
        {
            get => new Vector4(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 zzwx
        {
            get => new Vector4(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 zzwy
        {
            get => new Vector4(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 zzwz
        {
            get => new Vector4(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 zzww
        {
            get => new Vector4(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 zwxx
        {
            get => new Vector4(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4 zwxy
        {
            get => new Vector4(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 zwxz
        {
            get => new Vector4(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 zwxw
        {
            get => new Vector4(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4 zwyx
        {
            get => new Vector4(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 zwyy
        {
            get => new Vector4(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 zwyz
        {
            get => new Vector4(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 zwyw
        {
            get => new Vector4(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 zwzx
        {
            get => new Vector4(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 zwzy
        {
            get => new Vector4(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 zwzz
        {
            get => new Vector4(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 zwzw
        {
            get => new Vector4(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 zwwx
        {
            get => new Vector4(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4 zwwy
        {
            get => new Vector4(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 zwwz
        {
            get => new Vector4(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 zwww
        {
            get => new Vector4(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4 wxxx
        {
            get => new Vector4(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4 wxxy
        {
            get => new Vector4(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 wxxz
        {
            get => new Vector4(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 wxxw
        {
            get => new Vector4(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4 wxyx
        {
            get => new Vector4(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 wxyy
        {
            get => new Vector4(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 wxyz
        {
            get => new Vector4(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wxyw
        {
            get => new Vector4(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4 wxzx
        {
            get => new Vector4(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 wxzy
        {
            get => new Vector4(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wxzz
        {
            get => new Vector4(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 wxzw
        {
            get => new Vector4(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 wxwx
        {
            get => new Vector4(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4 wxwy
        {
            get => new Vector4(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 wxwz
        {
            get => new Vector4(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 wxww
        {
            get => new Vector4(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4 wyxx
        {
            get => new Vector4(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 wyxy
        {
            get => new Vector4(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 wyxz
        {
            get => new Vector4(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wyxw
        {
            get => new Vector4(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4 wyyx
        {
            get => new Vector4(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 wyyy
        {
            get => new Vector4(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 wyyz
        {
            get => new Vector4(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 wyyw
        {
            get => new Vector4(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4 wyzx
        {
            get => new Vector4(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wyzy
        {
            get => new Vector4(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 wyzz
        {
            get => new Vector4(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 wyzw
        {
            get => new Vector4(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 wywx
        {
            get => new Vector4(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 wywy
        {
            get => new Vector4(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 wywz
        {
            get => new Vector4(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 wyww
        {
            get => new Vector4(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4 wzxx
        {
            get => new Vector4(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 wzxy
        {
            get => new Vector4(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wzxz
        {
            get => new Vector4(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 wzxw
        {
            get => new Vector4(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4 wzyx
        {
            get => new Vector4(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 wzyy
        {
            get => new Vector4(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 wzyz
        {
            get => new Vector4(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 wzyw
        {
            get => new Vector4(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4 wzzx
        {
            get => new Vector4(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 wzzy
        {
            get => new Vector4(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 wzzz
        {
            get => new Vector4(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 wzzw
        {
            get => new Vector4(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 wzwx
        {
            get => new Vector4(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 wzwy
        {
            get => new Vector4(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 wzwz
        {
            get => new Vector4(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 wzww
        {
            get => new Vector4(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 wwxx
        {
            get => new Vector4(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4 wwxy
        {
            get => new Vector4(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 wwxz
        {
            get => new Vector4(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 wwxw
        {
            get => new Vector4(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4 wwyx
        {
            get => new Vector4(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 wwyy
        {
            get => new Vector4(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 wwyz
        {
            get => new Vector4(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 wwyw
        {
            get => new Vector4(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 wwzx
        {
            get => new Vector4(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 wwzy
        {
            get => new Vector4(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 wwzz
        {
            get => new Vector4(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 wwzw
        {
            get => new Vector4(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 wwwx
        {
            get => new Vector4(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4 wwwy
        {
            get => new Vector4(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 wwwz
        {
            get => new Vector4(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 wwww
        {
            get => new Vector4(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
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
        public float a
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2 ra
        {
            get => new Vector2(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2 ga
        {
            get => new Vector2(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2 ba
        {
            get => new Vector2(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ar
        {
            get => new Vector2(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ag
        {
            get => new Vector2(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 ab
        {
            get => new Vector2(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 aa
        {
            get => new Vector2(W, W);
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
        public Vector3 rra
        {
            get => new Vector3(X, X, W);
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
        public Vector3 rga
        {
            get => new Vector3(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3 rba
        {
            get => new Vector3(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 rar
        {
            get => new Vector3(X, W, X);
        }

        [XmlIgnore]
        public Vector3 rag
        {
            get => new Vector3(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 rab
        {
            get => new Vector3(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 raa
        {
            get => new Vector3(X, W, W);
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
        public Vector3 gra
        {
            get => new Vector3(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3 gga
        {
            get => new Vector3(Y, Y, W);
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
        public Vector3 gba
        {
            get => new Vector3(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 gar
        {
            get => new Vector3(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 gag
        {
            get => new Vector3(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3 gab
        {
            get => new Vector3(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 gaa
        {
            get => new Vector3(Y, W, W);
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
        public Vector3 bra
        {
            get => new Vector3(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3 bga
        {
            get => new Vector3(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3 bba
        {
            get => new Vector3(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3 bar
        {
            get => new Vector3(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 bag
        {
            get => new Vector3(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 bab
        {
            get => new Vector3(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3 baa
        {
            get => new Vector3(Z, W, W);
        }

        [XmlIgnore]
        public Vector3 arr
        {
            get => new Vector3(W, X, X);
        }

        [XmlIgnore]
        public Vector3 arg
        {
            get => new Vector3(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 arb
        {
            get => new Vector3(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 ara
        {
            get => new Vector3(W, X, W);
        }

        [XmlIgnore]
        public Vector3 agr
        {
            get => new Vector3(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 agg
        {
            get => new Vector3(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3 agb
        {
            get => new Vector3(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 aga
        {
            get => new Vector3(W, Y, W);
        }

        [XmlIgnore]
        public Vector3 abr
        {
            get => new Vector3(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 abg
        {
            get => new Vector3(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 abb
        {
            get => new Vector3(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3 aba
        {
            get => new Vector3(W, Z, W);
        }

        [XmlIgnore]
        public Vector3 aar
        {
            get => new Vector3(W, W, X);
        }

        [XmlIgnore]
        public Vector3 aag
        {
            get => new Vector3(W, W, Y);
        }

        [XmlIgnore]
        public Vector3 aab
        {
            get => new Vector3(W, W, Z);
        }

        [XmlIgnore]
        public Vector3 aaa
        {
            get => new Vector3(W, W, W);
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
        public Vector4 rrra
        {
            get => new Vector4(X, X, X, W);
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
        public Vector4 rrga
        {
            get => new Vector4(X, X, Y, W);
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
        public Vector4 rrba
        {
            get => new Vector4(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 rrar
        {
            get => new Vector4(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4 rrag
        {
            get => new Vector4(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 rrab
        {
            get => new Vector4(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 rraa
        {
            get => new Vector4(X, X, W, W);
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
        public Vector4 rgra
        {
            get => new Vector4(X, Y, X, W);
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
        public Vector4 rgga
        {
            get => new Vector4(X, Y, Y, W);
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
        public Vector4 rgba
        {
            get => new Vector4(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 rgar
        {
            get => new Vector4(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 rgag
        {
            get => new Vector4(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 rgab
        {
            get => new Vector4(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 rgaa
        {
            get => new Vector4(X, Y, W, W);
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
        public Vector4 rbra
        {
            get => new Vector4(X, Z, X, W);
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
        public Vector4 rbga
        {
            get => new Vector4(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 rbba
        {
            get => new Vector4(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 rbar
        {
            get => new Vector4(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 rbag
        {
            get => new Vector4(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 rbab
        {
            get => new Vector4(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 rbaa
        {
            get => new Vector4(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 rarr
        {
            get => new Vector4(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4 rarg
        {
            get => new Vector4(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 rarb
        {
            get => new Vector4(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 rara
        {
            get => new Vector4(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4 ragr
        {
            get => new Vector4(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 ragg
        {
            get => new Vector4(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 ragb
        {
            get => new Vector4(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 raga
        {
            get => new Vector4(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 rabr
        {
            get => new Vector4(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 rabg
        {
            get => new Vector4(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 rabb
        {
            get => new Vector4(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 raba
        {
            get => new Vector4(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 raar
        {
            get => new Vector4(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4 raag
        {
            get => new Vector4(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 raab
        {
            get => new Vector4(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 raaa
        {
            get => new Vector4(X, W, W, W);
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
        public Vector4 grra
        {
            get => new Vector4(Y, X, X, W);
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
        public Vector4 grga
        {
            get => new Vector4(Y, X, Y, W);
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
        public Vector4 grba
        {
            get => new Vector4(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 grar
        {
            get => new Vector4(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4 grag
        {
            get => new Vector4(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 grab
        {
            get => new Vector4(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 graa
        {
            get => new Vector4(Y, X, W, W);
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
        public Vector4 ggra
        {
            get => new Vector4(Y, Y, X, W);
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
        public Vector4 ggga
        {
            get => new Vector4(Y, Y, Y, W);
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
        public Vector4 ggba
        {
            get => new Vector4(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 ggar
        {
            get => new Vector4(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 ggag
        {
            get => new Vector4(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 ggab
        {
            get => new Vector4(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 ggaa
        {
            get => new Vector4(Y, Y, W, W);
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
        public Vector4 gbra
        {
            get => new Vector4(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 gbga
        {
            get => new Vector4(Y, Z, Y, W);
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
        public Vector4 gbba
        {
            get => new Vector4(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 gbar
        {
            get => new Vector4(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 gbag
        {
            get => new Vector4(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 gbab
        {
            get => new Vector4(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 gbaa
        {
            get => new Vector4(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 garr
        {
            get => new Vector4(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4 garg
        {
            get => new Vector4(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 garb
        {
            get => new Vector4(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 gara
        {
            get => new Vector4(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4 gagr
        {
            get => new Vector4(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 gagg
        {
            get => new Vector4(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 gagb
        {
            get => new Vector4(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 gaga
        {
            get => new Vector4(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 gabr
        {
            get => new Vector4(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 gabg
        {
            get => new Vector4(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 gabb
        {
            get => new Vector4(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 gaba
        {
            get => new Vector4(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 gaar
        {
            get => new Vector4(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4 gaag
        {
            get => new Vector4(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 gaab
        {
            get => new Vector4(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 gaaa
        {
            get => new Vector4(Y, W, W, W);
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
        public Vector4 brra
        {
            get => new Vector4(Z, X, X, W);
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
        public Vector4 brga
        {
            get => new Vector4(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 brba
        {
            get => new Vector4(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 brar
        {
            get => new Vector4(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4 brag
        {
            get => new Vector4(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 brab
        {
            get => new Vector4(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 braa
        {
            get => new Vector4(Z, X, W, W);
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
        public Vector4 bgra
        {
            get => new Vector4(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 bgga
        {
            get => new Vector4(Z, Y, Y, W);
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
        public Vector4 bgba
        {
            get => new Vector4(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 bgar
        {
            get => new Vector4(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 bgag
        {
            get => new Vector4(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 bgab
        {
            get => new Vector4(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 bgaa
        {
            get => new Vector4(Z, Y, W, W);
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
        public Vector4 bbra
        {
            get => new Vector4(Z, Z, X, W);
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
        public Vector4 bbga
        {
            get => new Vector4(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4 bbba
        {
            get => new Vector4(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 bbar
        {
            get => new Vector4(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 bbag
        {
            get => new Vector4(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 bbab
        {
            get => new Vector4(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 bbaa
        {
            get => new Vector4(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 barr
        {
            get => new Vector4(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4 barg
        {
            get => new Vector4(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 barb
        {
            get => new Vector4(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 bara
        {
            get => new Vector4(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4 bagr
        {
            get => new Vector4(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 bagg
        {
            get => new Vector4(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 bagb
        {
            get => new Vector4(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 baga
        {
            get => new Vector4(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 babr
        {
            get => new Vector4(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 babg
        {
            get => new Vector4(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 babb
        {
            get => new Vector4(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 baba
        {
            get => new Vector4(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 baar
        {
            get => new Vector4(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4 baag
        {
            get => new Vector4(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 baab
        {
            get => new Vector4(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 baaa
        {
            get => new Vector4(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4 arrr
        {
            get => new Vector4(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4 arrg
        {
            get => new Vector4(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 arrb
        {
            get => new Vector4(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 arra
        {
            get => new Vector4(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4 argr
        {
            get => new Vector4(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 argg
        {
            get => new Vector4(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 argb
        {
            get => new Vector4(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 arga
        {
            get => new Vector4(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4 arbr
        {
            get => new Vector4(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 arbg
        {
            get => new Vector4(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 arbb
        {
            get => new Vector4(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 arba
        {
            get => new Vector4(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 arar
        {
            get => new Vector4(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4 arag
        {
            get => new Vector4(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 arab
        {
            get => new Vector4(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 araa
        {
            get => new Vector4(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4 agrr
        {
            get => new Vector4(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 agrg
        {
            get => new Vector4(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 agrb
        {
            get => new Vector4(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 agra
        {
            get => new Vector4(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4 aggr
        {
            get => new Vector4(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 aggg
        {
            get => new Vector4(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 aggb
        {
            get => new Vector4(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 agga
        {
            get => new Vector4(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4 agbr
        {
            get => new Vector4(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 agbg
        {
            get => new Vector4(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 agbb
        {
            get => new Vector4(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 agba
        {
            get => new Vector4(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 agar
        {
            get => new Vector4(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 agag
        {
            get => new Vector4(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 agab
        {
            get => new Vector4(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 agaa
        {
            get => new Vector4(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4 abrr
        {
            get => new Vector4(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 abrg
        {
            get => new Vector4(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 abrb
        {
            get => new Vector4(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 abra
        {
            get => new Vector4(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4 abgr
        {
            get => new Vector4(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 abgg
        {
            get => new Vector4(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 abgb
        {
            get => new Vector4(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 abga
        {
            get => new Vector4(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4 abbr
        {
            get => new Vector4(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 abbg
        {
            get => new Vector4(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 abbb
        {
            get => new Vector4(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 abba
        {
            get => new Vector4(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 abar
        {
            get => new Vector4(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 abag
        {
            get => new Vector4(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 abab
        {
            get => new Vector4(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 abaa
        {
            get => new Vector4(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 aarr
        {
            get => new Vector4(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4 aarg
        {
            get => new Vector4(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 aarb
        {
            get => new Vector4(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 aara
        {
            get => new Vector4(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4 aagr
        {
            get => new Vector4(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 aagg
        {
            get => new Vector4(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 aagb
        {
            get => new Vector4(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 aaga
        {
            get => new Vector4(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 aabr
        {
            get => new Vector4(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 aabg
        {
            get => new Vector4(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 aabb
        {
            get => new Vector4(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 aaba
        {
            get => new Vector4(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 aaar
        {
            get => new Vector4(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4 aaag
        {
            get => new Vector4(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 aaab
        {
            get => new Vector4(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 aaaa
        {
            get => new Vector4(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
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
        public float q
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2 sq
        {
            get => new Vector2(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2 tq
        {
            get => new Vector2(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2 pq
        {
            get => new Vector2(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 qs
        {
            get => new Vector2(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 qt
        {
            get => new Vector2(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 qp
        {
            get => new Vector2(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2 qq
        {
            get => new Vector2(W, W);
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
        public Vector3 ssq
        {
            get => new Vector3(X, X, W);
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
        public Vector3 stq
        {
            get => new Vector3(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3 spq
        {
            get => new Vector3(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 sqs
        {
            get => new Vector3(X, W, X);
        }

        [XmlIgnore]
        public Vector3 sqt
        {
            get => new Vector3(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 sqp
        {
            get => new Vector3(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 sqq
        {
            get => new Vector3(X, W, W);
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
        public Vector3 tsq
        {
            get => new Vector3(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3 ttq
        {
            get => new Vector3(Y, Y, W);
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
        public Vector3 tpq
        {
            get => new Vector3(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 tqs
        {
            get => new Vector3(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 tqt
        {
            get => new Vector3(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3 tqp
        {
            get => new Vector3(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 tqq
        {
            get => new Vector3(Y, W, W);
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
        public Vector3 psq
        {
            get => new Vector3(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3 ptq
        {
            get => new Vector3(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3 ppq
        {
            get => new Vector3(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3 pqs
        {
            get => new Vector3(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 pqt
        {
            get => new Vector3(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 pqp
        {
            get => new Vector3(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3 pqq
        {
            get => new Vector3(Z, W, W);
        }

        [XmlIgnore]
        public Vector3 qss
        {
            get => new Vector3(W, X, X);
        }

        [XmlIgnore]
        public Vector3 qst
        {
            get => new Vector3(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qsp
        {
            get => new Vector3(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qsq
        {
            get => new Vector3(W, X, W);
        }

        [XmlIgnore]
        public Vector3 qts
        {
            get => new Vector3(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qtt
        {
            get => new Vector3(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3 qtp
        {
            get => new Vector3(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qtq
        {
            get => new Vector3(W, Y, W);
        }

        [XmlIgnore]
        public Vector3 qps
        {
            get => new Vector3(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qpt
        {
            get => new Vector3(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3 qpp
        {
            get => new Vector3(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3 qpq
        {
            get => new Vector3(W, Z, W);
        }

        [XmlIgnore]
        public Vector3 qqs
        {
            get => new Vector3(W, W, X);
        }

        [XmlIgnore]
        public Vector3 qqt
        {
            get => new Vector3(W, W, Y);
        }

        [XmlIgnore]
        public Vector3 qqp
        {
            get => new Vector3(W, W, Z);
        }

        [XmlIgnore]
        public Vector3 qqq
        {
            get => new Vector3(W, W, W);
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
        public Vector4 sssq
        {
            get => new Vector4(X, X, X, W);
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
        public Vector4 sstq
        {
            get => new Vector4(X, X, Y, W);
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
        public Vector4 sspq
        {
            get => new Vector4(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 ssqs
        {
            get => new Vector4(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4 ssqt
        {
            get => new Vector4(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 ssqp
        {
            get => new Vector4(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 ssqq
        {
            get => new Vector4(X, X, W, W);
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
        public Vector4 stsq
        {
            get => new Vector4(X, Y, X, W);
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
        public Vector4 sttq
        {
            get => new Vector4(X, Y, Y, W);
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
        public Vector4 stpq
        {
            get => new Vector4(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 stqs
        {
            get => new Vector4(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 stqt
        {
            get => new Vector4(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 stqp
        {
            get => new Vector4(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 stqq
        {
            get => new Vector4(X, Y, W, W);
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
        public Vector4 spsq
        {
            get => new Vector4(X, Z, X, W);
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
        public Vector4 sptq
        {
            get => new Vector4(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 sppq
        {
            get => new Vector4(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 spqs
        {
            get => new Vector4(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 spqt
        {
            get => new Vector4(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 spqp
        {
            get => new Vector4(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 spqq
        {
            get => new Vector4(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 sqss
        {
            get => new Vector4(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4 sqst
        {
            get => new Vector4(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 sqsp
        {
            get => new Vector4(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 sqsq
        {
            get => new Vector4(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4 sqts
        {
            get => new Vector4(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 sqtt
        {
            get => new Vector4(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 sqtp
        {
            get => new Vector4(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 sqtq
        {
            get => new Vector4(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 sqps
        {
            get => new Vector4(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 sqpt
        {
            get => new Vector4(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 sqpp
        {
            get => new Vector4(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 sqpq
        {
            get => new Vector4(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 sqqs
        {
            get => new Vector4(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4 sqqt
        {
            get => new Vector4(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 sqqp
        {
            get => new Vector4(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 sqqq
        {
            get => new Vector4(X, W, W, W);
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
        public Vector4 tssq
        {
            get => new Vector4(Y, X, X, W);
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
        public Vector4 tstq
        {
            get => new Vector4(Y, X, Y, W);
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
        public Vector4 tspq
        {
            get => new Vector4(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 tsqs
        {
            get => new Vector4(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4 tsqt
        {
            get => new Vector4(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 tsqp
        {
            get => new Vector4(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 tsqq
        {
            get => new Vector4(Y, X, W, W);
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
        public Vector4 ttsq
        {
            get => new Vector4(Y, Y, X, W);
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
        public Vector4 tttq
        {
            get => new Vector4(Y, Y, Y, W);
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
        public Vector4 ttpq
        {
            get => new Vector4(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 ttqs
        {
            get => new Vector4(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 ttqt
        {
            get => new Vector4(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 ttqp
        {
            get => new Vector4(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 ttqq
        {
            get => new Vector4(Y, Y, W, W);
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
        public Vector4 tpsq
        {
            get => new Vector4(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 tptq
        {
            get => new Vector4(Y, Z, Y, W);
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
        public Vector4 tppq
        {
            get => new Vector4(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 tpqs
        {
            get => new Vector4(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 tpqt
        {
            get => new Vector4(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 tpqp
        {
            get => new Vector4(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 tpqq
        {
            get => new Vector4(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 tqss
        {
            get => new Vector4(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4 tqst
        {
            get => new Vector4(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 tqsp
        {
            get => new Vector4(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 tqsq
        {
            get => new Vector4(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4 tqts
        {
            get => new Vector4(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 tqtt
        {
            get => new Vector4(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 tqtp
        {
            get => new Vector4(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 tqtq
        {
            get => new Vector4(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 tqps
        {
            get => new Vector4(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 tqpt
        {
            get => new Vector4(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 tqpp
        {
            get => new Vector4(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 tqpq
        {
            get => new Vector4(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 tqqs
        {
            get => new Vector4(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4 tqqt
        {
            get => new Vector4(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 tqqp
        {
            get => new Vector4(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 tqqq
        {
            get => new Vector4(Y, W, W, W);
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
        public Vector4 pssq
        {
            get => new Vector4(Z, X, X, W);
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
        public Vector4 pstq
        {
            get => new Vector4(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4 pspq
        {
            get => new Vector4(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 psqs
        {
            get => new Vector4(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4 psqt
        {
            get => new Vector4(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 psqp
        {
            get => new Vector4(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 psqq
        {
            get => new Vector4(Z, X, W, W);
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
        public Vector4 ptsq
        {
            get => new Vector4(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4 pttq
        {
            get => new Vector4(Z, Y, Y, W);
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
        public Vector4 ptpq
        {
            get => new Vector4(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 ptqs
        {
            get => new Vector4(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 ptqt
        {
            get => new Vector4(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 ptqp
        {
            get => new Vector4(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 ptqq
        {
            get => new Vector4(Z, Y, W, W);
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
        public Vector4 ppsq
        {
            get => new Vector4(Z, Z, X, W);
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
        public Vector4 pptq
        {
            get => new Vector4(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4 pppq
        {
            get => new Vector4(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 ppqs
        {
            get => new Vector4(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 ppqt
        {
            get => new Vector4(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 ppqp
        {
            get => new Vector4(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 ppqq
        {
            get => new Vector4(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 pqss
        {
            get => new Vector4(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4 pqst
        {
            get => new Vector4(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 pqsp
        {
            get => new Vector4(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 pqsq
        {
            get => new Vector4(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4 pqts
        {
            get => new Vector4(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 pqtt
        {
            get => new Vector4(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 pqtp
        {
            get => new Vector4(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 pqtq
        {
            get => new Vector4(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 pqps
        {
            get => new Vector4(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 pqpt
        {
            get => new Vector4(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 pqpp
        {
            get => new Vector4(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 pqpq
        {
            get => new Vector4(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 pqqs
        {
            get => new Vector4(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4 pqqt
        {
            get => new Vector4(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 pqqp
        {
            get => new Vector4(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 pqqq
        {
            get => new Vector4(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4 qsss
        {
            get => new Vector4(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4 qsst
        {
            get => new Vector4(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4 qssp
        {
            get => new Vector4(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4 qssq
        {
            get => new Vector4(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4 qsts
        {
            get => new Vector4(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4 qstt
        {
            get => new Vector4(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4 qstp
        {
            get => new Vector4(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qstq
        {
            get => new Vector4(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4 qsps
        {
            get => new Vector4(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4 qspt
        {
            get => new Vector4(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qspp
        {
            get => new Vector4(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4 qspq
        {
            get => new Vector4(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4 qsqs
        {
            get => new Vector4(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4 qsqt
        {
            get => new Vector4(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4 qsqp
        {
            get => new Vector4(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4 qsqq
        {
            get => new Vector4(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4 qtss
        {
            get => new Vector4(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4 qtst
        {
            get => new Vector4(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4 qtsp
        {
            get => new Vector4(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qtsq
        {
            get => new Vector4(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4 qtts
        {
            get => new Vector4(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4 qttt
        {
            get => new Vector4(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4 qttp
        {
            get => new Vector4(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4 qttq
        {
            get => new Vector4(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4 qtps
        {
            get => new Vector4(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qtpt
        {
            get => new Vector4(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4 qtpp
        {
            get => new Vector4(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4 qtpq
        {
            get => new Vector4(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4 qtqs
        {
            get => new Vector4(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4 qtqt
        {
            get => new Vector4(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4 qtqp
        {
            get => new Vector4(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4 qtqq
        {
            get => new Vector4(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4 qpss
        {
            get => new Vector4(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4 qpst
        {
            get => new Vector4(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qpsp
        {
            get => new Vector4(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4 qpsq
        {
            get => new Vector4(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4 qpts
        {
            get => new Vector4(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4 qptt
        {
            get => new Vector4(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4 qptp
        {
            get => new Vector4(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4 qptq
        {
            get => new Vector4(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4 qpps
        {
            get => new Vector4(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4 qppt
        {
            get => new Vector4(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4 qppp
        {
            get => new Vector4(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4 qppq
        {
            get => new Vector4(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4 qpqs
        {
            get => new Vector4(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4 qpqt
        {
            get => new Vector4(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4 qpqp
        {
            get => new Vector4(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4 qpqq
        {
            get => new Vector4(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4 qqss
        {
            get => new Vector4(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4 qqst
        {
            get => new Vector4(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4 qqsp
        {
            get => new Vector4(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4 qqsq
        {
            get => new Vector4(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4 qqts
        {
            get => new Vector4(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4 qqtt
        {
            get => new Vector4(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4 qqtp
        {
            get => new Vector4(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4 qqtq
        {
            get => new Vector4(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4 qqps
        {
            get => new Vector4(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4 qqpt
        {
            get => new Vector4(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4 qqpp
        {
            get => new Vector4(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4 qqpq
        {
            get => new Vector4(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4 qqqs
        {
            get => new Vector4(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4 qqqt
        {
            get => new Vector4(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4 qqqp
        {
            get => new Vector4(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4 qqqq
        {
            get => new Vector4(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
            left.W += right.W;
            return left;
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        /// Negates an instance.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator -(Vector4 vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            vec.W = -vec.W;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator *(Vector4 vec, float scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator *(float scale, Vector4 vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Component-wise multiplication between the specified instance by a scale vector.
        /// </summary>
        /// <param name="scale">Left operand.</param>
        /// <param name="vec">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector4 operator *(Vector4 vec, Vector4 scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            vec.W *= scale.W;
            return vec;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4 operator *(Vector4 vec, Matrix4 mat)
        {
            Transform(ref vec, ref mat, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix using right-handed notation.
        /// </summary>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4 operator *(Matrix4 mat, Vector4 vec)
        {
            Transform(ref mat, ref vec, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4 operator *(Quaternion quat, Vector4 vec)
        {
            Transform(ref vec, ref quat, out Vector4 result);
            return result;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4 operator /(Vector4 vec, float scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            vec.Z /= scale;
            vec.W /= scale;
            return vec;
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector4 left, Vector4 right)
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
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static unsafe explicit operator float*(Vector4 v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static explicit operator IntPtr(Vector4 v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4((float X, float Y, float Z, float W) values)
        {
            return new Vector4(values.X, values.Y, values.Z, values.W);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("({0}{4} {1}{4} {2}{4} {3})", X, Y, Z, W, ListSeparator);
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
                hashCode = (hashCode * 397) ^ W.GetHashCode();
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
            if (!(obj is Vector4))
            {
                return false;
            }

            return Equals((Vector4)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector4 other)
        {
            return
                X == other.X &&
                Y == other.Y &&
                Z == other.Z &&
                W == other.W;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        [Pure]
        public void Deconstruct(out float x, out float y, out float z, out float w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}