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
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenToolkit.Mathematics
{
    /// <summary>
    /// 4-component Vector of the Half type. Occupies 8 Byte total.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4h : ISerializable, IEquatable<Vector4h>
    {
        /// <summary>
        /// The X component of the Half4.
        /// </summary>
        public Half X;

        /// <summary>
        /// The Y component of the Half4.
        /// </summary>
        public Half Y;

        /// <summary>
        /// The Z component of the Half4.
        /// </summary>
        public Half Z;

        /// <summary>
        /// The W component of the Half4.
        /// </summary>
        public Half W;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4h(Half value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4h(float value)
        {
            X = new Half(value);
            Y = new Half(value);
            Z = new Half(value);
            W = new Half(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        public Vector4h(Half x, Half y, Half z, Half w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        public Vector4h(float x, float y, float z, float w)
        {
            X = new Half(x);
            Y = new Half(y);
            Z = new Half(z);
            W = new Half(w);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector4h(float x, float y, float z, float w, bool throwOnError)
        {
            X = new Half(x, throwOnError);
            Y = new Half(y, throwOnError);
            Z = new Half(z, throwOnError);
            W = new Half(w, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4"/> to convert.</param>
        public Vector4h(Vector4 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
            W = new Half(v.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector4h(Vector4 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
            W = new Half(v.W, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4"/> to convert.</param>
        public Vector4h(ref Vector4 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
            W = new Half(v.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector4h(ref Vector4 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
            W = new Half(v.W, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4d"/> to convert.</param>
        public Vector4h(Vector4d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
            W = new Half(v.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector4h(Vector4d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
            W = new Half(v.W, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4d"/> to convert.</param>
        public Vector4h(ref Vector4d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
            W = new Half(v.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector4d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector4h(ref Vector4d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
            W = new Half(v.W, throwOnError);
        }

        #region Components
        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Xy
        {
            get => Unsafe.As<Vector4h, Vector2h>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the X and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Xz
        {
            get => new Vector2h(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the X and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Xw
        {
            get => new Vector2h(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Y and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Yx
        {
            get => new Vector2h(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Y and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Yz
        {
            get => new Vector2h(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Y and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Yw
        {
            get => new Vector2h(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Z and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Zx
        {
            get => new Vector2h(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Z and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Zy
        {
            get => new Vector2h(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the Z and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Zw
        {
            get => new Vector2h(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the W and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Wx
        {
            get => new Vector2h(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the W and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Wy
        {
            get => new Vector2h(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the W and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Wz
        {
            get => new Vector2h(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xyz
        {
            get => Unsafe.As<Vector4h, Vector3h>(ref this);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xyw
        {
            get => new Vector3h(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xzy
        {
            get => new Vector3h(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xzw
        {
            get => new Vector3h(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xwy
        {
            get => new Vector3h(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Xwz
        {
            get => new Vector3h(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Yxz
        {
            get => new Vector3h(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Yxw
        {
            get => new Vector3h(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Yzx
        {
            get => new Vector3h(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Yzw
        {
            get => new Vector3h(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Ywx
        {
            get => new Vector3h(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Ywz
        {
            get => new Vector3h(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zxy
        {
            get => new Vector3h(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zxw
        {
            get => new Vector3h(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zyx
        {
            get => new Vector3h(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zyw
        {
            get => new Vector3h(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zwx
        {
            get => new Vector3h(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Zwy
        {
            get => new Vector3h(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wxy
        {
            get => new Vector3h(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wxz
        {
            get => new Vector3h(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wyx
        {
            get => new Vector3h(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wyz
        {
            get => new Vector3h(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wzx
        {
            get => new Vector3h(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector3h with the W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector3h Wzy
        {
            get => new Vector3h(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the X, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Xywz
        {
            get => new Vector4h(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the X, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Xzyw
        {
            get => new Vector4h(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the X, Z, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Xzwy
        {
            get => new Vector4h(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the X, W, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Xwyz
        {
            get => new Vector4h(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the X, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Xwzy
        {
            get => new Vector4h(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, X, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yxzw
        {
            get => new Vector4h(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, X, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yxwz
        {
            get => new Vector4h(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, Y, Z, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yyzw
        {
            get => new Vector4h(Y, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, Y, W, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yywz
        {
            get => new Vector4h(Y, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, Z, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yzxw
        {
            get => new Vector4h(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, Z, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Yzwx
        {
            get => new Vector4h(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, W, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Ywxz
        {
            get => new Vector4h(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Y, W, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Ywzx
        {
            get => new Vector4h(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zxyw
        {
            get => new Vector4h(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, X, W, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zxwy
        {
            get => new Vector4h(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, Y, X, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zyxw
        {
            get => new Vector4h(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, Y, W, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zywx
        {
            get => new Vector4h(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, W, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zwxy
        {
            get => new Vector4h(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, W, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zwyx
        {
            get => new Vector4h(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the Z, W, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Zwzy
        {
            get => new Vector4h(Z, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, X, Y, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wxyz
        {
            get => new Vector4h(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, X, Z, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wxzy
        {
            get => new Vector4h(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, Y, X, and Z components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wyxz
        {
            get => new Vector4h(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, Y, Z, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wyzx
        {
            get => new Vector4h(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, Z, X, and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wzxy
        {
            get => new Vector4h(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, Z, Y, and X components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wzyx
        {
            get => new Vector4h(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector4h with the W, Z, Y, and W components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector4h Wzyw
        {
            get => new Vector4h(W, Z, Y, W);
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
        public Half x
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public Half y
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Half z
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Half w
        {
            get => W;
            set
            {
                W = value;
            }
        }

        [XmlIgnore]
        public Vector2h xx
        {
            get => new Vector2h(X, X);
        }

        [XmlIgnore]
        public Vector2h xy
        {
            get => new Vector2h(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h xz
        {
            get => new Vector2h(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h xw
        {
            get => new Vector2h(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h yx
        {
            get => new Vector2h(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h yy
        {
            get => new Vector2h(Y, Y);
        }

        [XmlIgnore]
        public Vector2h yz
        {
            get => new Vector2h(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h yw
        {
            get => new Vector2h(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h zx
        {
            get => new Vector2h(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h zy
        {
            get => new Vector2h(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h zz
        {
            get => new Vector2h(Z, Z);
        }

        [XmlIgnore]
        public Vector2h zw
        {
            get => new Vector2h(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h wx
        {
            get => new Vector2h(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h wy
        {
            get => new Vector2h(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h wz
        {
            get => new Vector2h(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ww
        {
            get => new Vector2h(W, W);
        }

        [XmlIgnore]
        public Vector3h xxx
        {
            get => new Vector3h(X, X, X);
        }

        [XmlIgnore]
        public Vector3h xxy
        {
            get => new Vector3h(X, X, Y);
        }

        [XmlIgnore]
        public Vector3h xxz
        {
            get => new Vector3h(X, X, Z);
        }

        [XmlIgnore]
        public Vector3h xxw
        {
            get => new Vector3h(X, X, W);
        }

        [XmlIgnore]
        public Vector3h xyx
        {
            get => new Vector3h(X, Y, X);
        }

        [XmlIgnore]
        public Vector3h xyy
        {
            get => new Vector3h(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3h xyz
        {
            get => new Vector3h(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xyw
        {
            get => new Vector3h(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xzx
        {
            get => new Vector3h(X, Z, X);
        }

        [XmlIgnore]
        public Vector3h xzy
        {
            get => new Vector3h(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xzz
        {
            get => new Vector3h(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3h xzw
        {
            get => new Vector3h(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xwx
        {
            get => new Vector3h(X, W, X);
        }

        [XmlIgnore]
        public Vector3h xwy
        {
            get => new Vector3h(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xwz
        {
            get => new Vector3h(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h xww
        {
            get => new Vector3h(X, W, W);
        }

        [XmlIgnore]
        public Vector3h yxx
        {
            get => new Vector3h(Y, X, X);
        }

        [XmlIgnore]
        public Vector3h yxy
        {
            get => new Vector3h(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3h yxz
        {
            get => new Vector3h(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h yxw
        {
            get => new Vector3h(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h yyx
        {
            get => new Vector3h(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3h yyy
        {
            get => new Vector3h(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3h yyz
        {
            get => new Vector3h(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3h yyw
        {
            get => new Vector3h(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3h yzx
        {
            get => new Vector3h(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h yzy
        {
            get => new Vector3h(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3h yzz
        {
            get => new Vector3h(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3h yzw
        {
            get => new Vector3h(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h ywx
        {
            get => new Vector3h(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h ywy
        {
            get => new Vector3h(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3h ywz
        {
            get => new Vector3h(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h yww
        {
            get => new Vector3h(Y, W, W);
        }

        [XmlIgnore]
        public Vector3h zxx
        {
            get => new Vector3h(Z, X, X);
        }

        [XmlIgnore]
        public Vector3h zxy
        {
            get => new Vector3h(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zxz
        {
            get => new Vector3h(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3h zxw
        {
            get => new Vector3h(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zyx
        {
            get => new Vector3h(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zyy
        {
            get => new Vector3h(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3h zyz
        {
            get => new Vector3h(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3h zyw
        {
            get => new Vector3h(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zzx
        {
            get => new Vector3h(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3h zzy
        {
            get => new Vector3h(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3h zzz
        {
            get => new Vector3h(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3h zzw
        {
            get => new Vector3h(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3h zwx
        {
            get => new Vector3h(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zwy
        {
            get => new Vector3h(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h zwz
        {
            get => new Vector3h(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3h zww
        {
            get => new Vector3h(Z, W, W);
        }

        [XmlIgnore]
        public Vector3h wxx
        {
            get => new Vector3h(W, X, X);
        }

        [XmlIgnore]
        public Vector3h wxy
        {
            get => new Vector3h(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wxz
        {
            get => new Vector3h(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wxw
        {
            get => new Vector3h(W, X, W);
        }

        [XmlIgnore]
        public Vector3h wyx
        {
            get => new Vector3h(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wyy
        {
            get => new Vector3h(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3h wyz
        {
            get => new Vector3h(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wyw
        {
            get => new Vector3h(W, Y, W);
        }

        [XmlIgnore]
        public Vector3h wzx
        {
            get => new Vector3h(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wzy
        {
            get => new Vector3h(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h wzz
        {
            get => new Vector3h(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3h wzw
        {
            get => new Vector3h(W, Z, W);
        }

        [XmlIgnore]
        public Vector3h wwx
        {
            get => new Vector3h(W, W, X);
        }

        [XmlIgnore]
        public Vector3h wwy
        {
            get => new Vector3h(W, W, Y);
        }

        [XmlIgnore]
        public Vector3h wwz
        {
            get => new Vector3h(W, W, Z);
        }

        [XmlIgnore]
        public Vector3h www
        {
            get => new Vector3h(W, W, W);
        }

        [XmlIgnore]
        public Vector4h xxxx
        {
            get => new Vector4h(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4h xxxy
        {
            get => new Vector4h(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h xxxz
        {
            get => new Vector4h(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h xxxw
        {
            get => new Vector4h(X, X, X, W);
        }

        [XmlIgnore]
        public Vector4h xxyx
        {
            get => new Vector4h(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h xxyy
        {
            get => new Vector4h(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h xxyz
        {
            get => new Vector4h(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h xxyw
        {
            get => new Vector4h(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h xxzx
        {
            get => new Vector4h(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h xxzy
        {
            get => new Vector4h(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h xxzz
        {
            get => new Vector4h(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h xxzw
        {
            get => new Vector4h(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h xxwx
        {
            get => new Vector4h(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4h xxwy
        {
            get => new Vector4h(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h xxwz
        {
            get => new Vector4h(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h xxww
        {
            get => new Vector4h(X, X, W, W);
        }

        [XmlIgnore]
        public Vector4h xyxx
        {
            get => new Vector4h(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h xyxy
        {
            get => new Vector4h(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h xyxz
        {
            get => new Vector4h(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h xyxw
        {
            get => new Vector4h(X, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h xyyx
        {
            get => new Vector4h(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h xyyy
        {
            get => new Vector4h(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h xyyz
        {
            get => new Vector4h(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h xyyw
        {
            get => new Vector4h(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h xyzx
        {
            get => new Vector4h(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h xyzy
        {
            get => new Vector4h(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h xyzz
        {
            get => new Vector4h(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h xyzw
        {
            get => new Vector4h(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xywx
        {
            get => new Vector4h(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h xywy
        {
            get => new Vector4h(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h xywz
        {
            get => new Vector4h(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xyww
        {
            get => new Vector4h(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h xzxx
        {
            get => new Vector4h(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h xzxy
        {
            get => new Vector4h(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h xzxz
        {
            get => new Vector4h(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h xzxw
        {
            get => new Vector4h(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h xzyx
        {
            get => new Vector4h(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h xzyy
        {
            get => new Vector4h(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h xzyz
        {
            get => new Vector4h(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h xzyw
        {
            get => new Vector4h(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xzzx
        {
            get => new Vector4h(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h xzzy
        {
            get => new Vector4h(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h xzzz
        {
            get => new Vector4h(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h xzzw
        {
            get => new Vector4h(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h xzwx
        {
            get => new Vector4h(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h xzwy
        {
            get => new Vector4h(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xzwz
        {
            get => new Vector4h(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h xzww
        {
            get => new Vector4h(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h xwxx
        {
            get => new Vector4h(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4h xwxy
        {
            get => new Vector4h(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h xwxz
        {
            get => new Vector4h(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h xwxw
        {
            get => new Vector4h(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4h xwyx
        {
            get => new Vector4h(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h xwyy
        {
            get => new Vector4h(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h xwyz
        {
            get => new Vector4h(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xwyw
        {
            get => new Vector4h(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h xwzx
        {
            get => new Vector4h(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h xwzy
        {
            get => new Vector4h(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h xwzz
        {
            get => new Vector4h(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h xwzw
        {
            get => new Vector4h(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h xwwx
        {
            get => new Vector4h(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4h xwwy
        {
            get => new Vector4h(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h xwwz
        {
            get => new Vector4h(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h xwww
        {
            get => new Vector4h(X, W, W, W);
        }

        [XmlIgnore]
        public Vector4h yxxx
        {
            get => new Vector4h(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4h yxxy
        {
            get => new Vector4h(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h yxxz
        {
            get => new Vector4h(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h yxxw
        {
            get => new Vector4h(Y, X, X, W);
        }

        [XmlIgnore]
        public Vector4h yxyx
        {
            get => new Vector4h(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h yxyy
        {
            get => new Vector4h(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h yxyz
        {
            get => new Vector4h(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h yxyw
        {
            get => new Vector4h(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h yxzx
        {
            get => new Vector4h(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h yxzy
        {
            get => new Vector4h(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h yxzz
        {
            get => new Vector4h(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h yxzw
        {
            get => new Vector4h(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h yxwx
        {
            get => new Vector4h(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4h yxwy
        {
            get => new Vector4h(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h yxwz
        {
            get => new Vector4h(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h yxww
        {
            get => new Vector4h(Y, X, W, W);
        }

        [XmlIgnore]
        public Vector4h yyxx
        {
            get => new Vector4h(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h yyxy
        {
            get => new Vector4h(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h yyxz
        {
            get => new Vector4h(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h yyxw
        {
            get => new Vector4h(Y, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h yyyx
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h yyyy
        {
            get => new Vector4h(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h yyyz
        {
            get => new Vector4h(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h yyyw
        {
            get => new Vector4h(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h yyzx
        {
            get => new Vector4h(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h yyzy
        {
            get => new Vector4h(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h yyzz
        {
            get => new Vector4h(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h yyzw
        {
            get => new Vector4h(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h yywx
        {
            get => new Vector4h(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h yywy
        {
            get => new Vector4h(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h yywz
        {
            get => new Vector4h(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h yyww
        {
            get => new Vector4h(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h yzxx
        {
            get => new Vector4h(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h yzxy
        {
            get => new Vector4h(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h yzxz
        {
            get => new Vector4h(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h yzxw
        {
            get => new Vector4h(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h yzyx
        {
            get => new Vector4h(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h yzyy
        {
            get => new Vector4h(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h yzyz
        {
            get => new Vector4h(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h yzyw
        {
            get => new Vector4h(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h yzzx
        {
            get => new Vector4h(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h yzzy
        {
            get => new Vector4h(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h yzzz
        {
            get => new Vector4h(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h yzzw
        {
            get => new Vector4h(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h yzwx
        {
            get => new Vector4h(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h yzwy
        {
            get => new Vector4h(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h yzwz
        {
            get => new Vector4h(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h yzww
        {
            get => new Vector4h(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h ywxx
        {
            get => new Vector4h(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4h ywxy
        {
            get => new Vector4h(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h ywxz
        {
            get => new Vector4h(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h ywxw
        {
            get => new Vector4h(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4h ywyx
        {
            get => new Vector4h(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h ywyy
        {
            get => new Vector4h(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h ywyz
        {
            get => new Vector4h(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h ywyw
        {
            get => new Vector4h(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h ywzx
        {
            get => new Vector4h(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h ywzy
        {
            get => new Vector4h(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h ywzz
        {
            get => new Vector4h(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h ywzw
        {
            get => new Vector4h(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h ywwx
        {
            get => new Vector4h(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4h ywwy
        {
            get => new Vector4h(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h ywwz
        {
            get => new Vector4h(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h ywww
        {
            get => new Vector4h(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4h zxxx
        {
            get => new Vector4h(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4h zxxy
        {
            get => new Vector4h(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h zxxz
        {
            get => new Vector4h(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h zxxw
        {
            get => new Vector4h(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4h zxyx
        {
            get => new Vector4h(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h zxyy
        {
            get => new Vector4h(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h zxyz
        {
            get => new Vector4h(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h zxyw
        {
            get => new Vector4h(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zxzx
        {
            get => new Vector4h(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h zxzy
        {
            get => new Vector4h(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h zxzz
        {
            get => new Vector4h(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h zxzw
        {
            get => new Vector4h(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h zxwx
        {
            get => new Vector4h(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4h zxwy
        {
            get => new Vector4h(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zxwz
        {
            get => new Vector4h(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h zxww
        {
            get => new Vector4h(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4h zyxx
        {
            get => new Vector4h(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h zyxy
        {
            get => new Vector4h(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h zyxz
        {
            get => new Vector4h(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h zyxw
        {
            get => new Vector4h(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zyyx
        {
            get => new Vector4h(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h zyyy
        {
            get => new Vector4h(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h zyyz
        {
            get => new Vector4h(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h zyyw
        {
            get => new Vector4h(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h zyzx
        {
            get => new Vector4h(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h zyzy
        {
            get => new Vector4h(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h zyzz
        {
            get => new Vector4h(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h zyzw
        {
            get => new Vector4h(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h zywx
        {
            get => new Vector4h(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zywy
        {
            get => new Vector4h(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h zywz
        {
            get => new Vector4h(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h zyww
        {
            get => new Vector4h(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h zzxx
        {
            get => new Vector4h(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h zzxy
        {
            get => new Vector4h(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h zzxz
        {
            get => new Vector4h(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h zzxw
        {
            get => new Vector4h(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h zzyx
        {
            get => new Vector4h(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h zzyy
        {
            get => new Vector4h(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h zzyz
        {
            get => new Vector4h(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h zzyw
        {
            get => new Vector4h(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h zzzx
        {
            get => new Vector4h(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h zzzy
        {
            get => new Vector4h(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h zzzz
        {
            get => new Vector4h(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h zzzw
        {
            get => new Vector4h(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h zzwx
        {
            get => new Vector4h(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h zzwy
        {
            get => new Vector4h(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h zzwz
        {
            get => new Vector4h(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h zzww
        {
            get => new Vector4h(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h zwxx
        {
            get => new Vector4h(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4h zwxy
        {
            get => new Vector4h(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zwxz
        {
            get => new Vector4h(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h zwxw
        {
            get => new Vector4h(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4h zwyx
        {
            get => new Vector4h(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h zwyy
        {
            get => new Vector4h(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h zwyz
        {
            get => new Vector4h(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h zwyw
        {
            get => new Vector4h(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h zwzx
        {
            get => new Vector4h(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h zwzy
        {
            get => new Vector4h(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h zwzz
        {
            get => new Vector4h(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h zwzw
        {
            get => new Vector4h(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h zwwx
        {
            get => new Vector4h(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4h zwwy
        {
            get => new Vector4h(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h zwwz
        {
            get => new Vector4h(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h zwww
        {
            get => new Vector4h(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4h wxxx
        {
            get => new Vector4h(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4h wxxy
        {
            get => new Vector4h(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h wxxz
        {
            get => new Vector4h(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h wxxw
        {
            get => new Vector4h(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4h wxyx
        {
            get => new Vector4h(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h wxyy
        {
            get => new Vector4h(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h wxyz
        {
            get => new Vector4h(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wxyw
        {
            get => new Vector4h(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h wxzx
        {
            get => new Vector4h(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h wxzy
        {
            get => new Vector4h(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wxzz
        {
            get => new Vector4h(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h wxzw
        {
            get => new Vector4h(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h wxwx
        {
            get => new Vector4h(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4h wxwy
        {
            get => new Vector4h(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h wxwz
        {
            get => new Vector4h(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h wxww
        {
            get => new Vector4h(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4h wyxx
        {
            get => new Vector4h(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h wyxy
        {
            get => new Vector4h(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h wyxz
        {
            get => new Vector4h(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wyxw
        {
            get => new Vector4h(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h wyyx
        {
            get => new Vector4h(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h wyyy
        {
            get => new Vector4h(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h wyyz
        {
            get => new Vector4h(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h wyyw
        {
            get => new Vector4h(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h wyzx
        {
            get => new Vector4h(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wyzy
        {
            get => new Vector4h(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h wyzz
        {
            get => new Vector4h(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h wyzw
        {
            get => new Vector4h(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h wywx
        {
            get => new Vector4h(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h wywy
        {
            get => new Vector4h(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h wywz
        {
            get => new Vector4h(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h wyww
        {
            get => new Vector4h(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h wzxx
        {
            get => new Vector4h(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h wzxy
        {
            get => new Vector4h(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wzxz
        {
            get => new Vector4h(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h wzxw
        {
            get => new Vector4h(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h wzyx
        {
            get => new Vector4h(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h wzyy
        {
            get => new Vector4h(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h wzyz
        {
            get => new Vector4h(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h wzyw
        {
            get => new Vector4h(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h wzzx
        {
            get => new Vector4h(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h wzzy
        {
            get => new Vector4h(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h wzzz
        {
            get => new Vector4h(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h wzzw
        {
            get => new Vector4h(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h wzwx
        {
            get => new Vector4h(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h wzwy
        {
            get => new Vector4h(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h wzwz
        {
            get => new Vector4h(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h wzww
        {
            get => new Vector4h(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h wwxx
        {
            get => new Vector4h(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4h wwxy
        {
            get => new Vector4h(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h wwxz
        {
            get => new Vector4h(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h wwxw
        {
            get => new Vector4h(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4h wwyx
        {
            get => new Vector4h(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h wwyy
        {
            get => new Vector4h(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h wwyz
        {
            get => new Vector4h(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h wwyw
        {
            get => new Vector4h(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h wwzx
        {
            get => new Vector4h(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h wwzy
        {
            get => new Vector4h(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h wwzz
        {
            get => new Vector4h(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h wwzw
        {
            get => new Vector4h(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h wwwx
        {
            get => new Vector4h(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4h wwwy
        {
            get => new Vector4h(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h wwwz
        {
            get => new Vector4h(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h wwww
        {
            get => new Vector4h(W, W, W, W);
        }
        #endregion

        #region Coords: r, g, b, a
        [XmlIgnore]
        public Half r
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public Half g
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Half b
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Half a
        {
            get => W;
            set
            {
                W = value;
            }
        }

        [XmlIgnore]
        public Vector2h rr
        {
            get => new Vector2h(X, X);
        }

        [XmlIgnore]
        public Vector2h rg
        {
            get => new Vector2h(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h rb
        {
            get => new Vector2h(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ra
        {
            get => new Vector2h(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h gr
        {
            get => new Vector2h(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h gg
        {
            get => new Vector2h(Y, Y);
        }

        [XmlIgnore]
        public Vector2h gb
        {
            get => new Vector2h(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ga
        {
            get => new Vector2h(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h br
        {
            get => new Vector2h(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h bg
        {
            get => new Vector2h(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h bb
        {
            get => new Vector2h(Z, Z);
        }

        [XmlIgnore]
        public Vector2h ba
        {
            get => new Vector2h(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ar
        {
            get => new Vector2h(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ag
        {
            get => new Vector2h(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ab
        {
            get => new Vector2h(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h aa
        {
            get => new Vector2h(W, W);
        }

        [XmlIgnore]
        public Vector3h rrr
        {
            get => new Vector3h(X, X, X);
        }

        [XmlIgnore]
        public Vector3h rrg
        {
            get => new Vector3h(X, X, Y);
        }

        [XmlIgnore]
        public Vector3h rrb
        {
            get => new Vector3h(X, X, Z);
        }

        [XmlIgnore]
        public Vector3h rra
        {
            get => new Vector3h(X, X, W);
        }

        [XmlIgnore]
        public Vector3h rgr
        {
            get => new Vector3h(X, Y, X);
        }

        [XmlIgnore]
        public Vector3h rgg
        {
            get => new Vector3h(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3h rgb
        {
            get => new Vector3h(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h rga
        {
            get => new Vector3h(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h rbr
        {
            get => new Vector3h(X, Z, X);
        }

        [XmlIgnore]
        public Vector3h rbg
        {
            get => new Vector3h(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h rbb
        {
            get => new Vector3h(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3h rba
        {
            get => new Vector3h(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h rar
        {
            get => new Vector3h(X, W, X);
        }

        [XmlIgnore]
        public Vector3h rag
        {
            get => new Vector3h(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h rab
        {
            get => new Vector3h(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h raa
        {
            get => new Vector3h(X, W, W);
        }

        [XmlIgnore]
        public Vector3h grr
        {
            get => new Vector3h(Y, X, X);
        }

        [XmlIgnore]
        public Vector3h grg
        {
            get => new Vector3h(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3h grb
        {
            get => new Vector3h(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h gra
        {
            get => new Vector3h(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h ggr
        {
            get => new Vector3h(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3h ggg
        {
            get => new Vector3h(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3h ggb
        {
            get => new Vector3h(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3h gga
        {
            get => new Vector3h(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3h gbr
        {
            get => new Vector3h(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h gbg
        {
            get => new Vector3h(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3h gbb
        {
            get => new Vector3h(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3h gba
        {
            get => new Vector3h(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h gar
        {
            get => new Vector3h(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h gag
        {
            get => new Vector3h(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3h gab
        {
            get => new Vector3h(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h gaa
        {
            get => new Vector3h(Y, W, W);
        }

        [XmlIgnore]
        public Vector3h brr
        {
            get => new Vector3h(Z, X, X);
        }

        [XmlIgnore]
        public Vector3h brg
        {
            get => new Vector3h(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h brb
        {
            get => new Vector3h(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3h bra
        {
            get => new Vector3h(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h bgr
        {
            get => new Vector3h(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h bgg
        {
            get => new Vector3h(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3h bgb
        {
            get => new Vector3h(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3h bga
        {
            get => new Vector3h(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h bbr
        {
            get => new Vector3h(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3h bbg
        {
            get => new Vector3h(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3h bbb
        {
            get => new Vector3h(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3h bba
        {
            get => new Vector3h(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3h bar
        {
            get => new Vector3h(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h bag
        {
            get => new Vector3h(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h bab
        {
            get => new Vector3h(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3h baa
        {
            get => new Vector3h(Z, W, W);
        }

        [XmlIgnore]
        public Vector3h arr
        {
            get => new Vector3h(W, X, X);
        }

        [XmlIgnore]
        public Vector3h arg
        {
            get => new Vector3h(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h arb
        {
            get => new Vector3h(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h ara
        {
            get => new Vector3h(W, X, W);
        }

        [XmlIgnore]
        public Vector3h agr
        {
            get => new Vector3h(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h agg
        {
            get => new Vector3h(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3h agb
        {
            get => new Vector3h(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h aga
        {
            get => new Vector3h(W, Y, W);
        }

        [XmlIgnore]
        public Vector3h abr
        {
            get => new Vector3h(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h abg
        {
            get => new Vector3h(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h abb
        {
            get => new Vector3h(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3h aba
        {
            get => new Vector3h(W, Z, W);
        }

        [XmlIgnore]
        public Vector3h aar
        {
            get => new Vector3h(W, W, X);
        }

        [XmlIgnore]
        public Vector3h aag
        {
            get => new Vector3h(W, W, Y);
        }

        [XmlIgnore]
        public Vector3h aab
        {
            get => new Vector3h(W, W, Z);
        }

        [XmlIgnore]
        public Vector3h aaa
        {
            get => new Vector3h(W, W, W);
        }

        [XmlIgnore]
        public Vector4h rrrr
        {
            get => new Vector4h(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4h rrrg
        {
            get => new Vector4h(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h rrrb
        {
            get => new Vector4h(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h rrra
        {
            get => new Vector4h(X, X, X, W);
        }

        [XmlIgnore]
        public Vector4h rrgr
        {
            get => new Vector4h(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h rrgg
        {
            get => new Vector4h(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h rrgb
        {
            get => new Vector4h(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h rrga
        {
            get => new Vector4h(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h rrbr
        {
            get => new Vector4h(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h rrbg
        {
            get => new Vector4h(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h rrbb
        {
            get => new Vector4h(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h rrba
        {
            get => new Vector4h(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h rrar
        {
            get => new Vector4h(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4h rrag
        {
            get => new Vector4h(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h rrab
        {
            get => new Vector4h(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h rraa
        {
            get => new Vector4h(X, X, W, W);
        }

        [XmlIgnore]
        public Vector4h rgrr
        {
            get => new Vector4h(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h rgrg
        {
            get => new Vector4h(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h rgrb
        {
            get => new Vector4h(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h rgra
        {
            get => new Vector4h(X, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h rggr
        {
            get => new Vector4h(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h rggg
        {
            get => new Vector4h(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h rggb
        {
            get => new Vector4h(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h rgga
        {
            get => new Vector4h(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h rgbr
        {
            get => new Vector4h(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h rgbg
        {
            get => new Vector4h(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h rgbb
        {
            get => new Vector4h(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h rgba
        {
            get => new Vector4h(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h rgar
        {
            get => new Vector4h(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h rgag
        {
            get => new Vector4h(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h rgab
        {
            get => new Vector4h(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h rgaa
        {
            get => new Vector4h(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h rbrr
        {
            get => new Vector4h(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h rbrg
        {
            get => new Vector4h(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h rbrb
        {
            get => new Vector4h(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h rbra
        {
            get => new Vector4h(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h rbgr
        {
            get => new Vector4h(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h rbgg
        {
            get => new Vector4h(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h rbgb
        {
            get => new Vector4h(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h rbga
        {
            get => new Vector4h(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h rbbr
        {
            get => new Vector4h(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h rbbg
        {
            get => new Vector4h(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h rbbb
        {
            get => new Vector4h(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h rbba
        {
            get => new Vector4h(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h rbar
        {
            get => new Vector4h(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h rbag
        {
            get => new Vector4h(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h rbab
        {
            get => new Vector4h(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h rbaa
        {
            get => new Vector4h(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h rarr
        {
            get => new Vector4h(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4h rarg
        {
            get => new Vector4h(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h rarb
        {
            get => new Vector4h(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h rara
        {
            get => new Vector4h(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4h ragr
        {
            get => new Vector4h(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h ragg
        {
            get => new Vector4h(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h ragb
        {
            get => new Vector4h(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h raga
        {
            get => new Vector4h(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h rabr
        {
            get => new Vector4h(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h rabg
        {
            get => new Vector4h(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h rabb
        {
            get => new Vector4h(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h raba
        {
            get => new Vector4h(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h raar
        {
            get => new Vector4h(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4h raag
        {
            get => new Vector4h(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h raab
        {
            get => new Vector4h(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h raaa
        {
            get => new Vector4h(X, W, W, W);
        }

        [XmlIgnore]
        public Vector4h grrr
        {
            get => new Vector4h(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4h grrg
        {
            get => new Vector4h(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h grrb
        {
            get => new Vector4h(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h grra
        {
            get => new Vector4h(Y, X, X, W);
        }

        [XmlIgnore]
        public Vector4h grgr
        {
            get => new Vector4h(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h grgg
        {
            get => new Vector4h(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h grgb
        {
            get => new Vector4h(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h grga
        {
            get => new Vector4h(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h grbr
        {
            get => new Vector4h(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h grbg
        {
            get => new Vector4h(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h grbb
        {
            get => new Vector4h(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h grba
        {
            get => new Vector4h(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h grar
        {
            get => new Vector4h(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4h grag
        {
            get => new Vector4h(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h grab
        {
            get => new Vector4h(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h graa
        {
            get => new Vector4h(Y, X, W, W);
        }

        [XmlIgnore]
        public Vector4h ggrr
        {
            get => new Vector4h(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h ggrg
        {
            get => new Vector4h(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h ggrb
        {
            get => new Vector4h(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h ggra
        {
            get => new Vector4h(Y, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h gggr
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h gggg
        {
            get => new Vector4h(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h gggb
        {
            get => new Vector4h(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h ggga
        {
            get => new Vector4h(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h ggbr
        {
            get => new Vector4h(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h ggbg
        {
            get => new Vector4h(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h ggbb
        {
            get => new Vector4h(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h ggba
        {
            get => new Vector4h(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h ggar
        {
            get => new Vector4h(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h ggag
        {
            get => new Vector4h(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h ggab
        {
            get => new Vector4h(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h ggaa
        {
            get => new Vector4h(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h gbrr
        {
            get => new Vector4h(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h gbrg
        {
            get => new Vector4h(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h gbrb
        {
            get => new Vector4h(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h gbra
        {
            get => new Vector4h(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h gbgr
        {
            get => new Vector4h(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h gbgg
        {
            get => new Vector4h(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h gbgb
        {
            get => new Vector4h(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h gbga
        {
            get => new Vector4h(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h gbbr
        {
            get => new Vector4h(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h gbbg
        {
            get => new Vector4h(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h gbbb
        {
            get => new Vector4h(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h gbba
        {
            get => new Vector4h(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h gbar
        {
            get => new Vector4h(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h gbag
        {
            get => new Vector4h(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h gbab
        {
            get => new Vector4h(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h gbaa
        {
            get => new Vector4h(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h garr
        {
            get => new Vector4h(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4h garg
        {
            get => new Vector4h(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h garb
        {
            get => new Vector4h(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h gara
        {
            get => new Vector4h(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4h gagr
        {
            get => new Vector4h(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h gagg
        {
            get => new Vector4h(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h gagb
        {
            get => new Vector4h(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h gaga
        {
            get => new Vector4h(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h gabr
        {
            get => new Vector4h(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h gabg
        {
            get => new Vector4h(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h gabb
        {
            get => new Vector4h(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h gaba
        {
            get => new Vector4h(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h gaar
        {
            get => new Vector4h(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4h gaag
        {
            get => new Vector4h(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h gaab
        {
            get => new Vector4h(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h gaaa
        {
            get => new Vector4h(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4h brrr
        {
            get => new Vector4h(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4h brrg
        {
            get => new Vector4h(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h brrb
        {
            get => new Vector4h(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h brra
        {
            get => new Vector4h(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4h brgr
        {
            get => new Vector4h(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h brgg
        {
            get => new Vector4h(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h brgb
        {
            get => new Vector4h(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h brga
        {
            get => new Vector4h(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h brbr
        {
            get => new Vector4h(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h brbg
        {
            get => new Vector4h(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h brbb
        {
            get => new Vector4h(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h brba
        {
            get => new Vector4h(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h brar
        {
            get => new Vector4h(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4h brag
        {
            get => new Vector4h(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h brab
        {
            get => new Vector4h(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h braa
        {
            get => new Vector4h(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4h bgrr
        {
            get => new Vector4h(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h bgrg
        {
            get => new Vector4h(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h bgrb
        {
            get => new Vector4h(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h bgra
        {
            get => new Vector4h(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h bggr
        {
            get => new Vector4h(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h bggg
        {
            get => new Vector4h(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h bggb
        {
            get => new Vector4h(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h bgga
        {
            get => new Vector4h(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h bgbr
        {
            get => new Vector4h(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h bgbg
        {
            get => new Vector4h(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h bgbb
        {
            get => new Vector4h(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h bgba
        {
            get => new Vector4h(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h bgar
        {
            get => new Vector4h(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h bgag
        {
            get => new Vector4h(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h bgab
        {
            get => new Vector4h(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h bgaa
        {
            get => new Vector4h(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h bbrr
        {
            get => new Vector4h(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h bbrg
        {
            get => new Vector4h(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h bbrb
        {
            get => new Vector4h(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h bbra
        {
            get => new Vector4h(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h bbgr
        {
            get => new Vector4h(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h bbgg
        {
            get => new Vector4h(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h bbgb
        {
            get => new Vector4h(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h bbga
        {
            get => new Vector4h(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h bbbr
        {
            get => new Vector4h(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h bbbg
        {
            get => new Vector4h(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h bbbb
        {
            get => new Vector4h(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h bbba
        {
            get => new Vector4h(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h bbar
        {
            get => new Vector4h(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h bbag
        {
            get => new Vector4h(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h bbab
        {
            get => new Vector4h(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h bbaa
        {
            get => new Vector4h(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h barr
        {
            get => new Vector4h(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4h barg
        {
            get => new Vector4h(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h barb
        {
            get => new Vector4h(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h bara
        {
            get => new Vector4h(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4h bagr
        {
            get => new Vector4h(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h bagg
        {
            get => new Vector4h(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h bagb
        {
            get => new Vector4h(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h baga
        {
            get => new Vector4h(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h babr
        {
            get => new Vector4h(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h babg
        {
            get => new Vector4h(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h babb
        {
            get => new Vector4h(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h baba
        {
            get => new Vector4h(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h baar
        {
            get => new Vector4h(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4h baag
        {
            get => new Vector4h(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h baab
        {
            get => new Vector4h(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h baaa
        {
            get => new Vector4h(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4h arrr
        {
            get => new Vector4h(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4h arrg
        {
            get => new Vector4h(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h arrb
        {
            get => new Vector4h(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h arra
        {
            get => new Vector4h(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4h argr
        {
            get => new Vector4h(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h argg
        {
            get => new Vector4h(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h argb
        {
            get => new Vector4h(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h arga
        {
            get => new Vector4h(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h arbr
        {
            get => new Vector4h(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h arbg
        {
            get => new Vector4h(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h arbb
        {
            get => new Vector4h(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h arba
        {
            get => new Vector4h(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h arar
        {
            get => new Vector4h(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4h arag
        {
            get => new Vector4h(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h arab
        {
            get => new Vector4h(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h araa
        {
            get => new Vector4h(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4h agrr
        {
            get => new Vector4h(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h agrg
        {
            get => new Vector4h(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h agrb
        {
            get => new Vector4h(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h agra
        {
            get => new Vector4h(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h aggr
        {
            get => new Vector4h(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h aggg
        {
            get => new Vector4h(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h aggb
        {
            get => new Vector4h(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h agga
        {
            get => new Vector4h(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h agbr
        {
            get => new Vector4h(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h agbg
        {
            get => new Vector4h(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h agbb
        {
            get => new Vector4h(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h agba
        {
            get => new Vector4h(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h agar
        {
            get => new Vector4h(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h agag
        {
            get => new Vector4h(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h agab
        {
            get => new Vector4h(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h agaa
        {
            get => new Vector4h(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h abrr
        {
            get => new Vector4h(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h abrg
        {
            get => new Vector4h(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h abrb
        {
            get => new Vector4h(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h abra
        {
            get => new Vector4h(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h abgr
        {
            get => new Vector4h(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h abgg
        {
            get => new Vector4h(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h abgb
        {
            get => new Vector4h(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h abga
        {
            get => new Vector4h(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h abbr
        {
            get => new Vector4h(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h abbg
        {
            get => new Vector4h(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h abbb
        {
            get => new Vector4h(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h abba
        {
            get => new Vector4h(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h abar
        {
            get => new Vector4h(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h abag
        {
            get => new Vector4h(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h abab
        {
            get => new Vector4h(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h abaa
        {
            get => new Vector4h(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h aarr
        {
            get => new Vector4h(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4h aarg
        {
            get => new Vector4h(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h aarb
        {
            get => new Vector4h(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h aara
        {
            get => new Vector4h(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4h aagr
        {
            get => new Vector4h(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h aagg
        {
            get => new Vector4h(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h aagb
        {
            get => new Vector4h(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h aaga
        {
            get => new Vector4h(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h aabr
        {
            get => new Vector4h(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h aabg
        {
            get => new Vector4h(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h aabb
        {
            get => new Vector4h(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h aaba
        {
            get => new Vector4h(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h aaar
        {
            get => new Vector4h(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4h aaag
        {
            get => new Vector4h(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h aaab
        {
            get => new Vector4h(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h aaaa
        {
            get => new Vector4h(W, W, W, W);
        }
        #endregion

        #region Coords: s, t, p, q
        [XmlIgnore]
        public Half s
        {
            get => X;
            set
            {
                X = value;
            }
        }

        [XmlIgnore]
        public Half t
        {
            get => Y;
            set
            {
                Y = value;
            }
        }

        [XmlIgnore]
        public Half p
        {
            get => Z;
            set
            {
                Z = value;
            }
        }

        [XmlIgnore]
        public Half q
        {
            get => W;
            set
            {
                W = value;
            }
        }

        [XmlIgnore]
        public Vector2h ss
        {
            get => new Vector2h(X, X);
        }

        [XmlIgnore]
        public Vector2h st
        {
            get => new Vector2h(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h sp
        {
            get => new Vector2h(X, Z);
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h sq
        {
            get => new Vector2h(X, W);
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ts
        {
            get => new Vector2h(Y, X);
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h tt
        {
            get => new Vector2h(Y, Y);
        }

        [XmlIgnore]
        public Vector2h tp
        {
            get => new Vector2h(Y, Z);
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h tq
        {
            get => new Vector2h(Y, W);
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h ps
        {
            get => new Vector2h(Z, X);
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h pt
        {
            get => new Vector2h(Z, Y);
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h pp
        {
            get => new Vector2h(Z, Z);
        }

        [XmlIgnore]
        public Vector2h pq
        {
            get => new Vector2h(Z, W);
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h qs
        {
            get => new Vector2h(W, X);
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h qt
        {
            get => new Vector2h(W, Y);
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h qp
        {
            get => new Vector2h(W, Z);
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        [XmlIgnore]
        public Vector2h qq
        {
            get => new Vector2h(W, W);
        }

        [XmlIgnore]
        public Vector3h sss
        {
            get => new Vector3h(X, X, X);
        }

        [XmlIgnore]
        public Vector3h sst
        {
            get => new Vector3h(X, X, Y);
        }

        [XmlIgnore]
        public Vector3h ssp
        {
            get => new Vector3h(X, X, Z);
        }

        [XmlIgnore]
        public Vector3h ssq
        {
            get => new Vector3h(X, X, W);
        }

        [XmlIgnore]
        public Vector3h sts
        {
            get => new Vector3h(X, Y, X);
        }

        [XmlIgnore]
        public Vector3h stt
        {
            get => new Vector3h(X, Y, Y);
        }

        [XmlIgnore]
        public Vector3h stp
        {
            get => new Vector3h(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h stq
        {
            get => new Vector3h(X, Y, W);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h sps
        {
            get => new Vector3h(X, Z, X);
        }

        [XmlIgnore]
        public Vector3h spt
        {
            get => new Vector3h(X, Z, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h spp
        {
            get => new Vector3h(X, Z, Z);
        }

        [XmlIgnore]
        public Vector3h spq
        {
            get => new Vector3h(X, Z, W);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h sqs
        {
            get => new Vector3h(X, W, X);
        }

        [XmlIgnore]
        public Vector3h sqt
        {
            get => new Vector3h(X, W, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h sqp
        {
            get => new Vector3h(X, W, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h sqq
        {
            get => new Vector3h(X, W, W);
        }

        [XmlIgnore]
        public Vector3h tss
        {
            get => new Vector3h(Y, X, X);
        }

        [XmlIgnore]
        public Vector3h tst
        {
            get => new Vector3h(Y, X, Y);
        }

        [XmlIgnore]
        public Vector3h tsp
        {
            get => new Vector3h(Y, X, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tsq
        {
            get => new Vector3h(Y, X, W);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tts
        {
            get => new Vector3h(Y, Y, X);
        }

        [XmlIgnore]
        public Vector3h ttt
        {
            get => new Vector3h(Y, Y, Y);
        }

        [XmlIgnore]
        public Vector3h ttp
        {
            get => new Vector3h(Y, Y, Z);
        }

        [XmlIgnore]
        public Vector3h ttq
        {
            get => new Vector3h(Y, Y, W);
        }

        [XmlIgnore]
        public Vector3h tps
        {
            get => new Vector3h(Y, Z, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tpt
        {
            get => new Vector3h(Y, Z, Y);
        }

        [XmlIgnore]
        public Vector3h tpp
        {
            get => new Vector3h(Y, Z, Z);
        }

        [XmlIgnore]
        public Vector3h tpq
        {
            get => new Vector3h(Y, Z, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tqs
        {
            get => new Vector3h(Y, W, X);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tqt
        {
            get => new Vector3h(Y, W, Y);
        }

        [XmlIgnore]
        public Vector3h tqp
        {
            get => new Vector3h(Y, W, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h tqq
        {
            get => new Vector3h(Y, W, W);
        }

        [XmlIgnore]
        public Vector3h pss
        {
            get => new Vector3h(Z, X, X);
        }

        [XmlIgnore]
        public Vector3h pst
        {
            get => new Vector3h(Z, X, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h psp
        {
            get => new Vector3h(Z, X, Z);
        }

        [XmlIgnore]
        public Vector3h psq
        {
            get => new Vector3h(Z, X, W);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h pts
        {
            get => new Vector3h(Z, Y, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h ptt
        {
            get => new Vector3h(Z, Y, Y);
        }

        [XmlIgnore]
        public Vector3h ptp
        {
            get => new Vector3h(Z, Y, Z);
        }

        [XmlIgnore]
        public Vector3h ptq
        {
            get => new Vector3h(Z, Y, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h pps
        {
            get => new Vector3h(Z, Z, X);
        }

        [XmlIgnore]
        public Vector3h ppt
        {
            get => new Vector3h(Z, Z, Y);
        }

        [XmlIgnore]
        public Vector3h ppp
        {
            get => new Vector3h(Z, Z, Z);
        }

        [XmlIgnore]
        public Vector3h ppq
        {
            get => new Vector3h(Z, Z, W);
        }

        [XmlIgnore]
        public Vector3h pqs
        {
            get => new Vector3h(Z, W, X);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h pqt
        {
            get => new Vector3h(Z, W, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h pqp
        {
            get => new Vector3h(Z, W, Z);
        }

        [XmlIgnore]
        public Vector3h pqq
        {
            get => new Vector3h(Z, W, W);
        }

        [XmlIgnore]
        public Vector3h qss
        {
            get => new Vector3h(W, X, X);
        }

        [XmlIgnore]
        public Vector3h qst
        {
            get => new Vector3h(W, X, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qsp
        {
            get => new Vector3h(W, X, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qsq
        {
            get => new Vector3h(W, X, W);
        }

        [XmlIgnore]
        public Vector3h qts
        {
            get => new Vector3h(W, Y, X);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qtt
        {
            get => new Vector3h(W, Y, Y);
        }

        [XmlIgnore]
        public Vector3h qtp
        {
            get => new Vector3h(W, Y, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qtq
        {
            get => new Vector3h(W, Y, W);
        }

        [XmlIgnore]
        public Vector3h qps
        {
            get => new Vector3h(W, Z, X);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qpt
        {
            get => new Vector3h(W, Z, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        [XmlIgnore]
        public Vector3h qpp
        {
            get => new Vector3h(W, Z, Z);
        }

        [XmlIgnore]
        public Vector3h qpq
        {
            get => new Vector3h(W, Z, W);
        }

        [XmlIgnore]
        public Vector3h qqs
        {
            get => new Vector3h(W, W, X);
        }

        [XmlIgnore]
        public Vector3h qqt
        {
            get => new Vector3h(W, W, Y);
        }

        [XmlIgnore]
        public Vector3h qqp
        {
            get => new Vector3h(W, W, Z);
        }

        [XmlIgnore]
        public Vector3h qqq
        {
            get => new Vector3h(W, W, W);
        }

        [XmlIgnore]
        public Vector4h ssss
        {
            get => new Vector4h(X, X, X, X);
        }

        [XmlIgnore]
        public Vector4h ssst
        {
            get => new Vector4h(X, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h sssp
        {
            get => new Vector4h(X, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h sssq
        {
            get => new Vector4h(X, X, X, W);
        }

        [XmlIgnore]
        public Vector4h ssts
        {
            get => new Vector4h(X, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h sstt
        {
            get => new Vector4h(X, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h sstp
        {
            get => new Vector4h(X, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h sstq
        {
            get => new Vector4h(X, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h ssps
        {
            get => new Vector4h(X, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h sspt
        {
            get => new Vector4h(X, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h sspp
        {
            get => new Vector4h(X, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h sspq
        {
            get => new Vector4h(X, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h ssqs
        {
            get => new Vector4h(X, X, W, X);
        }

        [XmlIgnore]
        public Vector4h ssqt
        {
            get => new Vector4h(X, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h ssqp
        {
            get => new Vector4h(X, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h ssqq
        {
            get => new Vector4h(X, X, W, W);
        }

        [XmlIgnore]
        public Vector4h stss
        {
            get => new Vector4h(X, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h stst
        {
            get => new Vector4h(X, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h stsp
        {
            get => new Vector4h(X, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h stsq
        {
            get => new Vector4h(X, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h stts
        {
            get => new Vector4h(X, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h sttt
        {
            get => new Vector4h(X, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h sttp
        {
            get => new Vector4h(X, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h sttq
        {
            get => new Vector4h(X, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h stps
        {
            get => new Vector4h(X, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h stpt
        {
            get => new Vector4h(X, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h stpp
        {
            get => new Vector4h(X, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h stpq
        {
            get => new Vector4h(X, Y, Z, W);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h stqs
        {
            get => new Vector4h(X, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h stqt
        {
            get => new Vector4h(X, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h stqp
        {
            get => new Vector4h(X, Y, W, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h stqq
        {
            get => new Vector4h(X, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h spss
        {
            get => new Vector4h(X, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h spst
        {
            get => new Vector4h(X, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h spsp
        {
            get => new Vector4h(X, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h spsq
        {
            get => new Vector4h(X, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h spts
        {
            get => new Vector4h(X, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h sptt
        {
            get => new Vector4h(X, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h sptp
        {
            get => new Vector4h(X, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h sptq
        {
            get => new Vector4h(X, Z, Y, W);
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h spps
        {
            get => new Vector4h(X, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h sppt
        {
            get => new Vector4h(X, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h sppp
        {
            get => new Vector4h(X, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h sppq
        {
            get => new Vector4h(X, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h spqs
        {
            get => new Vector4h(X, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h spqt
        {
            get => new Vector4h(X, Z, W, Y);
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h spqp
        {
            get => new Vector4h(X, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h spqq
        {
            get => new Vector4h(X, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h sqss
        {
            get => new Vector4h(X, W, X, X);
        }

        [XmlIgnore]
        public Vector4h sqst
        {
            get => new Vector4h(X, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h sqsp
        {
            get => new Vector4h(X, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h sqsq
        {
            get => new Vector4h(X, W, X, W);
        }

        [XmlIgnore]
        public Vector4h sqts
        {
            get => new Vector4h(X, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h sqtt
        {
            get => new Vector4h(X, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h sqtp
        {
            get => new Vector4h(X, W, Y, Z);
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h sqtq
        {
            get => new Vector4h(X, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h sqps
        {
            get => new Vector4h(X, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h sqpt
        {
            get => new Vector4h(X, W, Z, Y);
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h sqpp
        {
            get => new Vector4h(X, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h sqpq
        {
            get => new Vector4h(X, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h sqqs
        {
            get => new Vector4h(X, W, W, X);
        }

        [XmlIgnore]
        public Vector4h sqqt
        {
            get => new Vector4h(X, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h sqqp
        {
            get => new Vector4h(X, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h sqqq
        {
            get => new Vector4h(X, W, W, W);
        }

        [XmlIgnore]
        public Vector4h tsss
        {
            get => new Vector4h(Y, X, X, X);
        }

        [XmlIgnore]
        public Vector4h tsst
        {
            get => new Vector4h(Y, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h tssp
        {
            get => new Vector4h(Y, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h tssq
        {
            get => new Vector4h(Y, X, X, W);
        }

        [XmlIgnore]
        public Vector4h tsts
        {
            get => new Vector4h(Y, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h tstt
        {
            get => new Vector4h(Y, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h tstp
        {
            get => new Vector4h(Y, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h tstq
        {
            get => new Vector4h(Y, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h tsps
        {
            get => new Vector4h(Y, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h tspt
        {
            get => new Vector4h(Y, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h tspp
        {
            get => new Vector4h(Y, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h tspq
        {
            get => new Vector4h(Y, X, Z, W);
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tsqs
        {
            get => new Vector4h(Y, X, W, X);
        }

        [XmlIgnore]
        public Vector4h tsqt
        {
            get => new Vector4h(Y, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h tsqp
        {
            get => new Vector4h(Y, X, W, Z);
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tsqq
        {
            get => new Vector4h(Y, X, W, W);
        }

        [XmlIgnore]
        public Vector4h ttss
        {
            get => new Vector4h(Y, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h ttst
        {
            get => new Vector4h(Y, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h ttsp
        {
            get => new Vector4h(Y, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h ttsq
        {
            get => new Vector4h(Y, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h ttts
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h tttt
        {
            get => new Vector4h(Y, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h tttp
        {
            get => new Vector4h(Y, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h tttq
        {
            get => new Vector4h(Y, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h ttps
        {
            get => new Vector4h(Y, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h ttpt
        {
            get => new Vector4h(Y, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h ttpp
        {
            get => new Vector4h(Y, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h ttpq
        {
            get => new Vector4h(Y, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h ttqs
        {
            get => new Vector4h(Y, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h ttqt
        {
            get => new Vector4h(Y, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h ttqp
        {
            get => new Vector4h(Y, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h ttqq
        {
            get => new Vector4h(Y, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h tpss
        {
            get => new Vector4h(Y, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h tpst
        {
            get => new Vector4h(Y, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h tpsp
        {
            get => new Vector4h(Y, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h tpsq
        {
            get => new Vector4h(Y, Z, X, W);
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tpts
        {
            get => new Vector4h(Y, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h tptt
        {
            get => new Vector4h(Y, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h tptp
        {
            get => new Vector4h(Y, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h tptq
        {
            get => new Vector4h(Y, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h tpps
        {
            get => new Vector4h(Y, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h tppt
        {
            get => new Vector4h(Y, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h tppp
        {
            get => new Vector4h(Y, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h tppq
        {
            get => new Vector4h(Y, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h tpqs
        {
            get => new Vector4h(Y, Z, W, X);
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tpqt
        {
            get => new Vector4h(Y, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h tpqp
        {
            get => new Vector4h(Y, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h tpqq
        {
            get => new Vector4h(Y, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h tqss
        {
            get => new Vector4h(Y, W, X, X);
        }

        [XmlIgnore]
        public Vector4h tqst
        {
            get => new Vector4h(Y, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h tqsp
        {
            get => new Vector4h(Y, W, X, Z);
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tqsq
        {
            get => new Vector4h(Y, W, X, W);
        }

        [XmlIgnore]
        public Vector4h tqts
        {
            get => new Vector4h(Y, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h tqtt
        {
            get => new Vector4h(Y, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h tqtp
        {
            get => new Vector4h(Y, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h tqtq
        {
            get => new Vector4h(Y, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h tqps
        {
            get => new Vector4h(Y, W, Z, X);
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h tqpt
        {
            get => new Vector4h(Y, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h tqpp
        {
            get => new Vector4h(Y, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h tqpq
        {
            get => new Vector4h(Y, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h tqqs
        {
            get => new Vector4h(Y, W, W, X);
        }

        [XmlIgnore]
        public Vector4h tqqt
        {
            get => new Vector4h(Y, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h tqqp
        {
            get => new Vector4h(Y, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h tqqq
        {
            get => new Vector4h(Y, W, W, W);
        }

        [XmlIgnore]
        public Vector4h psss
        {
            get => new Vector4h(Z, X, X, X);
        }

        [XmlIgnore]
        public Vector4h psst
        {
            get => new Vector4h(Z, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h pssp
        {
            get => new Vector4h(Z, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h pssq
        {
            get => new Vector4h(Z, X, X, W);
        }

        [XmlIgnore]
        public Vector4h psts
        {
            get => new Vector4h(Z, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h pstt
        {
            get => new Vector4h(Z, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h pstp
        {
            get => new Vector4h(Z, X, Y, Z);
        }

        [XmlIgnore]
        public Vector4h pstq
        {
            get => new Vector4h(Z, X, Y, W);
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h psps
        {
            get => new Vector4h(Z, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h pspt
        {
            get => new Vector4h(Z, X, Z, Y);
        }

        [XmlIgnore]
        public Vector4h pspp
        {
            get => new Vector4h(Z, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h pspq
        {
            get => new Vector4h(Z, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h psqs
        {
            get => new Vector4h(Z, X, W, X);
        }

        [XmlIgnore]
        public Vector4h psqt
        {
            get => new Vector4h(Z, X, W, Y);
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h psqp
        {
            get => new Vector4h(Z, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h psqq
        {
            get => new Vector4h(Z, X, W, W);
        }

        [XmlIgnore]
        public Vector4h ptss
        {
            get => new Vector4h(Z, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h ptst
        {
            get => new Vector4h(Z, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h ptsp
        {
            get => new Vector4h(Z, Y, X, Z);
        }

        [XmlIgnore]
        public Vector4h ptsq
        {
            get => new Vector4h(Z, Y, X, W);
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h ptts
        {
            get => new Vector4h(Z, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h pttt
        {
            get => new Vector4h(Z, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h pttp
        {
            get => new Vector4h(Z, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h pttq
        {
            get => new Vector4h(Z, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h ptps
        {
            get => new Vector4h(Z, Y, Z, X);
        }

        [XmlIgnore]
        public Vector4h ptpt
        {
            get => new Vector4h(Z, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h ptpp
        {
            get => new Vector4h(Z, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h ptpq
        {
            get => new Vector4h(Z, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h ptqs
        {
            get => new Vector4h(Z, Y, W, X);
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h ptqt
        {
            get => new Vector4h(Z, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h ptqp
        {
            get => new Vector4h(Z, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h ptqq
        {
            get => new Vector4h(Z, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h ppss
        {
            get => new Vector4h(Z, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h ppst
        {
            get => new Vector4h(Z, Z, X, Y);
        }

        [XmlIgnore]
        public Vector4h ppsp
        {
            get => new Vector4h(Z, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h ppsq
        {
            get => new Vector4h(Z, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h ppts
        {
            get => new Vector4h(Z, Z, Y, X);
        }

        [XmlIgnore]
        public Vector4h pptt
        {
            get => new Vector4h(Z, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h pptp
        {
            get => new Vector4h(Z, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h pptq
        {
            get => new Vector4h(Z, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h ppps
        {
            get => new Vector4h(Z, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h pppt
        {
            get => new Vector4h(Z, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h pppp
        {
            get => new Vector4h(Z, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h pppq
        {
            get => new Vector4h(Z, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h ppqs
        {
            get => new Vector4h(Z, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h ppqt
        {
            get => new Vector4h(Z, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h ppqp
        {
            get => new Vector4h(Z, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h ppqq
        {
            get => new Vector4h(Z, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h pqss
        {
            get => new Vector4h(Z, W, X, X);
        }

        [XmlIgnore]
        public Vector4h pqst
        {
            get => new Vector4h(Z, W, X, Y);
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h pqsp
        {
            get => new Vector4h(Z, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h pqsq
        {
            get => new Vector4h(Z, W, X, W);
        }

        [XmlIgnore]
        public Vector4h pqts
        {
            get => new Vector4h(Z, W, Y, X);
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h pqtt
        {
            get => new Vector4h(Z, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h pqtp
        {
            get => new Vector4h(Z, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h pqtq
        {
            get => new Vector4h(Z, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h pqps
        {
            get => new Vector4h(Z, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h pqpt
        {
            get => new Vector4h(Z, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h pqpp
        {
            get => new Vector4h(Z, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h pqpq
        {
            get => new Vector4h(Z, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h pqqs
        {
            get => new Vector4h(Z, W, W, X);
        }

        [XmlIgnore]
        public Vector4h pqqt
        {
            get => new Vector4h(Z, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h pqqp
        {
            get => new Vector4h(Z, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h pqqq
        {
            get => new Vector4h(Z, W, W, W);
        }

        [XmlIgnore]
        public Vector4h qsss
        {
            get => new Vector4h(W, X, X, X);
        }

        [XmlIgnore]
        public Vector4h qsst
        {
            get => new Vector4h(W, X, X, Y);
        }

        [XmlIgnore]
        public Vector4h qssp
        {
            get => new Vector4h(W, X, X, Z);
        }

        [XmlIgnore]
        public Vector4h qssq
        {
            get => new Vector4h(W, X, X, W);
        }

        [XmlIgnore]
        public Vector4h qsts
        {
            get => new Vector4h(W, X, Y, X);
        }

        [XmlIgnore]
        public Vector4h qstt
        {
            get => new Vector4h(W, X, Y, Y);
        }

        [XmlIgnore]
        public Vector4h qstp
        {
            get => new Vector4h(W, X, Y, Z);
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qstq
        {
            get => new Vector4h(W, X, Y, W);
        }

        [XmlIgnore]
        public Vector4h qsps
        {
            get => new Vector4h(W, X, Z, X);
        }

        [XmlIgnore]
        public Vector4h qspt
        {
            get => new Vector4h(W, X, Z, Y);
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qspp
        {
            get => new Vector4h(W, X, Z, Z);
        }

        [XmlIgnore]
        public Vector4h qspq
        {
            get => new Vector4h(W, X, Z, W);
        }

        [XmlIgnore]
        public Vector4h qsqs
        {
            get => new Vector4h(W, X, W, X);
        }

        [XmlIgnore]
        public Vector4h qsqt
        {
            get => new Vector4h(W, X, W, Y);
        }

        [XmlIgnore]
        public Vector4h qsqp
        {
            get => new Vector4h(W, X, W, Z);
        }

        [XmlIgnore]
        public Vector4h qsqq
        {
            get => new Vector4h(W, X, W, W);
        }

        [XmlIgnore]
        public Vector4h qtss
        {
            get => new Vector4h(W, Y, X, X);
        }

        [XmlIgnore]
        public Vector4h qtst
        {
            get => new Vector4h(W, Y, X, Y);
        }

        [XmlIgnore]
        public Vector4h qtsp
        {
            get => new Vector4h(W, Y, X, Z);
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qtsq
        {
            get => new Vector4h(W, Y, X, W);
        }

        [XmlIgnore]
        public Vector4h qtts
        {
            get => new Vector4h(W, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h qttt
        {
            get => new Vector4h(W, Y, Y, Y);
        }

        [XmlIgnore]
        public Vector4h qttp
        {
            get => new Vector4h(W, Y, Y, Z);
        }

        [XmlIgnore]
        public Vector4h qttq
        {
            get => new Vector4h(W, Y, Y, W);
        }

        [XmlIgnore]
        public Vector4h qtps
        {
            get => new Vector4h(W, Y, Z, X);
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qtpt
        {
            get => new Vector4h(W, Y, Z, Y);
        }

        [XmlIgnore]
        public Vector4h qtpp
        {
            get => new Vector4h(W, Y, Z, Z);
        }

        [XmlIgnore]
        public Vector4h qtpq
        {
            get => new Vector4h(W, Y, Z, W);
        }

        [XmlIgnore]
        public Vector4h qtqs
        {
            get => new Vector4h(W, Y, W, X);
        }

        [XmlIgnore]
        public Vector4h qtqt
        {
            get => new Vector4h(W, Y, W, Y);
        }

        [XmlIgnore]
        public Vector4h qtqp
        {
            get => new Vector4h(W, Y, W, Z);
        }

        [XmlIgnore]
        public Vector4h qtqq
        {
            get => new Vector4h(W, Y, W, W);
        }

        [XmlIgnore]
        public Vector4h qpss
        {
            get => new Vector4h(W, Z, X, X);
        }

        [XmlIgnore]
        public Vector4h qpst
        {
            get => new Vector4h(W, Z, X, Y);
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qpsp
        {
            get => new Vector4h(W, Z, X, Z);
        }

        [XmlIgnore]
        public Vector4h qpsq
        {
            get => new Vector4h(W, Z, X, W);
        }

        [XmlIgnore]
        public Vector4h qpts
        {
            get => new Vector4h(W, Z, Y, X);
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        [XmlIgnore]
        public Vector4h qptt
        {
            get => new Vector4h(W, Z, Y, Y);
        }

        [XmlIgnore]
        public Vector4h qptp
        {
            get => new Vector4h(W, Z, Y, Z);
        }

        [XmlIgnore]
        public Vector4h qptq
        {
            get => new Vector4h(W, Z, Y, W);
        }

        [XmlIgnore]
        public Vector4h qpps
        {
            get => new Vector4h(W, Z, Z, X);
        }

        [XmlIgnore]
        public Vector4h qppt
        {
            get => new Vector4h(W, Z, Z, Y);
        }

        [XmlIgnore]
        public Vector4h qppp
        {
            get => new Vector4h(W, Z, Z, Z);
        }

        [XmlIgnore]
        public Vector4h qppq
        {
            get => new Vector4h(W, Z, Z, W);
        }

        [XmlIgnore]
        public Vector4h qpqs
        {
            get => new Vector4h(W, Z, W, X);
        }

        [XmlIgnore]
        public Vector4h qpqt
        {
            get => new Vector4h(W, Z, W, Y);
        }

        [XmlIgnore]
        public Vector4h qpqp
        {
            get => new Vector4h(W, Z, W, Z);
        }

        [XmlIgnore]
        public Vector4h qpqq
        {
            get => new Vector4h(W, Z, W, W);
        }

        [XmlIgnore]
        public Vector4h qqss
        {
            get => new Vector4h(W, W, X, X);
        }

        [XmlIgnore]
        public Vector4h qqst
        {
            get => new Vector4h(W, W, X, Y);
        }

        [XmlIgnore]
        public Vector4h qqsp
        {
            get => new Vector4h(W, W, X, Z);
        }

        [XmlIgnore]
        public Vector4h qqsq
        {
            get => new Vector4h(W, W, X, W);
        }

        [XmlIgnore]
        public Vector4h qqts
        {
            get => new Vector4h(W, W, Y, X);
        }

        [XmlIgnore]
        public Vector4h qqtt
        {
            get => new Vector4h(W, W, Y, Y);
        }

        [XmlIgnore]
        public Vector4h qqtp
        {
            get => new Vector4h(W, W, Y, Z);
        }

        [XmlIgnore]
        public Vector4h qqtq
        {
            get => new Vector4h(W, W, Y, W);
        }

        [XmlIgnore]
        public Vector4h qqps
        {
            get => new Vector4h(W, W, Z, X);
        }

        [XmlIgnore]
        public Vector4h qqpt
        {
            get => new Vector4h(W, W, Z, Y);
        }

        [XmlIgnore]
        public Vector4h qqpp
        {
            get => new Vector4h(W, W, Z, Z);
        }

        [XmlIgnore]
        public Vector4h qqpq
        {
            get => new Vector4h(W, W, Z, W);
        }

        [XmlIgnore]
        public Vector4h qqqs
        {
            get => new Vector4h(W, W, W, X);
        }

        [XmlIgnore]
        public Vector4h qqqt
        {
            get => new Vector4h(W, W, W, Y);
        }

        [XmlIgnore]
        public Vector4h qqqp
        {
            get => new Vector4h(W, W, W, Z);
        }

        [XmlIgnore]
        public Vector4h qqqq
        {
            get => new Vector4h(W, W, W, W);
        }
        #endregion

        /// <summary>
        /// Returns this Half4 instance's contents as Vector4.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(X, Y, Z, W);
        }

        /// <summary>
        /// Returns this Half4 instance's contents as Vector4d.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector4d ToVector4d()
        {
            return new Vector4d(X, Y, Z, W);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector4 to OpenToolkit.Half4.
        /// </summary>
        /// <param name="v4f">The Vector4 to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector4h(Vector4 v4f)
        {
            return new Vector4h(v4f);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector4d to OpenToolkit.Half4.
        /// </summary>
        /// <param name="v4d">The Vector4d to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector4h(Vector4d v4d)
        {
            return new Vector4h(v4d);
        }

        /// <summary>
        /// Converts OpenToolkit.Half4 to OpenToolkit.Vector4.
        /// </summary>
        /// <param name="h4">The Half4 to convert.</param>
        /// <returns>The resulting Vector4.</returns>
        [Pure]
        public static explicit operator Vector4(Vector4h h4)
        {
            return new Vector4(
                h4.X.ToSingle(),
                h4.Y.ToSingle(),
                h4.Z.ToSingle(),
                h4.W.ToSingle());
        }

        /// <summary>
        /// Converts OpenToolkit.Half4 to OpenToolkit.Vector4d.
        /// </summary>
        /// <param name="h4">The Half4 to convert.</param>
        /// <returns>The resulting Vector4d.</returns>
        [Pure]
        public static explicit operator Vector4d(Vector4h h4)
        {
            return new Vector4d(
                h4.X.ToSingle(),
                h4.Y.ToSingle(),
                h4.Z.ToSingle(),
                h4.W.ToSingle());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector4h"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector4h((Half X, Half Y, Half Z, Half W) values)
        {
            return new Vector4h(values.X, values.Y, values.Z, values.W);
        }

        /// <summary>
        /// The size in bytes for an instance of the Half4 struct is 8.
        /// </summary>
        public static readonly int SizeInBytes = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4h"/> struct.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        public Vector4h(SerializationInfo info, StreamingContext context)
        {
            X = (Half)info.GetValue("X", typeof(Half));
            Y = (Half)info.GetValue("Y", typeof(Half));
            Z = (Half)info.GetValue("Z", typeof(Half));
            W = (Half)info.GetValue("W", typeof(Half));
        }

        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
            info.AddValue("W", W);
        }

        /// <summary>
        /// Updates the X,Y,Z and W components of this instance by reading from a Stream.
        /// </summary>
        /// <param name="bin">A BinaryReader instance associated with an open Stream.</param>
        public void FromBinaryStream(BinaryReader bin)
        {
            X.FromBinaryStream(bin);
            Y.FromBinaryStream(bin);
            Z.FromBinaryStream(bin);
            W.FromBinaryStream(bin);
        }

        /// <summary>
        /// Writes the X,Y,Z and W components of this instance into a Stream.
        /// </summary>
        /// <param name="bin">A BinaryWriter instance associated with an open Stream.</param>
        public void ToBinaryStream(BinaryWriter bin)
        {
            X.ToBinaryStream(bin);
            Y.ToBinaryStream(bin);
            Z.ToBinaryStream(bin);
            W.ToBinaryStream(bin);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified OpenToolkit.Half4 vector.
        /// </summary>
        /// <param name="other">OpenToolkit.Half4 to compare to this instance..</param>
        /// <returns>True, if other is equal to this instance; false otherwise.</returns>
        [Pure]
        public bool Equals(Vector4h other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format
            (
                "({0}{4} {1}{4} {2}{4} {3})",
                X.ToString(),
                Y.ToString(),
                Z.ToString(),
                W.ToString(),
                ListSeparator
            );
        }

        /// <summary>
        /// Returns the Half4 as an array of bytes.
        /// </summary>
        /// <param name="h">The Half4 to convert.</param>
        /// <returns>The input as byte array.</returns>
        [Pure]
        public static byte[] GetBytes(Vector4h h)
        {
            var result = new byte[SizeInBytes];

            var temp = Half.GetBytes(h.X);
            result[0] = temp[0];
            result[1] = temp[1];
            temp = Half.GetBytes(h.Y);
            result[2] = temp[0];
            result[3] = temp[1];
            temp = Half.GetBytes(h.Z);
            result[4] = temp[0];
            result[5] = temp[1];
            temp = Half.GetBytes(h.W);
            result[6] = temp[0];
            result[7] = temp[1];

            return result;
        }

        /// <summary>
        /// Converts an array of bytes into Half4.
        /// </summary>
        /// <param name="value">A Half4 in it's byte[] representation.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A new Half4 instance.</returns>
        [Pure]
        public static Vector4h FromBytes(byte[] value, int startIndex)
        {
            return new Vector4h(
                Half.FromBytes(value, startIndex),
                Half.FromBytes(value, startIndex + 2),
                Half.FromBytes(value, startIndex + 4),
                Half.FromBytes(value, startIndex + 6));
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="w">The W component of the vector.</param>
        [Pure]
        public void Deconstruct(out Half x, out Half y, out Half z, out Half w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
