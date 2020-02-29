//
//  Vector4b.cs
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
    public struct Vector4b : IEquatable<Vector4b>
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
        /// The W component of the Vector2b.
        /// </summary>
        public bool W;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4b(bool value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector4b.</param>
        /// <param name="y">The Y component of the Vector4b.</param>
        /// <param name="z">The Z component of the Vector4b.</param>
        public Vector4b(bool x, bool y, bool z, bool w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct.
        /// </summary>
        /// <param name="v">The Vector2b to copy components from.</param>
        public Vector4b(Vector2b v, bool z = false, bool w = false)
        {
            X = v.X;
            Y = v.Y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct.
        /// </summary>
        /// <param name="v">The Vector3b to copy components from.</param>
        /// <remarks>
        ///  .<seealso cref="Vector4b(Vector3b, bool)"/>
        /// </remarks>
        public Vector4b(Vector3b v, bool w = false)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct.
        /// </summary>
        /// <param name="v">The Vector4b to copy components from.</param>
        public Vector4b(Vector4b v)
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
        /// Defines an instance with all components set to false except X.
        /// </summary>
        public static readonly Vector4b UnitX = new Vector4b(true, false, false, false);

        /// <summary>
        /// Defines an instance with all components set to false except Y.
        /// </summary>
        public static readonly Vector4b UnitY = new Vector4b(false, true, false, false);

        /// <summary>
        /// Defines an instance with all components set to false except Z.
        /// </summary>
        public static readonly Vector4b UnitZ = new Vector4b(false, false, true, false);

        /// <summary>
        /// Defines an instance with all components set to false except W.
        /// </summary>
        public static readonly Vector4b UnitW = new Vector4b(false, false, false, true);

        /// <summary>
        /// Defines an instance with all components set to false.
        /// </summary>
        public static readonly Vector4b Zero = new Vector4b(false, false, false, false);

        /// <summary>
        /// Defines an instance with all components set to true.
        /// </summary>
        public static readonly Vector4b One = new Vector4b(true, true, true, true);

        /// <summary>
        /// Defines the size of the <see cref="Vector4b"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector4b>();

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector4b OR(Vector4b vector, bool value)
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
        public static void OR(ref Vector4b vector, bool value, out Vector4b result)
        {
            result.X = vector.X | value;
            result.Y = vector.Y | value;
            result.Z = vector.Z | value;
            result.W = vector.W | value;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector4b OR(Vector4b vector1, Vector4b vector2)
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
        public static void OR(ref Vector4b vector1, ref Vector4b vector2, out Vector4b result)
        {
            result.X = vector1.X | vector2.X;
            result.Y = vector1.Y | vector2.Y;
            result.Z = vector1.Z | vector2.Z;
            result.W = vector1.W | vector2.W;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector4b AND(Vector4b vector, bool value)
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
        public static void AND(ref Vector4b vector, bool value, out Vector4b result)
        {
            result.X = vector.X & value;
            result.Y = vector.Y & value;
            result.Z = vector.Z & value;
            result.W = vector.W & value;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector4b AND(Vector4b vector1, Vector4b vector2)
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
        public static void AND(ref Vector4b vector1, ref Vector4b vector2, out Vector4b result)
        {
            result.X = vector1.X & vector2.X;
            result.Y = vector1.Y & vector2.Y;
            result.Z = vector1.Z & vector2.Z;
            result.W = vector1.W & vector2.W;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector4b XOR(Vector4b vector, bool value)
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
        public static void XOR(ref Vector4b vector, bool value, out Vector4b result)
        {
            result.X = vector.X ^ value;
            result.Y = vector.Y ^ value;
            result.Z = vector.Z ^ value;
            result.W = vector.W ^ value;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector1">Left operand.</param>
        /// <param name="vector2">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector4b XOR(Vector4b vector1, Vector4b vector2)
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
        public static void XOR(ref Vector4b vector1, ref Vector4b vector2, out Vector4b result)
        {
            result.X = vector1.X ^ vector2.X;
            result.Y = vector1.Y ^ vector2.Y;
            result.Z = vector1.Z ^ vector2.Z;
            result.W = vector1.W ^ vector2.W;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector4b NOT(Vector4b vector)
        {
            NOT(ref vector, out vector);
            return vector;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <param name="result">Result of NOT.</param>
        public static void NOT(ref Vector4b vector, out Vector4b result)
        {
            result.X = !vector.X;
            result.Y = !vector.Y;
            result.Z = !vector.Z;
            result.W = !vector.W;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise minimum.</returns>
        [Pure]
        public static Vector4b ComponentMin(Vector4b a, Vector4b b)
        {
            a.X = a.X & b.X;
            a.Y = a.Y & b.Y;
            a.Z = a.Z & b.Z;
            a.W = a.W & b.W;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the smallest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise minimum.</param>
        public static void ComponentMin(ref Vector4b a, ref Vector4b b, out Vector4b result)
        {
            result.X = a.X & b.X;
            result.Y = a.Y & b.Y;
            result.Z = a.Z & b.Z;
            result.W = a.W & b.W;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The component-wise maximum.</returns>
        [Pure]
        public static Vector4b ComponentMax(Vector4b a, Vector4b b)
        {
            a.X = a.X | b.X;
            a.Y = a.Y | b.Y;
            a.Z = a.Z | b.Z;
            a.W = a.W | b.W;
            return a;
        }

        /// <summary>
        /// Returns a vector created from the largest of the corresponding components of the given vectors.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">The component-wise maximum.</param>
        public static void ComponentMax(ref Vector4b a, ref Vector4b b, out Vector4b result)
        {
            result.X = a.X | b.X;
            result.Y = a.Y | b.Y;
            result.Z = a.Z | b.Z;
            result.W = a.W | b.W;
        }

        #region Components
        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the X and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the X and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Xw
        {
            get => new Vector2b(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the Y and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the Y and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Yw
        {
            get => new Vector2b(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the Z and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the Z and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector2b with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Zw
        {
            get => new Vector2b(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Wx
        {
            get => new Vector2b(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Wy
        {
            get => new Vector2b(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2b with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2b Wz
        {
            get => new Vector2b(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xyz
        {
            get => new Vector3b(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xyw
        {
            get => new Vector3b(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the X, Z, and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3b with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xzw
        {
            get => new Vector3b(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xwy
        {
            get => new Vector3b(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Xwz
        {
            get => new Vector3b(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Y, X, and Z components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3b with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Yxw
        {
            get => new Vector3b(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Y, Z, and X components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3b with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Yzw
        {
            get => new Vector3b(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Ywx
        {
            get => new Vector3b(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Ywz
        {
            get => new Vector3b(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Z, X, and Y components of this instance.
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
        /// Gets or sets an OpenToolkit.Vector3b with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zxw
        {
            get => new Vector3b(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Z, Y, and X components of this instance.
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

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zyw
        {
            get => new Vector3b(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zwx
        {
            get => new Vector3b(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Zwy
        {
            get => new Vector3b(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wxy
        {
            get => new Vector3b(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wxz
        {
            get => new Vector3b(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wyx
        {
            get => new Vector3b(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wyz
        {
            get => new Vector3b(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wzx
        {
            get => new Vector3b(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3b with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3b Wzy
        {
            get => new Vector3b(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Xywz
        {
            get => new Vector4b(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Xzyw
        {
            get => new Vector4b(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Xzwy
        {
            get => new Vector4b(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Xwyz
        {
            get => new Vector4b(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Xwzy
        {
            get => new Vector4b(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yxzw
        {
            get => new Vector4b(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yxwz
        {
            get => new Vector4b(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yyzw
        {
            get => new Vector4b(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yywz
        {
            get => new Vector4b(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yzxw
        {
            get => new Vector4b(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Yzwx
        {
            get => new Vector4b(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Ywxz
        {
            get => new Vector4b(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Ywzx
        {
            get => new Vector4b(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zxyw
        {
            get => new Vector4b(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zxwy
        {
            get => new Vector4b(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zyxw
        {
            get => new Vector4b(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zywx
        {
            get => new Vector4b(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zwxy
        {
            get => new Vector4b(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zwyx
        {
            get => new Vector4b(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Zwzy
        {
            get => new Vector4b(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wxyz
        {
            get => new Vector4b(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wxzy
        {
            get => new Vector4b(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wyxz
        {
            get => new Vector4b(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wyzx
        {
            get => new Vector4b(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wzxy
        {
            get => new Vector4b(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wzyx
        {
            get => new Vector4b(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4b with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4b Wzyw
        {
            get => new Vector4b(W, Z, Y, W);
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
        public bool w
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2b xw
        {
            get => new Vector2b(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2b yw
        {
            get => new Vector2b(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2b zw
        {
            get => new Vector2b(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b wx
        {
            get => new Vector2b(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b wy
        {
            get => new Vector2b(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b wz
        {
            get => new Vector2b(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ww
        {
            get => new Vector2b(W, W);
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
        public Vector3b xxw
        {
            get => new Vector3b(X, X, W);
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
        public Vector3b xyw
        {
            get => new Vector3b(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3b xzw
        {
            get => new Vector3b(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b xwx
        {
            get => new Vector3b(X, W, X);
        }

        [XmlIgnore]
        public Vector3b xwy
        {
            get => new Vector3b(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b xwz
        {
            get => new Vector3b(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b xww
        {
            get => new Vector3b(X, W, W);
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
        public Vector3b yxw
        {
            get => new Vector3b(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3b yyw
        {
            get => new Vector3b(Y, Y, W);
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
        public Vector3b yzw
        {
            get => new Vector3b(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b ywx
        {
            get => new Vector3b(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b ywy
        {
            get => new Vector3b(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3b ywz
        {
            get => new Vector3b(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b yww
        {
            get => new Vector3b(Y, W, W);
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
        public Vector3b zxw
        {
            get => new Vector3b(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3b zyw
        {
            get => new Vector3b(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3b zzw
        {
            get => new Vector3b(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3b zwx
        {
            get => new Vector3b(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b zwy
        {
            get => new Vector3b(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b zwz
        {
            get => new Vector3b(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3b zww
        {
            get => new Vector3b(Z, W, W);
        }

        [XmlIgnore]
        public Vector3b wxx
        {
            get => new Vector3b(W, X, X);
        }

        [XmlIgnore]
        public Vector3b wxy
        {
            get => new Vector3b(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wxz
        {
            get => new Vector3b(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wxw
        {
            get => new Vector3b(W, X, W);
        }

        [XmlIgnore]
        public Vector3b wyx
        {
            get => new Vector3b(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wyy
        {
            get => new Vector3b(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3b wyz
        {
            get => new Vector3b(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wyw
        {
            get => new Vector3b(W, Y, W);
        }

        [XmlIgnore]
        public Vector3b wzx
        {
            get => new Vector3b(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wzy
        {
            get => new Vector3b(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b wzz
        {
            get => new Vector3b(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3b wzw
        {
            get => new Vector3b(W, Z, W);
        }

        [XmlIgnore]
        public Vector3b wwx
        {
            get => new Vector3b(W, W, X);
        }

        [XmlIgnore]
        public Vector3b wwy
        {
            get => new Vector3b(W, W, Y);
        }

        [XmlIgnore]
        public Vector3b wwz
        {
            get => new Vector3b(W, W, Z);
        }

        [XmlIgnore]
        public Vector3b www
        {
            get => new Vector3b(W, W, W);
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
        public Vector4b xxxw
        {
            get => new Vector4b(X, X, X, W);
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
        public Vector4b xxyw
        {
            get => new Vector4b(X, X, Y, W);
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
        public Vector4b xxzw
        {
            get => new Vector4b(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b xxwx
        {
            get => new Vector4b(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4b xxwy
        {
            get => new Vector4b(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b xxwz
        {
            get => new Vector4b(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b xxww
        {
            get => new Vector4b(X, X, W, W);
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
        public Vector4b xyxw
        {
            get => new Vector4b(X, Y, X, W);
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
        public Vector4b xyyw
        {
            get => new Vector4b(X, Y, Y, W);
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
        public Vector4b xyzw
        {
            get => new Vector4b(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b xywx
        {
            get => new Vector4b(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b xywy
        {
            get => new Vector4b(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b xywz
        {
            get => new Vector4b(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b xyww
        {
            get => new Vector4b(X, Y, W, W);
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
        public Vector4b xzxw
        {
            get => new Vector4b(X, Z, X, W);
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
        public Vector4b xzyw
        {
            get => new Vector4b(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b xzzw
        {
            get => new Vector4b(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b xzwx
        {
            get => new Vector4b(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b xzwy
        {
            get => new Vector4b(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b xzwz
        {
            get => new Vector4b(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b xzww
        {
            get => new Vector4b(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b xwxx
        {
            get => new Vector4b(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4b xwxy
        {
            get => new Vector4b(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b xwxz
        {
            get => new Vector4b(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b xwxw
        {
            get => new Vector4b(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4b xwyx
        {
            get => new Vector4b(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b xwyy
        {
            get => new Vector4b(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b xwyz
        {
            get => new Vector4b(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b xwyw
        {
            get => new Vector4b(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b xwzx
        {
            get => new Vector4b(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b xwzy
        {
            get => new Vector4b(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b xwzz
        {
            get => new Vector4b(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b xwzw
        {
            get => new Vector4b(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b xwwx
        {
            get => new Vector4b(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4b xwwy
        {
            get => new Vector4b(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b xwwz
        {
            get => new Vector4b(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b xwww
        {
            get => new Vector4b(X, W, W, W);
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
        public Vector4b yxxw
        {
            get => new Vector4b(Y, X, X, W);
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
        public Vector4b yxyw
        {
            get => new Vector4b(Y, X, Y, W);
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
        public Vector4b yxzw
        {
            get => new Vector4b(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b yxwx
        {
            get => new Vector4b(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4b yxwy
        {
            get => new Vector4b(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b yxwz
        {
            get => new Vector4b(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b yxww
        {
            get => new Vector4b(Y, X, W, W);
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
        public Vector4b yyxw
        {
            get => new Vector4b(Y, Y, X, W);
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
        public Vector4b yyyw
        {
            get => new Vector4b(Y, Y, Y, W);
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
        public Vector4b yyzw
        {
            get => new Vector4b(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b yywx
        {
            get => new Vector4b(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b yywy
        {
            get => new Vector4b(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b yywz
        {
            get => new Vector4b(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b yyww
        {
            get => new Vector4b(Y, Y, W, W);
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
        public Vector4b yzxw
        {
            get => new Vector4b(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b yzyw
        {
            get => new Vector4b(Y, Z, Y, W);
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
        public Vector4b yzzw
        {
            get => new Vector4b(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b yzwx
        {
            get => new Vector4b(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b yzwy
        {
            get => new Vector4b(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b yzwz
        {
            get => new Vector4b(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b yzww
        {
            get => new Vector4b(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b ywxx
        {
            get => new Vector4b(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4b ywxy
        {
            get => new Vector4b(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b ywxz
        {
            get => new Vector4b(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b ywxw
        {
            get => new Vector4b(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4b ywyx
        {
            get => new Vector4b(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b ywyy
        {
            get => new Vector4b(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b ywyz
        {
            get => new Vector4b(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b ywyw
        {
            get => new Vector4b(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b ywzx
        {
            get => new Vector4b(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b ywzy
        {
            get => new Vector4b(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b ywzz
        {
            get => new Vector4b(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b ywzw
        {
            get => new Vector4b(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b ywwx
        {
            get => new Vector4b(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4b ywwy
        {
            get => new Vector4b(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b ywwz
        {
            get => new Vector4b(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b ywww
        {
            get => new Vector4b(Y, W, W, W);
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
        public Vector4b zxxw
        {
            get => new Vector4b(Z, X, X, W);
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
        public Vector4b zxyw
        {
            get => new Vector4b(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b zxzw
        {
            get => new Vector4b(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b zxwx
        {
            get => new Vector4b(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4b zxwy
        {
            get => new Vector4b(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b zxwz
        {
            get => new Vector4b(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b zxww
        {
            get => new Vector4b(Z, X, W, W);
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
        public Vector4b zyxw
        {
            get => new Vector4b(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b zyyw
        {
            get => new Vector4b(Z, Y, Y, W);
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
        public Vector4b zyzw
        {
            get => new Vector4b(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b zywx
        {
            get => new Vector4b(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b zywy
        {
            get => new Vector4b(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b zywz
        {
            get => new Vector4b(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b zyww
        {
            get => new Vector4b(Z, Y, W, W);
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
        public Vector4b zzxw
        {
            get => new Vector4b(Z, Z, X, W);
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
        public Vector4b zzyw
        {
            get => new Vector4b(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4b zzzw
        {
            get => new Vector4b(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b zzwx
        {
            get => new Vector4b(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b zzwy
        {
            get => new Vector4b(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b zzwz
        {
            get => new Vector4b(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b zzww
        {
            get => new Vector4b(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b zwxx
        {
            get => new Vector4b(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4b zwxy
        {
            get => new Vector4b(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b zwxz
        {
            get => new Vector4b(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b zwxw
        {
            get => new Vector4b(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4b zwyx
        {
            get => new Vector4b(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b zwyy
        {
            get => new Vector4b(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b zwyz
        {
            get => new Vector4b(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b zwyw
        {
            get => new Vector4b(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b zwzx
        {
            get => new Vector4b(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b zwzy
        {
            get => new Vector4b(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b zwzz
        {
            get => new Vector4b(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b zwzw
        {
            get => new Vector4b(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b zwwx
        {
            get => new Vector4b(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4b zwwy
        {
            get => new Vector4b(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b zwwz
        {
            get => new Vector4b(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b zwww
        {
            get => new Vector4b(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4b wxxx
        {
            get => new Vector4b(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4b wxxy
        {
            get => new Vector4b(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b wxxz
        {
            get => new Vector4b(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b wxxw
        {
            get => new Vector4b(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4b wxyx
        {
            get => new Vector4b(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b wxyy
        {
            get => new Vector4b(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b wxyz
        {
            get => new Vector4b(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wxyw
        {
            get => new Vector4b(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4b wxzx
        {
            get => new Vector4b(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b wxzy
        {
            get => new Vector4b(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wxzz
        {
            get => new Vector4b(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b wxzw
        {
            get => new Vector4b(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b wxwx
        {
            get => new Vector4b(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4b wxwy
        {
            get => new Vector4b(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b wxwz
        {
            get => new Vector4b(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b wxww
        {
            get => new Vector4b(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4b wyxx
        {
            get => new Vector4b(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b wyxy
        {
            get => new Vector4b(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b wyxz
        {
            get => new Vector4b(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wyxw
        {
            get => new Vector4b(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4b wyyx
        {
            get => new Vector4b(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b wyyy
        {
            get => new Vector4b(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b wyyz
        {
            get => new Vector4b(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b wyyw
        {
            get => new Vector4b(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4b wyzx
        {
            get => new Vector4b(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wyzy
        {
            get => new Vector4b(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b wyzz
        {
            get => new Vector4b(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b wyzw
        {
            get => new Vector4b(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b wywx
        {
            get => new Vector4b(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b wywy
        {
            get => new Vector4b(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b wywz
        {
            get => new Vector4b(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b wyww
        {
            get => new Vector4b(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4b wzxx
        {
            get => new Vector4b(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b wzxy
        {
            get => new Vector4b(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wzxz
        {
            get => new Vector4b(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b wzxw
        {
            get => new Vector4b(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4b wzyx
        {
            get => new Vector4b(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b wzyy
        {
            get => new Vector4b(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b wzyz
        {
            get => new Vector4b(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b wzyw
        {
            get => new Vector4b(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4b wzzx
        {
            get => new Vector4b(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b wzzy
        {
            get => new Vector4b(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b wzzz
        {
            get => new Vector4b(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b wzzw
        {
            get => new Vector4b(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b wzwx
        {
            get => new Vector4b(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b wzwy
        {
            get => new Vector4b(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b wzwz
        {
            get => new Vector4b(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b wzww
        {
            get => new Vector4b(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b wwxx
        {
            get => new Vector4b(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4b wwxy
        {
            get => new Vector4b(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b wwxz
        {
            get => new Vector4b(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b wwxw
        {
            get => new Vector4b(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4b wwyx
        {
            get => new Vector4b(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b wwyy
        {
            get => new Vector4b(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b wwyz
        {
            get => new Vector4b(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b wwyw
        {
            get => new Vector4b(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b wwzx
        {
            get => new Vector4b(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b wwzy
        {
            get => new Vector4b(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b wwzz
        {
            get => new Vector4b(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b wwzw
        {
            get => new Vector4b(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b wwwx
        {
            get => new Vector4b(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4b wwwy
        {
            get => new Vector4b(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b wwwz
        {
            get => new Vector4b(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b wwww
        {
            get => new Vector4b(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
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
        public bool a
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2b ra
        {
            get => new Vector2b(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2b ga
        {
            get => new Vector2b(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2b ba
        {
            get => new Vector2b(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ar
        {
            get => new Vector2b(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ag
        {
            get => new Vector2b(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b ab
        {
            get => new Vector2b(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b aa
        {
            get => new Vector2b(W, W);
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
        public Vector3b rra
        {
            get => new Vector3b(X, X, W);
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
        public Vector3b rga
        {
            get => new Vector3b(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3b rba
        {
            get => new Vector3b(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b rar
        {
            get => new Vector3b(X, W, X);
        }

        [XmlIgnore]
        public Vector3b rag
        {
            get => new Vector3b(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b rab
        {
            get => new Vector3b(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b raa
        {
            get => new Vector3b(X, W, W);
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
        public Vector3b gra
        {
            get => new Vector3b(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3b gga
        {
            get => new Vector3b(Y, Y, W);
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
        public Vector3b gba
        {
            get => new Vector3b(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b gar
        {
            get => new Vector3b(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b gag
        {
            get => new Vector3b(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3b gab
        {
            get => new Vector3b(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b gaa
        {
            get => new Vector3b(Y, W, W);
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
        public Vector3b bra
        {
            get => new Vector3b(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3b bga
        {
            get => new Vector3b(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3b bba
        {
            get => new Vector3b(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3b bar
        {
            get => new Vector3b(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b bag
        {
            get => new Vector3b(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b bab
        {
            get => new Vector3b(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3b baa
        {
            get => new Vector3b(Z, W, W);
        }

        [XmlIgnore]
        public Vector3b arr
        {
            get => new Vector3b(W, X, X);
        }

        [XmlIgnore]
        public Vector3b arg
        {
            get => new Vector3b(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b arb
        {
            get => new Vector3b(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b ara
        {
            get => new Vector3b(W, X, W);
        }

        [XmlIgnore]
        public Vector3b agr
        {
            get => new Vector3b(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b agg
        {
            get => new Vector3b(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3b agb
        {
            get => new Vector3b(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b aga
        {
            get => new Vector3b(W, Y, W);
        }

        [XmlIgnore]
        public Vector3b abr
        {
            get => new Vector3b(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b abg
        {
            get => new Vector3b(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b abb
        {
            get => new Vector3b(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3b aba
        {
            get => new Vector3b(W, Z, W);
        }

        [XmlIgnore]
        public Vector3b aar
        {
            get => new Vector3b(W, W, X);
        }

        [XmlIgnore]
        public Vector3b aag
        {
            get => new Vector3b(W, W, Y);
        }

        [XmlIgnore]
        public Vector3b aab
        {
            get => new Vector3b(W, W, Z);
        }

        [XmlIgnore]
        public Vector3b aaa
        {
            get => new Vector3b(W, W, W);
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
        public Vector4b rrra
        {
            get => new Vector4b(X, X, X, W);
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
        public Vector4b rrga
        {
            get => new Vector4b(X, X, Y, W);
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
        public Vector4b rrba
        {
            get => new Vector4b(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b rrar
        {
            get => new Vector4b(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4b rrag
        {
            get => new Vector4b(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b rrab
        {
            get => new Vector4b(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b rraa
        {
            get => new Vector4b(X, X, W, W);
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
        public Vector4b rgra
        {
            get => new Vector4b(X, Y, X, W);
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
        public Vector4b rgga
        {
            get => new Vector4b(X, Y, Y, W);
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
        public Vector4b rgba
        {
            get => new Vector4b(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b rgar
        {
            get => new Vector4b(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b rgag
        {
            get => new Vector4b(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b rgab
        {
            get => new Vector4b(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b rgaa
        {
            get => new Vector4b(X, Y, W, W);
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
        public Vector4b rbra
        {
            get => new Vector4b(X, Z, X, W);
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
        public Vector4b rbga
        {
            get => new Vector4b(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b rbba
        {
            get => new Vector4b(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b rbar
        {
            get => new Vector4b(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b rbag
        {
            get => new Vector4b(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b rbab
        {
            get => new Vector4b(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b rbaa
        {
            get => new Vector4b(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b rarr
        {
            get => new Vector4b(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4b rarg
        {
            get => new Vector4b(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b rarb
        {
            get => new Vector4b(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b rara
        {
            get => new Vector4b(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4b ragr
        {
            get => new Vector4b(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b ragg
        {
            get => new Vector4b(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b ragb
        {
            get => new Vector4b(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b raga
        {
            get => new Vector4b(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b rabr
        {
            get => new Vector4b(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b rabg
        {
            get => new Vector4b(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b rabb
        {
            get => new Vector4b(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b raba
        {
            get => new Vector4b(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b raar
        {
            get => new Vector4b(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4b raag
        {
            get => new Vector4b(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b raab
        {
            get => new Vector4b(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b raaa
        {
            get => new Vector4b(X, W, W, W);
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
        public Vector4b grra
        {
            get => new Vector4b(Y, X, X, W);
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
        public Vector4b grga
        {
            get => new Vector4b(Y, X, Y, W);
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
        public Vector4b grba
        {
            get => new Vector4b(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b grar
        {
            get => new Vector4b(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4b grag
        {
            get => new Vector4b(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b grab
        {
            get => new Vector4b(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b graa
        {
            get => new Vector4b(Y, X, W, W);
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
        public Vector4b ggra
        {
            get => new Vector4b(Y, Y, X, W);
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
        public Vector4b ggga
        {
            get => new Vector4b(Y, Y, Y, W);
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
        public Vector4b ggba
        {
            get => new Vector4b(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b ggar
        {
            get => new Vector4b(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b ggag
        {
            get => new Vector4b(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b ggab
        {
            get => new Vector4b(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b ggaa
        {
            get => new Vector4b(Y, Y, W, W);
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
        public Vector4b gbra
        {
            get => new Vector4b(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b gbga
        {
            get => new Vector4b(Y, Z, Y, W);
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
        public Vector4b gbba
        {
            get => new Vector4b(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b gbar
        {
            get => new Vector4b(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b gbag
        {
            get => new Vector4b(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b gbab
        {
            get => new Vector4b(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b gbaa
        {
            get => new Vector4b(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b garr
        {
            get => new Vector4b(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4b garg
        {
            get => new Vector4b(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b garb
        {
            get => new Vector4b(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b gara
        {
            get => new Vector4b(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4b gagr
        {
            get => new Vector4b(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b gagg
        {
            get => new Vector4b(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b gagb
        {
            get => new Vector4b(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b gaga
        {
            get => new Vector4b(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b gabr
        {
            get => new Vector4b(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b gabg
        {
            get => new Vector4b(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b gabb
        {
            get => new Vector4b(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b gaba
        {
            get => new Vector4b(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b gaar
        {
            get => new Vector4b(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4b gaag
        {
            get => new Vector4b(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b gaab
        {
            get => new Vector4b(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b gaaa
        {
            get => new Vector4b(Y, W, W, W);
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
        public Vector4b brra
        {
            get => new Vector4b(Z, X, X, W);
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
        public Vector4b brga
        {
            get => new Vector4b(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b brba
        {
            get => new Vector4b(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b brar
        {
            get => new Vector4b(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4b brag
        {
            get => new Vector4b(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b brab
        {
            get => new Vector4b(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b braa
        {
            get => new Vector4b(Z, X, W, W);
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
        public Vector4b bgra
        {
            get => new Vector4b(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b bgga
        {
            get => new Vector4b(Z, Y, Y, W);
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
        public Vector4b bgba
        {
            get => new Vector4b(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b bgar
        {
            get => new Vector4b(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b bgag
        {
            get => new Vector4b(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b bgab
        {
            get => new Vector4b(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b bgaa
        {
            get => new Vector4b(Z, Y, W, W);
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
        public Vector4b bbra
        {
            get => new Vector4b(Z, Z, X, W);
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
        public Vector4b bbga
        {
            get => new Vector4b(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4b bbba
        {
            get => new Vector4b(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b bbar
        {
            get => new Vector4b(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b bbag
        {
            get => new Vector4b(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b bbab
        {
            get => new Vector4b(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b bbaa
        {
            get => new Vector4b(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b barr
        {
            get => new Vector4b(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4b barg
        {
            get => new Vector4b(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b barb
        {
            get => new Vector4b(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b bara
        {
            get => new Vector4b(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4b bagr
        {
            get => new Vector4b(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b bagg
        {
            get => new Vector4b(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b bagb
        {
            get => new Vector4b(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b baga
        {
            get => new Vector4b(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b babr
        {
            get => new Vector4b(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b babg
        {
            get => new Vector4b(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b babb
        {
            get => new Vector4b(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b baba
        {
            get => new Vector4b(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b baar
        {
            get => new Vector4b(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4b baag
        {
            get => new Vector4b(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b baab
        {
            get => new Vector4b(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b baaa
        {
            get => new Vector4b(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4b arrr
        {
            get => new Vector4b(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4b arrg
        {
            get => new Vector4b(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b arrb
        {
            get => new Vector4b(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b arra
        {
            get => new Vector4b(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4b argr
        {
            get => new Vector4b(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b argg
        {
            get => new Vector4b(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b argb
        {
            get => new Vector4b(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b arga
        {
            get => new Vector4b(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4b arbr
        {
            get => new Vector4b(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b arbg
        {
            get => new Vector4b(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b arbb
        {
            get => new Vector4b(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b arba
        {
            get => new Vector4b(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b arar
        {
            get => new Vector4b(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4b arag
        {
            get => new Vector4b(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b arab
        {
            get => new Vector4b(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b araa
        {
            get => new Vector4b(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4b agrr
        {
            get => new Vector4b(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b agrg
        {
            get => new Vector4b(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b agrb
        {
            get => new Vector4b(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b agra
        {
            get => new Vector4b(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4b aggr
        {
            get => new Vector4b(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b aggg
        {
            get => new Vector4b(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b aggb
        {
            get => new Vector4b(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b agga
        {
            get => new Vector4b(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4b agbr
        {
            get => new Vector4b(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b agbg
        {
            get => new Vector4b(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b agbb
        {
            get => new Vector4b(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b agba
        {
            get => new Vector4b(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b agar
        {
            get => new Vector4b(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b agag
        {
            get => new Vector4b(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b agab
        {
            get => new Vector4b(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b agaa
        {
            get => new Vector4b(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4b abrr
        {
            get => new Vector4b(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b abrg
        {
            get => new Vector4b(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b abrb
        {
            get => new Vector4b(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b abra
        {
            get => new Vector4b(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4b abgr
        {
            get => new Vector4b(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b abgg
        {
            get => new Vector4b(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b abgb
        {
            get => new Vector4b(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b abga
        {
            get => new Vector4b(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4b abbr
        {
            get => new Vector4b(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b abbg
        {
            get => new Vector4b(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b abbb
        {
            get => new Vector4b(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b abba
        {
            get => new Vector4b(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b abar
        {
            get => new Vector4b(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b abag
        {
            get => new Vector4b(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b abab
        {
            get => new Vector4b(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b abaa
        {
            get => new Vector4b(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b aarr
        {
            get => new Vector4b(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4b aarg
        {
            get => new Vector4b(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b aarb
        {
            get => new Vector4b(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b aara
        {
            get => new Vector4b(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4b aagr
        {
            get => new Vector4b(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b aagg
        {
            get => new Vector4b(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b aagb
        {
            get => new Vector4b(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b aaga
        {
            get => new Vector4b(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b aabr
        {
            get => new Vector4b(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b aabg
        {
            get => new Vector4b(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b aabb
        {
            get => new Vector4b(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b aaba
        {
            get => new Vector4b(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b aaar
        {
            get => new Vector4b(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4b aaag
        {
            get => new Vector4b(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b aaab
        {
            get => new Vector4b(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b aaaa
        {
            get => new Vector4b(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
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
        public bool q
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2b sq
        {
            get => new Vector2b(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2b tq
        {
            get => new Vector2b(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2b pq
        {
            get => new Vector2b(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b qs
        {
            get => new Vector2b(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b qt
        {
            get => new Vector2b(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b qp
        {
            get => new Vector2b(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2b qq
        {
            get => new Vector2b(W, W);
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
        public Vector3b ssq
        {
            get => new Vector3b(X, X, W);
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
        public Vector3b stq
        {
            get => new Vector3b(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3b spq
        {
            get => new Vector3b(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b sqs
        {
            get => new Vector3b(X, W, X);
        }

        [XmlIgnore]
        public Vector3b sqt
        {
            get => new Vector3b(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b sqp
        {
            get => new Vector3b(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b sqq
        {
            get => new Vector3b(X, W, W);
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
        public Vector3b tsq
        {
            get => new Vector3b(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3b ttq
        {
            get => new Vector3b(Y, Y, W);
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
        public Vector3b tpq
        {
            get => new Vector3b(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b tqs
        {
            get => new Vector3b(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b tqt
        {
            get => new Vector3b(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3b tqp
        {
            get => new Vector3b(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b tqq
        {
            get => new Vector3b(Y, W, W);
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
        public Vector3b psq
        {
            get => new Vector3b(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3b ptq
        {
            get => new Vector3b(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3b ppq
        {
            get => new Vector3b(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3b pqs
        {
            get => new Vector3b(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b pqt
        {
            get => new Vector3b(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b pqp
        {
            get => new Vector3b(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3b pqq
        {
            get => new Vector3b(Z, W, W);
        }

        [XmlIgnore]
        public Vector3b qss
        {
            get => new Vector3b(W, X, X);
        }

        [XmlIgnore]
        public Vector3b qst
        {
            get => new Vector3b(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qsp
        {
            get => new Vector3b(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qsq
        {
            get => new Vector3b(W, X, W);
        }

        [XmlIgnore]
        public Vector3b qts
        {
            get => new Vector3b(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qtt
        {
            get => new Vector3b(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3b qtp
        {
            get => new Vector3b(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qtq
        {
            get => new Vector3b(W, Y, W);
        }

        [XmlIgnore]
        public Vector3b qps
        {
            get => new Vector3b(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qpt
        {
            get => new Vector3b(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3b qpp
        {
            get => new Vector3b(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3b qpq
        {
            get => new Vector3b(W, Z, W);
        }

        [XmlIgnore]
        public Vector3b qqs
        {
            get => new Vector3b(W, W, X);
        }

        [XmlIgnore]
        public Vector3b qqt
        {
            get => new Vector3b(W, W, Y);
        }

        [XmlIgnore]
        public Vector3b qqp
        {
            get => new Vector3b(W, W, Z);
        }

        [XmlIgnore]
        public Vector3b qqq
        {
            get => new Vector3b(W, W, W);
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
        public Vector4b sssq
        {
            get => new Vector4b(X, X, X, W);
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
        public Vector4b sstq
        {
            get => new Vector4b(X, X, Y, W);
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
        public Vector4b sspq
        {
            get => new Vector4b(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b ssqs
        {
            get => new Vector4b(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4b ssqt
        {
            get => new Vector4b(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b ssqp
        {
            get => new Vector4b(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b ssqq
        {
            get => new Vector4b(X, X, W, W);
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
        public Vector4b stsq
        {
            get => new Vector4b(X, Y, X, W);
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
        public Vector4b sttq
        {
            get => new Vector4b(X, Y, Y, W);
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
        public Vector4b stpq
        {
            get => new Vector4b(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b stqs
        {
            get => new Vector4b(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b stqt
        {
            get => new Vector4b(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b stqp
        {
            get => new Vector4b(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b stqq
        {
            get => new Vector4b(X, Y, W, W);
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
        public Vector4b spsq
        {
            get => new Vector4b(X, Z, X, W);
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
        public Vector4b sptq
        {
            get => new Vector4b(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b sppq
        {
            get => new Vector4b(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b spqs
        {
            get => new Vector4b(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b spqt
        {
            get => new Vector4b(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b spqp
        {
            get => new Vector4b(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b spqq
        {
            get => new Vector4b(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b sqss
        {
            get => new Vector4b(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4b sqst
        {
            get => new Vector4b(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b sqsp
        {
            get => new Vector4b(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b sqsq
        {
            get => new Vector4b(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4b sqts
        {
            get => new Vector4b(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b sqtt
        {
            get => new Vector4b(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b sqtp
        {
            get => new Vector4b(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b sqtq
        {
            get => new Vector4b(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b sqps
        {
            get => new Vector4b(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b sqpt
        {
            get => new Vector4b(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b sqpp
        {
            get => new Vector4b(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b sqpq
        {
            get => new Vector4b(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b sqqs
        {
            get => new Vector4b(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4b sqqt
        {
            get => new Vector4b(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b sqqp
        {
            get => new Vector4b(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b sqqq
        {
            get => new Vector4b(X, W, W, W);
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
        public Vector4b tssq
        {
            get => new Vector4b(Y, X, X, W);
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
        public Vector4b tstq
        {
            get => new Vector4b(Y, X, Y, W);
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
        public Vector4b tspq
        {
            get => new Vector4b(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b tsqs
        {
            get => new Vector4b(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4b tsqt
        {
            get => new Vector4b(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b tsqp
        {
            get => new Vector4b(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b tsqq
        {
            get => new Vector4b(Y, X, W, W);
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
        public Vector4b ttsq
        {
            get => new Vector4b(Y, Y, X, W);
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
        public Vector4b tttq
        {
            get => new Vector4b(Y, Y, Y, W);
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
        public Vector4b ttpq
        {
            get => new Vector4b(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b ttqs
        {
            get => new Vector4b(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b ttqt
        {
            get => new Vector4b(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b ttqp
        {
            get => new Vector4b(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b ttqq
        {
            get => new Vector4b(Y, Y, W, W);
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
        public Vector4b tpsq
        {
            get => new Vector4b(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b tptq
        {
            get => new Vector4b(Y, Z, Y, W);
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
        public Vector4b tppq
        {
            get => new Vector4b(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b tpqs
        {
            get => new Vector4b(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b tpqt
        {
            get => new Vector4b(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b tpqp
        {
            get => new Vector4b(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b tpqq
        {
            get => new Vector4b(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b tqss
        {
            get => new Vector4b(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4b tqst
        {
            get => new Vector4b(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b tqsp
        {
            get => new Vector4b(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b tqsq
        {
            get => new Vector4b(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4b tqts
        {
            get => new Vector4b(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b tqtt
        {
            get => new Vector4b(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b tqtp
        {
            get => new Vector4b(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b tqtq
        {
            get => new Vector4b(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b tqps
        {
            get => new Vector4b(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b tqpt
        {
            get => new Vector4b(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b tqpp
        {
            get => new Vector4b(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b tqpq
        {
            get => new Vector4b(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b tqqs
        {
            get => new Vector4b(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4b tqqt
        {
            get => new Vector4b(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b tqqp
        {
            get => new Vector4b(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b tqqq
        {
            get => new Vector4b(Y, W, W, W);
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
        public Vector4b pssq
        {
            get => new Vector4b(Z, X, X, W);
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
        public Vector4b pstq
        {
            get => new Vector4b(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4b pspq
        {
            get => new Vector4b(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b psqs
        {
            get => new Vector4b(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4b psqt
        {
            get => new Vector4b(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b psqp
        {
            get => new Vector4b(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b psqq
        {
            get => new Vector4b(Z, X, W, W);
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
        public Vector4b ptsq
        {
            get => new Vector4b(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4b pttq
        {
            get => new Vector4b(Z, Y, Y, W);
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
        public Vector4b ptpq
        {
            get => new Vector4b(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b ptqs
        {
            get => new Vector4b(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b ptqt
        {
            get => new Vector4b(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b ptqp
        {
            get => new Vector4b(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b ptqq
        {
            get => new Vector4b(Z, Y, W, W);
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
        public Vector4b ppsq
        {
            get => new Vector4b(Z, Z, X, W);
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
        public Vector4b pptq
        {
            get => new Vector4b(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4b pppq
        {
            get => new Vector4b(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b ppqs
        {
            get => new Vector4b(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b ppqt
        {
            get => new Vector4b(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b ppqp
        {
            get => new Vector4b(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b ppqq
        {
            get => new Vector4b(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b pqss
        {
            get => new Vector4b(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4b pqst
        {
            get => new Vector4b(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b pqsp
        {
            get => new Vector4b(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b pqsq
        {
            get => new Vector4b(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4b pqts
        {
            get => new Vector4b(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b pqtt
        {
            get => new Vector4b(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b pqtp
        {
            get => new Vector4b(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b pqtq
        {
            get => new Vector4b(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b pqps
        {
            get => new Vector4b(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b pqpt
        {
            get => new Vector4b(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b pqpp
        {
            get => new Vector4b(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b pqpq
        {
            get => new Vector4b(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b pqqs
        {
            get => new Vector4b(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4b pqqt
        {
            get => new Vector4b(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b pqqp
        {
            get => new Vector4b(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b pqqq
        {
            get => new Vector4b(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4b qsss
        {
            get => new Vector4b(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4b qsst
        {
            get => new Vector4b(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4b qssp
        {
            get => new Vector4b(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4b qssq
        {
            get => new Vector4b(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4b qsts
        {
            get => new Vector4b(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4b qstt
        {
            get => new Vector4b(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4b qstp
        {
            get => new Vector4b(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qstq
        {
            get => new Vector4b(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4b qsps
        {
            get => new Vector4b(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4b qspt
        {
            get => new Vector4b(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qspp
        {
            get => new Vector4b(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4b qspq
        {
            get => new Vector4b(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4b qsqs
        {
            get => new Vector4b(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4b qsqt
        {
            get => new Vector4b(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4b qsqp
        {
            get => new Vector4b(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4b qsqq
        {
            get => new Vector4b(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4b qtss
        {
            get => new Vector4b(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4b qtst
        {
            get => new Vector4b(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4b qtsp
        {
            get => new Vector4b(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qtsq
        {
            get => new Vector4b(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4b qtts
        {
            get => new Vector4b(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4b qttt
        {
            get => new Vector4b(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4b qttp
        {
            get => new Vector4b(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4b qttq
        {
            get => new Vector4b(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4b qtps
        {
            get => new Vector4b(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qtpt
        {
            get => new Vector4b(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4b qtpp
        {
            get => new Vector4b(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4b qtpq
        {
            get => new Vector4b(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4b qtqs
        {
            get => new Vector4b(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4b qtqt
        {
            get => new Vector4b(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4b qtqp
        {
            get => new Vector4b(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4b qtqq
        {
            get => new Vector4b(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4b qpss
        {
            get => new Vector4b(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4b qpst
        {
            get => new Vector4b(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qpsp
        {
            get => new Vector4b(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4b qpsq
        {
            get => new Vector4b(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4b qpts
        {
            get => new Vector4b(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4b qptt
        {
            get => new Vector4b(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4b qptp
        {
            get => new Vector4b(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4b qptq
        {
            get => new Vector4b(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4b qpps
        {
            get => new Vector4b(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4b qppt
        {
            get => new Vector4b(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4b qppp
        {
            get => new Vector4b(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4b qppq
        {
            get => new Vector4b(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4b qpqs
        {
            get => new Vector4b(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4b qpqt
        {
            get => new Vector4b(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4b qpqp
        {
            get => new Vector4b(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4b qpqq
        {
            get => new Vector4b(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4b qqss
        {
            get => new Vector4b(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4b qqst
        {
            get => new Vector4b(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4b qqsp
        {
            get => new Vector4b(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4b qqsq
        {
            get => new Vector4b(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4b qqts
        {
            get => new Vector4b(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4b qqtt
        {
            get => new Vector4b(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4b qqtp
        {
            get => new Vector4b(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4b qqtq
        {
            get => new Vector4b(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4b qqps
        {
            get => new Vector4b(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4b qqpt
        {
            get => new Vector4b(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4b qqpp
        {
            get => new Vector4b(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4b qqpq
        {
            get => new Vector4b(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4b qqqs
        {
            get => new Vector4b(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4b qqqt
        {
            get => new Vector4b(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4b qqqp
        {
            get => new Vector4b(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4b qqqq
        {
            get => new Vector4b(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector4b"/> object with the same component values as the <see cref="Vector4b"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector4"/> instance.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(X ? 1 : 0, Y ? 1 : 0, Z ? 1 : 0, W ? 1 : 0);
        }

        /// <summary>
        /// Gets a <see cref="Vector4"/> object with the same component values as the <see cref="Vector4b"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector4b"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector4"/>.</param>
        public static void ToVector4(ref Vector4b input, out Vector4 result)
        {
            result.X = input.X ? 1 : 0;
            result.Y = input.Y ? 1 : 0;
            result.Z = input.Z ? 1 : 0;
            result.W = input.W ? 1 : 0;
        }

        /// <summary>
        /// Logical addition (OR) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector4b operator +(Vector4b vector, bool value)
        {
            vector.X |= value;
            vector.Y |= value;
            vector.Z |= value;
            vector.W |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of OR.</returns>
        [Pure]
        public static Vector4b operator +(bool value, Vector4b vector)
        {
            vector.X |= value;
            vector.Y |= value;
            vector.Z |= value;
            vector.W |= value;
            return vector;
        }

        /// <summary>
        /// Logical addition (OR) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of OR operation.</returns>
        [Pure]
        public static Vector4b operator +(Vector4b left, Vector4b right)
        {
            left.X |= right.X;
            left.Y |= right.Y;
            left.Z |= right.Z;
            left.W |= right.W;
            return left;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instance by a bool.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector4b operator *(Vector4b vector, bool value)
        {
            vector.X &= value;
            vector.Y &= value;
            vector.Z &= value;
            vector.W &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the bool value by a specified instance.
        /// </summary>
        /// <param name="value">Left operand.</param>
        /// <param name="vector">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector4b operator *(bool value, Vector4b vector)
        {
            vector.X &= value;
            vector.Y &= value;
            vector.Z &= value;
            vector.W &= value;
            return vector;
        }

        /// <summary>
        /// Logical multiplies (AND) the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of AND.</returns>
        [Pure]
        public static Vector4b operator *(Vector4b left, Vector4b right)
        {
            left.X &= right.X;
            left.Y &= right.Y;
            left.Z &= right.Z;
            left.W &= right.W;
            return left;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="value">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector4b operator ^(Vector4b vector, bool value)
        {
            vector.X ^= value;
            vector.Y ^= value;
            vector.Z ^= value;
            vector.W ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="value">Right operand.</param>
        /// <param name="vector">Left operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector4b operator ^(bool value, Vector4b vector)
        {
            vector.X ^= value;
            vector.Y ^= value;
            vector.Z ^= value;
            vector.W ^= value;
            return vector;
        }

        /// <summary>
        /// Logical XOR operation.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of XOR.</returns>
        [Pure]
        public static Vector4b operator ^(Vector4b left, Vector4b right)
        {
            left.X ^= right.X;
            left.Y ^= right.Y;
            left.Z ^= right.Z;
            left.W ^= right.W;
            return left;
        }

        /// <summary>
        /// Logical inversion (NOT) the specified instance.
        /// </summary>
        /// <param name="vector">Operand.</param>
        /// <returns>Result of NOT.</returns>
        [Pure]
        public static Vector4b operator !(Vector4b vector)
        {
            vector.X = !vector.X;
            vector.Y = !vector.Y;
            vector.Z = !vector.Z;
            vector.W = !vector.W;
            return vector;
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Vector4b left, Vector4b right)
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
        public static bool operator !=(Vector4b left, Vector4b right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4b"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4b"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4b((bool X, bool Y, bool Z, bool W) values)
        {
            return new Vector4b(values.X, values.Y, values.Z, values.W);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
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
            return ((W ? 1 : 0) << 3) | ((Z ? 1 : 0) << 2) | ((Y ? 1 : 0) << 1) | (X ? 1 : 0);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4b))
            {
                return false;
            }

            return Equals((Vector4b)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector4b other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        [Pure]
        public void Deconstruct(out bool x, out bool y, out bool z, out bool w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}