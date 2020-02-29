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
    /// Represents a 4D vector using four double-precision floating-point numbers.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4d : IEquatable<Vector4d>
    {
        /// <summary>
        /// The X component of the Vector4d.
        /// </summary>
        public double X;

        /// <summary>
        /// The Y component of the Vector4d.
        /// </summary>
        public double Y;

        /// <summary>
        /// The Z component of the Vector4d.
        /// </summary>
        public double Z;

        /// <summary>
        /// The W component of the Vector4d.
        /// </summary>
        public double W;

        /// <summary>
        /// Defines a unit-length Vector4d that points towards the X-axis.
        /// </summary>
        public static readonly Vector4d UnitX = new Vector4d(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4d that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4d UnitY = new Vector4d(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4d that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4d UnitZ = new Vector4d(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector4d that points towards the W-axis.
        /// </summary>
        public static readonly Vector4d UnitW = new Vector4d(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector4d.
        /// </summary>
        public static readonly Vector4d Zero = new Vector4d(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4d One = new Vector4d(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector4d struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector4d>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4d(double value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector4d.</param>
        /// <param name="y">The y component of the Vector4d.</param>
        /// <param name="z">The z component of the Vector4d.</param>
        /// <param name="w">The w component of the Vector4d.</param>
        public Vector4d(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector4d(Vector2d v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0.0f;
            W = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        /// <remarks>
        /// <seealso cref="Vector4d(Vector3d, double)"/>.
        /// </remarks>
        public Vector4d(Vector3d v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        /// <param name="w">The w component of the new Vector4.</param>
        public Vector4d(Vector3d v, double w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector4d(Vector4d v)
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
        public double Length => Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));

        /// <summary>
        /// Gets an approximation of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property uses an approximation of the square root function to calculate vector magnitude, with
        /// an upper error bound of 0.001.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthSquared"/>
        public double LengthFast => 1.0 / MathHelper.InverseSqrtFast((X * X) + (Y * Y) + (Z * Z) + (W * W));

        /// <summary>
        /// Gets the square of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
        /// for comparisons.
        /// </remarks>
        /// <see cref="Length"/>
        public double LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);

        /// <summary>
        /// Compute the euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The distance.</returns>
        [Pure]
        public static double Distance(Vector4d vec1, Vector4d vec2)
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
        public static void Distance(ref Vector4d vec1, ref Vector4d vec2, out double result)
        {
            result = Math.Sqrt(((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                                      ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)) + ((vec2.W - vec1.W) * (vec2.W - vec1.W)));
        }

        /// <summary>
        /// Compute the squared euclidean distance between two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The squared distance.</returns>
        [Pure]
        public static double DistanceSquared(Vector4d vec1, Vector4d vec2)
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
        public static void DistanceSquared(ref Vector4d vec1, ref Vector4d vec2, out double result)
        {
            result = ((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)) +
                     ((vec2.Z - vec1.Z) * (vec2.Z - vec1.Z)) + ((vec2.W - vec1.W) * (vec2.W - vec1.W));
        }

        /// <summary>
        /// Returns a copy of the Vector4d scaled to unit length.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public Vector4d Normalized()
        {
            var v = this;
            v.Normalize();
            return v;
        }

        /// <summary>
        /// Scales the Vector4d to unit length.
        /// </summary>
        public void Normalize()
        {
            var scale = 1.0 / Length;
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// Scales the Vector4d to approximately unit length.
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
        public static Vector4d Add(Vector4d a, Vector4d b)
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
        public static void Add(ref Vector4d a, ref Vector4d b, out Vector4d result)
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
        public static Vector4d Subtract(Vector4d a, Vector4d b)
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
        public static void Subtract(ref Vector4d a, ref Vector4d b, out Vector4d result)
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
        public static Vector4d Multiply(Vector4d vector, double scale)
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
        public static void Multiply(ref Vector4d vector, double scale, out Vector4d result)
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
        public static Vector4d Multiply(Vector4d vector, Vector4d scale)
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
        public static void Multiply(ref Vector4d vector, ref Vector4d scale, out Vector4d result)
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
        public static Vector4d Divide(Vector4d vector, double scale)
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
        public static void Divide(ref Vector4d vector, double scale, out Vector4d result)
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
        public static Vector4d Divide(Vector4d vector, Vector4d scale)
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
        public static void Divide(ref Vector4d vector, ref Vector4d scale, out Vector4d result)
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
        public static Vector4d ComponentMin(Vector4d a, Vector4d b)
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
        public static void ComponentMin(ref Vector4d a, ref Vector4d b, out Vector4d result)
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
        public static Vector4d ComponentMax(Vector4d a, Vector4d b)
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
        public static void ComponentMax(ref Vector4d a, ref Vector4d b, out Vector4d result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
            result.W = a.W > b.W ? a.W : b.W;
        }

        /// <summary>
        /// Returns the Vector4d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector4d.</returns>
        [Pure]
        public static Vector4d MagnitudeMin(Vector4d left, Vector4d right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise minimum.</param>
        public static void MagnitudeMin(ref Vector4d left, ref Vector4d right, out Vector4d result)
        {
            result = left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4d with the minimum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>The minimum Vector4d.</returns>
        [Pure]
        public static Vector4d MagnitudeMax(Vector4d left, Vector4d right)
        {
            return left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector4d with the maximum magnitude.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <param name="result">The magnitude-wise maximum.</param>
        public static void MagnitudeMax(ref Vector4d left, ref Vector4d right, out Vector4d result)
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
        public static Vector4d Clamp(Vector4d vec, Vector4d min, Vector4d max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            vec.Z = vec.X < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            vec.W = vec.Y < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <param name="result">The clamped vector.</param>
        public static void Clamp(ref Vector4d vec, ref Vector4d min, ref Vector4d max, out Vector4d result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.X < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.Y < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        /// <summary>
        /// Scale a vector to unit length.
        /// </summary>
        /// <param name="vec">The input vector.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Vector4d Normalize(Vector4d vec)
        {
            var scale = 1.0 / vec.Length;
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
        public static void Normalize(ref Vector4d vec, out Vector4d result)
        {
            var scale = 1.0 / vec.Length;
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
        public static Vector4d NormalizeFast(Vector4d vec)
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
        /// <param name="result">The normalized vector.</param>
        public static void NormalizeFast(ref Vector4d vec, out Vector4d result)
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
        public static double Dot(Vector4d left, Vector4d right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }

        /// <summary>
        /// Calculate the dot product of two vectors.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <param name="result">The dot product of the two inputs.</param>
        public static void Dot(ref Vector4d left, ref Vector4d right, out double result)
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
        public static Vector4d Lerp(Vector4d a, Vector4d b, double blend)
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
        public static void Lerp(ref Vector4d a, ref Vector4d b, double blend, out Vector4d result)
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
        public static Vector4d BaryCentric(Vector4d a, Vector4d b, Vector4d c, double u, double v)
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
            ref Vector4d a,
            ref Vector4d b,
            ref Vector4d c,
            double u,
            double v,
            out Vector4d result
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
        public static Vector4d Transform(Vector4d vec, Matrix4d mat)
        {
            Transform(ref vec, ref mat, out Vector4d result);
            return result;
        }

        /// <summary>
        /// Transform a Vector by the given Matrix.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="mat">The desired transformation.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref Vector4d vec, ref Matrix4d mat, out Vector4d result)
        {
            result = new Vector4d(
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
        public static Vector4d Transform(Vector4d vec, Quaterniond quat)
        {
            Transform(ref vec, ref quat, out Vector4d result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector4d vec, ref Quaterniond quat, out Vector4d result)
        {
            Quaterniond v = new Quaterniond(vec.X, vec.Y, vec.Z, vec.W);
            Quaterniond.Invert(ref quat, out Quaterniond i);
            Quaterniond.Multiply(ref quat, ref v, out Quaterniond t);
            Quaterniond.Multiply(ref t, ref i, out v);

            result.X = v.X;
            result.Y = v.Y;
            result.Z = v.Z;
            result.W = v.W;
        }

        #region Components
        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Xy
        {
            get => Unsafe.As<Vector4d, Vector2d>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the X and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2d with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Xw
        {
            get => new Vector2d(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the Y and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2d with the Y and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2d with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Yw
        {
            get => new Vector2d(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the Z and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2d with the Z and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2d with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Zw
        {
            get => new Vector2d(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Wx
        {
            get => new Vector2d(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Wy
        {
            get => new Vector2d(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2d with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2d Wz
        {
            get => new Vector2d(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xyz
        {
            get => Unsafe.As<Vector4d, Vector3d>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xyw
        {
            get => new Vector3d(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the X, Z, and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3d with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xzw
        {
            get => new Vector3d(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xwy
        {
            get => new Vector3d(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Xwz
        {
            get => new Vector3d(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Y, X, and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3d with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Yxw
        {
            get => new Vector3d(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Y, Z, and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3d with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Yzw
        {
            get => new Vector3d(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Ywx
        {
            get => new Vector3d(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Ywz
        {
            get => new Vector3d(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Z, X, and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3d with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zxw
        {
            get => new Vector3d(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Z, Y, and X components of this instance.
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

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zyw
        {
            get => new Vector3d(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zwx
        {
            get => new Vector3d(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Zwy
        {
            get => new Vector3d(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wxy
        {
            get => new Vector3d(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wxz
        {
            get => new Vector3d(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wyx
        {
            get => new Vector3d(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wyz
        {
            get => new Vector3d(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wzx
        {
            get => new Vector3d(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3d with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3d Wzy
        {
            get => new Vector3d(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Xywz
        {
            get => new Vector4d(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Xzyw
        {
            get => new Vector4d(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Xzwy
        {
            get => new Vector4d(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Xwyz
        {
            get => new Vector4d(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Xwzy
        {
            get => new Vector4d(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yxzw
        {
            get => new Vector4d(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yxwz
        {
            get => new Vector4d(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yyzw
        {
            get => new Vector4d(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yywz
        {
            get => new Vector4d(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yzxw
        {
            get => new Vector4d(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Yzwx
        {
            get => new Vector4d(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Ywxz
        {
            get => new Vector4d(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Ywzx
        {
            get => new Vector4d(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zxyw
        {
            get => new Vector4d(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zxwy
        {
            get => new Vector4d(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zyxw
        {
            get => new Vector4d(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zywx
        {
            get => new Vector4d(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zwxy
        {
            get => new Vector4d(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zwyx
        {
            get => new Vector4d(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Zwzy
        {
            get => new Vector4d(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wxyz
        {
            get => new Vector4d(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wxzy
        {
            get => new Vector4d(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wyxz
        {
            get => new Vector4d(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wyzx
        {
            get => new Vector4d(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wzxy
        {
            get => new Vector4d(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wzyx
        {
            get => new Vector4d(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4d with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4d Wzyw
        {
            get => new Vector4d(W, Z, Y, W);
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
        public double w
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2d xw
        {
            get => new Vector2d(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2d yw
        {
            get => new Vector2d(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2d zw
        {
            get => new Vector2d(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d wx
        {
            get => new Vector2d(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d wy
        {
            get => new Vector2d(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d wz
        {
            get => new Vector2d(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ww
        {
            get => new Vector2d(W, W);
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
        public Vector3d xxw
        {
            get => new Vector3d(X, X, W);
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
        public Vector3d xyw
        {
            get => new Vector3d(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3d xzw
        {
            get => new Vector3d(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d xwx
        {
            get => new Vector3d(X, W, X);
        }

        [XmlIgnore]
        public Vector3d xwy
        {
            get => new Vector3d(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d xwz
        {
            get => new Vector3d(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d xww
        {
            get => new Vector3d(X, W, W);
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
        public Vector3d yxw
        {
            get => new Vector3d(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3d yyw
        {
            get => new Vector3d(Y, Y, W);
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
        public Vector3d yzw
        {
            get => new Vector3d(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d ywx
        {
            get => new Vector3d(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d ywy
        {
            get => new Vector3d(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3d ywz
        {
            get => new Vector3d(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d yww
        {
            get => new Vector3d(Y, W, W);
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
        public Vector3d zxw
        {
            get => new Vector3d(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3d zyw
        {
            get => new Vector3d(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3d zzw
        {
            get => new Vector3d(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3d zwx
        {
            get => new Vector3d(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d zwy
        {
            get => new Vector3d(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d zwz
        {
            get => new Vector3d(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3d zww
        {
            get => new Vector3d(Z, W, W);
        }

        [XmlIgnore]
        public Vector3d wxx
        {
            get => new Vector3d(W, X, X);
        }

        [XmlIgnore]
        public Vector3d wxy
        {
            get => new Vector3d(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wxz
        {
            get => new Vector3d(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wxw
        {
            get => new Vector3d(W, X, W);
        }

        [XmlIgnore]
        public Vector3d wyx
        {
            get => new Vector3d(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wyy
        {
            get => new Vector3d(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3d wyz
        {
            get => new Vector3d(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wyw
        {
            get => new Vector3d(W, Y, W);
        }

        [XmlIgnore]
        public Vector3d wzx
        {
            get => new Vector3d(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wzy
        {
            get => new Vector3d(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d wzz
        {
            get => new Vector3d(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3d wzw
        {
            get => new Vector3d(W, Z, W);
        }

        [XmlIgnore]
        public Vector3d wwx
        {
            get => new Vector3d(W, W, X);
        }

        [XmlIgnore]
        public Vector3d wwy
        {
            get => new Vector3d(W, W, Y);
        }

        [XmlIgnore]
        public Vector3d wwz
        {
            get => new Vector3d(W, W, Z);
        }

        [XmlIgnore]
        public Vector3d www
        {
            get => new Vector3d(W, W, W);
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
        public Vector4d xxxw
        {
            get => new Vector4d(X, X, X, W);
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
        public Vector4d xxyw
        {
            get => new Vector4d(X, X, Y, W);
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
        public Vector4d xxzw
        {
            get => new Vector4d(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d xxwx
        {
            get => new Vector4d(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4d xxwy
        {
            get => new Vector4d(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d xxwz
        {
            get => new Vector4d(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d xxww
        {
            get => new Vector4d(X, X, W, W);
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
        public Vector4d xyxw
        {
            get => new Vector4d(X, Y, X, W);
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
        public Vector4d xyyw
        {
            get => new Vector4d(X, Y, Y, W);
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
        public Vector4d xyzw
        {
            get => new Vector4d(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d xywx
        {
            get => new Vector4d(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d xywy
        {
            get => new Vector4d(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d xywz
        {
            get => new Vector4d(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d xyww
        {
            get => new Vector4d(X, Y, W, W);
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
        public Vector4d xzxw
        {
            get => new Vector4d(X, Z, X, W);
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
        public Vector4d xzyw
        {
            get => new Vector4d(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d xzzw
        {
            get => new Vector4d(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d xzwx
        {
            get => new Vector4d(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d xzwy
        {
            get => new Vector4d(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d xzwz
        {
            get => new Vector4d(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d xzww
        {
            get => new Vector4d(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d xwxx
        {
            get => new Vector4d(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4d xwxy
        {
            get => new Vector4d(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d xwxz
        {
            get => new Vector4d(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d xwxw
        {
            get => new Vector4d(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4d xwyx
        {
            get => new Vector4d(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d xwyy
        {
            get => new Vector4d(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d xwyz
        {
            get => new Vector4d(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d xwyw
        {
            get => new Vector4d(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d xwzx
        {
            get => new Vector4d(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d xwzy
        {
            get => new Vector4d(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d xwzz
        {
            get => new Vector4d(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d xwzw
        {
            get => new Vector4d(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d xwwx
        {
            get => new Vector4d(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4d xwwy
        {
            get => new Vector4d(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d xwwz
        {
            get => new Vector4d(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d xwww
        {
            get => new Vector4d(X, W, W, W);
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
        public Vector4d yxxw
        {
            get => new Vector4d(Y, X, X, W);
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
        public Vector4d yxyw
        {
            get => new Vector4d(Y, X, Y, W);
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
        public Vector4d yxzw
        {
            get => new Vector4d(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d yxwx
        {
            get => new Vector4d(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4d yxwy
        {
            get => new Vector4d(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d yxwz
        {
            get => new Vector4d(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d yxww
        {
            get => new Vector4d(Y, X, W, W);
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
        public Vector4d yyxw
        {
            get => new Vector4d(Y, Y, X, W);
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
        public Vector4d yyyw
        {
            get => new Vector4d(Y, Y, Y, W);
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
        public Vector4d yyzw
        {
            get => new Vector4d(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d yywx
        {
            get => new Vector4d(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d yywy
        {
            get => new Vector4d(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d yywz
        {
            get => new Vector4d(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d yyww
        {
            get => new Vector4d(Y, Y, W, W);
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
        public Vector4d yzxw
        {
            get => new Vector4d(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d yzyw
        {
            get => new Vector4d(Y, Z, Y, W);
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
        public Vector4d yzzw
        {
            get => new Vector4d(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d yzwx
        {
            get => new Vector4d(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d yzwy
        {
            get => new Vector4d(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d yzwz
        {
            get => new Vector4d(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d yzww
        {
            get => new Vector4d(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d ywxx
        {
            get => new Vector4d(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4d ywxy
        {
            get => new Vector4d(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d ywxz
        {
            get => new Vector4d(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d ywxw
        {
            get => new Vector4d(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4d ywyx
        {
            get => new Vector4d(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d ywyy
        {
            get => new Vector4d(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d ywyz
        {
            get => new Vector4d(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d ywyw
        {
            get => new Vector4d(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d ywzx
        {
            get => new Vector4d(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d ywzy
        {
            get => new Vector4d(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d ywzz
        {
            get => new Vector4d(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d ywzw
        {
            get => new Vector4d(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d ywwx
        {
            get => new Vector4d(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4d ywwy
        {
            get => new Vector4d(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d ywwz
        {
            get => new Vector4d(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d ywww
        {
            get => new Vector4d(Y, W, W, W);
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
        public Vector4d zxxw
        {
            get => new Vector4d(Z, X, X, W);
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
        public Vector4d zxyw
        {
            get => new Vector4d(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d zxzw
        {
            get => new Vector4d(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d zxwx
        {
            get => new Vector4d(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4d zxwy
        {
            get => new Vector4d(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d zxwz
        {
            get => new Vector4d(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d zxww
        {
            get => new Vector4d(Z, X, W, W);
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
        public Vector4d zyxw
        {
            get => new Vector4d(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d zyyw
        {
            get => new Vector4d(Z, Y, Y, W);
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
        public Vector4d zyzw
        {
            get => new Vector4d(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d zywx
        {
            get => new Vector4d(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d zywy
        {
            get => new Vector4d(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d zywz
        {
            get => new Vector4d(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d zyww
        {
            get => new Vector4d(Z, Y, W, W);
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
        public Vector4d zzxw
        {
            get => new Vector4d(Z, Z, X, W);
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
        public Vector4d zzyw
        {
            get => new Vector4d(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4d zzzw
        {
            get => new Vector4d(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d zzwx
        {
            get => new Vector4d(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d zzwy
        {
            get => new Vector4d(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d zzwz
        {
            get => new Vector4d(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d zzww
        {
            get => new Vector4d(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d zwxx
        {
            get => new Vector4d(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4d zwxy
        {
            get => new Vector4d(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d zwxz
        {
            get => new Vector4d(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d zwxw
        {
            get => new Vector4d(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4d zwyx
        {
            get => new Vector4d(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d zwyy
        {
            get => new Vector4d(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d zwyz
        {
            get => new Vector4d(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d zwyw
        {
            get => new Vector4d(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d zwzx
        {
            get => new Vector4d(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d zwzy
        {
            get => new Vector4d(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d zwzz
        {
            get => new Vector4d(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d zwzw
        {
            get => new Vector4d(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d zwwx
        {
            get => new Vector4d(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4d zwwy
        {
            get => new Vector4d(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d zwwz
        {
            get => new Vector4d(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d zwww
        {
            get => new Vector4d(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4d wxxx
        {
            get => new Vector4d(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4d wxxy
        {
            get => new Vector4d(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d wxxz
        {
            get => new Vector4d(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d wxxw
        {
            get => new Vector4d(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4d wxyx
        {
            get => new Vector4d(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d wxyy
        {
            get => new Vector4d(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d wxyz
        {
            get => new Vector4d(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wxyw
        {
            get => new Vector4d(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4d wxzx
        {
            get => new Vector4d(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d wxzy
        {
            get => new Vector4d(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wxzz
        {
            get => new Vector4d(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d wxzw
        {
            get => new Vector4d(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d wxwx
        {
            get => new Vector4d(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4d wxwy
        {
            get => new Vector4d(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d wxwz
        {
            get => new Vector4d(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d wxww
        {
            get => new Vector4d(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4d wyxx
        {
            get => new Vector4d(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d wyxy
        {
            get => new Vector4d(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d wyxz
        {
            get => new Vector4d(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wyxw
        {
            get => new Vector4d(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4d wyyx
        {
            get => new Vector4d(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d wyyy
        {
            get => new Vector4d(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d wyyz
        {
            get => new Vector4d(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d wyyw
        {
            get => new Vector4d(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4d wyzx
        {
            get => new Vector4d(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wyzy
        {
            get => new Vector4d(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d wyzz
        {
            get => new Vector4d(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d wyzw
        {
            get => new Vector4d(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d wywx
        {
            get => new Vector4d(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d wywy
        {
            get => new Vector4d(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d wywz
        {
            get => new Vector4d(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d wyww
        {
            get => new Vector4d(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4d wzxx
        {
            get => new Vector4d(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d wzxy
        {
            get => new Vector4d(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wzxz
        {
            get => new Vector4d(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d wzxw
        {
            get => new Vector4d(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4d wzyx
        {
            get => new Vector4d(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d wzyy
        {
            get => new Vector4d(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d wzyz
        {
            get => new Vector4d(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d wzyw
        {
            get => new Vector4d(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4d wzzx
        {
            get => new Vector4d(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d wzzy
        {
            get => new Vector4d(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d wzzz
        {
            get => new Vector4d(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d wzzw
        {
            get => new Vector4d(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d wzwx
        {
            get => new Vector4d(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d wzwy
        {
            get => new Vector4d(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d wzwz
        {
            get => new Vector4d(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d wzww
        {
            get => new Vector4d(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d wwxx
        {
            get => new Vector4d(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4d wwxy
        {
            get => new Vector4d(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d wwxz
        {
            get => new Vector4d(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d wwxw
        {
            get => new Vector4d(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4d wwyx
        {
            get => new Vector4d(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d wwyy
        {
            get => new Vector4d(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d wwyz
        {
            get => new Vector4d(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d wwyw
        {
            get => new Vector4d(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d wwzx
        {
            get => new Vector4d(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d wwzy
        {
            get => new Vector4d(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d wwzz
        {
            get => new Vector4d(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d wwzw
        {
            get => new Vector4d(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d wwwx
        {
            get => new Vector4d(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4d wwwy
        {
            get => new Vector4d(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d wwwz
        {
            get => new Vector4d(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d wwww
        {
            get => new Vector4d(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
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
        public double a
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2d ra
        {
            get => new Vector2d(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2d ga
        {
            get => new Vector2d(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2d ba
        {
            get => new Vector2d(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ar
        {
            get => new Vector2d(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ag
        {
            get => new Vector2d(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d ab
        {
            get => new Vector2d(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d aa
        {
            get => new Vector2d(W, W);
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
        public Vector3d rra
        {
            get => new Vector3d(X, X, W);
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
        public Vector3d rga
        {
            get => new Vector3d(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3d rba
        {
            get => new Vector3d(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d rar
        {
            get => new Vector3d(X, W, X);
        }

        [XmlIgnore]
        public Vector3d rag
        {
            get => new Vector3d(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d rab
        {
            get => new Vector3d(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d raa
        {
            get => new Vector3d(X, W, W);
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
        public Vector3d gra
        {
            get => new Vector3d(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3d gga
        {
            get => new Vector3d(Y, Y, W);
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
        public Vector3d gba
        {
            get => new Vector3d(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d gar
        {
            get => new Vector3d(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d gag
        {
            get => new Vector3d(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3d gab
        {
            get => new Vector3d(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d gaa
        {
            get => new Vector3d(Y, W, W);
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
        public Vector3d bra
        {
            get => new Vector3d(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3d bga
        {
            get => new Vector3d(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3d bba
        {
            get => new Vector3d(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3d bar
        {
            get => new Vector3d(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d bag
        {
            get => new Vector3d(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d bab
        {
            get => new Vector3d(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3d baa
        {
            get => new Vector3d(Z, W, W);
        }

        [XmlIgnore]
        public Vector3d arr
        {
            get => new Vector3d(W, X, X);
        }

        [XmlIgnore]
        public Vector3d arg
        {
            get => new Vector3d(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d arb
        {
            get => new Vector3d(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d ara
        {
            get => new Vector3d(W, X, W);
        }

        [XmlIgnore]
        public Vector3d agr
        {
            get => new Vector3d(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d agg
        {
            get => new Vector3d(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3d agb
        {
            get => new Vector3d(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d aga
        {
            get => new Vector3d(W, Y, W);
        }

        [XmlIgnore]
        public Vector3d abr
        {
            get => new Vector3d(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d abg
        {
            get => new Vector3d(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d abb
        {
            get => new Vector3d(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3d aba
        {
            get => new Vector3d(W, Z, W);
        }

        [XmlIgnore]
        public Vector3d aar
        {
            get => new Vector3d(W, W, X);
        }

        [XmlIgnore]
        public Vector3d aag
        {
            get => new Vector3d(W, W, Y);
        }

        [XmlIgnore]
        public Vector3d aab
        {
            get => new Vector3d(W, W, Z);
        }

        [XmlIgnore]
        public Vector3d aaa
        {
            get => new Vector3d(W, W, W);
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
        public Vector4d rrra
        {
            get => new Vector4d(X, X, X, W);
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
        public Vector4d rrga
        {
            get => new Vector4d(X, X, Y, W);
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
        public Vector4d rrba
        {
            get => new Vector4d(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d rrar
        {
            get => new Vector4d(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4d rrag
        {
            get => new Vector4d(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d rrab
        {
            get => new Vector4d(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d rraa
        {
            get => new Vector4d(X, X, W, W);
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
        public Vector4d rgra
        {
            get => new Vector4d(X, Y, X, W);
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
        public Vector4d rgga
        {
            get => new Vector4d(X, Y, Y, W);
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
        public Vector4d rgba
        {
            get => new Vector4d(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d rgar
        {
            get => new Vector4d(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d rgag
        {
            get => new Vector4d(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d rgab
        {
            get => new Vector4d(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d rgaa
        {
            get => new Vector4d(X, Y, W, W);
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
        public Vector4d rbra
        {
            get => new Vector4d(X, Z, X, W);
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
        public Vector4d rbga
        {
            get => new Vector4d(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d rbba
        {
            get => new Vector4d(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d rbar
        {
            get => new Vector4d(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d rbag
        {
            get => new Vector4d(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d rbab
        {
            get => new Vector4d(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d rbaa
        {
            get => new Vector4d(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d rarr
        {
            get => new Vector4d(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4d rarg
        {
            get => new Vector4d(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d rarb
        {
            get => new Vector4d(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d rara
        {
            get => new Vector4d(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4d ragr
        {
            get => new Vector4d(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d ragg
        {
            get => new Vector4d(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d ragb
        {
            get => new Vector4d(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d raga
        {
            get => new Vector4d(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d rabr
        {
            get => new Vector4d(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d rabg
        {
            get => new Vector4d(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d rabb
        {
            get => new Vector4d(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d raba
        {
            get => new Vector4d(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d raar
        {
            get => new Vector4d(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4d raag
        {
            get => new Vector4d(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d raab
        {
            get => new Vector4d(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d raaa
        {
            get => new Vector4d(X, W, W, W);
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
        public Vector4d grra
        {
            get => new Vector4d(Y, X, X, W);
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
        public Vector4d grga
        {
            get => new Vector4d(Y, X, Y, W);
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
        public Vector4d grba
        {
            get => new Vector4d(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d grar
        {
            get => new Vector4d(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4d grag
        {
            get => new Vector4d(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d grab
        {
            get => new Vector4d(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d graa
        {
            get => new Vector4d(Y, X, W, W);
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
        public Vector4d ggra
        {
            get => new Vector4d(Y, Y, X, W);
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
        public Vector4d ggga
        {
            get => new Vector4d(Y, Y, Y, W);
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
        public Vector4d ggba
        {
            get => new Vector4d(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d ggar
        {
            get => new Vector4d(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d ggag
        {
            get => new Vector4d(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d ggab
        {
            get => new Vector4d(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d ggaa
        {
            get => new Vector4d(Y, Y, W, W);
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
        public Vector4d gbra
        {
            get => new Vector4d(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d gbga
        {
            get => new Vector4d(Y, Z, Y, W);
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
        public Vector4d gbba
        {
            get => new Vector4d(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d gbar
        {
            get => new Vector4d(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d gbag
        {
            get => new Vector4d(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d gbab
        {
            get => new Vector4d(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d gbaa
        {
            get => new Vector4d(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d garr
        {
            get => new Vector4d(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4d garg
        {
            get => new Vector4d(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d garb
        {
            get => new Vector4d(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d gara
        {
            get => new Vector4d(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4d gagr
        {
            get => new Vector4d(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d gagg
        {
            get => new Vector4d(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d gagb
        {
            get => new Vector4d(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d gaga
        {
            get => new Vector4d(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d gabr
        {
            get => new Vector4d(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d gabg
        {
            get => new Vector4d(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d gabb
        {
            get => new Vector4d(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d gaba
        {
            get => new Vector4d(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d gaar
        {
            get => new Vector4d(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4d gaag
        {
            get => new Vector4d(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d gaab
        {
            get => new Vector4d(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d gaaa
        {
            get => new Vector4d(Y, W, W, W);
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
        public Vector4d brra
        {
            get => new Vector4d(Z, X, X, W);
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
        public Vector4d brga
        {
            get => new Vector4d(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d brba
        {
            get => new Vector4d(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d brar
        {
            get => new Vector4d(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4d brag
        {
            get => new Vector4d(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d brab
        {
            get => new Vector4d(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d braa
        {
            get => new Vector4d(Z, X, W, W);
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
        public Vector4d bgra
        {
            get => new Vector4d(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d bgga
        {
            get => new Vector4d(Z, Y, Y, W);
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
        public Vector4d bgba
        {
            get => new Vector4d(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d bgar
        {
            get => new Vector4d(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d bgag
        {
            get => new Vector4d(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d bgab
        {
            get => new Vector4d(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d bgaa
        {
            get => new Vector4d(Z, Y, W, W);
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
        public Vector4d bbra
        {
            get => new Vector4d(Z, Z, X, W);
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
        public Vector4d bbga
        {
            get => new Vector4d(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4d bbba
        {
            get => new Vector4d(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d bbar
        {
            get => new Vector4d(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d bbag
        {
            get => new Vector4d(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d bbab
        {
            get => new Vector4d(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d bbaa
        {
            get => new Vector4d(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d barr
        {
            get => new Vector4d(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4d barg
        {
            get => new Vector4d(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d barb
        {
            get => new Vector4d(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d bara
        {
            get => new Vector4d(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4d bagr
        {
            get => new Vector4d(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d bagg
        {
            get => new Vector4d(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d bagb
        {
            get => new Vector4d(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d baga
        {
            get => new Vector4d(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d babr
        {
            get => new Vector4d(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d babg
        {
            get => new Vector4d(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d babb
        {
            get => new Vector4d(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d baba
        {
            get => new Vector4d(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d baar
        {
            get => new Vector4d(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4d baag
        {
            get => new Vector4d(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d baab
        {
            get => new Vector4d(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d baaa
        {
            get => new Vector4d(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4d arrr
        {
            get => new Vector4d(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4d arrg
        {
            get => new Vector4d(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d arrb
        {
            get => new Vector4d(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d arra
        {
            get => new Vector4d(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4d argr
        {
            get => new Vector4d(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d argg
        {
            get => new Vector4d(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d argb
        {
            get => new Vector4d(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d arga
        {
            get => new Vector4d(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4d arbr
        {
            get => new Vector4d(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d arbg
        {
            get => new Vector4d(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d arbb
        {
            get => new Vector4d(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d arba
        {
            get => new Vector4d(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d arar
        {
            get => new Vector4d(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4d arag
        {
            get => new Vector4d(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d arab
        {
            get => new Vector4d(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d araa
        {
            get => new Vector4d(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4d agrr
        {
            get => new Vector4d(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d agrg
        {
            get => new Vector4d(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d agrb
        {
            get => new Vector4d(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d agra
        {
            get => new Vector4d(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4d aggr
        {
            get => new Vector4d(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d aggg
        {
            get => new Vector4d(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d aggb
        {
            get => new Vector4d(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d agga
        {
            get => new Vector4d(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4d agbr
        {
            get => new Vector4d(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d agbg
        {
            get => new Vector4d(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d agbb
        {
            get => new Vector4d(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d agba
        {
            get => new Vector4d(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d agar
        {
            get => new Vector4d(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d agag
        {
            get => new Vector4d(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d agab
        {
            get => new Vector4d(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d agaa
        {
            get => new Vector4d(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4d abrr
        {
            get => new Vector4d(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d abrg
        {
            get => new Vector4d(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d abrb
        {
            get => new Vector4d(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d abra
        {
            get => new Vector4d(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4d abgr
        {
            get => new Vector4d(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d abgg
        {
            get => new Vector4d(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d abgb
        {
            get => new Vector4d(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d abga
        {
            get => new Vector4d(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4d abbr
        {
            get => new Vector4d(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d abbg
        {
            get => new Vector4d(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d abbb
        {
            get => new Vector4d(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d abba
        {
            get => new Vector4d(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d abar
        {
            get => new Vector4d(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d abag
        {
            get => new Vector4d(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d abab
        {
            get => new Vector4d(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d abaa
        {
            get => new Vector4d(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d aarr
        {
            get => new Vector4d(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4d aarg
        {
            get => new Vector4d(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d aarb
        {
            get => new Vector4d(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d aara
        {
            get => new Vector4d(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4d aagr
        {
            get => new Vector4d(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d aagg
        {
            get => new Vector4d(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d aagb
        {
            get => new Vector4d(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d aaga
        {
            get => new Vector4d(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d aabr
        {
            get => new Vector4d(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d aabg
        {
            get => new Vector4d(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d aabb
        {
            get => new Vector4d(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d aaba
        {
            get => new Vector4d(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d aaar
        {
            get => new Vector4d(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4d aaag
        {
            get => new Vector4d(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d aaab
        {
            get => new Vector4d(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d aaaa
        {
            get => new Vector4d(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
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
        public double q
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2d sq
        {
            get => new Vector2d(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2d tq
        {
            get => new Vector2d(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2d pq
        {
            get => new Vector2d(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d qs
        {
            get => new Vector2d(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d qt
        {
            get => new Vector2d(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d qp
        {
            get => new Vector2d(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2d qq
        {
            get => new Vector2d(W, W);
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
        public Vector3d ssq
        {
            get => new Vector3d(X, X, W);
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
        public Vector3d stq
        {
            get => new Vector3d(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3d spq
        {
            get => new Vector3d(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d sqs
        {
            get => new Vector3d(X, W, X);
        }

        [XmlIgnore]
        public Vector3d sqt
        {
            get => new Vector3d(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d sqp
        {
            get => new Vector3d(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d sqq
        {
            get => new Vector3d(X, W, W);
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
        public Vector3d tsq
        {
            get => new Vector3d(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3d ttq
        {
            get => new Vector3d(Y, Y, W);
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
        public Vector3d tpq
        {
            get => new Vector3d(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d tqs
        {
            get => new Vector3d(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d tqt
        {
            get => new Vector3d(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3d tqp
        {
            get => new Vector3d(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d tqq
        {
            get => new Vector3d(Y, W, W);
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
        public Vector3d psq
        {
            get => new Vector3d(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3d ptq
        {
            get => new Vector3d(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3d ppq
        {
            get => new Vector3d(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3d pqs
        {
            get => new Vector3d(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d pqt
        {
            get => new Vector3d(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d pqp
        {
            get => new Vector3d(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3d pqq
        {
            get => new Vector3d(Z, W, W);
        }

        [XmlIgnore]
        public Vector3d qss
        {
            get => new Vector3d(W, X, X);
        }

        [XmlIgnore]
        public Vector3d qst
        {
            get => new Vector3d(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qsp
        {
            get => new Vector3d(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qsq
        {
            get => new Vector3d(W, X, W);
        }

        [XmlIgnore]
        public Vector3d qts
        {
            get => new Vector3d(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qtt
        {
            get => new Vector3d(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3d qtp
        {
            get => new Vector3d(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qtq
        {
            get => new Vector3d(W, Y, W);
        }

        [XmlIgnore]
        public Vector3d qps
        {
            get => new Vector3d(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qpt
        {
            get => new Vector3d(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3d qpp
        {
            get => new Vector3d(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3d qpq
        {
            get => new Vector3d(W, Z, W);
        }

        [XmlIgnore]
        public Vector3d qqs
        {
            get => new Vector3d(W, W, X);
        }

        [XmlIgnore]
        public Vector3d qqt
        {
            get => new Vector3d(W, W, Y);
        }

        [XmlIgnore]
        public Vector3d qqp
        {
            get => new Vector3d(W, W, Z);
        }

        [XmlIgnore]
        public Vector3d qqq
        {
            get => new Vector3d(W, W, W);
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
        public Vector4d sssq
        {
            get => new Vector4d(X, X, X, W);
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
        public Vector4d sstq
        {
            get => new Vector4d(X, X, Y, W);
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
        public Vector4d sspq
        {
            get => new Vector4d(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d ssqs
        {
            get => new Vector4d(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4d ssqt
        {
            get => new Vector4d(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d ssqp
        {
            get => new Vector4d(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d ssqq
        {
            get => new Vector4d(X, X, W, W);
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
        public Vector4d stsq
        {
            get => new Vector4d(X, Y, X, W);
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
        public Vector4d sttq
        {
            get => new Vector4d(X, Y, Y, W);
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
        public Vector4d stpq
        {
            get => new Vector4d(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d stqs
        {
            get => new Vector4d(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d stqt
        {
            get => new Vector4d(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d stqp
        {
            get => new Vector4d(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d stqq
        {
            get => new Vector4d(X, Y, W, W);
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
        public Vector4d spsq
        {
            get => new Vector4d(X, Z, X, W);
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
        public Vector4d sptq
        {
            get => new Vector4d(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d sppq
        {
            get => new Vector4d(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d spqs
        {
            get => new Vector4d(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d spqt
        {
            get => new Vector4d(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d spqp
        {
            get => new Vector4d(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d spqq
        {
            get => new Vector4d(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d sqss
        {
            get => new Vector4d(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4d sqst
        {
            get => new Vector4d(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d sqsp
        {
            get => new Vector4d(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d sqsq
        {
            get => new Vector4d(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4d sqts
        {
            get => new Vector4d(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d sqtt
        {
            get => new Vector4d(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d sqtp
        {
            get => new Vector4d(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d sqtq
        {
            get => new Vector4d(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d sqps
        {
            get => new Vector4d(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d sqpt
        {
            get => new Vector4d(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d sqpp
        {
            get => new Vector4d(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d sqpq
        {
            get => new Vector4d(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d sqqs
        {
            get => new Vector4d(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4d sqqt
        {
            get => new Vector4d(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d sqqp
        {
            get => new Vector4d(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d sqqq
        {
            get => new Vector4d(X, W, W, W);
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
        public Vector4d tssq
        {
            get => new Vector4d(Y, X, X, W);
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
        public Vector4d tstq
        {
            get => new Vector4d(Y, X, Y, W);
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
        public Vector4d tspq
        {
            get => new Vector4d(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d tsqs
        {
            get => new Vector4d(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4d tsqt
        {
            get => new Vector4d(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d tsqp
        {
            get => new Vector4d(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d tsqq
        {
            get => new Vector4d(Y, X, W, W);
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
        public Vector4d ttsq
        {
            get => new Vector4d(Y, Y, X, W);
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
        public Vector4d tttq
        {
            get => new Vector4d(Y, Y, Y, W);
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
        public Vector4d ttpq
        {
            get => new Vector4d(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d ttqs
        {
            get => new Vector4d(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d ttqt
        {
            get => new Vector4d(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d ttqp
        {
            get => new Vector4d(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d ttqq
        {
            get => new Vector4d(Y, Y, W, W);
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
        public Vector4d tpsq
        {
            get => new Vector4d(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d tptq
        {
            get => new Vector4d(Y, Z, Y, W);
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
        public Vector4d tppq
        {
            get => new Vector4d(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d tpqs
        {
            get => new Vector4d(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d tpqt
        {
            get => new Vector4d(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d tpqp
        {
            get => new Vector4d(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d tpqq
        {
            get => new Vector4d(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d tqss
        {
            get => new Vector4d(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4d tqst
        {
            get => new Vector4d(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d tqsp
        {
            get => new Vector4d(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d tqsq
        {
            get => new Vector4d(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4d tqts
        {
            get => new Vector4d(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d tqtt
        {
            get => new Vector4d(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d tqtp
        {
            get => new Vector4d(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d tqtq
        {
            get => new Vector4d(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d tqps
        {
            get => new Vector4d(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d tqpt
        {
            get => new Vector4d(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d tqpp
        {
            get => new Vector4d(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d tqpq
        {
            get => new Vector4d(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d tqqs
        {
            get => new Vector4d(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4d tqqt
        {
            get => new Vector4d(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d tqqp
        {
            get => new Vector4d(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d tqqq
        {
            get => new Vector4d(Y, W, W, W);
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
        public Vector4d pssq
        {
            get => new Vector4d(Z, X, X, W);
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
        public Vector4d pstq
        {
            get => new Vector4d(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4d pspq
        {
            get => new Vector4d(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d psqs
        {
            get => new Vector4d(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4d psqt
        {
            get => new Vector4d(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d psqp
        {
            get => new Vector4d(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d psqq
        {
            get => new Vector4d(Z, X, W, W);
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
        public Vector4d ptsq
        {
            get => new Vector4d(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4d pttq
        {
            get => new Vector4d(Z, Y, Y, W);
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
        public Vector4d ptpq
        {
            get => new Vector4d(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d ptqs
        {
            get => new Vector4d(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d ptqt
        {
            get => new Vector4d(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d ptqp
        {
            get => new Vector4d(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d ptqq
        {
            get => new Vector4d(Z, Y, W, W);
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
        public Vector4d ppsq
        {
            get => new Vector4d(Z, Z, X, W);
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
        public Vector4d pptq
        {
            get => new Vector4d(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4d pppq
        {
            get => new Vector4d(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d ppqs
        {
            get => new Vector4d(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d ppqt
        {
            get => new Vector4d(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d ppqp
        {
            get => new Vector4d(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d ppqq
        {
            get => new Vector4d(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d pqss
        {
            get => new Vector4d(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4d pqst
        {
            get => new Vector4d(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d pqsp
        {
            get => new Vector4d(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d pqsq
        {
            get => new Vector4d(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4d pqts
        {
            get => new Vector4d(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d pqtt
        {
            get => new Vector4d(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d pqtp
        {
            get => new Vector4d(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d pqtq
        {
            get => new Vector4d(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d pqps
        {
            get => new Vector4d(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d pqpt
        {
            get => new Vector4d(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d pqpp
        {
            get => new Vector4d(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d pqpq
        {
            get => new Vector4d(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d pqqs
        {
            get => new Vector4d(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4d pqqt
        {
            get => new Vector4d(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d pqqp
        {
            get => new Vector4d(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d pqqq
        {
            get => new Vector4d(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4d qsss
        {
            get => new Vector4d(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4d qsst
        {
            get => new Vector4d(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4d qssp
        {
            get => new Vector4d(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4d qssq
        {
            get => new Vector4d(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4d qsts
        {
            get => new Vector4d(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4d qstt
        {
            get => new Vector4d(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4d qstp
        {
            get => new Vector4d(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qstq
        {
            get => new Vector4d(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4d qsps
        {
            get => new Vector4d(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4d qspt
        {
            get => new Vector4d(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qspp
        {
            get => new Vector4d(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4d qspq
        {
            get => new Vector4d(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4d qsqs
        {
            get => new Vector4d(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4d qsqt
        {
            get => new Vector4d(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4d qsqp
        {
            get => new Vector4d(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4d qsqq
        {
            get => new Vector4d(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4d qtss
        {
            get => new Vector4d(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4d qtst
        {
            get => new Vector4d(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4d qtsp
        {
            get => new Vector4d(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qtsq
        {
            get => new Vector4d(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4d qtts
        {
            get => new Vector4d(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4d qttt
        {
            get => new Vector4d(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4d qttp
        {
            get => new Vector4d(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4d qttq
        {
            get => new Vector4d(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4d qtps
        {
            get => new Vector4d(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qtpt
        {
            get => new Vector4d(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4d qtpp
        {
            get => new Vector4d(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4d qtpq
        {
            get => new Vector4d(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4d qtqs
        {
            get => new Vector4d(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4d qtqt
        {
            get => new Vector4d(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4d qtqp
        {
            get => new Vector4d(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4d qtqq
        {
            get => new Vector4d(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4d qpss
        {
            get => new Vector4d(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4d qpst
        {
            get => new Vector4d(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qpsp
        {
            get => new Vector4d(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4d qpsq
        {
            get => new Vector4d(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4d qpts
        {
            get => new Vector4d(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4d qptt
        {
            get => new Vector4d(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4d qptp
        {
            get => new Vector4d(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4d qptq
        {
            get => new Vector4d(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4d qpps
        {
            get => new Vector4d(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4d qppt
        {
            get => new Vector4d(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4d qppp
        {
            get => new Vector4d(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4d qppq
        {
            get => new Vector4d(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4d qpqs
        {
            get => new Vector4d(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4d qpqt
        {
            get => new Vector4d(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4d qpqp
        {
            get => new Vector4d(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4d qpqq
        {
            get => new Vector4d(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4d qqss
        {
            get => new Vector4d(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4d qqst
        {
            get => new Vector4d(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4d qqsp
        {
            get => new Vector4d(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4d qqsq
        {
            get => new Vector4d(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4d qqts
        {
            get => new Vector4d(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4d qqtt
        {
            get => new Vector4d(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4d qqtp
        {
            get => new Vector4d(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4d qqtq
        {
            get => new Vector4d(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4d qqps
        {
            get => new Vector4d(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4d qqpt
        {
            get => new Vector4d(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4d qqpp
        {
            get => new Vector4d(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4d qqpq
        {
            get => new Vector4d(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4d qqqs
        {
            get => new Vector4d(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4d qqqt
        {
            get => new Vector4d(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4d qqqp
        {
            get => new Vector4d(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4d qqqq
        {
            get => new Vector4d(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4d operator +(Vector4d left, Vector4d right)
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
        public static Vector4d operator -(Vector4d left, Vector4d right)
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
        public static Vector4d operator -(Vector4d vec)
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
        public static Vector4d operator *(Vector4d vec, double scale)
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
        public static Vector4d operator *(double scale, Vector4d vec)
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
        public static Vector4d operator *(Vector4d vec, Vector4d scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            vec.W *= scale.W;
            return vec;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="vec">The vector to transform.</param>
        /// <returns>The transformed vector.</returns>
        [Pure]
        public static Vector4d operator *(Quaterniond quat, Vector4d vec)
        {
            Transform(ref vec, ref quat, out Vector4d result);
            return result;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4d operator /(Vector4d vec, double scale)
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
        public static bool operator ==(Vector4d left, Vector4d right)
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
        public static bool operator !=(Vector4d left, Vector4d right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static unsafe explicit operator double*(Vector4d v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static explicit operator IntPtr(Vector4d v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Converts OpenToolkit.Vector4 to OpenToolkit.Vector4d.
        /// </summary>
        /// <param name="v4">The Vector4 to convert.</param>
        /// <returns>The resulting Vector4d.</returns>
        [Pure]
        public static explicit operator Vector4d(Vector4 v4)
        {
            return new Vector4d(v4.X, v4.Y, v4.Z, v4.W);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector4d to OpenToolkit.Vector4.
        /// </summary>
        /// <param name="v4d">The Vector4d to convert.</param>
        /// <returns>The resulting Vector4.</returns>
        [Pure]
        public static explicit operator Vector4(Vector4d v4d)
        {
            return new Vector4((float)v4d.X, (float)v4d.Y, (float)v4d.Z, (float)v4d.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4d"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4d"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4d((double X, double Y, double Z, double W) values)
        {
            return new Vector4d(values.X, values.Y, values.Z, values.W);
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
            if (!(obj is Vector4d))
            {
                return false;
            }

            return Equals((Vector4d)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector4d other)
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
        public void Deconstruct(out double x, out double y, out double z, out double w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
