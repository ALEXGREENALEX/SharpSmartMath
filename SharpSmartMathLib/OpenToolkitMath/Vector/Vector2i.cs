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
    /// Represents a 2D vector using two 32-bit integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector2i structure is suitable for interoperation with unmanaged code requiring two consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2i : IEquatable<Vector2i>
    {
        /// <summary>
        /// The X component of the Vector2i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y component of the Vector2i.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2i"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2i(int value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2i"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector2i.</param>
        /// <param name="y">The Y component of the Vector2i.</param>
        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the value at the index of the vector.
        /// </summary>
        /// <param name="index">The index of the component from the vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 1.</exception>
        public int this[int index]
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
        /// Gets the perpendicular vector on the right side of this vector.
        /// </summary>
        public Vector2i PerpendicularRight => new Vector2i(Y, -X);

        /// <summary>
        /// Gets the perpendicular vector on the left side of this vector.
        /// </summary>
        public Vector2i PerpendicularLeft => new Vector2i(-Y, X);

        /// <summary>
        /// Defines a unit-length <see cref="Vector2i"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector2i UnitX = new Vector2i(1, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector2i"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector2i UnitY = new Vector2i(0, 1);

        /// <summary>
        /// Defines a zero-length <see cref="Vector2i"/>.
        /// </summary>
        public static readonly Vector2i Zero = new Vector2i(0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector2i One = new Vector2i(1, 1);

        /// <summary>
        /// Defines the size of the <see cref="Vector2i"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector2i>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector2i Add(Vector2i a, Vector2i b)
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
        public static void Add(ref Vector2i a, ref Vector2i b, out Vector2i result)
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
        public static Vector2i Subtract(Vector2i a, Vector2i b)
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
        public static void Subtract(ref Vector2i a, ref Vector2i b, out Vector2i result)
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
        public static Vector2i Multiply(Vector2i vector, int scale)
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
        public static void Multiply(ref Vector2i vector, int scale, out Vector2i result)
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
        public static Vector2i Multiply(Vector2i vector, Vector2i scale)
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
        public static void Multiply(ref Vector2i vector, ref Vector2i scale, out Vector2i result)
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
        public static Vector2i Divide(Vector2i vector, int scale)
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
        public static void Divide(ref Vector2i vector, int scale, out Vector2i result)
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
        public static Vector2i Divide(Vector2i vector, Vector2i scale)
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
        public static void Divide(ref Vector2i vector, ref Vector2i scale, out Vector2i result)
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
        public static Vector2i ComponentMin(Vector2i a, Vector2i b)
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
        public static void ComponentMin(ref Vector2i a, ref Vector2i b, out Vector2i result)
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
        public static Vector2i ComponentMax(Vector2i a, Vector2i b)
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
        public static void ComponentMax(ref Vector2i a, ref Vector2i b, out Vector2i result)
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
        public static Vector2i Clamp(Vector2i vec, Vector2i min, Vector2i max)
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
        public static void Clamp(ref Vector2i vec, ref Vector2i min, ref Vector2i max, out Vector2i result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Yx
        {
            get => new Vector2i(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        #region Coords: x, y
        [XmlIgnore]
        public int x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public int y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2i xx
        {
            get => new Vector2i(X, X);
        }

        [XmlIgnore]
        public Vector2i xy
        {
            get => new Vector2i(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i yx
        {
            get => new Vector2i(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i yy
        {
            get => new Vector2i(Y, Y);
        }

        [XmlIgnore]
        public Vector3i xxx
        {
            get => new Vector3i(X, X, X);
        }

        [XmlIgnore]
        public Vector3i xxy
        {
            get => new Vector3i(X, X, Y);
        }

        [XmlIgnore]
        public Vector3i xyx
        {
            get => new Vector3i(X, Y, X);
        }

        [XmlIgnore]
        public Vector3i xyy
        {
            get => new Vector3i(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3i yxx
        {
            get => new Vector3i(Y, X, X);
        }

        [XmlIgnore]
        public Vector3i yxy
        {
            get => new Vector3i(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3i yyx
        {
            get => new Vector3i(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3i yyy
        {
            get => new Vector3i(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i xxxx
        {
            get => new Vector4i(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4i xxxy
        {
            get => new Vector4i(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i xxyx
        {
            get => new Vector4i(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i xxyy
        {
            get => new Vector4i(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i xyxx
        {
            get => new Vector4i(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i xyxy
        {
            get => new Vector4i(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i xyyx
        {
            get => new Vector4i(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i xyyy
        {
            get => new Vector4i(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i yxxx
        {
            get => new Vector4i(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4i yxxy
        {
            get => new Vector4i(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i yxyx
        {
            get => new Vector4i(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i yxyy
        {
            get => new Vector4i(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i yyxx
        {
            get => new Vector4i(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i yyxy
        {
            get => new Vector4i(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i yyyx
        {
            get => new Vector4i(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i yyyy
        {
            get => new Vector4i(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: r, g
        [XmlIgnore]
        public int r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public int g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2i rr
        {
            get => new Vector2i(X, X);
        }

        [XmlIgnore]
        public Vector2i rg
        {
            get => new Vector2i(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i gr
        {
            get => new Vector2i(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i gg
        {
            get => new Vector2i(Y, Y);
        }

        [XmlIgnore]
        public Vector3i rrr
        {
            get => new Vector3i(X, X, X);
        }

        [XmlIgnore]
        public Vector3i rrg
        {
            get => new Vector3i(X, X, Y);
        }

        [XmlIgnore]
        public Vector3i rgr
        {
            get => new Vector3i(X, Y, X);
        }

        [XmlIgnore]
        public Vector3i rgg
        {
            get => new Vector3i(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3i grr
        {
            get => new Vector3i(Y, X, X);
        }

        [XmlIgnore]
        public Vector3i grg
        {
            get => new Vector3i(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3i ggr
        {
            get => new Vector3i(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3i ggg
        {
            get => new Vector3i(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i rrrr
        {
            get => new Vector4i(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4i rrrg
        {
            get => new Vector4i(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i rrgr
        {
            get => new Vector4i(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i rrgg
        {
            get => new Vector4i(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i rgrr
        {
            get => new Vector4i(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i rgrg
        {
            get => new Vector4i(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i rggr
        {
            get => new Vector4i(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i rggg
        {
            get => new Vector4i(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i grrr
        {
            get => new Vector4i(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4i grrg
        {
            get => new Vector4i(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i grgr
        {
            get => new Vector4i(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i grgg
        {
            get => new Vector4i(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i ggrr
        {
            get => new Vector4i(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i ggrg
        {
            get => new Vector4i(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i gggr
        {
            get => new Vector4i(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i gggg
        {
            get => new Vector4i(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: s, t
        [XmlIgnore]
        public int s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public int t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2i ss
        {
            get => new Vector2i(X, X);
        }

        [XmlIgnore]
        public Vector2i st
        {
            get => new Vector2i(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ts
        {
            get => new Vector2i(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i tt
        {
            get => new Vector2i(Y, Y);
        }

        [XmlIgnore]
        public Vector3i sss
        {
            get => new Vector3i(X, X, X);
        }

        [XmlIgnore]
        public Vector3i sst
        {
            get => new Vector3i(X, X, Y);
        }

        [XmlIgnore]
        public Vector3i sts
        {
            get => new Vector3i(X, Y, X);
        }

        [XmlIgnore]
        public Vector3i stt
        {
            get => new Vector3i(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3i tss
        {
            get => new Vector3i(Y, X, X);
        }

        [XmlIgnore]
        public Vector3i tst
        {
            get => new Vector3i(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3i tts
        {
            get => new Vector3i(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3i ttt
        {
            get => new Vector3i(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i ssss
        {
            get => new Vector4i(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4i ssst
        {
            get => new Vector4i(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i ssts
        {
            get => new Vector4i(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i sstt
        {
            get => new Vector4i(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i stss
        {
            get => new Vector4i(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i stst
        {
            get => new Vector4i(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i stts
        {
            get => new Vector4i(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i sttt
        {
            get => new Vector4i(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i tsss
        {
            get => new Vector4i(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4i tsst
        {
            get => new Vector4i(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i tsts
        {
            get => new Vector4i(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i tstt
        {
            get => new Vector4i(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i ttss
        {
            get => new Vector4i(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i ttst
        {
            get => new Vector4i(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i ttts
        {
            get => new Vector4i(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i tttt
        {
            get => new Vector4i(Y, Y, Y, Y);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2i"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector2"/> instance.</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2i"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector2i"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector2"/>.</param>
        public static void ToVector2(ref Vector2i input, out Vector2 result)
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
        public static Vector2i operator +(Vector2i left, Vector2i right)
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
        public static Vector2i operator -(Vector2i left, Vector2i right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            return left;
        }

        /// <summary>
        /// Negates the specified instance.
        /// </summary>
        /// <param name="vec">Operand.</param>
        /// <returns>Result of negation.</returns>
        [Pure]
        public static Vector2i operator -(Vector2i vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            return vec;
        }

        /// <summary>
        /// Multiplies the specified instance by a scalar.
        /// </summary>
        /// <param name="vec">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        [Pure]
        public static Vector2i operator *(Vector2i vec, int scale)
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
        public static Vector2i operator *(int scale, Vector2i vec)
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
        public static Vector2i operator *(Vector2i vec, Vector2i scale)
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
        public static Vector2i operator /(Vector2i vec, int scale)
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
        public static bool operator ==(Vector2i left, Vector2i right)
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
        public static bool operator !=(Vector2i left, Vector2i right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2i"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector2i"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector2i((int X, int Y) values)
        {
            return new Vector2i(values.X, values.Y);
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
                return (X * 397) ^ Y;
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
            if (!(obj is Vector2i))
            {
                return false;
            }

            return Equals((Vector2i)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector2i other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        [Pure]
        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}