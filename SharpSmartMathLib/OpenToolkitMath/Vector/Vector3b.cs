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
    public struct Vector3b : IEquatable<Vector3b>
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
        /// The Z component of the Vector2b.
        /// </summary>
        public bool Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3b"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3b(bool value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3b"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector3b.</param>
        /// <param name="y">The Y component of the Vector3b.</param>
        /// <param name="z">The Z component of the Vector3b.</param>
        public Vector3b(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        /// <param name="index">The index of the component from the Vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 2.</exception>
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
        /// Defines an instance with all components set to false except X.
        /// </summary>
        public static readonly Vector3b UnitX = new Vector3b(true, false, false);

        /// <summary>
        /// Defines an instance with all components set to false except Y.
        /// </summary>
        public static readonly Vector3b UnitY = new Vector3b(false, true, false);

        /// <summary>
        /// Defines an instance with all components set to false except Z.
        /// </summary>
        public static readonly Vector3b UnitZ = new Vector3b(false, false, true);

        /// <summary>
        /// Defines an instance with all components set to false.
        /// </summary>
        public static readonly Vector3b Zero = new Vector3b(false, false, false);

        /// <summary>
        /// Defines an instance with all components set to true.
        /// </summary>
        public static readonly Vector3b One = new Vector3b(true, true, true);

        /// <summary>
        /// Defines the size of the <see cref="Vector3b"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector3b>();

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector3b OR(Vector3b vector, bool value)
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
        public static void OR(ref Vector3b vector, bool value, out Vector3b result)
        {
            result.X = vector.X | value;
            result.Y = vector.Y | value;
            result.Z = vector.Z | value;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector3b OR(Vector3b vector1, Vector3b vector2)
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
        public static void OR(ref Vector3b vector1, ref Vector3b vector2, out Vector3b result)
        {
            result.X = vector1.X | vector2.X;
            result.Y = vector1.Y | vector2.Y;
            result.Z = vector1.Z | vector2.Z;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector3b AND(Vector3b vector, bool value)
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
        public static void AND(ref Vector3b vector, bool value, out Vector3b result)
        {
            result.X = vector.X & value;
            result.Y = vector.Y & value;
            result.Z = vector.Z & value;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector3b AND(Vector3b vector1, Vector3b vector2)
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
        public static void AND(ref Vector3b vector1, ref Vector3b vector2, out Vector3b result)
        {
            result.X = vector1.X & vector2.X;
            result.Y = vector1.Y & vector2.Y;
            result.Z = vector1.Z & vector2.Z;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector3b XOR(Vector3b vector, bool value)
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
        public static void XOR(ref Vector3b vector, bool value, out Vector3b result)
        {
            result.X = vector.X ^ value;
            result.Y = vector.Y ^ value;
            result.Z = vector.Z ^ value;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector3b XOR(Vector3b vector1, Vector3b vector2)
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
        public static void XOR(ref Vector3b vector1, ref Vector3b vector2, out Vector3b result)
        {
            result.X = vector1.X ^ vector2.X;
            result.Y = vector1.Y ^ vector2.Y;
            result.Z = vector1.Z ^ vector2.Z;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector3b NOT(Vector3b vector)
        {
            NOT(ref vector, out vector);
            return vector;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <param name="result">Result of NOT.</param>
        public static void NOT(ref Vector3b vector, out Vector3b result)
        {
            result.X = !vector.X;
            result.Y = !vector.Y;
            result.Z = !vector.Z;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector3b ComponentMin(Vector3b a, Vector3b b)
        {
            a.X = a.X & b.X;
            a.Y = a.Y & b.Y;
            a.Z = a.Z & b.Z;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector3b a, ref Vector3b b, out Vector3b result)
        {
            result.X = a.X & b.X;
            result.Y = a.Y & b.Y;
            result.Z = a.Z & b.Z;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector3b ComponentMax(Vector3b a, Vector3b b)
        {
            a.X = a.X | b.X;
            a.Y = a.Y | b.Y;
            a.Z = a.Z | b.Z;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector3b a, ref Vector3b b, out Vector3b result)
        {
            result.X = a.X | b.X;
            result.Y = a.Y | b.Y;
            result.Z = a.Z | b.Z;
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Xy
        {
            get => new Vector2b(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Xz
        {
            get => new Vector2b(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the Y and X components of this instance.
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

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Yz
        {
            get => new Vector2b(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Zx
        {
            get => new Vector2b(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector2b"/> with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Zy
        {
            get => new Vector2b(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3b"/> with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xzy
        {
            get => new Vector3b(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3b"/> with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Yxz
        {
            get => new Vector3b(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3b"/> with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Yzx
        {
            get => new Vector3b(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3b"/> with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zxy
        {
            get => new Vector3b(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an <see cref="Vector3b"/> with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zyx
        {
            get => new Vector3b(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        #region Coords: x, y, z
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
        public bool z
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2b xz
        {
            get => new Vector2b(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2b yz
        {
            get => new Vector2b(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b zx
        {
            get => new Vector2b(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b zy
        {
            get => new Vector2b(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b zz
        {
            get => new Vector2b(Z, Z);
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
        public Vector3b xxz
        {
            get => new Vector3b(X, X, Z);
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
        public Vector3b xyz
        {
            get => new Vector3b(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b xzx
        {
            get => new Vector3b(X, Z, X);
        }

        [XmlIgnore]
        public Vector3b xzy
        {
            get => new Vector3b(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b xzz
        {
            get => new Vector3b(X, Z, Z);
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
        public Vector3b yxz
        {
            get => new Vector3b(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3b yyz
        {
            get => new Vector3b(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3b yzx
        {
            get => new Vector3b(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b yzy
        {
            get => new Vector3b(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3b yzz
        {
            get => new Vector3b(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3b zxx
        {
            get => new Vector3b(Z, X, X);
        }

        [XmlIgnore]
        public Vector3b zxy
        {
            get => new Vector3b(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b zxz
        {
            get => new Vector3b(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3b zyx
        {
            get => new Vector3b(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b zyy
        {
            get => new Vector3b(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3b zyz
        {
            get => new Vector3b(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3b zzx
        {
            get => new Vector3b(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3b zzy
        {
            get => new Vector3b(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3b zzz
        {
            get => new Vector3b(Z, Z, Z);
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
        public Vector4b xxxz
        {
            get => new Vector4b(X, X, X, Z);
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
        public Vector4b xxyz
        {
            get => new Vector4b(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b xxzx
        {
            get => new Vector4b(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b xxzy
        {
            get => new Vector4b(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b xxzz
        {
            get => new Vector4b(X, X, Z, Z);
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
        public Vector4b xyxz
        {
            get => new Vector4b(X, Y, X, Z);
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
        public Vector4b xyyz
        {
            get => new Vector4b(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b xyzx
        {
            get => new Vector4b(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b xyzy
        {
            get => new Vector4b(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b xyzz
        {
            get => new Vector4b(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b xzxx
        {
            get => new Vector4b(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b xzxy
        {
            get => new Vector4b(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b xzxz
        {
            get => new Vector4b(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b xzyx
        {
            get => new Vector4b(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b xzyy
        {
            get => new Vector4b(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b xzyz
        {
            get => new Vector4b(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b xzzx
        {
            get => new Vector4b(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b xzzy
        {
            get => new Vector4b(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b xzzz
        {
            get => new Vector4b(X, Z, Z, Z);
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
        public Vector4b yxxz
        {
            get => new Vector4b(Y, X, X, Z);
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
        public Vector4b yxyz
        {
            get => new Vector4b(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b yxzx
        {
            get => new Vector4b(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b yxzy
        {
            get => new Vector4b(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b yxzz
        {
            get => new Vector4b(Y, X, Z, Z);
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
        public Vector4b yyxz
        {
            get => new Vector4b(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4b yyyz
        {
            get => new Vector4b(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b yyzx
        {
            get => new Vector4b(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b yyzy
        {
            get => new Vector4b(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b yyzz
        {
            get => new Vector4b(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b yzxx
        {
            get => new Vector4b(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b yzxy
        {
            get => new Vector4b(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b yzxz
        {
            get => new Vector4b(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b yzyx
        {
            get => new Vector4b(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b yzyy
        {
            get => new Vector4b(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b yzyz
        {
            get => new Vector4b(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b yzzx
        {
            get => new Vector4b(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b yzzy
        {
            get => new Vector4b(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b yzzz
        {
            get => new Vector4b(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b zxxx
        {
            get => new Vector4b(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4b zxxy
        {
            get => new Vector4b(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b zxxz
        {
            get => new Vector4b(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b zxyx
        {
            get => new Vector4b(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b zxyy
        {
            get => new Vector4b(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b zxyz
        {
            get => new Vector4b(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b zxzx
        {
            get => new Vector4b(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b zxzy
        {
            get => new Vector4b(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b zxzz
        {
            get => new Vector4b(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b zyxx
        {
            get => new Vector4b(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b zyxy
        {
            get => new Vector4b(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b zyxz
        {
            get => new Vector4b(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4b zyyx
        {
            get => new Vector4b(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b zyyy
        {
            get => new Vector4b(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b zyyz
        {
            get => new Vector4b(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b zyzx
        {
            get => new Vector4b(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b zyzy
        {
            get => new Vector4b(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b zyzz
        {
            get => new Vector4b(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b zzxx
        {
            get => new Vector4b(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b zzxy
        {
            get => new Vector4b(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b zzxz
        {
            get => new Vector4b(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b zzyx
        {
            get => new Vector4b(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b zzyy
        {
            get => new Vector4b(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b zzyz
        {
            get => new Vector4b(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b zzzx
        {
            get => new Vector4b(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b zzzy
        {
            get => new Vector4b(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b zzzz
        {
            get => new Vector4b(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: r, g, b
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
        public bool b
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2b rb
        {
            get => new Vector2b(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2b gb
        {
            get => new Vector2b(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b br
        {
            get => new Vector2b(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b bg
        {
            get => new Vector2b(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b bb
        {
            get => new Vector2b(Z, Z);
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
        public Vector3b rrb
        {
            get => new Vector3b(X, X, Z);
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
        public Vector3b rgb
        {
            get => new Vector3b(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b rbr
        {
            get => new Vector3b(X, Z, X);
        }

        [XmlIgnore]
        public Vector3b rbg
        {
            get => new Vector3b(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b rbb
        {
            get => new Vector3b(X, Z, Z);
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
        public Vector3b grb
        {
            get => new Vector3b(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3b ggb
        {
            get => new Vector3b(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3b gbr
        {
            get => new Vector3b(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b gbg
        {
            get => new Vector3b(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3b gbb
        {
            get => new Vector3b(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3b brr
        {
            get => new Vector3b(Z, X, X);
        }

        [XmlIgnore]
        public Vector3b brg
        {
            get => new Vector3b(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b brb
        {
            get => new Vector3b(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3b bgr
        {
            get => new Vector3b(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b bgg
        {
            get => new Vector3b(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3b bgb
        {
            get => new Vector3b(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3b bbr
        {
            get => new Vector3b(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3b bbg
        {
            get => new Vector3b(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3b bbb
        {
            get => new Vector3b(Z, Z, Z);
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
        public Vector4b rrrb
        {
            get => new Vector4b(X, X, X, Z);
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
        public Vector4b rrgb
        {
            get => new Vector4b(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b rrbr
        {
            get => new Vector4b(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b rrbg
        {
            get => new Vector4b(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b rrbb
        {
            get => new Vector4b(X, X, Z, Z);
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
        public Vector4b rgrb
        {
            get => new Vector4b(X, Y, X, Z);
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
        public Vector4b rggb
        {
            get => new Vector4b(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b rgbr
        {
            get => new Vector4b(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b rgbg
        {
            get => new Vector4b(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b rgbb
        {
            get => new Vector4b(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b rbrr
        {
            get => new Vector4b(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b rbrg
        {
            get => new Vector4b(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b rbrb
        {
            get => new Vector4b(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b rbgr
        {
            get => new Vector4b(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b rbgg
        {
            get => new Vector4b(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b rbgb
        {
            get => new Vector4b(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b rbbr
        {
            get => new Vector4b(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b rbbg
        {
            get => new Vector4b(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b rbbb
        {
            get => new Vector4b(X, Z, Z, Z);
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
        public Vector4b grrb
        {
            get => new Vector4b(Y, X, X, Z);
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
        public Vector4b grgb
        {
            get => new Vector4b(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b grbr
        {
            get => new Vector4b(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b grbg
        {
            get => new Vector4b(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b grbb
        {
            get => new Vector4b(Y, X, Z, Z);
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
        public Vector4b ggrb
        {
            get => new Vector4b(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4b gggb
        {
            get => new Vector4b(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ggbr
        {
            get => new Vector4b(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b ggbg
        {
            get => new Vector4b(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b ggbb
        {
            get => new Vector4b(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b gbrr
        {
            get => new Vector4b(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b gbrg
        {
            get => new Vector4b(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b gbrb
        {
            get => new Vector4b(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b gbgr
        {
            get => new Vector4b(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b gbgg
        {
            get => new Vector4b(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b gbgb
        {
            get => new Vector4b(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b gbbr
        {
            get => new Vector4b(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b gbbg
        {
            get => new Vector4b(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b gbbb
        {
            get => new Vector4b(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b brrr
        {
            get => new Vector4b(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4b brrg
        {
            get => new Vector4b(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b brrb
        {
            get => new Vector4b(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b brgr
        {
            get => new Vector4b(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b brgg
        {
            get => new Vector4b(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b brgb
        {
            get => new Vector4b(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b brbr
        {
            get => new Vector4b(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b brbg
        {
            get => new Vector4b(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b brbb
        {
            get => new Vector4b(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b bgrr
        {
            get => new Vector4b(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b bgrg
        {
            get => new Vector4b(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b bgrb
        {
            get => new Vector4b(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4b bggr
        {
            get => new Vector4b(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b bggg
        {
            get => new Vector4b(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b bggb
        {
            get => new Vector4b(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b bgbr
        {
            get => new Vector4b(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b bgbg
        {
            get => new Vector4b(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b bgbb
        {
            get => new Vector4b(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b bbrr
        {
            get => new Vector4b(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b bbrg
        {
            get => new Vector4b(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b bbrb
        {
            get => new Vector4b(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b bbgr
        {
            get => new Vector4b(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b bbgg
        {
            get => new Vector4b(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b bbgb
        {
            get => new Vector4b(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b bbbr
        {
            get => new Vector4b(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b bbbg
        {
            get => new Vector4b(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b bbbb
        {
            get => new Vector4b(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: s, t, p
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
        public bool p
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2b sp
        {
            get => new Vector2b(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2b tp
        {
            get => new Vector2b(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ps
        {
            get => new Vector2b(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b pt
        {
            get => new Vector2b(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b pp
        {
            get => new Vector2b(Z, Z);
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
        public Vector3b ssp
        {
            get => new Vector3b(X, X, Z);
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
        public Vector3b stp
        {
            get => new Vector3b(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b sps
        {
            get => new Vector3b(X, Z, X);
        }

        [XmlIgnore]
        public Vector3b spt
        {
            get => new Vector3b(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b spp
        {
            get => new Vector3b(X, Z, Z);
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
        public Vector3b tsp
        {
            get => new Vector3b(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3b ttp
        {
            get => new Vector3b(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3b tps
        {
            get => new Vector3b(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b tpt
        {
            get => new Vector3b(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3b tpp
        {
            get => new Vector3b(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3b pss
        {
            get => new Vector3b(Z, X, X);
        }

        [XmlIgnore]
        public Vector3b pst
        {
            get => new Vector3b(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b psp
        {
            get => new Vector3b(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3b pts
        {
            get => new Vector3b(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b ptt
        {
            get => new Vector3b(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3b ptp
        {
            get => new Vector3b(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3b pps
        {
            get => new Vector3b(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3b ppt
        {
            get => new Vector3b(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3b ppp
        {
            get => new Vector3b(Z, Z, Z);
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
        public Vector4b sssp
        {
            get => new Vector4b(X, X, X, Z);
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
        public Vector4b sstp
        {
            get => new Vector4b(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ssps
        {
            get => new Vector4b(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b sspt
        {
            get => new Vector4b(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b sspp
        {
            get => new Vector4b(X, X, Z, Z);
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
        public Vector4b stsp
        {
            get => new Vector4b(X, Y, X, Z);
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
        public Vector4b sttp
        {
            get => new Vector4b(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b stps
        {
            get => new Vector4b(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b stpt
        {
            get => new Vector4b(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b stpp
        {
            get => new Vector4b(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b spss
        {
            get => new Vector4b(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b spst
        {
            get => new Vector4b(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b spsp
        {
            get => new Vector4b(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b spts
        {
            get => new Vector4b(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b sptt
        {
            get => new Vector4b(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b sptp
        {
            get => new Vector4b(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b spps
        {
            get => new Vector4b(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b sppt
        {
            get => new Vector4b(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b sppp
        {
            get => new Vector4b(X, Z, Z, Z);
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
        public Vector4b tssp
        {
            get => new Vector4b(Y, X, X, Z);
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
        public Vector4b tstp
        {
            get => new Vector4b(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b tsps
        {
            get => new Vector4b(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b tspt
        {
            get => new Vector4b(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b tspp
        {
            get => new Vector4b(Y, X, Z, Z);
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
        public Vector4b ttsp
        {
            get => new Vector4b(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4b tttp
        {
            get => new Vector4b(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ttps
        {
            get => new Vector4b(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b ttpt
        {
            get => new Vector4b(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b ttpp
        {
            get => new Vector4b(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b tpss
        {
            get => new Vector4b(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b tpst
        {
            get => new Vector4b(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b tpsp
        {
            get => new Vector4b(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b tpts
        {
            get => new Vector4b(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b tptt
        {
            get => new Vector4b(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b tptp
        {
            get => new Vector4b(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b tpps
        {
            get => new Vector4b(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b tppt
        {
            get => new Vector4b(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b tppp
        {
            get => new Vector4b(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b psss
        {
            get => new Vector4b(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4b psst
        {
            get => new Vector4b(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b pssp
        {
            get => new Vector4b(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b psts
        {
            get => new Vector4b(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b pstt
        {
            get => new Vector4b(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b pstp
        {
            get => new Vector4b(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4b psps
        {
            get => new Vector4b(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b pspt
        {
            get => new Vector4b(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4b pspp
        {
            get => new Vector4b(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b ptss
        {
            get => new Vector4b(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b ptst
        {
            get => new Vector4b(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b ptsp
        {
            get => new Vector4b(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4b ptts
        {
            get => new Vector4b(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b pttt
        {
            get => new Vector4b(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b pttp
        {
            get => new Vector4b(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ptps
        {
            get => new Vector4b(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4b ptpt
        {
            get => new Vector4b(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b ptpp
        {
            get => new Vector4b(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b ppss
        {
            get => new Vector4b(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b ppst
        {
            get => new Vector4b(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4b ppsp
        {
            get => new Vector4b(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b ppts
        {
            get => new Vector4b(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4b pptt
        {
            get => new Vector4b(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b pptp
        {
            get => new Vector4b(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ppps
        {
            get => new Vector4b(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b pppt
        {
            get => new Vector4b(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b pppp
        {
            get => new Vector4b(Z, Z, Z, Z);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector3b"/> object with the same component values as the <see cref="Vector3b"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector3"/> instance.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(X ? 1 : 0, Y ? 1 : 0, Z ? 1 : 0);
        }

        /// <summary>
        /// Gets a <see cref="Vector3"/> object with the same component values as the <see cref="Vector3b"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector3b"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector3"/>.</param>
        public static void ToVector3(ref Vector3b input, out Vector3 result)
        {
            result.X = input.X ? 1 : 0;
            result.Y = input.Y ? 1 : 0;
            result.Z = input.Z ? 1 : 0;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector3b operator +(Vector3b vector, bool value)
        {
            vector.X |= value;
            vector.Y |= value;
            vector.Z |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector3b operator +(bool value, Vector3b vector)
        {
            vector.X |= value;
            vector.Y |= value;
            vector.Z |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector3b operator +(Vector3b left, Vector3b right)
        {
            left.X |= right.X;
            left.Y |= right.Y;
            left.Z |= right.Z;
            return left;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector3b operator *(Vector3b vector, bool value)
        {
            vector.X &= value;
            vector.Y &= value;
            vector.Z &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector3b operator *(bool value, Vector3b vector)
        {
            vector.X &= value;
            vector.Y &= value;
            vector.Z &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector3b operator *(Vector3b left, Vector3b right)
        {
            left.X &= right.X;
            left.Y &= right.Y;
            left.Z &= right.Z;
            return left;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector3b operator ^(Vector3b vector, bool value)
        {
            vector.X ^= value;
            vector.Y ^= value;
            vector.Z ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="value">Right operand.</param>
        /// <param name="vector">Left operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector3b operator ^(bool value, Vector3b vector)
        {
            vector.X ^= value;
            vector.Y ^= value;
            vector.Z ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector3b operator ^(Vector3b left, Vector3b right)
        {
            left.X ^= right.X;
            left.Y ^= right.Y;
            left.Z ^= right.Z;
            return left;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector3b operator !(Vector3b vector)
        {
            vector.X = !vector.X;
            vector.Y = !vector.Y;
            vector.Z = !vector.Z;
            return vector;
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector3b left, Vector3b right)
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
        public static bool operator !=(Vector3b left, Vector3b right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3b"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3b"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3b((bool X, bool Y, bool Z) values)
        {
            return new Vector3b(values.X, values.Y, values.Z);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
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
            return ((Z ? 1 : 0) << 2) | ((Y ? 1 : 0) << 1) | (X ? 1 : 0);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3b))
            {
                return false;
            }

            return Equals((Vector3b)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector3b other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        [Pure]
        public void Deconstruct(out bool x, out bool y, out bool z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}