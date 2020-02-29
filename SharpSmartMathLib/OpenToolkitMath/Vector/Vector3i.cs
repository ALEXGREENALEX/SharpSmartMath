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
    /// Represents a 3D vector using three 32-bit integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector3i structure is suitable for interoperation with unmanaged code requiring three consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3i : IEquatable<Vector3i>
    {
        /// <summary>
        /// The X component of the Vector3i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y component of the Vector3i.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z component of the Vector3i.
        /// </summary>
        public int Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3i"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3i(int value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3i"/> struct.
        /// </summary>
        /// <param name="x">The x component of the Vector3.</param>
        /// <param name="y">The y component of the Vector3.</param>
        /// <param name="z">The z component of the Vector3.</param>
        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3i"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2i"/> to copy components from.</param>
        public Vector3i(Vector2i v)
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
        /// Defines a unit-length Vector3i that points towards the X-axis.
        /// </summary>
        public static readonly Vector3i UnitX = new Vector3i(1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector3i that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3i UnitY = new Vector3i(0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector3i that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3i UnitZ = new Vector3i(0, 0, 1);

        /// <summary>
        /// Defines the size of the Vector3i struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector3i>();

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        [Pure]
        public static Vector3i Add(Vector3i a, Vector3i b)
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
        public static void Add(ref Vector3i a, ref Vector3i b, out Vector3i result)
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
        public static Vector3i Subtract(Vector3i a, Vector3i b)
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
        public static void Subtract(ref Vector3i a, ref Vector3i b, out Vector3i result)
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
        public static Vector3i Multiply(Vector3i vector, int scale)
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
        public static void Multiply(ref Vector3i vector, int scale, out Vector3i result)
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
        public static Vector3i Multiply(Vector3i vector, Vector3i scale)
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
        public static void Multiply(ref Vector3i vector, ref Vector3i scale, out Vector3i result)
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
        public static Vector3i Divide(Vector3i vector, int scale)
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
        public static void Divide(ref Vector3i vector, int scale, out Vector3i result)
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
        public static Vector3i Divide(Vector3i vector, Vector3i scale)
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
        public static void Divide(ref Vector3i vector, ref Vector3i scale, out Vector3i result)
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
        public static Vector3i ComponentMin(Vector3i a, Vector3i b)
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
        public static void ComponentMin(ref Vector3i a, ref Vector3i b, out Vector3i result)
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
        public static Vector3i ComponentMax(Vector3i a, Vector3i b)
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
        public static void ComponentMax(ref Vector3i a, ref Vector3i b, out Vector3i result)
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
        public static Vector3i Clamp(Vector3i vec, Vector3i min, Vector3i max)
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
        public static void Clamp(ref Vector3i vec, ref Vector3i min, ref Vector3i max, out Vector3i result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Xy
        {
            get => Unsafe.As<Vector3i, Vector2i>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Xz
        {
            get => new Vector2i(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
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

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Yz
        {
            get => new Vector2i(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Zx
        {
            get => new Vector2i(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Zy
        {
            get => new Vector2i(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xzy
        {
            get => new Vector3i(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Yxz
        {
            get => new Vector3i(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Yzx
        {
            get => new Vector3i(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zxy
        {
            get => new Vector3i(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zyx
        {
            get => new Vector3i(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        #region Coords: x, y, z
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
        public int z
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2i xz
        {
            get => new Vector2i(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2i yz
        {
            get => new Vector2i(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i zx
        {
            get => new Vector2i(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i zy
        {
            get => new Vector2i(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i zz
        {
            get => new Vector2i(Z, Z);
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
        public Vector3i xxz
        {
            get => new Vector3i(X, X, Z);
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
        public Vector3i xyz
        {
            get => new Vector3i(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i xzx
        {
            get => new Vector3i(X, Z, X);
        }

        [XmlIgnore]
        public Vector3i xzy
        {
            get => new Vector3i(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i xzz
        {
            get => new Vector3i(X, Z, Z);
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
        public Vector3i yxz
        {
            get => new Vector3i(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3i yyz
        {
            get => new Vector3i(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3i yzx
        {
            get => new Vector3i(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i yzy
        {
            get => new Vector3i(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3i yzz
        {
            get => new Vector3i(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3i zxx
        {
            get => new Vector3i(Z, X, X);
        }

        [XmlIgnore]
        public Vector3i zxy
        {
            get => new Vector3i(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i zxz
        {
            get => new Vector3i(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3i zyx
        {
            get => new Vector3i(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i zyy
        {
            get => new Vector3i(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3i zyz
        {
            get => new Vector3i(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3i zzx
        {
            get => new Vector3i(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3i zzy
        {
            get => new Vector3i(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3i zzz
        {
            get => new Vector3i(Z, Z, Z);
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
        public Vector4i xxxz
        {
            get => new Vector4i(X, X, X, Z);
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
        public Vector4i xxyz
        {
            get => new Vector4i(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i xxzx
        {
            get => new Vector4i(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i xxzy
        {
            get => new Vector4i(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i xxzz
        {
            get => new Vector4i(X, X, Z, Z);
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
        public Vector4i xyxz
        {
            get => new Vector4i(X, Y, X, Z);
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
        public Vector4i xyyz
        {
            get => new Vector4i(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i xyzx
        {
            get => new Vector4i(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i xyzy
        {
            get => new Vector4i(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i xyzz
        {
            get => new Vector4i(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i xzxx
        {
            get => new Vector4i(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i xzxy
        {
            get => new Vector4i(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i xzxz
        {
            get => new Vector4i(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i xzyx
        {
            get => new Vector4i(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i xzyy
        {
            get => new Vector4i(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i xzyz
        {
            get => new Vector4i(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i xzzx
        {
            get => new Vector4i(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i xzzy
        {
            get => new Vector4i(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i xzzz
        {
            get => new Vector4i(X, Z, Z, Z);
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
        public Vector4i yxxz
        {
            get => new Vector4i(Y, X, X, Z);
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
        public Vector4i yxyz
        {
            get => new Vector4i(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i yxzx
        {
            get => new Vector4i(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i yxzy
        {
            get => new Vector4i(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i yxzz
        {
            get => new Vector4i(Y, X, Z, Z);
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
        public Vector4i yyxz
        {
            get => new Vector4i(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4i yyyz
        {
            get => new Vector4i(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i yyzx
        {
            get => new Vector4i(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i yyzy
        {
            get => new Vector4i(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i yyzz
        {
            get => new Vector4i(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i yzxx
        {
            get => new Vector4i(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i yzxy
        {
            get => new Vector4i(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i yzxz
        {
            get => new Vector4i(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i yzyx
        {
            get => new Vector4i(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i yzyy
        {
            get => new Vector4i(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i yzyz
        {
            get => new Vector4i(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i yzzx
        {
            get => new Vector4i(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i yzzy
        {
            get => new Vector4i(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i yzzz
        {
            get => new Vector4i(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i zxxx
        {
            get => new Vector4i(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4i zxxy
        {
            get => new Vector4i(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i zxxz
        {
            get => new Vector4i(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i zxyx
        {
            get => new Vector4i(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i zxyy
        {
            get => new Vector4i(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i zxyz
        {
            get => new Vector4i(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i zxzx
        {
            get => new Vector4i(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i zxzy
        {
            get => new Vector4i(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i zxzz
        {
            get => new Vector4i(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i zyxx
        {
            get => new Vector4i(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i zyxy
        {
            get => new Vector4i(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i zyxz
        {
            get => new Vector4i(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4i zyyx
        {
            get => new Vector4i(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i zyyy
        {
            get => new Vector4i(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i zyyz
        {
            get => new Vector4i(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i zyzx
        {
            get => new Vector4i(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i zyzy
        {
            get => new Vector4i(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i zyzz
        {
            get => new Vector4i(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i zzxx
        {
            get => new Vector4i(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i zzxy
        {
            get => new Vector4i(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i zzxz
        {
            get => new Vector4i(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i zzyx
        {
            get => new Vector4i(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i zzyy
        {
            get => new Vector4i(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i zzyz
        {
            get => new Vector4i(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i zzzx
        {
            get => new Vector4i(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i zzzy
        {
            get => new Vector4i(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i zzzz
        {
            get => new Vector4i(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: r, g, b
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
        public int b
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2i rb
        {
            get => new Vector2i(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2i gb
        {
            get => new Vector2i(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i br
        {
            get => new Vector2i(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i bg
        {
            get => new Vector2i(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i bb
        {
            get => new Vector2i(Z, Z);
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
        public Vector3i rrb
        {
            get => new Vector3i(X, X, Z);
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
        public Vector3i rgb
        {
            get => new Vector3i(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i rbr
        {
            get => new Vector3i(X, Z, X);
        }

        [XmlIgnore]
        public Vector3i rbg
        {
            get => new Vector3i(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i rbb
        {
            get => new Vector3i(X, Z, Z);
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
        public Vector3i grb
        {
            get => new Vector3i(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3i ggb
        {
            get => new Vector3i(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3i gbr
        {
            get => new Vector3i(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i gbg
        {
            get => new Vector3i(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3i gbb
        {
            get => new Vector3i(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3i brr
        {
            get => new Vector3i(Z, X, X);
        }

        [XmlIgnore]
        public Vector3i brg
        {
            get => new Vector3i(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i brb
        {
            get => new Vector3i(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3i bgr
        {
            get => new Vector3i(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i bgg
        {
            get => new Vector3i(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3i bgb
        {
            get => new Vector3i(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3i bbr
        {
            get => new Vector3i(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3i bbg
        {
            get => new Vector3i(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3i bbb
        {
            get => new Vector3i(Z, Z, Z);
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
        public Vector4i rrrb
        {
            get => new Vector4i(X, X, X, Z);
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
        public Vector4i rrgb
        {
            get => new Vector4i(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i rrbr
        {
            get => new Vector4i(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i rrbg
        {
            get => new Vector4i(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i rrbb
        {
            get => new Vector4i(X, X, Z, Z);
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
        public Vector4i rgrb
        {
            get => new Vector4i(X, Y, X, Z);
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
        public Vector4i rggb
        {
            get => new Vector4i(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i rgbr
        {
            get => new Vector4i(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i rgbg
        {
            get => new Vector4i(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i rgbb
        {
            get => new Vector4i(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i rbrr
        {
            get => new Vector4i(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i rbrg
        {
            get => new Vector4i(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i rbrb
        {
            get => new Vector4i(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i rbgr
        {
            get => new Vector4i(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i rbgg
        {
            get => new Vector4i(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i rbgb
        {
            get => new Vector4i(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i rbbr
        {
            get => new Vector4i(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i rbbg
        {
            get => new Vector4i(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i rbbb
        {
            get => new Vector4i(X, Z, Z, Z);
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
        public Vector4i grrb
        {
            get => new Vector4i(Y, X, X, Z);
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
        public Vector4i grgb
        {
            get => new Vector4i(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i grbr
        {
            get => new Vector4i(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i grbg
        {
            get => new Vector4i(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i grbb
        {
            get => new Vector4i(Y, X, Z, Z);
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
        public Vector4i ggrb
        {
            get => new Vector4i(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4i gggb
        {
            get => new Vector4i(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ggbr
        {
            get => new Vector4i(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i ggbg
        {
            get => new Vector4i(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i ggbb
        {
            get => new Vector4i(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i gbrr
        {
            get => new Vector4i(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i gbrg
        {
            get => new Vector4i(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i gbrb
        {
            get => new Vector4i(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i gbgr
        {
            get => new Vector4i(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i gbgg
        {
            get => new Vector4i(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i gbgb
        {
            get => new Vector4i(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i gbbr
        {
            get => new Vector4i(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i gbbg
        {
            get => new Vector4i(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i gbbb
        {
            get => new Vector4i(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i brrr
        {
            get => new Vector4i(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4i brrg
        {
            get => new Vector4i(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i brrb
        {
            get => new Vector4i(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i brgr
        {
            get => new Vector4i(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i brgg
        {
            get => new Vector4i(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i brgb
        {
            get => new Vector4i(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i brbr
        {
            get => new Vector4i(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i brbg
        {
            get => new Vector4i(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i brbb
        {
            get => new Vector4i(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i bgrr
        {
            get => new Vector4i(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i bgrg
        {
            get => new Vector4i(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i bgrb
        {
            get => new Vector4i(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4i bggr
        {
            get => new Vector4i(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i bggg
        {
            get => new Vector4i(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i bggb
        {
            get => new Vector4i(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i bgbr
        {
            get => new Vector4i(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i bgbg
        {
            get => new Vector4i(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i bgbb
        {
            get => new Vector4i(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i bbrr
        {
            get => new Vector4i(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i bbrg
        {
            get => new Vector4i(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i bbrb
        {
            get => new Vector4i(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i bbgr
        {
            get => new Vector4i(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i bbgg
        {
            get => new Vector4i(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i bbgb
        {
            get => new Vector4i(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i bbbr
        {
            get => new Vector4i(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i bbbg
        {
            get => new Vector4i(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i bbbb
        {
            get => new Vector4i(Z, Z, Z, Z);
        }
        #endregion

        #region Coords: s, t, p
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
        public int p
        {
            get => Z;
            set
            {
                Z = value;
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
        public Vector2i sp
        {
            get => new Vector2i(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
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
        public Vector2i tp
        {
            get => new Vector2i(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ps
        {
            get => new Vector2i(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i pt
        {
            get => new Vector2i(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i pp
        {
            get => new Vector2i(Z, Z);
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
        public Vector3i ssp
        {
            get => new Vector3i(X, X, Z);
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
        public Vector3i stp
        {
            get => new Vector3i(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i sps
        {
            get => new Vector3i(X, Z, X);
        }

        [XmlIgnore]
        public Vector3i spt
        {
            get => new Vector3i(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i spp
        {
            get => new Vector3i(X, Z, Z);
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
        public Vector3i tsp
        {
            get => new Vector3i(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
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
        public Vector3i ttp
        {
            get => new Vector3i(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3i tps
        {
            get => new Vector3i(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i tpt
        {
            get => new Vector3i(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3i tpp
        {
            get => new Vector3i(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3i pss
        {
            get => new Vector3i(Z, X, X);
        }

        [XmlIgnore]
        public Vector3i pst
        {
            get => new Vector3i(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i psp
        {
            get => new Vector3i(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3i pts
        {
            get => new Vector3i(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i ptt
        {
            get => new Vector3i(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3i ptp
        {
            get => new Vector3i(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3i pps
        {
            get => new Vector3i(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3i ppt
        {
            get => new Vector3i(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3i ppp
        {
            get => new Vector3i(Z, Z, Z);
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
        public Vector4i sssp
        {
            get => new Vector4i(X, X, X, Z);
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
        public Vector4i sstp
        {
            get => new Vector4i(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ssps
        {
            get => new Vector4i(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i sspt
        {
            get => new Vector4i(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i sspp
        {
            get => new Vector4i(X, X, Z, Z);
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
        public Vector4i stsp
        {
            get => new Vector4i(X, Y, X, Z);
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
        public Vector4i sttp
        {
            get => new Vector4i(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i stps
        {
            get => new Vector4i(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i stpt
        {
            get => new Vector4i(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i stpp
        {
            get => new Vector4i(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i spss
        {
            get => new Vector4i(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i spst
        {
            get => new Vector4i(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i spsp
        {
            get => new Vector4i(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i spts
        {
            get => new Vector4i(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i sptt
        {
            get => new Vector4i(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i sptp
        {
            get => new Vector4i(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i spps
        {
            get => new Vector4i(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i sppt
        {
            get => new Vector4i(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i sppp
        {
            get => new Vector4i(X, Z, Z, Z);
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
        public Vector4i tssp
        {
            get => new Vector4i(Y, X, X, Z);
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
        public Vector4i tstp
        {
            get => new Vector4i(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i tsps
        {
            get => new Vector4i(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i tspt
        {
            get => new Vector4i(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i tspp
        {
            get => new Vector4i(Y, X, Z, Z);
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
        public Vector4i ttsp
        {
            get => new Vector4i(Y, Y, X, Z);
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

        [XmlIgnore]
        public Vector4i tttp
        {
            get => new Vector4i(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ttps
        {
            get => new Vector4i(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i ttpt
        {
            get => new Vector4i(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i ttpp
        {
            get => new Vector4i(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i tpss
        {
            get => new Vector4i(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i tpst
        {
            get => new Vector4i(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i tpsp
        {
            get => new Vector4i(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i tpts
        {
            get => new Vector4i(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i tptt
        {
            get => new Vector4i(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i tptp
        {
            get => new Vector4i(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i tpps
        {
            get => new Vector4i(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i tppt
        {
            get => new Vector4i(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i tppp
        {
            get => new Vector4i(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i psss
        {
            get => new Vector4i(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4i psst
        {
            get => new Vector4i(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i pssp
        {
            get => new Vector4i(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i psts
        {
            get => new Vector4i(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i pstt
        {
            get => new Vector4i(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i pstp
        {
            get => new Vector4i(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4i psps
        {
            get => new Vector4i(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i pspt
        {
            get => new Vector4i(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4i pspp
        {
            get => new Vector4i(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i ptss
        {
            get => new Vector4i(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i ptst
        {
            get => new Vector4i(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i ptsp
        {
            get => new Vector4i(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4i ptts
        {
            get => new Vector4i(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i pttt
        {
            get => new Vector4i(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i pttp
        {
            get => new Vector4i(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ptps
        {
            get => new Vector4i(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4i ptpt
        {
            get => new Vector4i(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i ptpp
        {
            get => new Vector4i(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i ppss
        {
            get => new Vector4i(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i ppst
        {
            get => new Vector4i(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4i ppsp
        {
            get => new Vector4i(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i ppts
        {
            get => new Vector4i(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4i pptt
        {
            get => new Vector4i(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i pptp
        {
            get => new Vector4i(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ppps
        {
            get => new Vector4i(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i pppt
        {
            get => new Vector4i(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i pppp
        {
            get => new Vector4i(Z, Z, Z, Z);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector3"/> object with the same component values as the <see cref="Vector3i"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector3"/> instance.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Gets a <see cref="Vector3"/> object with the same component values as the <see cref="Vector3i"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector3i"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector3"/>.</param>
        public static void ToVector3(ref Vector3i input, out Vector3 result)
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
        public static Vector3i operator +(Vector3i left, Vector3i right)
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
        public static Vector3i operator -(Vector3i left, Vector3i right)
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
        public static Vector3i operator -(Vector3i vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector3i operator *(Vector3i vec, int scale)
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
        public static Vector3i operator *(int scale, Vector3i vec)
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
        public static Vector3i operator *(Vector3i vec, Vector3i scale)
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
        public static Vector3i operator /(Vector3i vec, int scale)
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
        public static bool operator ==(Vector3i left, Vector3i right)
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
        public static bool operator !=(Vector3i left, Vector3i right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3i"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3i"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3i((int X, int Y, int Z) values)
        {
            return new Vector3i(values.X, values.Y, values.Z);
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
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
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
            if (!(obj is Vector3i))
            {
                return false;
            }

            return Equals((Vector3i)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector3i other)
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
        public void Deconstruct(out int x, out int y, out int z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
