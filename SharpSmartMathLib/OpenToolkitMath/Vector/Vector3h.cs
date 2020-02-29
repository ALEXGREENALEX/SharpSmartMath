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
    /// 3-component Vector of the Half type. Occupies 6 Byte total.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3h : ISerializable, IEquatable<Vector3h>
    {
        /// <summary>
        /// The X component of the Half3.
        /// </summary>
        public Half X;

        /// <summary>
        /// The Y component of the Half3.
        /// </summary>
        public Half Y;

        /// <summary>
        /// The Z component of the Half3.
        /// </summary>
        public Half Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3h(Half value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3h(float value)
        {
            X = new Half(value);
            Y = new Half(value);
            Z = new Half(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        public Vector3h(Half x, Half y, Half z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// The new Half3 instance will convert the 3 parameters into 16-bit half-precision floating-point.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        public Vector3h(float x, float y, float z)
        {
            X = new Half(x);
            Y = new Half(y);
            Z = new Half(z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// The new Half3 instance will convert the 3 parameters into 16-bit half-precision floating-point.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector3h(float x, float y, float z, bool throwOnError)
        {
            X = new Half(x, throwOnError);
            Y = new Half(y, throwOnError);
            Z = new Half(z, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3"/> to convert.</param>
        public Vector3h(Vector3 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector3h(Vector3 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3"/> to convert.</param>
        public Vector3h(ref Vector3 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector3h(ref Vector3 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3d"/> to convert.</param>
        public Vector3h(Vector3d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector3h(Vector3d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3d"/> to convert.</param>
        public Vector3h(ref Vector3d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
            Z = new Half(v.Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector3d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector3h(ref Vector3d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
            Z = new Half(v.Z, throwOnError);
        }

        /// <summary>
        /// Gets or sets an OpenToolkit.Vector2h with the X and Y components of this instance.
        /// </summary>
        [XmlIgnore]
        public Vector2h Xy
        {
            get => Unsafe.As<Vector3h, Vector2h>(ref this);
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

        #region Coords: x, y, z
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
        #endregion

        #region Coords: r, g, b
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
        #endregion

        #region Coords: s, t, p
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
        #endregion

        /// <summary>
        /// Returns this Half3 instance's contents as Vector3.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Returns this Half3 instance's contents as Vector3d.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector3d ToVector3d()
        {
            return new Vector3d(X, Y, Z);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector3 to OpenToolkit.Half3.
        /// </summary>
        /// <param name="v3f">The Vector3 to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector3h(Vector3 v3f)
        {
            return new Vector3h(v3f);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector3d to OpenToolkit.Half3.
        /// </summary>
        /// <param name="v3d">The Vector3d to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector3h(Vector3d v3d)
        {
            return new Vector3h(v3d);
        }

        /// <summary>
        /// Converts OpenToolkit.Half3 to OpenToolkit.Vector3.
        /// </summary>
        /// <param name="h3">The Half3 to convert.</param>
        /// <returns>The resulting Vector3.</returns>
        [Pure]
        public static explicit operator Vector3(Vector3h h3)
        {
            return new Vector3(
                h3.X.ToSingle(),
                h3.Y.ToSingle(),
                h3.Z.ToSingle());
        }

        /// <summary>
        /// Converts OpenToolkit.Half3 to OpenToolkit.Vector3d.
        /// </summary>
        /// <param name="h3">The Half3 to convert.</param>
        /// <returns>The resulting Vector3d.</returns>
        [Pure]
        public static explicit operator Vector3d(Vector3h h3)
        {
            return new Vector3d(
                h3.X.ToSingle(),
                h3.Y.ToSingle(),
                h3.Z.ToSingle());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector3h"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector3h((Half X, Half Y, Half Z) values)
        {
            return new Vector3h(values.X, values.Y, values.Z);
        }

        /// <summary>
        /// The size in bytes for an instance of the Half3 struct is 6.
        /// </summary>
        public static readonly int SizeInBytes = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3h"/> struct.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        [Pure]
        public Vector3h(SerializationInfo info, StreamingContext context)
        {
            X = (Half)info.GetValue("X", typeof(Half));
            Y = (Half)info.GetValue("Y", typeof(Half));
            Z = (Half)info.GetValue("Z", typeof(Half));
        }

        /// <inheritdoc/>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
        }

        /// <summary>
        /// Updates the X,Y and Z components of this instance by reading from a Stream.
        /// </summary>
        /// <param name="bin">A BinaryReader instance associated with an open Stream.</param>
        public void FromBinaryStream(BinaryReader bin)
        {
            X.FromBinaryStream(bin);
            Y.FromBinaryStream(bin);
            Z.FromBinaryStream(bin);
        }

        /// <summary>
        /// Writes the X,Y and Z components of this instance into a Stream.
        /// </summary>
        /// <param name="bin">A BinaryWriter instance associated with an open Stream.</param>
        public void ToBinaryStream(BinaryWriter bin)
        {
            X.ToBinaryStream(bin);
            Y.ToBinaryStream(bin);
            Z.ToBinaryStream(bin);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified OpenToolkit.Half3 vector.
        /// </summary>
        /// <param name="other">OpenToolkit.Half3 to compare to this instance..</param>
        /// <returns>True, if other is equal to this instance; false otherwise.</returns>
        [Pure]
        public bool Equals(Vector3h other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("({0}{3} {1}{3} {2})", X.ToString(), Y.ToString(), Z.ToString(), ListSeparator);
        }

        /// <summary>
        /// Returns the Half3 as an array of bytes.
        /// </summary>
        /// <param name="h">The Half3 to convert.</param>
        /// <returns>The input as byte array.</returns>
        [Pure]
        public static byte[] GetBytes(Vector3h h)
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

            return result;
        }

        /// <summary>
        /// Converts an array of bytes into Half3.
        /// </summary>
        /// <param name="value">A Half3 in it's byte[] representation.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A new Half3 instance.</returns>
        [Pure]
        public static Vector3h FromBytes(byte[] value, int startIndex)
        {
            return new Vector3h(
                Half.FromBytes(value, startIndex),
                Half.FromBytes(value, startIndex + 2),
                Half.FromBytes(value, startIndex + 4));
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        [Pure]
        public void Deconstruct(out Half x, out Half y, out Half z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
