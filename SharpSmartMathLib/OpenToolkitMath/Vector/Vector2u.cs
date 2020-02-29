//
//  Vector3i.cs
//
//  Copyright (C) OpenTK
//
//  This software may be modified and distributed under the terms
//  of the MIT license. See the LICENSE file for details.
//

using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenToolkit.Mathematics
{
    /// <summary>
    /// Represents a 2D vector using two 32-bit unsigned integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector2u structure is suitable for interoperation with unmanaged code requiring two consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2u : IEquatable<Vector2u>
    {
        /// <summary>
        /// The X component of the Vector2u.
        /// </summary>
        public uint X;

        /// <summary>
        /// The Y component of the Vector2u.
        /// </summary>
        public uint Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2u"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2u(uint value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2u"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector2u.</param>
        /// <param name="y">The Y component of the Vector2u.</param>
        public Vector2u(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the value at the index of the vector.
        /// </summary>
        /// <param name="index">The index of the component from the vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 1.</exception>
        public uint this[int index]
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
                else
                {
                    throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
                }
            }
        }

        /// <summary>
        /// Defines a unit-length <see cref="Vector2u"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector2u UnitX = new Vector2u(1, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector2u"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector2u UnitY = new Vector2u(0, 1);

        /// <summary>
        /// Defines a zero-length <see cref="Vector2u"/>.
        /// </summary>
        public static readonly Vector2u Zero = new Vector2u(0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector2u One = new Vector2u(1, 1);

        /// <summary>
        /// Defines the size of the <see cref="Vector2u"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector2u>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector2u Add(Vector2u a, Vector2u b)
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
        public static void Add(ref Vector2u a, ref Vector2u b, out Vector2u result)
        {
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
        }

        /// <summary>
        /// Subtract one Vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>Result of subtraction.</returns>
        [Pure]
        public static Vector2u Subtract(Vector2u a, Vector2u b)
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
        public static void Subtract(ref Vector2u a, ref Vector2u b, out Vector2u result)
        {
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
        }

        /// <summary>
        /// Multiplies a vector by an integer scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector2u Multiply(Vector2u vector, uint scale)
        {
            Multiply(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Multiplies a vector by an integer scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector2u vector, uint scale, out Vector2u result)
        {
            result.X = vector.X * scale;
            result.Y = vector.Y * scale;
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector2u Multiply(Vector2u vector, Vector2u scale)
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
        public static void Multiply(ref Vector2u vector, ref Vector2u scale, out Vector2u result)
        {
            result.X = vector.X * scale.X;
            result.Y = vector.Y * scale.Y;
        }

        /// <summary>
        /// Divides a vector by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector2u Divide(Vector2u vector, uint scale)
        {
            Divide(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divides a vector by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector2u vector, uint scale, out Vector2u result)
        {
            result.X = vector.X / scale;
            result.Y = vector.Y / scale;
        }

        /// <summary>
        /// Divides a vector by the components of a vector using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector2u Divide(Vector2u vector, Vector2u scale)
        {
            Divide(ref vector, ref scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divides a vector by the components of a vector using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector2u vector, ref Vector2u scale, out Vector2u result)
        {
            result.X = vector.X / scale.X;
            result.Y = vector.Y / scale.Y;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector2u ComponentMin(Vector2u a, Vector2u b)
        {
            a.X = a.X < b.X ? a.X : b.X;
            a.Y = a.Y < b.Y ? a.Y : b.Y;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector2u a, ref Vector2u b, out Vector2u result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector2u ComponentMax(Vector2u a, Vector2u b)
        {
            a.X = a.X > b.X ? a.X : b.X;
            a.Y = a.Y > b.Y ? a.Y : b.Y;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector2u a, ref Vector2u b, out Vector2u result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <returns>The clamped vector.</returns>
        [Pure]
        public static Vector2u Clamp(Vector2u vec, Vector2u min, Vector2u max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <param name="result">The clamped vector.</param>
        public static void Clamp(ref Vector2u vec, ref Vector2u min, ref Vector2u max, out Vector2u result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Yx
        {
            get => new Vector2u(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        #region Coords: x, y
        [XmlIgnore]
        public uint x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public uint y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2u xx
        {
            get => new Vector2u(X, X);
        }

        [XmlIgnore]
        public Vector2u xy
        {
            get => new Vector2u(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u yx
        {
            get => new Vector2u(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u yy
        {
            get => new Vector2u(Y, Y);
        }

        [XmlIgnore]
        public Vector3u xxx
        {
            get => new Vector3u(X, X, X);
        }

        [XmlIgnore]
        public Vector3u xxy
        {
            get => new Vector3u(X, X, Y);
        }

        [XmlIgnore]
        public Vector3u xyx
        {
            get => new Vector3u(X, Y, X);
        }

        [XmlIgnore]
        public Vector3u xyy
        {
            get => new Vector3u(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3u yxx
        {
            get => new Vector3u(Y, X, X);
        }

        [XmlIgnore]
        public Vector3u yxy
        {
            get => new Vector3u(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3u yyx
        {
            get => new Vector3u(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3u yyy
        {
            get => new Vector3u(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u xxxx
        {
            get => new Vector4u(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4u xxxy
        {
            get => new Vector4u(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u xxyx
        {
            get => new Vector4u(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u xxyy
        {
            get => new Vector4u(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u xyxx
        {
            get => new Vector4u(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u xyxy
        {
            get => new Vector4u(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u xyyx
        {
            get => new Vector4u(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u xyyy
        {
            get => new Vector4u(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u yxxx
        {
            get => new Vector4u(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4u yxxy
        {
            get => new Vector4u(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u yxyx
        {
            get => new Vector4u(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u yxyy
        {
            get => new Vector4u(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u yyxx
        {
            get => new Vector4u(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u yyxy
        {
            get => new Vector4u(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u yyyx
        {
            get => new Vector4u(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u yyyy
        {
            get => new Vector4u(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: r, g
        [XmlIgnore]
        public uint r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public uint g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2u rr
        {
            get => new Vector2u(X, X);
        }

        [XmlIgnore]
        public Vector2u rg
        {
            get => new Vector2u(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u gr
        {
            get => new Vector2u(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u gg
        {
            get => new Vector2u(Y, Y);
        }

        [XmlIgnore]
        public Vector3u rrr
        {
            get => new Vector3u(X, X, X);
        }

        [XmlIgnore]
        public Vector3u rrg
        {
            get => new Vector3u(X, X, Y);
        }

        [XmlIgnore]
        public Vector3u rgr
        {
            get => new Vector3u(X, Y, X);
        }

        [XmlIgnore]
        public Vector3u rgg
        {
            get => new Vector3u(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3u grr
        {
            get => new Vector3u(Y, X, X);
        }

        [XmlIgnore]
        public Vector3u grg
        {
            get => new Vector3u(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3u ggr
        {
            get => new Vector3u(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3u ggg
        {
            get => new Vector3u(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u rrrr
        {
            get => new Vector4u(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4u rrrg
        {
            get => new Vector4u(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u rrgr
        {
            get => new Vector4u(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u rrgg
        {
            get => new Vector4u(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u rgrr
        {
            get => new Vector4u(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u rgrg
        {
            get => new Vector4u(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u rggr
        {
            get => new Vector4u(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u rggg
        {
            get => new Vector4u(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u grrr
        {
            get => new Vector4u(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4u grrg
        {
            get => new Vector4u(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u grgr
        {
            get => new Vector4u(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u grgg
        {
            get => new Vector4u(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u ggrr
        {
            get => new Vector4u(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u ggrg
        {
            get => new Vector4u(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u gggr
        {
            get => new Vector4u(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u gggg
        {
            get => new Vector4u(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: s, t
        [XmlIgnore]
        public uint s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public uint t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2u ss
        {
            get => new Vector2u(X, X);
        }

        [XmlIgnore]
        public Vector2u st
        {
            get => new Vector2u(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ts
        {
            get => new Vector2u(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u tt
        {
            get => new Vector2u(Y, Y);
        }

        [XmlIgnore]
        public Vector3u sss
        {
            get => new Vector3u(X, X, X);
        }

        [XmlIgnore]
        public Vector3u sst
        {
            get => new Vector3u(X, X, Y);
        }

        [XmlIgnore]
        public Vector3u sts
        {
            get => new Vector3u(X, Y, X);
        }

        [XmlIgnore]
        public Vector3u stt
        {
            get => new Vector3u(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3u tss
        {
            get => new Vector3u(Y, X, X);
        }

        [XmlIgnore]
        public Vector3u tst
        {
            get => new Vector3u(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3u tts
        {
            get => new Vector3u(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3u ttt
        {
            get => new Vector3u(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u ssss
        {
            get => new Vector4u(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4u ssst
        {
            get => new Vector4u(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u ssts
        {
            get => new Vector4u(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u sstt
        {
            get => new Vector4u(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u stss
        {
            get => new Vector4u(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u stst
        {
            get => new Vector4u(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u stts
        {
            get => new Vector4u(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u sttt
        {
            get => new Vector4u(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u tsss
        {
            get => new Vector4u(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4u tsst
        {
            get => new Vector4u(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u tsts
        {
            get => new Vector4u(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u tstt
        {
            get => new Vector4u(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u ttss
        {
            get => new Vector4u(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u ttst
        {
            get => new Vector4u(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u ttts
        {
            get => new Vector4u(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u tttt
        {
            get => new Vector4u(Y, Y, Y, Y);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2u"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector2"/> instance.</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2u"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector2u"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector2"/>.</param>
        public static void ToVector2(ref Vector2u input, out Vector2 result)
        {
            result.X = input.X;
            result.Y = input.Y;
        }

        /// <summary>
        /// Adds the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of addition.</returns>
        [Pure]
        public static Vector2u operator +(Vector2u left, Vector2u right)
        {
            left.X += right.X;
            left.Y += right.Y;
            return left;
        }

        /// <summary>
        /// Subtracts the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of subtraction.</returns>
        [Pure]
        public static Vector2u operator -(Vector2u left, Vector2u right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            return left;
        }

        /// <summary>
        /// Multiplies the specified instance by a scalar.
        /// </summary>
        /// <param name="vec">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector2u operator *(Vector2u vec, uint scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies the specified instance by a scalar.
        /// </summary>
        /// <param name="scale">Left operand.</param>
        /// <param name="vec">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector2u operator *(uint scale, Vector2u vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Component-wise multiplication between the specified instance by a scale vector.
        /// </summary>
        /// <param name="scale">Left operand.</param>
        /// <param name="vec">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector2u operator *(Vector2u vec, Vector2u scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            return vec;
        }

        /// <summary>
        /// Divides the instance by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vec">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the division.</returns>
        [Pure]
        public static Vector2u operator /(Vector2u vec, uint scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            return vec;
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector2u left, Vector2u right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares the specified instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        [Pure]
        public static bool operator !=(Vector2u left, Vector2u right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2u"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector2u"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector2u((uint X, uint Y) values)
        {
            return new Vector2u(values.X, values.Y);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("({0}{2} {1})", X, Y, ListSeparator);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 1531;
                hashCode *= 1319 + (int)X;
                hashCode *= 1319 + (int)Y;
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
            if (!(obj is Vector2u))
            {
                return false;
            }

            return Equals((Vector2u)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector2u other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        [Pure]
        public void Deconstruct(out uint x, out uint y)
        {
            x = X;
            y = Y;
        }
    }
}