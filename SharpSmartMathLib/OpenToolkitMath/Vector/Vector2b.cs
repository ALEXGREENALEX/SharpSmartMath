//
//  Vector3b.cs
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
    /// Represents a 2D vector using two boolean numbers.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2b : IEquatable<Vector2b>
    {
        /// <summary>
        /// The X component of the Vector2b.
        /// </summary>
        public bool X;

        /// <summary>
        /// The Y component of the Vector2b.
        /// </summary>
        public bool Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2b"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2b(bool value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2b"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector2b.</param>
        /// <param name="y">The Y component of the Vector2b.</param>
        public Vector2b(bool x, bool y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the value at the index of the vector.
        /// </summary>
        /// <param name="index">The index of the component from the vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 1.</exception>
        public bool this[int index]
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
        /// Defines an instance with all components set to false except X.
        /// </summary>
        public static readonly Vector2b UnitX = new Vector2b(true, false);

        /// <summary>
        /// Defines an instance with all components set to false except Y.
        /// </summary>
        public static readonly Vector2b UnitY = new Vector2b(false, true);

        /// <summary>
        /// Defines an instance with all components set to false.
        /// </summary>
        public static readonly Vector2b Zero = new Vector2b(false, false);

        /// <summary>
        /// Defines an instance with all components set to true.
        /// </summary>
        public static readonly Vector2b One = new Vector2b(true, true);

        /// <summary>
        /// Defines the size of the <see cref="Vector2b"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector2b>();

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector2b OR(Vector2b vector, bool value)
        {
            OR(ref vector, value, out vector);
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <param name="result">Result of OR.</param>
        public static void OR(ref Vector2b vector, bool value, out Vector2b result)
        {
            result.X = vector.X | value;
            result.Y = vector.Y | value;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector2b OR(Vector2b vector1, Vector2b vector2)
        {
            OR(ref vector1, ref vector2, out vector1);
            return vector1;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <param name="result">Result of OR operation.</param>
        public static void OR(ref Vector2b vector1, ref Vector2b vector2, out Vector2b result)
        {
            result.X = vector1.X | vector2.X;
            result.Y = vector1.Y | vector2.Y;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector2b AND(Vector2b vector, bool value)
        {
            AND(ref vector, value, out vector);
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <param name="result">Result of OR.</param>
        public static void AND(ref Vector2b vector, bool value, out Vector2b result)
        {
            result.X = vector.X & value;
            result.Y = vector.Y & value;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector2b AND(Vector2b vector1, Vector2b vector2)
        {
            AND(ref vector1, ref vector2, out vector1);
            return vector1;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <param name="result">Result of AND.</param>
        public static void AND(ref Vector2b vector1, ref Vector2b vector2, out Vector2b result)
        {
            result.X = vector1.X & vector2.X;
            result.Y = vector1.Y & vector2.Y;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector2b XOR(Vector2b vector, bool value)
        {
            XOR(ref vector, value, out vector);
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <param name="result">Result of XOR.</param>
        public static void XOR(ref Vector2b vector, bool value, out Vector2b result)
        {
            result.X = vector.X ^ value;
            result.Y = vector.Y ^ value;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector2b XOR(Vector2b vector1, Vector2b vector2)
        {
            XOR(ref vector1, ref vector2, out vector1);
            return vector1;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <param name="result">Result of XOR.</param>
        public static void XOR(ref Vector2b vector1, ref Vector2b vector2, out Vector2b result)
        {
            result.X = vector1.X ^ vector2.X;
            result.Y = vector1.Y ^ vector2.Y;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector2b NOT(Vector2b vector)
        {
            NOT(ref vector, out vector);
            return vector;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <param name="result">Result of NOT.</param>
        public static void NOT(ref Vector2b vector, out Vector2b result)
        {
            result.X = !vector.X;
            result.Y = !vector.Y;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector2b ComponentMin(Vector2b a, Vector2b b)
        {
            a.X = a.X & b.X;
            a.Y = a.Y & b.Y;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector2b a, ref Vector2b b, out Vector2b result)
        {
            result.X = a.X & b.X;
            result.Y = a.Y & b.Y;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector2b ComponentMax(Vector2b a, Vector2b b)
        {
            a.X = a.X | b.X;
            a.Y = a.Y | b.Y;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector2b a, ref Vector2b b, out Vector2b result)
        {
            result.X = a.X | b.X;
            result.Y = a.Y | b.Y;
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2b"/> with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Yx
        {
            get => new Vector2b(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        #region Coords: x, y
        [XmlIgnore]
        public bool x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public bool y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2b xx
        {
            get => new Vector2b(X, X);
        }

        [XmlIgnore]
        public Vector2b xy
        {
            get => new Vector2b(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b yx
        {
            get => new Vector2b(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b yy
        {
            get => new Vector2b(Y, Y);
        }

        [XmlIgnore]
        public Vector3b xxx
        {
            get => new Vector3b(X, X, X);
        }

        [XmlIgnore]
        public Vector3b xxy
        {
            get => new Vector3b(X, X, Y);
        }

        [XmlIgnore]
        public Vector3b xyx
        {
            get => new Vector3b(X, Y, X);
        }

        [XmlIgnore]
        public Vector3b xyy
        {
            get => new Vector3b(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3b yxx
        {
            get => new Vector3b(Y, X, X);
        }

        [XmlIgnore]
        public Vector3b yxy
        {
            get => new Vector3b(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3b yyx
        {
            get => new Vector3b(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3b yyy
        {
            get => new Vector3b(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b xxxx
        {
            get => new Vector4b(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4b xxxy
        {
            get => new Vector4b(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b xxyx
        {
            get => new Vector4b(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b xxyy
        {
            get => new Vector4b(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b xyxx
        {
            get => new Vector4b(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b xyxy
        {
            get => new Vector4b(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b xyyx
        {
            get => new Vector4b(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b xyyy
        {
            get => new Vector4b(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b yxxx
        {
            get => new Vector4b(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4b yxxy
        {
            get => new Vector4b(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b yxyx
        {
            get => new Vector4b(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b yxyy
        {
            get => new Vector4b(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b yyxx
        {
            get => new Vector4b(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b yyxy
        {
            get => new Vector4b(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b yyyx
        {
            get => new Vector4b(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b yyyy
        {
            get => new Vector4b(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: r, g
        [XmlIgnore]
        public bool r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public bool g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2b rr
        {
            get => new Vector2b(X, X);
        }

        [XmlIgnore]
        public Vector2b rg
        {
            get => new Vector2b(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b gr
        {
            get => new Vector2b(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b gg
        {
            get => new Vector2b(Y, Y);
        }

        [XmlIgnore]
        public Vector3b rrr
        {
            get => new Vector3b(X, X, X);
        }

        [XmlIgnore]
        public Vector3b rrg
        {
            get => new Vector3b(X, X, Y);
        }

        [XmlIgnore]
        public Vector3b rgr
        {
            get => new Vector3b(X, Y, X);
        }

        [XmlIgnore]
        public Vector3b rgg
        {
            get => new Vector3b(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3b grr
        {
            get => new Vector3b(Y, X, X);
        }

        [XmlIgnore]
        public Vector3b grg
        {
            get => new Vector3b(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3b ggr
        {
            get => new Vector3b(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3b ggg
        {
            get => new Vector3b(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b rrrr
        {
            get => new Vector4b(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4b rrrg
        {
            get => new Vector4b(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b rrgr
        {
            get => new Vector4b(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b rrgg
        {
            get => new Vector4b(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b rgrr
        {
            get => new Vector4b(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b rgrg
        {
            get => new Vector4b(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b rggr
        {
            get => new Vector4b(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b rggg
        {
            get => new Vector4b(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b grrr
        {
            get => new Vector4b(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4b grrg
        {
            get => new Vector4b(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b grgr
        {
            get => new Vector4b(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b grgg
        {
            get => new Vector4b(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b ggrr
        {
            get => new Vector4b(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b ggrg
        {
            get => new Vector4b(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b gggr
        {
            get => new Vector4b(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b gggg
        {
            get => new Vector4b(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: s, t
        [XmlIgnore]
        public bool s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public bool t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Vector2b ss
        {
            get => new Vector2b(X, X);
        }

        [XmlIgnore]
        public Vector2b st
        {
            get => new Vector2b(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ts
        {
            get => new Vector2b(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b tt
        {
            get => new Vector2b(Y, Y);
        }

        [XmlIgnore]
        public Vector3b sss
        {
            get => new Vector3b(X, X, X);
        }

        [XmlIgnore]
        public Vector3b sst
        {
            get => new Vector3b(X, X, Y);
        }

        [XmlIgnore]
        public Vector3b sts
        {
            get => new Vector3b(X, Y, X);
        }

        [XmlIgnore]
        public Vector3b stt
        {
            get => new Vector3b(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3b tss
        {
            get => new Vector3b(Y, X, X);
        }

        [XmlIgnore]
        public Vector3b tst
        {
            get => new Vector3b(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3b tts
        {
            get => new Vector3b(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3b ttt
        {
            get => new Vector3b(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b ssss
        {
            get => new Vector4b(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4b ssst
        {
            get => new Vector4b(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b ssts
        {
            get => new Vector4b(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b sstt
        {
            get => new Vector4b(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b stss
        {
            get => new Vector4b(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b stst
        {
            get => new Vector4b(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b stts
        {
            get => new Vector4b(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b sttt
        {
            get => new Vector4b(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b tsss
        {
            get => new Vector4b(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4b tsst
        {
            get => new Vector4b(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b tsts
        {
            get => new Vector4b(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b tstt
        {
            get => new Vector4b(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b ttss
        {
            get => new Vector4b(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b ttst
        {
            get => new Vector4b(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b ttts
        {
            get => new Vector4b(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b tttt
        {
            get => new Vector4b(Y, Y, Y, Y);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2b"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector2"/> instance.</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X ? 1 : 0, Y ? 1 : 0);
        }

        /// <summary>
        /// Gets a <see cref="Vector2"/> object with the same component values as the <see cref="Vector2b"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector2b"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector2"/>.</param>
        public static void ToVector2(ref Vector2b input, out Vector2 result)
        {
            result.X = input.X ? 1 : 0;
            result.Y = input.Y ? 1 : 0;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector2b operator +(Vector2b vector, bool value)
        {
            vector.X |= value;
            vector.Y |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector2b operator +(bool value, Vector2b vector)
        {
            vector.X |= value;
            vector.Y |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector2b operator +(Vector2b left, Vector2b right)
        {
            left.X |= right.X;
            left.Y |= right.Y;
            return left;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector2b operator *(Vector2b vector, bool value)
        {
            vector.X &= value;
            vector.Y &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector2b operator *(bool value, Vector2b vector)
        {
            vector.X &= value;
            vector.Y &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector2b operator *(Vector2b left, Vector2b right)
        {
            left.X &= right.X;
            left.Y &= right.Y;
            return left;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector2b operator ^(Vector2b vector, bool value)
        {
            vector.X ^= value;
            vector.Y ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="value">Right operand.</param>
        /// <param name="vector">Left operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector2b operator ^(bool value, Vector2b vector)
        {
            vector.X ^= value;
            vector.Y ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector2b operator ^(Vector2b left, Vector2b right)
        {
            left.X ^= right.X;
            left.Y ^= right.Y;
            return left;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector2b operator !(Vector2b vector)
        {
            vector.X = !vector.X;
            vector.Y = !vector.Y;
            return vector;
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector2b left, Vector2b right)
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
        public static bool operator !=(Vector2b left, Vector2b right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2b"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector2b"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector2b((bool X, bool Y) values)
        {
            return new Vector2b(values.X, values.Y);
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
            return ((Y ? 1 : 0) << 1) | (X ? 1 : 0);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2b))
            {
                return false;
            }

            return Equals((Vector2b)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector2b other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        [Pure]
        public void Deconstruct(out bool x, out bool y)
        {
            x = X;
            y = Y;
        }
    }
}