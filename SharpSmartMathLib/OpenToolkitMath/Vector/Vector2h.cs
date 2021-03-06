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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenToolkit.Mathematics
{
    /// <summary>
    /// 2-component Vector of the Half type. Occupies 4 Byte total.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2h : ISerializable, IEquatable<Vector2h>
    {
        /// <summary>
        /// The X component of the Half2.
        /// </summary>
        public Half X;

        /// <summary>
        /// The Y component of the Half2.
        /// </summary>
        public Half Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2h(Half value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2h(float value)
        {
            X = new Half(value);
            Y = new Half(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        public Vector2h(Half x, Half y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        public Vector2h(float x, float y)
        {
            X = new Half(x);
            Y = new Half(y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector2h(float x, float y, bool throwOnError)
        {
            X = new Half(x, throwOnError);
            Y = new Half(y, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2"/> to convert.</param>
        public Vector2h(Vector2 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector2h(Vector2 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2"/> to convert.</param>
        public Vector2h(ref Vector2 v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector2h(ref Vector2 v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2d"/> to convert.</param>
        public Vector2h(Vector2d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector2h(Vector2d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2d"/> to convert.</param>
        public Vector2h(ref Vector2d v)
        {
            X = new Half(v.X);
            Y = new Half(v.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="v">The <see cref="Vector2d"/> to convert.</param>
        /// <param name="throwOnError">Enable checks that will throw if the conversion result is not meaningful.</param>
        public Vector2h(ref Vector2d v, bool throwOnError)
        {
            X = new Half(v.X, throwOnError);
            Y = new Half(v.Y, throwOnError);
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

        #region Coords: x, y
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
        public Vector4h yyyx
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h yyyy
        {
            get => new Vector4h(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: r, g
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
        public Vector4h gggr
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h gggg
        {
            get => new Vector4h(Y, Y, Y, Y);
        }
        #endregion

        #region Coords: s, t
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
        public Vector4h ttts
        {
            get => new Vector4h(Y, Y, Y, X);
        }

        [XmlIgnore]
        public Vector4h tttt
        {
            get => new Vector4h(Y, Y, Y, Y);
        }
        #endregion

        /// <summary>
        /// Returns this Half2 instance's contents as Vector2.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        /// <summary>
        /// Returns this Half2 instance's contents as Vector2d.
        /// </summary>
        /// <returns>The vector.</returns>
        public Vector2d ToVector2d()
        {
            return new Vector2d(X, Y);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector2 to OpenToolkit.Half2.
        /// </summary>
        /// <param name="v">The Vector2 to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector2h(Vector2 v)
        {
            return new Vector2h(v);
        }

        /// <summary>
        /// Converts OpenToolkit.Vector2d to OpenToolkit.Half2.
        /// </summary>
        /// <param name="v">The Vector2d to convert.</param>
        /// <returns>The resulting Half vector.</returns>
        [Pure]
        public static explicit operator Vector2h(Vector2d v)
        {
            return new Vector2h(v);
        }

        /// <summary>
        /// Converts OpenToolkit.Half2 to OpenToolkit.Vector2.
        /// </summary>
        /// <param name="h">The Half2 to convert.</param>
        /// <returns>The resulting Vector2.</returns>
        [Pure]
        public static explicit operator Vector2(Vector2h h)
        {
            return new Vector2(h.X, h.Y);
        }

        /// <summary>
        /// Converts OpenToolkit.Half2 to OpenToolkit.Vector2d.
        /// </summary>
        /// <param name="h">The Half2 to convert.</param>
        /// <returns>The resulting Vector2d.</returns>
        [Pure]
        public static explicit operator Vector2d(Vector2h h)
        {
            return new Vector2d(h.X, h.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct using a tuple containing the component
        /// values.
        /// </summary>
        /// <param name="values">A tuple containing the component values.</param>
        /// <returns>A new instance of the <see cref="Vector2h"/> struct with the given component values.</returns>
        [Pure]
        public static implicit operator Vector2h((Half X, Half Y) values)
        {
            return new Vector2h(values.X, values.Y);
        }

        /// <summary>
        /// The size in bytes for an instance of the Half2 struct is 4.
        /// </summary>
        public static readonly int SizeInBytes = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2h"/> struct.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        public Vector2h(SerializationInfo info, StreamingContext context)
        {
            X = (Half)info.GetValue("X", typeof(Half));
            Y = (Half)info.GetValue("Y", typeof(Half));
        }

        /// <inheritdoc/>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
        }

        /// <summary>
        /// Updates the X and Y components of this instance by reading from a Stream.
        /// </summary>
        /// <param name="bin">A BinaryReader instance associated with an open Stream.</param>
        public void FromBinaryStream(BinaryReader bin)
        {
            X.FromBinaryStream(bin);
            Y.FromBinaryStream(bin);
        }

        /// <summary>
        /// Writes the X and Y components of this instance into a Stream.
        /// </summary>
        /// <param name="bin">A BinaryWriter instance associated with an open Stream.</param>
        public void ToBinaryStream(BinaryWriter bin)
        {
            X.ToBinaryStream(bin);
            Y.ToBinaryStream(bin);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified OpenToolkit.Half2 vector.
        /// </summary>
        /// <param name="other">OpenToolkit.Half2 to compare to this instance..</param>
        /// <returns>True, if other is equal to this instance; false otherwise.</returns>
        [Pure]
        public bool Equals(Vector2h other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        private static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("({0}{2} {1})", X, Y, ListSeparator);
        }

        /// <summary>
        /// Returns the Half2 as an array of bytes.
        /// </summary>
        /// <param name="h">The Half2 to convert.</param>
        /// <returns>The input as byte array.</returns>
        [Pure]
        public static byte[] GetBytes(Vector2h h)
        {
            var result = new byte[SizeInBytes];

            var temp = Half.GetBytes(h.X);
            result[0] = temp[0];
            result[1] = temp[1];
            temp = Half.GetBytes(h.Y);
            result[2] = temp[0];
            result[3] = temp[1];

            return result;
        }

        /// <summary>
        /// Converts an array of bytes into Half2.
        /// </summary>
        /// <param name="value">A Half2 in it's byte[] representation.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A new Half2 instance.</returns>
        [Pure]
        public static Vector2h FromBytes(byte[] value, int startIndex)
        {
            return new Vector2h(
                Half.FromBytes(value, startIndex),
                Half.FromBytes(value, startIndex + 2));
        }

        /// <summary>
        /// Deconstructs the vector into it's individual components.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        [Pure]
        public void Deconstruct(out Half x, out Half y)
        {
            x = X;
            y = Y;
        }
    }
}
