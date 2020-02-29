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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenToolkit.Mathematics
{
    /// <summary>
    /// Represents a 4D vector using four 32-bit unsigned integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector4u structure is suitable for interoperation with unmanaged code requiring four consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4u : IEquatable<Vector4u>
    {
        /// <summary>
        /// The X component of the Vector4u.
        /// </summary>
        public uint X;

        /// <summary>
        /// The Y component of the Vector4u.
        /// </summary>
        public uint Y;

        /// <summary>
        /// The Z component of the Vector4u.
        /// </summary>
        public uint Z;

        /// <summary>
        /// The W component of the Vector4u.
        /// </summary>
        public uint W;

        /// <summary>
        /// Defines a unit-length <see cref="Vector4u"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector4u UnitX = new Vector4u(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4u"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4u UnitY = new Vector4u(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4u"/> that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4u UnitZ = new Vector4u(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4u"/> that points towards the W-axis.
        /// </summary>
        public static readonly Vector4u UnitW = new Vector4u(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length <see cref="Vector4u"/>.
        /// </summary>
        public static readonly Vector4u Zero = new Vector4u(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4u One = new Vector4u(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the <see cref="Vector4u"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector4u>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4u(uint value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector4u.</param>
        /// <param name="y">The Y component of the Vector4u.</param>
        /// <param name="z">The Z component of the Vector4u.</param>
        /// <param name="w">The W component of the Vector4u.</param>
        public Vector4u(uint x, uint y, uint z, uint w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct.
        /// </summary>
        /// <param name="v">The Vector2 to copy components from.</param>
        public Vector4u(Vector2u v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3u"/> to copy components from.</param>
        public Vector4u(Vector3u v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3u"/> to copy components from.</param>
        /// <param name="w">The w component of the new Vector4.</param>
        public Vector4u(Vector3u v, uint w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Gets or sets the value at the index of the vector.
        /// </summary>
        /// <param name="index">The index of the component from the vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 3.</exception>
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
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector4u Add(Vector4u a, Vector4u b)
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
        public static void Add(ref Vector4u a, ref Vector4u b, out Vector4u result)
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
        public static Vector4u Subtract(Vector4u a, Vector4u b)
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
        public static void Subtract(ref Vector4u a, ref Vector4u b, out Vector4u result)
        {
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
            result.Z = a.Z - b.Z;
            result.W = a.W - b.W;
        }

        /// <summary>
        /// Multiplies a vector by an integer scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4u Multiply(Vector4u vector, uint scale)
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
        public static void Multiply(ref Vector4u vector, uint scale, out Vector4u result)
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
        public static Vector4u Multiply(Vector4u vector, Vector4u scale)
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
        public static void Multiply(ref Vector4u vector, ref Vector4u scale, out Vector4u result)
        {
            result.X = vector.X * scale.X;
            result.Y = vector.Y * scale.Y;
            result.Z = vector.Z * scale.Z;
            result.W = vector.W * scale.W;
        }

        /// <summary>
        /// Divides a vector by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4u Divide(Vector4u vector, uint scale)
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
        public static void Divide(ref Vector4u vector, uint scale, out Vector4u result)
        {
            result.X = vector.X / scale;
            result.Y = vector.Y / scale;
            result.Z = vector.Z / scale;
            result.W = vector.W / scale;
        }

        /// <summary>
        /// Divides a vector by the components of a vector using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector4u Divide(Vector4u vector, Vector4u scale)
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
        public static void Divide(ref Vector4u vector, ref Vector4u scale, out Vector4u result)
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
        public static Vector4u ComponentMin(Vector4u a, Vector4u b)
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
        public static void ComponentMin(ref Vector4u a, ref Vector4u b, out Vector4u result)
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
        public static Vector4u ComponentMax(Vector4u a, Vector4u b)
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
        public static void ComponentMax(ref Vector4u a, ref Vector4u b, out Vector4u result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
            result.W = a.W > b.W ? a.W : b.W;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <returns>The clamped vector.</returns>
        [Pure]
        public static Vector4u Clamp(Vector4u vec, Vector4u min, Vector4u max)
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
        public static void Clamp(ref Vector4u vec, ref Vector4u min, ref Vector4u max, out Vector4u result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.W < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        #region Components
        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Xy
        {
            get => Unsafe.As<Vector4u, Vector2u>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Xz
        {
            get => new Vector2u(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Xw
        {
            get => new Vector2u(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
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

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Yz
        {
            get => new Vector2u(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Yw
        {
            get => new Vector2u(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Zx
        {
            get => new Vector2u(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Zy
        {
            get => new Vector2u(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Zw
        {
            get => new Vector2u(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Wx
        {
            get => new Vector2u(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Wy
        {
            get => new Vector2u(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Wz
        {
            get => new Vector2u(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xyz
        {
            get => Unsafe.As<Vector4u, Vector3u>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xyw
        {
            get => new Vector3u(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xzy
        {
            get => new Vector3u(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xzw
        {
            get => new Vector3u(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xwy
        {
            get => new Vector3u(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Xwz
        {
            get => new Vector3u(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Yxz
        {
            get => new Vector3u(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Yxw
        {
            get => new Vector3u(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Yzx
        {
            get => new Vector3u(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Yzw
        {
            get => new Vector3u(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Ywx
        {
            get => new Vector3u(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Ywz
        {
            get => new Vector3u(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zxy
        {
            get => new Vector3u(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zxw
        {
            get => new Vector3u(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zyx
        {
            get => new Vector3u(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zyw
        {
            get => new Vector3u(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zwx
        {
            get => new Vector3u(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Zwy
        {
            get => new Vector3u(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wxy
        {
            get => new Vector3u(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wxz
        {
            get => new Vector3u(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wyx
        {
            get => new Vector3u(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wyz
        {
            get => new Vector3u(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wzx
        {
            get => new Vector3u(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3u"/> with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3u Wzy
        {
            get => new Vector3u(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Xywz
        {
            get => new Vector4u(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Xzyw
        {
            get => new Vector4u(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Xzwy
        {
            get => new Vector4u(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Xwyz
        {
            get => new Vector4u(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Xwzy
        {
            get => new Vector4u(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yxzw
        {
            get => new Vector4u(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yxwz
        {
            get => new Vector4u(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yyzw
        {
            get => new Vector4u(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yywz
        {
            get => new Vector4u(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yzxw
        {
            get => new Vector4u(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Yzwx
        {
            get => new Vector4u(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Ywxz
        {
            get => new Vector4u(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Ywzx
        {
            get => new Vector4u(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zxyw
        {
            get => new Vector4u(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zxwy
        {
            get => new Vector4u(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zyxw
        {
            get => new Vector4u(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zywx
        {
            get => new Vector4u(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zwxy
        {
            get => new Vector4u(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zwyx
        {
            get => new Vector4u(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Zwzy
        {
            get => new Vector4u(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wxyz
        {
            get => new Vector4u(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wxzy
        {
            get => new Vector4u(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wyxz
        {
            get => new Vector4u(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wyzx
        {
            get => new Vector4u(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wzxy
        {
            get => new Vector4u(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wzyx
        {
            get => new Vector4u(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4u"/> with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4u Wzyw
        {
            get => new Vector4u(W, Z, Y, W);
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
        public uint z
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public uint w
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2u xz
        {
            get => new Vector2u(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u xw
        {
            get => new Vector2u(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2u yz
        {
            get => new Vector2u(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u yw
        {
            get => new Vector2u(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u zx
        {
            get => new Vector2u(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u zy
        {
            get => new Vector2u(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u zz
        {
            get => new Vector2u(Z, Z);
        }

        [XmlIgnore]
        public Vector2u zw
        {
            get => new Vector2u(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u wx
        {
            get => new Vector2u(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u wy
        {
            get => new Vector2u(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u wz
        {
            get => new Vector2u(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ww
        {
            get => new Vector2u(W, W);
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
        public Vector3u xxz
        {
            get => new Vector3u(X, X, Z);
        }

        [XmlIgnore]
        public Vector3u xxw
        {
            get => new Vector3u(X, X, W);
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
        public Vector3u xyz
        {
            get => new Vector3u(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xyw
        {
            get => new Vector3u(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xzx
        {
            get => new Vector3u(X, Z, X);
        }

        [XmlIgnore]
        public Vector3u xzy
        {
            get => new Vector3u(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xzz
        {
            get => new Vector3u(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3u xzw
        {
            get => new Vector3u(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xwx
        {
            get => new Vector3u(X, W, X);
        }

        [XmlIgnore]
        public Vector3u xwy
        {
            get => new Vector3u(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xwz
        {
            get => new Vector3u(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u xww
        {
            get => new Vector3u(X, W, W);
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
        public Vector3u yxz
        {
            get => new Vector3u(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u yxw
        {
            get => new Vector3u(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3u yyz
        {
            get => new Vector3u(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3u yyw
        {
            get => new Vector3u(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3u yzx
        {
            get => new Vector3u(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u yzy
        {
            get => new Vector3u(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3u yzz
        {
            get => new Vector3u(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3u yzw
        {
            get => new Vector3u(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u ywx
        {
            get => new Vector3u(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u ywy
        {
            get => new Vector3u(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3u ywz
        {
            get => new Vector3u(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u yww
        {
            get => new Vector3u(Y, W, W);
        }

        [XmlIgnore]
        public Vector3u zxx
        {
            get => new Vector3u(Z, X, X);
        }

        [XmlIgnore]
        public Vector3u zxy
        {
            get => new Vector3u(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zxz
        {
            get => new Vector3u(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3u zxw
        {
            get => new Vector3u(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zyx
        {
            get => new Vector3u(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zyy
        {
            get => new Vector3u(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3u zyz
        {
            get => new Vector3u(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3u zyw
        {
            get => new Vector3u(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zzx
        {
            get => new Vector3u(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3u zzy
        {
            get => new Vector3u(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3u zzz
        {
            get => new Vector3u(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3u zzw
        {
            get => new Vector3u(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3u zwx
        {
            get => new Vector3u(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zwy
        {
            get => new Vector3u(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u zwz
        {
            get => new Vector3u(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3u zww
        {
            get => new Vector3u(Z, W, W);
        }

        [XmlIgnore]
        public Vector3u wxx
        {
            get => new Vector3u(W, X, X);
        }

        [XmlIgnore]
        public Vector3u wxy
        {
            get => new Vector3u(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wxz
        {
            get => new Vector3u(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wxw
        {
            get => new Vector3u(W, X, W);
        }

        [XmlIgnore]
        public Vector3u wyx
        {
            get => new Vector3u(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wyy
        {
            get => new Vector3u(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3u wyz
        {
            get => new Vector3u(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wyw
        {
            get => new Vector3u(W, Y, W);
        }

        [XmlIgnore]
        public Vector3u wzx
        {
            get => new Vector3u(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wzy
        {
            get => new Vector3u(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u wzz
        {
            get => new Vector3u(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3u wzw
        {
            get => new Vector3u(W, Z, W);
        }

        [XmlIgnore]
        public Vector3u wwx
        {
            get => new Vector3u(W, W, X);
        }

        [XmlIgnore]
        public Vector3u wwy
        {
            get => new Vector3u(W, W, Y);
        }

        [XmlIgnore]
        public Vector3u wwz
        {
            get => new Vector3u(W, W, Z);
        }

        [XmlIgnore]
        public Vector3u www
        {
            get => new Vector3u(W, W, W);
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
        public Vector4u xxxz
        {
            get => new Vector4u(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u xxxw
        {
            get => new Vector4u(X, X, X, W);
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
        public Vector4u xxyz
        {
            get => new Vector4u(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u xxyw
        {
            get => new Vector4u(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u xxzx
        {
            get => new Vector4u(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u xxzy
        {
            get => new Vector4u(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u xxzz
        {
            get => new Vector4u(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u xxzw
        {
            get => new Vector4u(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u xxwx
        {
            get => new Vector4u(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4u xxwy
        {
            get => new Vector4u(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u xxwz
        {
            get => new Vector4u(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u xxww
        {
            get => new Vector4u(X, X, W, W);
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
        public Vector4u xyxz
        {
            get => new Vector4u(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u xyxw
        {
            get => new Vector4u(X, Y, X, W);
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
        public Vector4u xyyz
        {
            get => new Vector4u(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u xyyw
        {
            get => new Vector4u(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u xyzx
        {
            get => new Vector4u(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u xyzy
        {
            get => new Vector4u(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u xyzz
        {
            get => new Vector4u(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u xyzw
        {
            get => new Vector4u(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xywx
        {
            get => new Vector4u(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u xywy
        {
            get => new Vector4u(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u xywz
        {
            get => new Vector4u(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xyww
        {
            get => new Vector4u(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u xzxx
        {
            get => new Vector4u(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u xzxy
        {
            get => new Vector4u(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u xzxz
        {
            get => new Vector4u(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u xzxw
        {
            get => new Vector4u(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u xzyx
        {
            get => new Vector4u(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u xzyy
        {
            get => new Vector4u(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u xzyz
        {
            get => new Vector4u(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u xzyw
        {
            get => new Vector4u(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xzzx
        {
            get => new Vector4u(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u xzzy
        {
            get => new Vector4u(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u xzzz
        {
            get => new Vector4u(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u xzzw
        {
            get => new Vector4u(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u xzwx
        {
            get => new Vector4u(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u xzwy
        {
            get => new Vector4u(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xzwz
        {
            get => new Vector4u(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u xzww
        {
            get => new Vector4u(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u xwxx
        {
            get => new Vector4u(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4u xwxy
        {
            get => new Vector4u(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u xwxz
        {
            get => new Vector4u(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u xwxw
        {
            get => new Vector4u(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4u xwyx
        {
            get => new Vector4u(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u xwyy
        {
            get => new Vector4u(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u xwyz
        {
            get => new Vector4u(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xwyw
        {
            get => new Vector4u(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u xwzx
        {
            get => new Vector4u(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u xwzy
        {
            get => new Vector4u(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u xwzz
        {
            get => new Vector4u(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u xwzw
        {
            get => new Vector4u(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u xwwx
        {
            get => new Vector4u(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4u xwwy
        {
            get => new Vector4u(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u xwwz
        {
            get => new Vector4u(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u xwww
        {
            get => new Vector4u(X, W, W, W);
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
        public Vector4u yxxz
        {
            get => new Vector4u(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u yxxw
        {
            get => new Vector4u(Y, X, X, W);
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
        public Vector4u yxyz
        {
            get => new Vector4u(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u yxyw
        {
            get => new Vector4u(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u yxzx
        {
            get => new Vector4u(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u yxzy
        {
            get => new Vector4u(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u yxzz
        {
            get => new Vector4u(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u yxzw
        {
            get => new Vector4u(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u yxwx
        {
            get => new Vector4u(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4u yxwy
        {
            get => new Vector4u(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u yxwz
        {
            get => new Vector4u(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u yxww
        {
            get => new Vector4u(Y, X, W, W);
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
        public Vector4u yyxz
        {
            get => new Vector4u(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u yyxw
        {
            get => new Vector4u(Y, Y, X, W);
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

        [XmlIgnore]
        public Vector4u yyyz
        {
            get => new Vector4u(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u yyyw
        {
            get => new Vector4u(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u yyzx
        {
            get => new Vector4u(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u yyzy
        {
            get => new Vector4u(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u yyzz
        {
            get => new Vector4u(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u yyzw
        {
            get => new Vector4u(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u yywx
        {
            get => new Vector4u(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u yywy
        {
            get => new Vector4u(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u yywz
        {
            get => new Vector4u(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u yyww
        {
            get => new Vector4u(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u yzxx
        {
            get => new Vector4u(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u yzxy
        {
            get => new Vector4u(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u yzxz
        {
            get => new Vector4u(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u yzxw
        {
            get => new Vector4u(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u yzyx
        {
            get => new Vector4u(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u yzyy
        {
            get => new Vector4u(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u yzyz
        {
            get => new Vector4u(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u yzyw
        {
            get => new Vector4u(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u yzzx
        {
            get => new Vector4u(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u yzzy
        {
            get => new Vector4u(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u yzzz
        {
            get => new Vector4u(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u yzzw
        {
            get => new Vector4u(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u yzwx
        {
            get => new Vector4u(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u yzwy
        {
            get => new Vector4u(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u yzwz
        {
            get => new Vector4u(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u yzww
        {
            get => new Vector4u(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u ywxx
        {
            get => new Vector4u(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4u ywxy
        {
            get => new Vector4u(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u ywxz
        {
            get => new Vector4u(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u ywxw
        {
            get => new Vector4u(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4u ywyx
        {
            get => new Vector4u(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u ywyy
        {
            get => new Vector4u(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u ywyz
        {
            get => new Vector4u(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u ywyw
        {
            get => new Vector4u(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u ywzx
        {
            get => new Vector4u(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u ywzy
        {
            get => new Vector4u(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u ywzz
        {
            get => new Vector4u(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u ywzw
        {
            get => new Vector4u(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u ywwx
        {
            get => new Vector4u(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4u ywwy
        {
            get => new Vector4u(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u ywwz
        {
            get => new Vector4u(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u ywww
        {
            get => new Vector4u(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4u zxxx
        {
            get => new Vector4u(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4u zxxy
        {
            get => new Vector4u(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u zxxz
        {
            get => new Vector4u(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u zxxw
        {
            get => new Vector4u(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4u zxyx
        {
            get => new Vector4u(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u zxyy
        {
            get => new Vector4u(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u zxyz
        {
            get => new Vector4u(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u zxyw
        {
            get => new Vector4u(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zxzx
        {
            get => new Vector4u(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u zxzy
        {
            get => new Vector4u(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u zxzz
        {
            get => new Vector4u(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u zxzw
        {
            get => new Vector4u(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u zxwx
        {
            get => new Vector4u(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4u zxwy
        {
            get => new Vector4u(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zxwz
        {
            get => new Vector4u(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u zxww
        {
            get => new Vector4u(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4u zyxx
        {
            get => new Vector4u(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u zyxy
        {
            get => new Vector4u(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u zyxz
        {
            get => new Vector4u(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u zyxw
        {
            get => new Vector4u(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zyyx
        {
            get => new Vector4u(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u zyyy
        {
            get => new Vector4u(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u zyyz
        {
            get => new Vector4u(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u zyyw
        {
            get => new Vector4u(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u zyzx
        {
            get => new Vector4u(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u zyzy
        {
            get => new Vector4u(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u zyzz
        {
            get => new Vector4u(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u zyzw
        {
            get => new Vector4u(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u zywx
        {
            get => new Vector4u(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zywy
        {
            get => new Vector4u(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u zywz
        {
            get => new Vector4u(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u zyww
        {
            get => new Vector4u(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u zzxx
        {
            get => new Vector4u(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u zzxy
        {
            get => new Vector4u(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u zzxz
        {
            get => new Vector4u(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u zzxw
        {
            get => new Vector4u(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u zzyx
        {
            get => new Vector4u(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u zzyy
        {
            get => new Vector4u(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u zzyz
        {
            get => new Vector4u(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u zzyw
        {
            get => new Vector4u(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u zzzx
        {
            get => new Vector4u(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u zzzy
        {
            get => new Vector4u(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u zzzz
        {
            get => new Vector4u(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u zzzw
        {
            get => new Vector4u(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u zzwx
        {
            get => new Vector4u(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u zzwy
        {
            get => new Vector4u(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u zzwz
        {
            get => new Vector4u(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u zzww
        {
            get => new Vector4u(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u zwxx
        {
            get => new Vector4u(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4u zwxy
        {
            get => new Vector4u(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zwxz
        {
            get => new Vector4u(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u zwxw
        {
            get => new Vector4u(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4u zwyx
        {
            get => new Vector4u(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u zwyy
        {
            get => new Vector4u(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u zwyz
        {
            get => new Vector4u(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u zwyw
        {
            get => new Vector4u(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u zwzx
        {
            get => new Vector4u(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u zwzy
        {
            get => new Vector4u(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u zwzz
        {
            get => new Vector4u(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u zwzw
        {
            get => new Vector4u(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u zwwx
        {
            get => new Vector4u(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4u zwwy
        {
            get => new Vector4u(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u zwwz
        {
            get => new Vector4u(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u zwww
        {
            get => new Vector4u(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4u wxxx
        {
            get => new Vector4u(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4u wxxy
        {
            get => new Vector4u(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u wxxz
        {
            get => new Vector4u(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u wxxw
        {
            get => new Vector4u(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4u wxyx
        {
            get => new Vector4u(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u wxyy
        {
            get => new Vector4u(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u wxyz
        {
            get => new Vector4u(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wxyw
        {
            get => new Vector4u(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u wxzx
        {
            get => new Vector4u(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u wxzy
        {
            get => new Vector4u(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wxzz
        {
            get => new Vector4u(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u wxzw
        {
            get => new Vector4u(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u wxwx
        {
            get => new Vector4u(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4u wxwy
        {
            get => new Vector4u(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u wxwz
        {
            get => new Vector4u(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u wxww
        {
            get => new Vector4u(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4u wyxx
        {
            get => new Vector4u(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u wyxy
        {
            get => new Vector4u(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u wyxz
        {
            get => new Vector4u(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wyxw
        {
            get => new Vector4u(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4u wyyx
        {
            get => new Vector4u(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u wyyy
        {
            get => new Vector4u(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u wyyz
        {
            get => new Vector4u(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u wyyw
        {
            get => new Vector4u(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u wyzx
        {
            get => new Vector4u(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wyzy
        {
            get => new Vector4u(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u wyzz
        {
            get => new Vector4u(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u wyzw
        {
            get => new Vector4u(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u wywx
        {
            get => new Vector4u(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u wywy
        {
            get => new Vector4u(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u wywz
        {
            get => new Vector4u(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u wyww
        {
            get => new Vector4u(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u wzxx
        {
            get => new Vector4u(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u wzxy
        {
            get => new Vector4u(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wzxz
        {
            get => new Vector4u(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u wzxw
        {
            get => new Vector4u(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u wzyx
        {
            get => new Vector4u(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u wzyy
        {
            get => new Vector4u(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u wzyz
        {
            get => new Vector4u(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u wzyw
        {
            get => new Vector4u(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u wzzx
        {
            get => new Vector4u(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u wzzy
        {
            get => new Vector4u(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u wzzz
        {
            get => new Vector4u(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u wzzw
        {
            get => new Vector4u(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u wzwx
        {
            get => new Vector4u(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u wzwy
        {
            get => new Vector4u(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u wzwz
        {
            get => new Vector4u(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u wzww
        {
            get => new Vector4u(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u wwxx
        {
            get => new Vector4u(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4u wwxy
        {
            get => new Vector4u(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u wwxz
        {
            get => new Vector4u(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u wwxw
        {
            get => new Vector4u(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4u wwyx
        {
            get => new Vector4u(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u wwyy
        {
            get => new Vector4u(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u wwyz
        {
            get => new Vector4u(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u wwyw
        {
            get => new Vector4u(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u wwzx
        {
            get => new Vector4u(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u wwzy
        {
            get => new Vector4u(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u wwzz
        {
            get => new Vector4u(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u wwzw
        {
            get => new Vector4u(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u wwwx
        {
            get => new Vector4u(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4u wwwy
        {
            get => new Vector4u(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u wwwz
        {
            get => new Vector4u(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u wwww
        {
            get => new Vector4u(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
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
        public uint b
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public uint a
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2u rb
        {
            get => new Vector2u(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ra
        {
            get => new Vector2u(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2u gb
        {
            get => new Vector2u(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ga
        {
            get => new Vector2u(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u br
        {
            get => new Vector2u(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u bg
        {
            get => new Vector2u(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u bb
        {
            get => new Vector2u(Z, Z);
        }

        [XmlIgnore]
        public Vector2u ba
        {
            get => new Vector2u(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ar
        {
            get => new Vector2u(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ag
        {
            get => new Vector2u(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ab
        {
            get => new Vector2u(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u aa
        {
            get => new Vector2u(W, W);
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
        public Vector3u rrb
        {
            get => new Vector3u(X, X, Z);
        }

        [XmlIgnore]
        public Vector3u rra
        {
            get => new Vector3u(X, X, W);
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
        public Vector3u rgb
        {
            get => new Vector3u(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u rga
        {
            get => new Vector3u(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u rbr
        {
            get => new Vector3u(X, Z, X);
        }

        [XmlIgnore]
        public Vector3u rbg
        {
            get => new Vector3u(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u rbb
        {
            get => new Vector3u(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3u rba
        {
            get => new Vector3u(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u rar
        {
            get => new Vector3u(X, W, X);
        }

        [XmlIgnore]
        public Vector3u rag
        {
            get => new Vector3u(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u rab
        {
            get => new Vector3u(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u raa
        {
            get => new Vector3u(X, W, W);
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
        public Vector3u grb
        {
            get => new Vector3u(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u gra
        {
            get => new Vector3u(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3u ggb
        {
            get => new Vector3u(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3u gga
        {
            get => new Vector3u(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3u gbr
        {
            get => new Vector3u(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u gbg
        {
            get => new Vector3u(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3u gbb
        {
            get => new Vector3u(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3u gba
        {
            get => new Vector3u(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u gar
        {
            get => new Vector3u(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u gag
        {
            get => new Vector3u(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3u gab
        {
            get => new Vector3u(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u gaa
        {
            get => new Vector3u(Y, W, W);
        }

        [XmlIgnore]
        public Vector3u brr
        {
            get => new Vector3u(Z, X, X);
        }

        [XmlIgnore]
        public Vector3u brg
        {
            get => new Vector3u(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u brb
        {
            get => new Vector3u(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3u bra
        {
            get => new Vector3u(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u bgr
        {
            get => new Vector3u(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u bgg
        {
            get => new Vector3u(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3u bgb
        {
            get => new Vector3u(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3u bga
        {
            get => new Vector3u(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u bbr
        {
            get => new Vector3u(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3u bbg
        {
            get => new Vector3u(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3u bbb
        {
            get => new Vector3u(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3u bba
        {
            get => new Vector3u(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3u bar
        {
            get => new Vector3u(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u bag
        {
            get => new Vector3u(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u bab
        {
            get => new Vector3u(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3u baa
        {
            get => new Vector3u(Z, W, W);
        }

        [XmlIgnore]
        public Vector3u arr
        {
            get => new Vector3u(W, X, X);
        }

        [XmlIgnore]
        public Vector3u arg
        {
            get => new Vector3u(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u arb
        {
            get => new Vector3u(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u ara
        {
            get => new Vector3u(W, X, W);
        }

        [XmlIgnore]
        public Vector3u agr
        {
            get => new Vector3u(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u agg
        {
            get => new Vector3u(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3u agb
        {
            get => new Vector3u(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u aga
        {
            get => new Vector3u(W, Y, W);
        }

        [XmlIgnore]
        public Vector3u abr
        {
            get => new Vector3u(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u abg
        {
            get => new Vector3u(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u abb
        {
            get => new Vector3u(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3u aba
        {
            get => new Vector3u(W, Z, W);
        }

        [XmlIgnore]
        public Vector3u aar
        {
            get => new Vector3u(W, W, X);
        }

        [XmlIgnore]
        public Vector3u aag
        {
            get => new Vector3u(W, W, Y);
        }

        [XmlIgnore]
        public Vector3u aab
        {
            get => new Vector3u(W, W, Z);
        }

        [XmlIgnore]
        public Vector3u aaa
        {
            get => new Vector3u(W, W, W);
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
        public Vector4u rrrb
        {
            get => new Vector4u(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u rrra
        {
            get => new Vector4u(X, X, X, W);
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
        public Vector4u rrgb
        {
            get => new Vector4u(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u rrga
        {
            get => new Vector4u(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u rrbr
        {
            get => new Vector4u(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u rrbg
        {
            get => new Vector4u(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u rrbb
        {
            get => new Vector4u(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u rrba
        {
            get => new Vector4u(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u rrar
        {
            get => new Vector4u(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4u rrag
        {
            get => new Vector4u(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u rrab
        {
            get => new Vector4u(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u rraa
        {
            get => new Vector4u(X, X, W, W);
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
        public Vector4u rgrb
        {
            get => new Vector4u(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u rgra
        {
            get => new Vector4u(X, Y, X, W);
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
        public Vector4u rggb
        {
            get => new Vector4u(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u rgga
        {
            get => new Vector4u(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u rgbr
        {
            get => new Vector4u(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u rgbg
        {
            get => new Vector4u(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u rgbb
        {
            get => new Vector4u(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u rgba
        {
            get => new Vector4u(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u rgar
        {
            get => new Vector4u(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u rgag
        {
            get => new Vector4u(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u rgab
        {
            get => new Vector4u(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u rgaa
        {
            get => new Vector4u(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u rbrr
        {
            get => new Vector4u(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u rbrg
        {
            get => new Vector4u(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u rbrb
        {
            get => new Vector4u(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u rbra
        {
            get => new Vector4u(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u rbgr
        {
            get => new Vector4u(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u rbgg
        {
            get => new Vector4u(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u rbgb
        {
            get => new Vector4u(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u rbga
        {
            get => new Vector4u(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u rbbr
        {
            get => new Vector4u(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u rbbg
        {
            get => new Vector4u(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u rbbb
        {
            get => new Vector4u(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u rbba
        {
            get => new Vector4u(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u rbar
        {
            get => new Vector4u(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u rbag
        {
            get => new Vector4u(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u rbab
        {
            get => new Vector4u(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u rbaa
        {
            get => new Vector4u(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u rarr
        {
            get => new Vector4u(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4u rarg
        {
            get => new Vector4u(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u rarb
        {
            get => new Vector4u(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u rara
        {
            get => new Vector4u(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4u ragr
        {
            get => new Vector4u(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u ragg
        {
            get => new Vector4u(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u ragb
        {
            get => new Vector4u(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u raga
        {
            get => new Vector4u(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u rabr
        {
            get => new Vector4u(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u rabg
        {
            get => new Vector4u(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u rabb
        {
            get => new Vector4u(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u raba
        {
            get => new Vector4u(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u raar
        {
            get => new Vector4u(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4u raag
        {
            get => new Vector4u(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u raab
        {
            get => new Vector4u(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u raaa
        {
            get => new Vector4u(X, W, W, W);
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
        public Vector4u grrb
        {
            get => new Vector4u(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u grra
        {
            get => new Vector4u(Y, X, X, W);
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
        public Vector4u grgb
        {
            get => new Vector4u(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u grga
        {
            get => new Vector4u(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u grbr
        {
            get => new Vector4u(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u grbg
        {
            get => new Vector4u(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u grbb
        {
            get => new Vector4u(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u grba
        {
            get => new Vector4u(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u grar
        {
            get => new Vector4u(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4u grag
        {
            get => new Vector4u(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u grab
        {
            get => new Vector4u(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u graa
        {
            get => new Vector4u(Y, X, W, W);
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
        public Vector4u ggrb
        {
            get => new Vector4u(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u ggra
        {
            get => new Vector4u(Y, Y, X, W);
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

        [XmlIgnore]
        public Vector4u gggb
        {
            get => new Vector4u(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u ggga
        {
            get => new Vector4u(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u ggbr
        {
            get => new Vector4u(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u ggbg
        {
            get => new Vector4u(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u ggbb
        {
            get => new Vector4u(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u ggba
        {
            get => new Vector4u(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u ggar
        {
            get => new Vector4u(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u ggag
        {
            get => new Vector4u(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u ggab
        {
            get => new Vector4u(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u ggaa
        {
            get => new Vector4u(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u gbrr
        {
            get => new Vector4u(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u gbrg
        {
            get => new Vector4u(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u gbrb
        {
            get => new Vector4u(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u gbra
        {
            get => new Vector4u(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u gbgr
        {
            get => new Vector4u(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u gbgg
        {
            get => new Vector4u(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u gbgb
        {
            get => new Vector4u(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u gbga
        {
            get => new Vector4u(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u gbbr
        {
            get => new Vector4u(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u gbbg
        {
            get => new Vector4u(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u gbbb
        {
            get => new Vector4u(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u gbba
        {
            get => new Vector4u(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u gbar
        {
            get => new Vector4u(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u gbag
        {
            get => new Vector4u(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u gbab
        {
            get => new Vector4u(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u gbaa
        {
            get => new Vector4u(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u garr
        {
            get => new Vector4u(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4u garg
        {
            get => new Vector4u(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u garb
        {
            get => new Vector4u(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u gara
        {
            get => new Vector4u(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4u gagr
        {
            get => new Vector4u(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u gagg
        {
            get => new Vector4u(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u gagb
        {
            get => new Vector4u(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u gaga
        {
            get => new Vector4u(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u gabr
        {
            get => new Vector4u(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u gabg
        {
            get => new Vector4u(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u gabb
        {
            get => new Vector4u(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u gaba
        {
            get => new Vector4u(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u gaar
        {
            get => new Vector4u(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4u gaag
        {
            get => new Vector4u(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u gaab
        {
            get => new Vector4u(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u gaaa
        {
            get => new Vector4u(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4u brrr
        {
            get => new Vector4u(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4u brrg
        {
            get => new Vector4u(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u brrb
        {
            get => new Vector4u(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u brra
        {
            get => new Vector4u(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4u brgr
        {
            get => new Vector4u(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u brgg
        {
            get => new Vector4u(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u brgb
        {
            get => new Vector4u(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u brga
        {
            get => new Vector4u(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u brbr
        {
            get => new Vector4u(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u brbg
        {
            get => new Vector4u(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u brbb
        {
            get => new Vector4u(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u brba
        {
            get => new Vector4u(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u brar
        {
            get => new Vector4u(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4u brag
        {
            get => new Vector4u(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u brab
        {
            get => new Vector4u(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u braa
        {
            get => new Vector4u(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4u bgrr
        {
            get => new Vector4u(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u bgrg
        {
            get => new Vector4u(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u bgrb
        {
            get => new Vector4u(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u bgra
        {
            get => new Vector4u(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u bggr
        {
            get => new Vector4u(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u bggg
        {
            get => new Vector4u(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u bggb
        {
            get => new Vector4u(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u bgga
        {
            get => new Vector4u(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u bgbr
        {
            get => new Vector4u(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u bgbg
        {
            get => new Vector4u(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u bgbb
        {
            get => new Vector4u(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u bgba
        {
            get => new Vector4u(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u bgar
        {
            get => new Vector4u(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u bgag
        {
            get => new Vector4u(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u bgab
        {
            get => new Vector4u(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u bgaa
        {
            get => new Vector4u(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u bbrr
        {
            get => new Vector4u(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u bbrg
        {
            get => new Vector4u(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u bbrb
        {
            get => new Vector4u(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u bbra
        {
            get => new Vector4u(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u bbgr
        {
            get => new Vector4u(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u bbgg
        {
            get => new Vector4u(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u bbgb
        {
            get => new Vector4u(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u bbga
        {
            get => new Vector4u(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u bbbr
        {
            get => new Vector4u(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u bbbg
        {
            get => new Vector4u(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u bbbb
        {
            get => new Vector4u(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u bbba
        {
            get => new Vector4u(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u bbar
        {
            get => new Vector4u(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u bbag
        {
            get => new Vector4u(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u bbab
        {
            get => new Vector4u(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u bbaa
        {
            get => new Vector4u(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u barr
        {
            get => new Vector4u(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4u barg
        {
            get => new Vector4u(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u barb
        {
            get => new Vector4u(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u bara
        {
            get => new Vector4u(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4u bagr
        {
            get => new Vector4u(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u bagg
        {
            get => new Vector4u(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u bagb
        {
            get => new Vector4u(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u baga
        {
            get => new Vector4u(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u babr
        {
            get => new Vector4u(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u babg
        {
            get => new Vector4u(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u babb
        {
            get => new Vector4u(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u baba
        {
            get => new Vector4u(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u baar
        {
            get => new Vector4u(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4u baag
        {
            get => new Vector4u(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u baab
        {
            get => new Vector4u(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u baaa
        {
            get => new Vector4u(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4u arrr
        {
            get => new Vector4u(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4u arrg
        {
            get => new Vector4u(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u arrb
        {
            get => new Vector4u(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u arra
        {
            get => new Vector4u(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4u argr
        {
            get => new Vector4u(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u argg
        {
            get => new Vector4u(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u argb
        {
            get => new Vector4u(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u arga
        {
            get => new Vector4u(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u arbr
        {
            get => new Vector4u(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u arbg
        {
            get => new Vector4u(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u arbb
        {
            get => new Vector4u(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u arba
        {
            get => new Vector4u(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u arar
        {
            get => new Vector4u(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4u arag
        {
            get => new Vector4u(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u arab
        {
            get => new Vector4u(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u araa
        {
            get => new Vector4u(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4u agrr
        {
            get => new Vector4u(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u agrg
        {
            get => new Vector4u(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u agrb
        {
            get => new Vector4u(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u agra
        {
            get => new Vector4u(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4u aggr
        {
            get => new Vector4u(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u aggg
        {
            get => new Vector4u(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u aggb
        {
            get => new Vector4u(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u agga
        {
            get => new Vector4u(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u agbr
        {
            get => new Vector4u(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u agbg
        {
            get => new Vector4u(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u agbb
        {
            get => new Vector4u(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u agba
        {
            get => new Vector4u(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u agar
        {
            get => new Vector4u(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u agag
        {
            get => new Vector4u(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u agab
        {
            get => new Vector4u(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u agaa
        {
            get => new Vector4u(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u abrr
        {
            get => new Vector4u(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u abrg
        {
            get => new Vector4u(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u abrb
        {
            get => new Vector4u(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u abra
        {
            get => new Vector4u(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u abgr
        {
            get => new Vector4u(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u abgg
        {
            get => new Vector4u(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u abgb
        {
            get => new Vector4u(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u abga
        {
            get => new Vector4u(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u abbr
        {
            get => new Vector4u(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u abbg
        {
            get => new Vector4u(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u abbb
        {
            get => new Vector4u(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u abba
        {
            get => new Vector4u(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u abar
        {
            get => new Vector4u(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u abag
        {
            get => new Vector4u(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u abab
        {
            get => new Vector4u(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u abaa
        {
            get => new Vector4u(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u aarr
        {
            get => new Vector4u(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4u aarg
        {
            get => new Vector4u(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u aarb
        {
            get => new Vector4u(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u aara
        {
            get => new Vector4u(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4u aagr
        {
            get => new Vector4u(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u aagg
        {
            get => new Vector4u(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u aagb
        {
            get => new Vector4u(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u aaga
        {
            get => new Vector4u(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u aabr
        {
            get => new Vector4u(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u aabg
        {
            get => new Vector4u(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u aabb
        {
            get => new Vector4u(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u aaba
        {
            get => new Vector4u(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u aaar
        {
            get => new Vector4u(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4u aaag
        {
            get => new Vector4u(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u aaab
        {
            get => new Vector4u(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u aaaa
        {
            get => new Vector4u(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
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
        public uint p
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public uint q
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2u sp
        {
            get => new Vector2u(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u sq
        {
            get => new Vector2u(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2u tp
        {
            get => new Vector2u(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u tq
        {
            get => new Vector2u(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u ps
        {
            get => new Vector2u(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u pt
        {
            get => new Vector2u(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u pp
        {
            get => new Vector2u(Z, Z);
        }

        [XmlIgnore]
        public Vector2u pq
        {
            get => new Vector2u(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u qs
        {
            get => new Vector2u(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u qt
        {
            get => new Vector2u(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u qp
        {
            get => new Vector2u(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2u qq
        {
            get => new Vector2u(W, W);
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
        public Vector3u ssp
        {
            get => new Vector3u(X, X, Z);
        }

        [XmlIgnore]
        public Vector3u ssq
        {
            get => new Vector3u(X, X, W);
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
        public Vector3u stp
        {
            get => new Vector3u(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u stq
        {
            get => new Vector3u(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u sps
        {
            get => new Vector3u(X, Z, X);
        }

        [XmlIgnore]
        public Vector3u spt
        {
            get => new Vector3u(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u spp
        {
            get => new Vector3u(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3u spq
        {
            get => new Vector3u(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u sqs
        {
            get => new Vector3u(X, W, X);
        }

        [XmlIgnore]
        public Vector3u sqt
        {
            get => new Vector3u(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u sqp
        {
            get => new Vector3u(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u sqq
        {
            get => new Vector3u(X, W, W);
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
        public Vector3u tsp
        {
            get => new Vector3u(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u tsq
        {
            get => new Vector3u(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3u ttp
        {
            get => new Vector3u(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3u ttq
        {
            get => new Vector3u(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3u tps
        {
            get => new Vector3u(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u tpt
        {
            get => new Vector3u(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3u tpp
        {
            get => new Vector3u(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3u tpq
        {
            get => new Vector3u(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u tqs
        {
            get => new Vector3u(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u tqt
        {
            get => new Vector3u(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3u tqp
        {
            get => new Vector3u(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u tqq
        {
            get => new Vector3u(Y, W, W);
        }

        [XmlIgnore]
        public Vector3u pss
        {
            get => new Vector3u(Z, X, X);
        }

        [XmlIgnore]
        public Vector3u pst
        {
            get => new Vector3u(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u psp
        {
            get => new Vector3u(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3u psq
        {
            get => new Vector3u(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u pts
        {
            get => new Vector3u(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u ptt
        {
            get => new Vector3u(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3u ptp
        {
            get => new Vector3u(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3u ptq
        {
            get => new Vector3u(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u pps
        {
            get => new Vector3u(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3u ppt
        {
            get => new Vector3u(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3u ppp
        {
            get => new Vector3u(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3u ppq
        {
            get => new Vector3u(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3u pqs
        {
            get => new Vector3u(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u pqt
        {
            get => new Vector3u(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u pqp
        {
            get => new Vector3u(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3u pqq
        {
            get => new Vector3u(Z, W, W);
        }

        [XmlIgnore]
        public Vector3u qss
        {
            get => new Vector3u(W, X, X);
        }

        [XmlIgnore]
        public Vector3u qst
        {
            get => new Vector3u(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qsp
        {
            get => new Vector3u(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qsq
        {
            get => new Vector3u(W, X, W);
        }

        [XmlIgnore]
        public Vector3u qts
        {
            get => new Vector3u(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qtt
        {
            get => new Vector3u(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3u qtp
        {
            get => new Vector3u(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qtq
        {
            get => new Vector3u(W, Y, W);
        }

        [XmlIgnore]
        public Vector3u qps
        {
            get => new Vector3u(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qpt
        {
            get => new Vector3u(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3u qpp
        {
            get => new Vector3u(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3u qpq
        {
            get => new Vector3u(W, Z, W);
        }

        [XmlIgnore]
        public Vector3u qqs
        {
            get => new Vector3u(W, W, X);
        }

        [XmlIgnore]
        public Vector3u qqt
        {
            get => new Vector3u(W, W, Y);
        }

        [XmlIgnore]
        public Vector3u qqp
        {
            get => new Vector3u(W, W, Z);
        }

        [XmlIgnore]
        public Vector3u qqq
        {
            get => new Vector3u(W, W, W);
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
        public Vector4u sssp
        {
            get => new Vector4u(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u sssq
        {
            get => new Vector4u(X, X, X, W);
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
        public Vector4u sstp
        {
            get => new Vector4u(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u sstq
        {
            get => new Vector4u(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u ssps
        {
            get => new Vector4u(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u sspt
        {
            get => new Vector4u(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u sspp
        {
            get => new Vector4u(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u sspq
        {
            get => new Vector4u(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u ssqs
        {
            get => new Vector4u(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4u ssqt
        {
            get => new Vector4u(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u ssqp
        {
            get => new Vector4u(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u ssqq
        {
            get => new Vector4u(X, X, W, W);
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
        public Vector4u stsp
        {
            get => new Vector4u(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u stsq
        {
            get => new Vector4u(X, Y, X, W);
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
        public Vector4u sttp
        {
            get => new Vector4u(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u sttq
        {
            get => new Vector4u(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u stps
        {
            get => new Vector4u(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u stpt
        {
            get => new Vector4u(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u stpp
        {
            get => new Vector4u(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u stpq
        {
            get => new Vector4u(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u stqs
        {
            get => new Vector4u(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u stqt
        {
            get => new Vector4u(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u stqp
        {
            get => new Vector4u(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u stqq
        {
            get => new Vector4u(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u spss
        {
            get => new Vector4u(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u spst
        {
            get => new Vector4u(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u spsp
        {
            get => new Vector4u(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u spsq
        {
            get => new Vector4u(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u spts
        {
            get => new Vector4u(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u sptt
        {
            get => new Vector4u(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u sptp
        {
            get => new Vector4u(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u sptq
        {
            get => new Vector4u(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u spps
        {
            get => new Vector4u(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u sppt
        {
            get => new Vector4u(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u sppp
        {
            get => new Vector4u(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u sppq
        {
            get => new Vector4u(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u spqs
        {
            get => new Vector4u(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u spqt
        {
            get => new Vector4u(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u spqp
        {
            get => new Vector4u(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u spqq
        {
            get => new Vector4u(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u sqss
        {
            get => new Vector4u(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4u sqst
        {
            get => new Vector4u(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u sqsp
        {
            get => new Vector4u(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u sqsq
        {
            get => new Vector4u(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4u sqts
        {
            get => new Vector4u(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u sqtt
        {
            get => new Vector4u(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u sqtp
        {
            get => new Vector4u(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u sqtq
        {
            get => new Vector4u(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u sqps
        {
            get => new Vector4u(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u sqpt
        {
            get => new Vector4u(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u sqpp
        {
            get => new Vector4u(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u sqpq
        {
            get => new Vector4u(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u sqqs
        {
            get => new Vector4u(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4u sqqt
        {
            get => new Vector4u(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u sqqp
        {
            get => new Vector4u(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u sqqq
        {
            get => new Vector4u(X, W, W, W);
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
        public Vector4u tssp
        {
            get => new Vector4u(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u tssq
        {
            get => new Vector4u(Y, X, X, W);
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
        public Vector4u tstp
        {
            get => new Vector4u(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u tstq
        {
            get => new Vector4u(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u tsps
        {
            get => new Vector4u(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u tspt
        {
            get => new Vector4u(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u tspp
        {
            get => new Vector4u(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u tspq
        {
            get => new Vector4u(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tsqs
        {
            get => new Vector4u(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4u tsqt
        {
            get => new Vector4u(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u tsqp
        {
            get => new Vector4u(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tsqq
        {
            get => new Vector4u(Y, X, W, W);
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
        public Vector4u ttsp
        {
            get => new Vector4u(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u ttsq
        {
            get => new Vector4u(Y, Y, X, W);
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

        [XmlIgnore]
        public Vector4u tttp
        {
            get => new Vector4u(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u tttq
        {
            get => new Vector4u(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u ttps
        {
            get => new Vector4u(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u ttpt
        {
            get => new Vector4u(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u ttpp
        {
            get => new Vector4u(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u ttpq
        {
            get => new Vector4u(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u ttqs
        {
            get => new Vector4u(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u ttqt
        {
            get => new Vector4u(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u ttqp
        {
            get => new Vector4u(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u ttqq
        {
            get => new Vector4u(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u tpss
        {
            get => new Vector4u(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u tpst
        {
            get => new Vector4u(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u tpsp
        {
            get => new Vector4u(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u tpsq
        {
            get => new Vector4u(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tpts
        {
            get => new Vector4u(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u tptt
        {
            get => new Vector4u(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u tptp
        {
            get => new Vector4u(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u tptq
        {
            get => new Vector4u(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u tpps
        {
            get => new Vector4u(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u tppt
        {
            get => new Vector4u(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u tppp
        {
            get => new Vector4u(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u tppq
        {
            get => new Vector4u(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u tpqs
        {
            get => new Vector4u(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tpqt
        {
            get => new Vector4u(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u tpqp
        {
            get => new Vector4u(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u tpqq
        {
            get => new Vector4u(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u tqss
        {
            get => new Vector4u(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4u tqst
        {
            get => new Vector4u(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u tqsp
        {
            get => new Vector4u(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tqsq
        {
            get => new Vector4u(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4u tqts
        {
            get => new Vector4u(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u tqtt
        {
            get => new Vector4u(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u tqtp
        {
            get => new Vector4u(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u tqtq
        {
            get => new Vector4u(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u tqps
        {
            get => new Vector4u(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u tqpt
        {
            get => new Vector4u(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u tqpp
        {
            get => new Vector4u(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u tqpq
        {
            get => new Vector4u(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u tqqs
        {
            get => new Vector4u(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4u tqqt
        {
            get => new Vector4u(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u tqqp
        {
            get => new Vector4u(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u tqqq
        {
            get => new Vector4u(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4u psss
        {
            get => new Vector4u(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4u psst
        {
            get => new Vector4u(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u pssp
        {
            get => new Vector4u(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u pssq
        {
            get => new Vector4u(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4u psts
        {
            get => new Vector4u(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u pstt
        {
            get => new Vector4u(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u pstp
        {
            get => new Vector4u(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4u pstq
        {
            get => new Vector4u(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u psps
        {
            get => new Vector4u(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u pspt
        {
            get => new Vector4u(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4u pspp
        {
            get => new Vector4u(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u pspq
        {
            get => new Vector4u(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u psqs
        {
            get => new Vector4u(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4u psqt
        {
            get => new Vector4u(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u psqp
        {
            get => new Vector4u(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u psqq
        {
            get => new Vector4u(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4u ptss
        {
            get => new Vector4u(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u ptst
        {
            get => new Vector4u(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u ptsp
        {
            get => new Vector4u(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4u ptsq
        {
            get => new Vector4u(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u ptts
        {
            get => new Vector4u(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u pttt
        {
            get => new Vector4u(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u pttp
        {
            get => new Vector4u(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u pttq
        {
            get => new Vector4u(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u ptps
        {
            get => new Vector4u(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4u ptpt
        {
            get => new Vector4u(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u ptpp
        {
            get => new Vector4u(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u ptpq
        {
            get => new Vector4u(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u ptqs
        {
            get => new Vector4u(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u ptqt
        {
            get => new Vector4u(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u ptqp
        {
            get => new Vector4u(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u ptqq
        {
            get => new Vector4u(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u ppss
        {
            get => new Vector4u(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u ppst
        {
            get => new Vector4u(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4u ppsp
        {
            get => new Vector4u(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u ppsq
        {
            get => new Vector4u(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u ppts
        {
            get => new Vector4u(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4u pptt
        {
            get => new Vector4u(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u pptp
        {
            get => new Vector4u(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u pptq
        {
            get => new Vector4u(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u ppps
        {
            get => new Vector4u(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u pppt
        {
            get => new Vector4u(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u pppp
        {
            get => new Vector4u(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u pppq
        {
            get => new Vector4u(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u ppqs
        {
            get => new Vector4u(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u ppqt
        {
            get => new Vector4u(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u ppqp
        {
            get => new Vector4u(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u ppqq
        {
            get => new Vector4u(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u pqss
        {
            get => new Vector4u(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4u pqst
        {
            get => new Vector4u(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u pqsp
        {
            get => new Vector4u(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u pqsq
        {
            get => new Vector4u(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4u pqts
        {
            get => new Vector4u(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u pqtt
        {
            get => new Vector4u(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u pqtp
        {
            get => new Vector4u(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u pqtq
        {
            get => new Vector4u(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u pqps
        {
            get => new Vector4u(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u pqpt
        {
            get => new Vector4u(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u pqpp
        {
            get => new Vector4u(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u pqpq
        {
            get => new Vector4u(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u pqqs
        {
            get => new Vector4u(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4u pqqt
        {
            get => new Vector4u(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u pqqp
        {
            get => new Vector4u(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u pqqq
        {
            get => new Vector4u(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4u qsss
        {
            get => new Vector4u(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4u qsst
        {
            get => new Vector4u(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4u qssp
        {
            get => new Vector4u(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4u qssq
        {
            get => new Vector4u(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4u qsts
        {
            get => new Vector4u(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4u qstt
        {
            get => new Vector4u(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4u qstp
        {
            get => new Vector4u(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qstq
        {
            get => new Vector4u(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4u qsps
        {
            get => new Vector4u(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4u qspt
        {
            get => new Vector4u(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qspp
        {
            get => new Vector4u(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4u qspq
        {
            get => new Vector4u(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4u qsqs
        {
            get => new Vector4u(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4u qsqt
        {
            get => new Vector4u(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4u qsqp
        {
            get => new Vector4u(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4u qsqq
        {
            get => new Vector4u(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4u qtss
        {
            get => new Vector4u(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4u qtst
        {
            get => new Vector4u(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4u qtsp
        {
            get => new Vector4u(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qtsq
        {
            get => new Vector4u(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4u qtts
        {
            get => new Vector4u(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4u qttt
        {
            get => new Vector4u(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4u qttp
        {
            get => new Vector4u(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4u qttq
        {
            get => new Vector4u(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4u qtps
        {
            get => new Vector4u(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qtpt
        {
            get => new Vector4u(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4u qtpp
        {
            get => new Vector4u(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4u qtpq
        {
            get => new Vector4u(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4u qtqs
        {
            get => new Vector4u(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4u qtqt
        {
            get => new Vector4u(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4u qtqp
        {
            get => new Vector4u(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4u qtqq
        {
            get => new Vector4u(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4u qpss
        {
            get => new Vector4u(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4u qpst
        {
            get => new Vector4u(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qpsp
        {
            get => new Vector4u(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4u qpsq
        {
            get => new Vector4u(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4u qpts
        {
            get => new Vector4u(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4u qptt
        {
            get => new Vector4u(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4u qptp
        {
            get => new Vector4u(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4u qptq
        {
            get => new Vector4u(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4u qpps
        {
            get => new Vector4u(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4u qppt
        {
            get => new Vector4u(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4u qppp
        {
            get => new Vector4u(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4u qppq
        {
            get => new Vector4u(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4u qpqs
        {
            get => new Vector4u(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4u qpqt
        {
            get => new Vector4u(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4u qpqp
        {
            get => new Vector4u(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4u qpqq
        {
            get => new Vector4u(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4u qqss
        {
            get => new Vector4u(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4u qqst
        {
            get => new Vector4u(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4u qqsp
        {
            get => new Vector4u(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4u qqsq
        {
            get => new Vector4u(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4u qqts
        {
            get => new Vector4u(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4u qqtt
        {
            get => new Vector4u(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4u qqtp
        {
            get => new Vector4u(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4u qqtq
        {
            get => new Vector4u(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4u qqps
        {
            get => new Vector4u(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4u qqpt
        {
            get => new Vector4u(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4u qqpp
        {
            get => new Vector4u(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4u qqpq
        {
            get => new Vector4u(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4u qqqs
        {
            get => new Vector4u(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4u qqqt
        {
            get => new Vector4u(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4u qqqp
        {
            get => new Vector4u(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4u qqqq
        {
            get => new Vector4u(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector4"/> object with the same component values as the <see cref="Vector4u"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector4"/> instance.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(X, Y, Z, W);
        }

        /// <summary>
        /// Gets a <see cref="Vector4"/> object with the same component values as the <see cref="Vector4u"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector4u"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector4"/>.</param>
        public static void ToVector4(ref Vector4u input, out Vector4 result)
        {
            result.X = input.X;
            result.Y = input.Y;
            result.Z = input.Z;
            result.W = input.W;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4u operator +(Vector4u left, Vector4u right)
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
        public static Vector4u operator -(Vector4u left, Vector4u right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4u operator *(Vector4u vec, uint scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4u operator *(uint scale, Vector4u vec)
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
        public static Vector4u operator *(Vector4u vec, Vector4u scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            vec.W *= scale.W;
            return vec;
        }

        /// <summary>
        /// Divides the instance by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4u operator /(Vector4u vec, uint scale)
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
        public static bool operator ==(Vector4u left, Vector4u right)
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
        public static bool operator !=(Vector4u left, Vector4u right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static unsafe explicit operator uint* (Vector4u v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static explicit operator IntPtr(Vector4u v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4u"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4u"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4u((uint X, uint Y, uint Z, uint W) values)
        {
            return new Vector4u(values.X, values.Y, values.Z, values.W);
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
                int hashCode = 353;
                hashCode *= 104 + X.GetHashCode();
                hashCode *= 104 + Y.GetHashCode();
                hashCode *= 104 + Z.GetHashCode();
                hashCode *= 104 + W.GetHashCode();
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
            if (!(obj is Vector4u))
            {
                return false;
            }

            return Equals((Vector4u)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector4u other)
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
        public void Deconstruct(out uint x, out uint y, out uint z, out uint w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}