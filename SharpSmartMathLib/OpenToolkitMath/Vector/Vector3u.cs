//
//  Vector3u.cs
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
    /// Represents a 3D vector using three 32-bit unsigned integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector3u structure is suitable for interoperation with unmanaged code requiring three consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3u : IEquatable<Vector3u>
    {
        /// <summary>
        /// The X component of the Vector3u.
        /// </summary>
        public uint X;

        /// <summary>
        /// The Y component of the Vector3u.
        /// </summary>
        public uint Y;

        /// <summary>
        /// The Z component of the Vector3u.
        /// </summary>
        public uint Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3u"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3u(uint value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3u"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector3.</param>
        /// <param name="y">The y component of the Vector3.</param>
        /// <param name="z">The z component of the Vector3.</param>
        public Vector3u(uint x, uint y, uint z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3u"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2u"/> to copy components from.</param>
        public Vector3u(Vector2u v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0;
        }

        /// <summary>
        /// Gets or sets the value at the index of the vector.
        /// </summary>
        /// <param name="index">The index of the component from the vector.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 2.</exception>
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
        /// Defines a unit-length Vector3u that points towards the X-axis.
        /// </summary>
        public static readonly Vector3u UnitX = new Vector3u(1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector3u that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3u UnitY = new Vector3u(0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector3u that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3u UnitZ = new Vector3u(0, 0, 1);

        /// <summary>
        /// Defines the size of the Vector3u struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector3u>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector3u Add(Vector3u a, Vector3u b)
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
        public static void Add(ref Vector3u a, ref Vector3u b, out Vector3u result)
        {
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
            result.Z = a.Z + b.Z;
        }

        /// <summary>
        /// Subtract one vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>Result of subtraction.</returns>
        [Pure]
        public static Vector3u Subtract(Vector3u a, Vector3u b)
        {
            Subtract(ref a, ref b, out a);
            return a;
        }

        /// <summary>
        /// Subtract one vector from another.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="result">Result of subtraction.</param>
        public static void Subtract(ref Vector3u a, ref Vector3u b, out Vector3u result)
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
        public static Vector3u Multiply(Vector3u vector, uint scale)
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
        public static void Multiply(ref Vector3u vector, uint scale, out Vector3u result)
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
        public static Vector3u Multiply(Vector3u vector, Vector3u scale)
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
        public static void Multiply(ref Vector3u vector, ref Vector3u scale, out Vector3u result)
        {
            result.X = vector.X * scale.X;
            result.Y = vector.Y * scale.Y;
            result.Z = vector.Z * scale.Z;
        }

        /// <summary>
        /// Divides a vector by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3u Divide(Vector3u vector, uint scale)
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
        public static void Divide(ref Vector3u vector, uint scale, out Vector3u result)
        {
            result.X = vector.X / scale;
            result.Y = vector.Y / scale;
            result.Z = vector.Z / scale;
        }

        /// <summary>
        /// Divides a vector by the components of a vector using integer division, floor(a/b).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        [Pure]
        public static Vector3u Divide(Vector3u vector, Vector3u scale)
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
        public static void Divide(ref Vector3u vector, ref Vector3u scale, out Vector3u result)
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
        public static Vector3u ComponentMin(Vector3u a, Vector3u b)
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
        public static void ComponentMin(ref Vector3u a, ref Vector3u b, out Vector3u result)
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
        public static Vector3u ComponentMax(Vector3u a, Vector3u b)
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
        public static void ComponentMax(ref Vector3u a, ref Vector3u b, out Vector3u result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors.
        /// </summary>
        /// <param name="vec">Input vector.</param>
        /// <param name="min">Minimum vector.</param>
        /// <param name="max">Maximum vector.</param>
        /// <returns>The clamped vector.</returns>
        [Pure]
        public static Vector3u Clamp(Vector3u vec, Vector3u min, Vector3u max)
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
        public static void Clamp(ref Vector3u vec, ref Vector3u min, ref Vector3u max, out Vector3u result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2u"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2u Xy
        {
            get => Unsafe.As<Vector3u, Vector2u>(ref this);
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

        #region Coords: x, y, z
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
        #endregion

        #region Coords: r, g, b
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
        #endregion

        #region Coords: s, t, p
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
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector3"/> object with the same component values as the <see cref="Vector3u"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector3"/> instance.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Gets a <see cref="Vector3"/> object with the same component values as the <see cref="Vector3u"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector3u"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector3"/>.</param>
        public static void ToVector3(ref Vector3u input, out Vector3 result)
        {
            result.X = input.X;
            result.Y = input.Y;
            result.Z = input.Z;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3u operator +(Vector3u left, Vector3u right)
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
        public static Vector3u operator -(Vector3u left, Vector3u right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            return left;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3u operator *(Vector3u vec, uint scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3u operator *(uint scale, Vector3u vec)
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
        public static Vector3u operator *(Vector3u vec, Vector3u scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            return vec;
        }

        /// <summary>
        /// Divides the instance by a scalar using integer division, floor(a/b).
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3u operator /(Vector3u vec, uint scale)
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
        public static bool operator ==(Vector3u left, Vector3u right)
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
        public static bool operator !=(Vector3u left, Vector3u right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3u"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3u"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3u((uint X, uint Y, uint Z) values)
        {
            return new Vector3u(values.X, values.Y, values.Z);
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
                int hashCode = 4673;
                hashCode *= 251 + (int)X;
                hashCode *= 251 + (int)Y;
                hashCode *= 251 + (int)Z;
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
            if (!(obj is Vector3u))
            {
                return false;
            }

            return Equals((Vector3u)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector3u other)
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
        public void Deconstruct(out uint x, out uint y, out uint z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}