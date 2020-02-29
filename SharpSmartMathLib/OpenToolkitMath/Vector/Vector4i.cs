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
    /// Represents a 4D vector using four 32-bit integer numbers.
    /// </summary>
    /// <remarks>
    /// The Vector4i structure is suitable for interoperation with unmanaged code requiring four consecutive integers.
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4i : IEquatable<Vector4i>
    {
        /// <summary>
        /// The X component of the Vector4i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y component of the Vector4i.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z component of the Vector4i.
        /// </summary>
        public int Z;

        /// <summary>
        /// The W component of the Vector4i.
        /// </summary>
        public int W;

        /// <summary>
        /// Defines a unit-length <see cref="Vector4i"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector4i UnitX = new Vector4i(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4i"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4i UnitY = new Vector4i(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4i"/> that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4i UnitZ = new Vector4i(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4i"/> that points towards the W-axis.
        /// </summary>
        public static readonly Vector4i UnitW = new Vector4i(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length <see cref="Vector4i"/>.
        /// </summary>
        public static readonly Vector4i Zero = new Vector4i(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4i One = new Vector4i(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the <see cref="Vector4i"/> struct in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vector4i>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4i(int value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct.
        /// </summary>
        /// <param name="x">The X component of the Vector4i.</param>
        /// <param name="y">The Y component of the Vector4i.</param>
        /// <param name="z">The Z component of the Vector4i.</param>
        /// <param name="w">The W component of the Vector4i.</param>
        public Vector4i(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct.
        /// </summary>
        /// <param name="v">The Vector2 to copy components from.</param>
        public Vector4i(Vector2i v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3i"/> to copy components from.</param>
        public Vector4i(Vector3i v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3i"/> to copy components from.</param>
        /// <param name="w">The w component of the new Vector4.</param>
        public Vector4i(Vector3i v, int w)
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
        public static Vector4i Add(Vector4i a, Vector4i b)
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
        public static void Add(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Subtract(Vector4i a, Vector4i b)
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
        public static void Subtract(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Multiply(Vector4i vector, int scale)
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
        public static void Multiply(ref Vector4i vector, int scale, out Vector4i result)
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
        public static Vector4i Multiply(Vector4i vector, Vector4i scale)
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
        public static void Multiply(ref Vector4i vector, ref Vector4i scale, out Vector4i result)
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
        public static Vector4i Divide(Vector4i vector, int scale)
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
        public static void Divide(ref Vector4i vector, int scale, out Vector4i result)
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
        public static Vector4i Divide(Vector4i vector, Vector4i scale)
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
        public static void Divide(ref Vector4i vector, ref Vector4i scale, out Vector4i result)
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
        public static Vector4i ComponentMin(Vector4i a, Vector4i b)
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
        public static void ComponentMin(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i ComponentMax(Vector4i a, Vector4i b)
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
        public static void ComponentMax(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Clamp(Vector4i vec, Vector4i min, Vector4i max)
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
        public static void Clamp(ref Vector4i vec, ref Vector4i min, ref Vector4i max, out Vector4i result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.W < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        #region Components
        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Xy
        {
            get => Unsafe.As<Vector4i, Vector2i>(ref this);
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
        /// Gets or sets a <see cref="Vector2i"/> with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Xw
        {
            get => new Vector2i(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        /// Gets or sets a <see cref="Vector2i"/> with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Yw
        {
            get => new Vector2i(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        /// Gets or sets a <see cref="Vector2i"/> with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Zw
        {
            get => new Vector2i(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Wx
        {
            get => new Vector2i(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Wy
        {
            get => new Vector2i(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector2i"/> with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2i Wz
        {
            get => new Vector2i(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xyz
        {
            get => Unsafe.As<Vector4i, Vector3i>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xyw
        {
            get => new Vector3i(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        /// Gets or sets a <see cref="Vector3i"/> with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xzw
        {
            get => new Vector3i(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xwy
        {
            get => new Vector3i(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Xwz
        {
            get => new Vector3i(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets a <see cref="Vector3i"/> with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Yxw
        {
            get => new Vector3i(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        /// Gets or sets a <see cref="Vector3i"/> with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Yzw
        {
            get => new Vector3i(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Ywx
        {
            get => new Vector3i(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Ywz
        {
            get => new Vector3i(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets a <see cref="Vector3i"/> with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zxw
        {
            get => new Vector3i(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
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

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zyw
        {
            get => new Vector3i(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zwx
        {
            get => new Vector3i(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Zwy
        {
            get => new Vector3i(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wxy
        {
            get => new Vector3i(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wxz
        {
            get => new Vector3i(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wyx
        {
            get => new Vector3i(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wyz
        {
            get => new Vector3i(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wzx
        {
            get => new Vector3i(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector3i"/> with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3i Wzy
        {
            get => new Vector3i(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Xywz
        {
            get => new Vector4i(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Xzyw
        {
            get => new Vector4i(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Xzwy
        {
            get => new Vector4i(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Xwyz
        {
            get => new Vector4i(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Xwzy
        {
            get => new Vector4i(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yxzw
        {
            get => new Vector4i(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yxwz
        {
            get => new Vector4i(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yyzw
        {
            get => new Vector4i(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yywz
        {
            get => new Vector4i(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yzxw
        {
            get => new Vector4i(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Yzwx
        {
            get => new Vector4i(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Ywxz
        {
            get => new Vector4i(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Ywzx
        {
            get => new Vector4i(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zxyw
        {
            get => new Vector4i(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zxwy
        {
            get => new Vector4i(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zyxw
        {
            get => new Vector4i(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zywx
        {
            get => new Vector4i(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zwxy
        {
            get => new Vector4i(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zwyx
        {
            get => new Vector4i(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Zwzy
        {
            get => new Vector4i(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wxyz
        {
            get => new Vector4i(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wxzy
        {
            get => new Vector4i(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wyxz
        {
            get => new Vector4i(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wyzx
        {
            get => new Vector4i(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wzxy
        {
            get => new Vector4i(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wzyx
        {
            get => new Vector4i(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Vector4i"/> with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4i Wzyw
        {
            get => new Vector4i(W, Z, Y, W);
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
        public int w
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2i xw
        {
            get => new Vector2i(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2i yw
        {
            get => new Vector2i(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2i zw
        {
            get => new Vector2i(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i wx
        {
            get => new Vector2i(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i wy
        {
            get => new Vector2i(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i wz
        {
            get => new Vector2i(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ww
        {
            get => new Vector2i(W, W);
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
        public Vector3i xxw
        {
            get => new Vector3i(X, X, W);
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
        public Vector3i xyw
        {
            get => new Vector3i(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3i xzw
        {
            get => new Vector3i(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i xwx
        {
            get => new Vector3i(X, W, X);
        }

        [XmlIgnore]
        public Vector3i xwy
        {
            get => new Vector3i(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i xwz
        {
            get => new Vector3i(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i xww
        {
            get => new Vector3i(X, W, W);
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
        public Vector3i yxw
        {
            get => new Vector3i(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3i yyw
        {
            get => new Vector3i(Y, Y, W);
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
        public Vector3i yzw
        {
            get => new Vector3i(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i ywx
        {
            get => new Vector3i(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i ywy
        {
            get => new Vector3i(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3i ywz
        {
            get => new Vector3i(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i yww
        {
            get => new Vector3i(Y, W, W);
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
        public Vector3i zxw
        {
            get => new Vector3i(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3i zyw
        {
            get => new Vector3i(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3i zzw
        {
            get => new Vector3i(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3i zwx
        {
            get => new Vector3i(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i zwy
        {
            get => new Vector3i(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i zwz
        {
            get => new Vector3i(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3i zww
        {
            get => new Vector3i(Z, W, W);
        }

        [XmlIgnore]
        public Vector3i wxx
        {
            get => new Vector3i(W, X, X);
        }

        [XmlIgnore]
        public Vector3i wxy
        {
            get => new Vector3i(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wxz
        {
            get => new Vector3i(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wxw
        {
            get => new Vector3i(W, X, W);
        }

        [XmlIgnore]
        public Vector3i wyx
        {
            get => new Vector3i(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wyy
        {
            get => new Vector3i(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3i wyz
        {
            get => new Vector3i(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wyw
        {
            get => new Vector3i(W, Y, W);
        }

        [XmlIgnore]
        public Vector3i wzx
        {
            get => new Vector3i(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wzy
        {
            get => new Vector3i(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i wzz
        {
            get => new Vector3i(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3i wzw
        {
            get => new Vector3i(W, Z, W);
        }

        [XmlIgnore]
        public Vector3i wwx
        {
            get => new Vector3i(W, W, X);
        }

        [XmlIgnore]
        public Vector3i wwy
        {
            get => new Vector3i(W, W, Y);
        }

        [XmlIgnore]
        public Vector3i wwz
        {
            get => new Vector3i(W, W, Z);
        }

        [XmlIgnore]
        public Vector3i www
        {
            get => new Vector3i(W, W, W);
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
        public Vector4i xxxw
        {
            get => new Vector4i(X, X, X, W);
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
        public Vector4i xxyw
        {
            get => new Vector4i(X, X, Y, W);
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
        public Vector4i xxzw
        {
            get => new Vector4i(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i xxwx
        {
            get => new Vector4i(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4i xxwy
        {
            get => new Vector4i(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i xxwz
        {
            get => new Vector4i(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i xxww
        {
            get => new Vector4i(X, X, W, W);
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
        public Vector4i xyxw
        {
            get => new Vector4i(X, Y, X, W);
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
        public Vector4i xyyw
        {
            get => new Vector4i(X, Y, Y, W);
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
        public Vector4i xyzw
        {
            get => new Vector4i(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i xywx
        {
            get => new Vector4i(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i xywy
        {
            get => new Vector4i(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i xywz
        {
            get => new Vector4i(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i xyww
        {
            get => new Vector4i(X, Y, W, W);
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
        public Vector4i xzxw
        {
            get => new Vector4i(X, Z, X, W);
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
        public Vector4i xzyw
        {
            get => new Vector4i(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i xzzw
        {
            get => new Vector4i(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i xzwx
        {
            get => new Vector4i(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i xzwy
        {
            get => new Vector4i(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i xzwz
        {
            get => new Vector4i(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i xzww
        {
            get => new Vector4i(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i xwxx
        {
            get => new Vector4i(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4i xwxy
        {
            get => new Vector4i(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i xwxz
        {
            get => new Vector4i(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i xwxw
        {
            get => new Vector4i(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4i xwyx
        {
            get => new Vector4i(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i xwyy
        {
            get => new Vector4i(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i xwyz
        {
            get => new Vector4i(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i xwyw
        {
            get => new Vector4i(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i xwzx
        {
            get => new Vector4i(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i xwzy
        {
            get => new Vector4i(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i xwzz
        {
            get => new Vector4i(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i xwzw
        {
            get => new Vector4i(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i xwwx
        {
            get => new Vector4i(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4i xwwy
        {
            get => new Vector4i(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i xwwz
        {
            get => new Vector4i(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i xwww
        {
            get => new Vector4i(X, W, W, W);
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
        public Vector4i yxxw
        {
            get => new Vector4i(Y, X, X, W);
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
        public Vector4i yxyw
        {
            get => new Vector4i(Y, X, Y, W);
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
        public Vector4i yxzw
        {
            get => new Vector4i(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i yxwx
        {
            get => new Vector4i(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4i yxwy
        {
            get => new Vector4i(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i yxwz
        {
            get => new Vector4i(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i yxww
        {
            get => new Vector4i(Y, X, W, W);
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
        public Vector4i yyxw
        {
            get => new Vector4i(Y, Y, X, W);
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
        public Vector4i yyyw
        {
            get => new Vector4i(Y, Y, Y, W);
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
        public Vector4i yyzw
        {
            get => new Vector4i(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i yywx
        {
            get => new Vector4i(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i yywy
        {
            get => new Vector4i(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i yywz
        {
            get => new Vector4i(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i yyww
        {
            get => new Vector4i(Y, Y, W, W);
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
        public Vector4i yzxw
        {
            get => new Vector4i(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i yzyw
        {
            get => new Vector4i(Y, Z, Y, W);
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
        public Vector4i yzzw
        {
            get => new Vector4i(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i yzwx
        {
            get => new Vector4i(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i yzwy
        {
            get => new Vector4i(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i yzwz
        {
            get => new Vector4i(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i yzww
        {
            get => new Vector4i(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i ywxx
        {
            get => new Vector4i(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4i ywxy
        {
            get => new Vector4i(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i ywxz
        {
            get => new Vector4i(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i ywxw
        {
            get => new Vector4i(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4i ywyx
        {
            get => new Vector4i(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i ywyy
        {
            get => new Vector4i(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i ywyz
        {
            get => new Vector4i(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i ywyw
        {
            get => new Vector4i(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i ywzx
        {
            get => new Vector4i(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i ywzy
        {
            get => new Vector4i(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i ywzz
        {
            get => new Vector4i(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i ywzw
        {
            get => new Vector4i(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i ywwx
        {
            get => new Vector4i(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4i ywwy
        {
            get => new Vector4i(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i ywwz
        {
            get => new Vector4i(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i ywww
        {
            get => new Vector4i(Y, W, W, W);
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
        public Vector4i zxxw
        {
            get => new Vector4i(Z, X, X, W);
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
        public Vector4i zxyw
        {
            get => new Vector4i(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i zxzw
        {
            get => new Vector4i(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i zxwx
        {
            get => new Vector4i(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4i zxwy
        {
            get => new Vector4i(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i zxwz
        {
            get => new Vector4i(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i zxww
        {
            get => new Vector4i(Z, X, W, W);
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
        public Vector4i zyxw
        {
            get => new Vector4i(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i zyyw
        {
            get => new Vector4i(Z, Y, Y, W);
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
        public Vector4i zyzw
        {
            get => new Vector4i(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i zywx
        {
            get => new Vector4i(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i zywy
        {
            get => new Vector4i(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i zywz
        {
            get => new Vector4i(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i zyww
        {
            get => new Vector4i(Z, Y, W, W);
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
        public Vector4i zzxw
        {
            get => new Vector4i(Z, Z, X, W);
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
        public Vector4i zzyw
        {
            get => new Vector4i(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4i zzzw
        {
            get => new Vector4i(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i zzwx
        {
            get => new Vector4i(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i zzwy
        {
            get => new Vector4i(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i zzwz
        {
            get => new Vector4i(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i zzww
        {
            get => new Vector4i(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i zwxx
        {
            get => new Vector4i(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4i zwxy
        {
            get => new Vector4i(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i zwxz
        {
            get => new Vector4i(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i zwxw
        {
            get => new Vector4i(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4i zwyx
        {
            get => new Vector4i(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i zwyy
        {
            get => new Vector4i(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i zwyz
        {
            get => new Vector4i(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i zwyw
        {
            get => new Vector4i(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i zwzx
        {
            get => new Vector4i(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i zwzy
        {
            get => new Vector4i(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i zwzz
        {
            get => new Vector4i(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i zwzw
        {
            get => new Vector4i(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i zwwx
        {
            get => new Vector4i(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4i zwwy
        {
            get => new Vector4i(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i zwwz
        {
            get => new Vector4i(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i zwww
        {
            get => new Vector4i(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4i wxxx
        {
            get => new Vector4i(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4i wxxy
        {
            get => new Vector4i(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i wxxz
        {
            get => new Vector4i(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i wxxw
        {
            get => new Vector4i(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4i wxyx
        {
            get => new Vector4i(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i wxyy
        {
            get => new Vector4i(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i wxyz
        {
            get => new Vector4i(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wxyw
        {
            get => new Vector4i(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4i wxzx
        {
            get => new Vector4i(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i wxzy
        {
            get => new Vector4i(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wxzz
        {
            get => new Vector4i(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i wxzw
        {
            get => new Vector4i(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i wxwx
        {
            get => new Vector4i(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4i wxwy
        {
            get => new Vector4i(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i wxwz
        {
            get => new Vector4i(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i wxww
        {
            get => new Vector4i(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4i wyxx
        {
            get => new Vector4i(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i wyxy
        {
            get => new Vector4i(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i wyxz
        {
            get => new Vector4i(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wyxw
        {
            get => new Vector4i(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4i wyyx
        {
            get => new Vector4i(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i wyyy
        {
            get => new Vector4i(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i wyyz
        {
            get => new Vector4i(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i wyyw
        {
            get => new Vector4i(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4i wyzx
        {
            get => new Vector4i(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wyzy
        {
            get => new Vector4i(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i wyzz
        {
            get => new Vector4i(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i wyzw
        {
            get => new Vector4i(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i wywx
        {
            get => new Vector4i(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i wywy
        {
            get => new Vector4i(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i wywz
        {
            get => new Vector4i(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i wyww
        {
            get => new Vector4i(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4i wzxx
        {
            get => new Vector4i(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i wzxy
        {
            get => new Vector4i(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wzxz
        {
            get => new Vector4i(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i wzxw
        {
            get => new Vector4i(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4i wzyx
        {
            get => new Vector4i(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i wzyy
        {
            get => new Vector4i(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i wzyz
        {
            get => new Vector4i(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i wzyw
        {
            get => new Vector4i(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4i wzzx
        {
            get => new Vector4i(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i wzzy
        {
            get => new Vector4i(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i wzzz
        {
            get => new Vector4i(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i wzzw
        {
            get => new Vector4i(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i wzwx
        {
            get => new Vector4i(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i wzwy
        {
            get => new Vector4i(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i wzwz
        {
            get => new Vector4i(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i wzww
        {
            get => new Vector4i(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i wwxx
        {
            get => new Vector4i(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4i wwxy
        {
            get => new Vector4i(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i wwxz
        {
            get => new Vector4i(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i wwxw
        {
            get => new Vector4i(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4i wwyx
        {
            get => new Vector4i(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i wwyy
        {
            get => new Vector4i(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i wwyz
        {
            get => new Vector4i(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i wwyw
        {
            get => new Vector4i(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i wwzx
        {
            get => new Vector4i(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i wwzy
        {
            get => new Vector4i(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i wwzz
        {
            get => new Vector4i(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i wwzw
        {
            get => new Vector4i(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i wwwx
        {
            get => new Vector4i(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4i wwwy
        {
            get => new Vector4i(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i wwwz
        {
            get => new Vector4i(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i wwww
        {
            get => new Vector4i(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
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
        public int a
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2i ra
        {
            get => new Vector2i(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2i ga
        {
            get => new Vector2i(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2i ba
        {
            get => new Vector2i(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ar
        {
            get => new Vector2i(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ag
        {
            get => new Vector2i(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i ab
        {
            get => new Vector2i(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i aa
        {
            get => new Vector2i(W, W);
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
        public Vector3i rra
        {
            get => new Vector3i(X, X, W);
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
        public Vector3i rga
        {
            get => new Vector3i(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3i rba
        {
            get => new Vector3i(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i rar
        {
            get => new Vector3i(X, W, X);
        }

        [XmlIgnore]
        public Vector3i rag
        {
            get => new Vector3i(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i rab
        {
            get => new Vector3i(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i raa
        {
            get => new Vector3i(X, W, W);
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
        public Vector3i gra
        {
            get => new Vector3i(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3i gga
        {
            get => new Vector3i(Y, Y, W);
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
        public Vector3i gba
        {
            get => new Vector3i(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i gar
        {
            get => new Vector3i(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i gag
        {
            get => new Vector3i(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3i gab
        {
            get => new Vector3i(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i gaa
        {
            get => new Vector3i(Y, W, W);
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
        public Vector3i bra
        {
            get => new Vector3i(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3i bga
        {
            get => new Vector3i(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3i bba
        {
            get => new Vector3i(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3i bar
        {
            get => new Vector3i(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i bag
        {
            get => new Vector3i(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i bab
        {
            get => new Vector3i(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3i baa
        {
            get => new Vector3i(Z, W, W);
        }

        [XmlIgnore]
        public Vector3i arr
        {
            get => new Vector3i(W, X, X);
        }

        [XmlIgnore]
        public Vector3i arg
        {
            get => new Vector3i(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i arb
        {
            get => new Vector3i(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i ara
        {
            get => new Vector3i(W, X, W);
        }

        [XmlIgnore]
        public Vector3i agr
        {
            get => new Vector3i(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i agg
        {
            get => new Vector3i(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3i agb
        {
            get => new Vector3i(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i aga
        {
            get => new Vector3i(W, Y, W);
        }

        [XmlIgnore]
        public Vector3i abr
        {
            get => new Vector3i(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i abg
        {
            get => new Vector3i(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i abb
        {
            get => new Vector3i(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3i aba
        {
            get => new Vector3i(W, Z, W);
        }

        [XmlIgnore]
        public Vector3i aar
        {
            get => new Vector3i(W, W, X);
        }

        [XmlIgnore]
        public Vector3i aag
        {
            get => new Vector3i(W, W, Y);
        }

        [XmlIgnore]
        public Vector3i aab
        {
            get => new Vector3i(W, W, Z);
        }

        [XmlIgnore]
        public Vector3i aaa
        {
            get => new Vector3i(W, W, W);
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
        public Vector4i rrra
        {
            get => new Vector4i(X, X, X, W);
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
        public Vector4i rrga
        {
            get => new Vector4i(X, X, Y, W);
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
        public Vector4i rrba
        {
            get => new Vector4i(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i rrar
        {
            get => new Vector4i(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4i rrag
        {
            get => new Vector4i(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i rrab
        {
            get => new Vector4i(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i rraa
        {
            get => new Vector4i(X, X, W, W);
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
        public Vector4i rgra
        {
            get => new Vector4i(X, Y, X, W);
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
        public Vector4i rgga
        {
            get => new Vector4i(X, Y, Y, W);
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
        public Vector4i rgba
        {
            get => new Vector4i(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i rgar
        {
            get => new Vector4i(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i rgag
        {
            get => new Vector4i(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i rgab
        {
            get => new Vector4i(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i rgaa
        {
            get => new Vector4i(X, Y, W, W);
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
        public Vector4i rbra
        {
            get => new Vector4i(X, Z, X, W);
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
        public Vector4i rbga
        {
            get => new Vector4i(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i rbba
        {
            get => new Vector4i(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i rbar
        {
            get => new Vector4i(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i rbag
        {
            get => new Vector4i(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i rbab
        {
            get => new Vector4i(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i rbaa
        {
            get => new Vector4i(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i rarr
        {
            get => new Vector4i(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4i rarg
        {
            get => new Vector4i(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i rarb
        {
            get => new Vector4i(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i rara
        {
            get => new Vector4i(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4i ragr
        {
            get => new Vector4i(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i ragg
        {
            get => new Vector4i(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i ragb
        {
            get => new Vector4i(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i raga
        {
            get => new Vector4i(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i rabr
        {
            get => new Vector4i(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i rabg
        {
            get => new Vector4i(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i rabb
        {
            get => new Vector4i(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i raba
        {
            get => new Vector4i(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i raar
        {
            get => new Vector4i(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4i raag
        {
            get => new Vector4i(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i raab
        {
            get => new Vector4i(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i raaa
        {
            get => new Vector4i(X, W, W, W);
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
        public Vector4i grra
        {
            get => new Vector4i(Y, X, X, W);
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
        public Vector4i grga
        {
            get => new Vector4i(Y, X, Y, W);
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
        public Vector4i grba
        {
            get => new Vector4i(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i grar
        {
            get => new Vector4i(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4i grag
        {
            get => new Vector4i(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i grab
        {
            get => new Vector4i(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i graa
        {
            get => new Vector4i(Y, X, W, W);
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
        public Vector4i ggra
        {
            get => new Vector4i(Y, Y, X, W);
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
        public Vector4i ggga
        {
            get => new Vector4i(Y, Y, Y, W);
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
        public Vector4i ggba
        {
            get => new Vector4i(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i ggar
        {
            get => new Vector4i(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i ggag
        {
            get => new Vector4i(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i ggab
        {
            get => new Vector4i(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i ggaa
        {
            get => new Vector4i(Y, Y, W, W);
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
        public Vector4i gbra
        {
            get => new Vector4i(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i gbga
        {
            get => new Vector4i(Y, Z, Y, W);
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
        public Vector4i gbba
        {
            get => new Vector4i(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i gbar
        {
            get => new Vector4i(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i gbag
        {
            get => new Vector4i(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i gbab
        {
            get => new Vector4i(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i gbaa
        {
            get => new Vector4i(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i garr
        {
            get => new Vector4i(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4i garg
        {
            get => new Vector4i(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i garb
        {
            get => new Vector4i(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i gara
        {
            get => new Vector4i(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4i gagr
        {
            get => new Vector4i(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i gagg
        {
            get => new Vector4i(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i gagb
        {
            get => new Vector4i(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i gaga
        {
            get => new Vector4i(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i gabr
        {
            get => new Vector4i(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i gabg
        {
            get => new Vector4i(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i gabb
        {
            get => new Vector4i(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i gaba
        {
            get => new Vector4i(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i gaar
        {
            get => new Vector4i(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4i gaag
        {
            get => new Vector4i(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i gaab
        {
            get => new Vector4i(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i gaaa
        {
            get => new Vector4i(Y, W, W, W);
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
        public Vector4i brra
        {
            get => new Vector4i(Z, X, X, W);
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
        public Vector4i brga
        {
            get => new Vector4i(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i brba
        {
            get => new Vector4i(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i brar
        {
            get => new Vector4i(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4i brag
        {
            get => new Vector4i(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i brab
        {
            get => new Vector4i(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i braa
        {
            get => new Vector4i(Z, X, W, W);
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
        public Vector4i bgra
        {
            get => new Vector4i(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i bgga
        {
            get => new Vector4i(Z, Y, Y, W);
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
        public Vector4i bgba
        {
            get => new Vector4i(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i bgar
        {
            get => new Vector4i(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i bgag
        {
            get => new Vector4i(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i bgab
        {
            get => new Vector4i(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i bgaa
        {
            get => new Vector4i(Z, Y, W, W);
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
        public Vector4i bbra
        {
            get => new Vector4i(Z, Z, X, W);
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
        public Vector4i bbga
        {
            get => new Vector4i(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4i bbba
        {
            get => new Vector4i(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i bbar
        {
            get => new Vector4i(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i bbag
        {
            get => new Vector4i(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i bbab
        {
            get => new Vector4i(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i bbaa
        {
            get => new Vector4i(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i barr
        {
            get => new Vector4i(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4i barg
        {
            get => new Vector4i(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i barb
        {
            get => new Vector4i(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i bara
        {
            get => new Vector4i(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4i bagr
        {
            get => new Vector4i(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i bagg
        {
            get => new Vector4i(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i bagb
        {
            get => new Vector4i(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i baga
        {
            get => new Vector4i(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i babr
        {
            get => new Vector4i(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i babg
        {
            get => new Vector4i(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i babb
        {
            get => new Vector4i(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i baba
        {
            get => new Vector4i(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i baar
        {
            get => new Vector4i(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4i baag
        {
            get => new Vector4i(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i baab
        {
            get => new Vector4i(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i baaa
        {
            get => new Vector4i(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4i arrr
        {
            get => new Vector4i(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4i arrg
        {
            get => new Vector4i(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i arrb
        {
            get => new Vector4i(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i arra
        {
            get => new Vector4i(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4i argr
        {
            get => new Vector4i(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i argg
        {
            get => new Vector4i(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i argb
        {
            get => new Vector4i(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i arga
        {
            get => new Vector4i(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4i arbr
        {
            get => new Vector4i(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i arbg
        {
            get => new Vector4i(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i arbb
        {
            get => new Vector4i(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i arba
        {
            get => new Vector4i(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i arar
        {
            get => new Vector4i(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4i arag
        {
            get => new Vector4i(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i arab
        {
            get => new Vector4i(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i araa
        {
            get => new Vector4i(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4i agrr
        {
            get => new Vector4i(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i agrg
        {
            get => new Vector4i(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i agrb
        {
            get => new Vector4i(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i agra
        {
            get => new Vector4i(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4i aggr
        {
            get => new Vector4i(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i aggg
        {
            get => new Vector4i(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i aggb
        {
            get => new Vector4i(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i agga
        {
            get => new Vector4i(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4i agbr
        {
            get => new Vector4i(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i agbg
        {
            get => new Vector4i(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i agbb
        {
            get => new Vector4i(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i agba
        {
            get => new Vector4i(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i agar
        {
            get => new Vector4i(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i agag
        {
            get => new Vector4i(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i agab
        {
            get => new Vector4i(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i agaa
        {
            get => new Vector4i(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4i abrr
        {
            get => new Vector4i(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i abrg
        {
            get => new Vector4i(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i abrb
        {
            get => new Vector4i(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i abra
        {
            get => new Vector4i(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4i abgr
        {
            get => new Vector4i(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i abgg
        {
            get => new Vector4i(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i abgb
        {
            get => new Vector4i(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i abga
        {
            get => new Vector4i(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4i abbr
        {
            get => new Vector4i(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i abbg
        {
            get => new Vector4i(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i abbb
        {
            get => new Vector4i(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i abba
        {
            get => new Vector4i(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i abar
        {
            get => new Vector4i(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i abag
        {
            get => new Vector4i(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i abab
        {
            get => new Vector4i(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i abaa
        {
            get => new Vector4i(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i aarr
        {
            get => new Vector4i(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4i aarg
        {
            get => new Vector4i(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i aarb
        {
            get => new Vector4i(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i aara
        {
            get => new Vector4i(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4i aagr
        {
            get => new Vector4i(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i aagg
        {
            get => new Vector4i(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i aagb
        {
            get => new Vector4i(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i aaga
        {
            get => new Vector4i(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i aabr
        {
            get => new Vector4i(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i aabg
        {
            get => new Vector4i(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i aabb
        {
            get => new Vector4i(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i aaba
        {
            get => new Vector4i(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i aaar
        {
            get => new Vector4i(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4i aaag
        {
            get => new Vector4i(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i aaab
        {
            get => new Vector4i(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i aaaa
        {
            get => new Vector4i(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
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
        public int q
        {
            get => W;
            set
            {
                W = value;
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
        public Vector2i sq
        {
            get => new Vector2i(X, W);
            set
            {
                X = value.X;
                W = value.Y;
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
        public Vector2i tq
        {
            get => new Vector2i(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
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
        public Vector2i pq
        {
            get => new Vector2i(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i qs
        {
            get => new Vector2i(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i qt
        {
            get => new Vector2i(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i qp
        {
            get => new Vector2i(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2i qq
        {
            get => new Vector2i(W, W);
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
        public Vector3i ssq
        {
            get => new Vector3i(X, X, W);
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
        public Vector3i stq
        {
            get => new Vector3i(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
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
        public Vector3i spq
        {
            get => new Vector3i(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i sqs
        {
            get => new Vector3i(X, W, X);
        }

        [XmlIgnore]
        public Vector3i sqt
        {
            get => new Vector3i(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i sqp
        {
            get => new Vector3i(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i sqq
        {
            get => new Vector3i(X, W, W);
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
        public Vector3i tsq
        {
            get => new Vector3i(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        public Vector3i ttq
        {
            get => new Vector3i(Y, Y, W);
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
        public Vector3i tpq
        {
            get => new Vector3i(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i tqs
        {
            get => new Vector3i(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i tqt
        {
            get => new Vector3i(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3i tqp
        {
            get => new Vector3i(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i tqq
        {
            get => new Vector3i(Y, W, W);
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
        public Vector3i psq
        {
            get => new Vector3i(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
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
        public Vector3i ptq
        {
            get => new Vector3i(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
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
        public Vector3i ppq
        {
            get => new Vector3i(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3i pqs
        {
            get => new Vector3i(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i pqt
        {
            get => new Vector3i(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i pqp
        {
            get => new Vector3i(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3i pqq
        {
            get => new Vector3i(Z, W, W);
        }

        [XmlIgnore]
        public Vector3i qss
        {
            get => new Vector3i(W, X, X);
        }

        [XmlIgnore]
        public Vector3i qst
        {
            get => new Vector3i(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qsp
        {
            get => new Vector3i(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qsq
        {
            get => new Vector3i(W, X, W);
        }

        [XmlIgnore]
        public Vector3i qts
        {
            get => new Vector3i(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qtt
        {
            get => new Vector3i(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3i qtp
        {
            get => new Vector3i(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qtq
        {
            get => new Vector3i(W, Y, W);
        }

        [XmlIgnore]
        public Vector3i qps
        {
            get => new Vector3i(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qpt
        {
            get => new Vector3i(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3i qpp
        {
            get => new Vector3i(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3i qpq
        {
            get => new Vector3i(W, Z, W);
        }

        [XmlIgnore]
        public Vector3i qqs
        {
            get => new Vector3i(W, W, X);
        }

        [XmlIgnore]
        public Vector3i qqt
        {
            get => new Vector3i(W, W, Y);
        }

        [XmlIgnore]
        public Vector3i qqp
        {
            get => new Vector3i(W, W, Z);
        }

        [XmlIgnore]
        public Vector3i qqq
        {
            get => new Vector3i(W, W, W);
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
        public Vector4i sssq
        {
            get => new Vector4i(X, X, X, W);
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
        public Vector4i sstq
        {
            get => new Vector4i(X, X, Y, W);
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
        public Vector4i sspq
        {
            get => new Vector4i(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i ssqs
        {
            get => new Vector4i(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4i ssqt
        {
            get => new Vector4i(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i ssqp
        {
            get => new Vector4i(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i ssqq
        {
            get => new Vector4i(X, X, W, W);
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
        public Vector4i stsq
        {
            get => new Vector4i(X, Y, X, W);
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
        public Vector4i sttq
        {
            get => new Vector4i(X, Y, Y, W);
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
        public Vector4i stpq
        {
            get => new Vector4i(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i stqs
        {
            get => new Vector4i(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i stqt
        {
            get => new Vector4i(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i stqp
        {
            get => new Vector4i(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i stqq
        {
            get => new Vector4i(X, Y, W, W);
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
        public Vector4i spsq
        {
            get => new Vector4i(X, Z, X, W);
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
        public Vector4i sptq
        {
            get => new Vector4i(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i sppq
        {
            get => new Vector4i(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i spqs
        {
            get => new Vector4i(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i spqt
        {
            get => new Vector4i(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i spqp
        {
            get => new Vector4i(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i spqq
        {
            get => new Vector4i(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i sqss
        {
            get => new Vector4i(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4i sqst
        {
            get => new Vector4i(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i sqsp
        {
            get => new Vector4i(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i sqsq
        {
            get => new Vector4i(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4i sqts
        {
            get => new Vector4i(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i sqtt
        {
            get => new Vector4i(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i sqtp
        {
            get => new Vector4i(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i sqtq
        {
            get => new Vector4i(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i sqps
        {
            get => new Vector4i(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i sqpt
        {
            get => new Vector4i(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i sqpp
        {
            get => new Vector4i(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i sqpq
        {
            get => new Vector4i(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i sqqs
        {
            get => new Vector4i(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4i sqqt
        {
            get => new Vector4i(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i sqqp
        {
            get => new Vector4i(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i sqqq
        {
            get => new Vector4i(X, W, W, W);
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
        public Vector4i tssq
        {
            get => new Vector4i(Y, X, X, W);
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
        public Vector4i tstq
        {
            get => new Vector4i(Y, X, Y, W);
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
        public Vector4i tspq
        {
            get => new Vector4i(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i tsqs
        {
            get => new Vector4i(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4i tsqt
        {
            get => new Vector4i(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i tsqp
        {
            get => new Vector4i(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i tsqq
        {
            get => new Vector4i(Y, X, W, W);
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
        public Vector4i ttsq
        {
            get => new Vector4i(Y, Y, X, W);
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
        public Vector4i tttq
        {
            get => new Vector4i(Y, Y, Y, W);
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
        public Vector4i ttpq
        {
            get => new Vector4i(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i ttqs
        {
            get => new Vector4i(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i ttqt
        {
            get => new Vector4i(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i ttqp
        {
            get => new Vector4i(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i ttqq
        {
            get => new Vector4i(Y, Y, W, W);
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
        public Vector4i tpsq
        {
            get => new Vector4i(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i tptq
        {
            get => new Vector4i(Y, Z, Y, W);
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
        public Vector4i tppq
        {
            get => new Vector4i(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i tpqs
        {
            get => new Vector4i(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i tpqt
        {
            get => new Vector4i(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i tpqp
        {
            get => new Vector4i(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i tpqq
        {
            get => new Vector4i(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i tqss
        {
            get => new Vector4i(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4i tqst
        {
            get => new Vector4i(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i tqsp
        {
            get => new Vector4i(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i tqsq
        {
            get => new Vector4i(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4i tqts
        {
            get => new Vector4i(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i tqtt
        {
            get => new Vector4i(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i tqtp
        {
            get => new Vector4i(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i tqtq
        {
            get => new Vector4i(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i tqps
        {
            get => new Vector4i(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i tqpt
        {
            get => new Vector4i(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i tqpp
        {
            get => new Vector4i(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i tqpq
        {
            get => new Vector4i(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i tqqs
        {
            get => new Vector4i(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4i tqqt
        {
            get => new Vector4i(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i tqqp
        {
            get => new Vector4i(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i tqqq
        {
            get => new Vector4i(Y, W, W, W);
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
        public Vector4i pssq
        {
            get => new Vector4i(Z, X, X, W);
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
        public Vector4i pstq
        {
            get => new Vector4i(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
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
        public Vector4i pspq
        {
            get => new Vector4i(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i psqs
        {
            get => new Vector4i(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4i psqt
        {
            get => new Vector4i(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i psqp
        {
            get => new Vector4i(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i psqq
        {
            get => new Vector4i(Z, X, W, W);
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
        public Vector4i ptsq
        {
            get => new Vector4i(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
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
        public Vector4i pttq
        {
            get => new Vector4i(Z, Y, Y, W);
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
        public Vector4i ptpq
        {
            get => new Vector4i(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i ptqs
        {
            get => new Vector4i(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i ptqt
        {
            get => new Vector4i(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i ptqp
        {
            get => new Vector4i(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i ptqq
        {
            get => new Vector4i(Z, Y, W, W);
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
        public Vector4i ppsq
        {
            get => new Vector4i(Z, Z, X, W);
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
        public Vector4i pptq
        {
            get => new Vector4i(Z, Z, Y, W);
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

        [XmlIgnore]
        public Vector4i pppq
        {
            get => new Vector4i(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i ppqs
        {
            get => new Vector4i(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i ppqt
        {
            get => new Vector4i(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i ppqp
        {
            get => new Vector4i(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i ppqq
        {
            get => new Vector4i(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i pqss
        {
            get => new Vector4i(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4i pqst
        {
            get => new Vector4i(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i pqsp
        {
            get => new Vector4i(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i pqsq
        {
            get => new Vector4i(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4i pqts
        {
            get => new Vector4i(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i pqtt
        {
            get => new Vector4i(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i pqtp
        {
            get => new Vector4i(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i pqtq
        {
            get => new Vector4i(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i pqps
        {
            get => new Vector4i(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i pqpt
        {
            get => new Vector4i(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i pqpp
        {
            get => new Vector4i(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i pqpq
        {
            get => new Vector4i(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i pqqs
        {
            get => new Vector4i(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4i pqqt
        {
            get => new Vector4i(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i pqqp
        {
            get => new Vector4i(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i pqqq
        {
            get => new Vector4i(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4i qsss
        {
            get => new Vector4i(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4i qsst
        {
            get => new Vector4i(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4i qssp
        {
            get => new Vector4i(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4i qssq
        {
            get => new Vector4i(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4i qsts
        {
            get => new Vector4i(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4i qstt
        {
            get => new Vector4i(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4i qstp
        {
            get => new Vector4i(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qstq
        {
            get => new Vector4i(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4i qsps
        {
            get => new Vector4i(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4i qspt
        {
            get => new Vector4i(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qspp
        {
            get => new Vector4i(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4i qspq
        {
            get => new Vector4i(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4i qsqs
        {
            get => new Vector4i(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4i qsqt
        {
            get => new Vector4i(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4i qsqp
        {
            get => new Vector4i(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4i qsqq
        {
            get => new Vector4i(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4i qtss
        {
            get => new Vector4i(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4i qtst
        {
            get => new Vector4i(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4i qtsp
        {
            get => new Vector4i(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qtsq
        {
            get => new Vector4i(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4i qtts
        {
            get => new Vector4i(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4i qttt
        {
            get => new Vector4i(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4i qttp
        {
            get => new Vector4i(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4i qttq
        {
            get => new Vector4i(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4i qtps
        {
            get => new Vector4i(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qtpt
        {
            get => new Vector4i(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4i qtpp
        {
            get => new Vector4i(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4i qtpq
        {
            get => new Vector4i(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4i qtqs
        {
            get => new Vector4i(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4i qtqt
        {
            get => new Vector4i(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4i qtqp
        {
            get => new Vector4i(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4i qtqq
        {
            get => new Vector4i(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4i qpss
        {
            get => new Vector4i(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4i qpst
        {
            get => new Vector4i(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qpsp
        {
            get => new Vector4i(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4i qpsq
        {
            get => new Vector4i(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4i qpts
        {
            get => new Vector4i(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4i qptt
        {
            get => new Vector4i(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4i qptp
        {
            get => new Vector4i(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4i qptq
        {
            get => new Vector4i(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4i qpps
        {
            get => new Vector4i(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4i qppt
        {
            get => new Vector4i(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4i qppp
        {
            get => new Vector4i(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4i qppq
        {
            get => new Vector4i(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4i qpqs
        {
            get => new Vector4i(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4i qpqt
        {
            get => new Vector4i(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4i qpqp
        {
            get => new Vector4i(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4i qpqq
        {
            get => new Vector4i(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4i qqss
        {
            get => new Vector4i(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4i qqst
        {
            get => new Vector4i(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4i qqsp
        {
            get => new Vector4i(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4i qqsq
        {
            get => new Vector4i(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4i qqts
        {
            get => new Vector4i(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4i qqtt
        {
            get => new Vector4i(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4i qqtp
        {
            get => new Vector4i(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4i qqtq
        {
            get => new Vector4i(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4i qqps
        {
            get => new Vector4i(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4i qqpt
        {
            get => new Vector4i(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4i qqpp
        {
            get => new Vector4i(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4i qqpq
        {
            get => new Vector4i(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4i qqqs
        {
            get => new Vector4i(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4i qqqt
        {
            get => new Vector4i(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4i qqqp
        {
            get => new Vector4i(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4i qqqq
        {
            get => new Vector4i(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Gets a <see cref="Vector4"/> object with the same component values as the <see cref="Vector4i"/> instance.
        /// </summary>
        /// <returns>The resulting <see cref="Vector4"/> instance.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(X, Y, Z, W);
        }

        /// <summary>
        /// Gets a <see cref="Vector4"/> object with the same component values as the <see cref="Vector4i"/> instance.
        /// </summary>
        /// <param name="input">The given <see cref="Vector4i"/> to convert.</param>
        /// <param name="result">The resulting <see cref="Vector4"/>.</param>
        public static void ToVector4(ref Vector4i input, out Vector4 result)
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
        public static Vector4i operator +(Vector4i left, Vector4i right)
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
        public static Vector4i operator -(Vector4i left, Vector4i right)
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
        public static Vector4i operator -(Vector4i vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            vec.W = -vec.W;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by an integer scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Vector4i operator *(Vector4i vec, int scale)
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
        public static Vector4i operator *(int scale, Vector4i vec)
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
        public static Vector4i operator *(Vector4i vec, Vector4i scale)
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
        public static Vector4i operator /(Vector4i vec, int scale)
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
        public static bool operator ==(Vector4i left, Vector4i right)
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
        public static bool operator !=(Vector4i left, Vector4i right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static unsafe explicit operator int*(Vector4i v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [Pure]
        public static explicit operator IntPtr(Vector4i v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4i"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4i"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4i((int X, int Y, int Z, int W) values)
        {
            return new Vector4i(values.X, values.Y, values.Z, values.W);
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
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                hashCode = (hashCode * 397) ^ W;
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
            if (!(obj is Vector4i))
            {
                return false;
            }

            return Equals((Vector4i)obj);
        }

        /// <summary>
        /// Indicates whether the current vector is equal to another vector.
        /// </summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(Vector4i other)
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
        public void Deconstruct(out int x, out int y, out int z, out int w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
