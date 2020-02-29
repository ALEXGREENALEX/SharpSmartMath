using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

using ExtMethods;
using OpenToolkit.Mathematics;
using static ShaderMath;
using static OpenToolkit.Mathematics.MathHelper;

#region GLSL, HLSL like data types
#region Scalar Data Types
using half = OpenToolkit.Mathematics.Half;
using dword = System.UInt32;
#endregion

#region Vectors
using vec2 = OpenToolkit.Mathematics.Vector2;
using vec3 = OpenToolkit.Mathematics.Vector3;
using vec4 = OpenToolkit.Mathematics.Vector4;

using dvec2 = OpenToolkit.Mathematics.Vector2d;
using dvec3 = OpenToolkit.Mathematics.Vector3d;
using dvec4 = OpenToolkit.Mathematics.Vector4d;

using hvec2 = OpenToolkit.Mathematics.Vector2h;
using hvec3 = OpenToolkit.Mathematics.Vector3h;
using hvec4 = OpenToolkit.Mathematics.Vector4h;

using ivec2 = OpenToolkit.Mathematics.Vector2i;
using ivec3 = OpenToolkit.Mathematics.Vector3i;
using ivec4 = OpenToolkit.Mathematics.Vector4i;

using uvec2 = OpenToolkit.Mathematics.Vector2u;
using uvec3 = OpenToolkit.Mathematics.Vector3u;
using uvec4 = OpenToolkit.Mathematics.Vector4u;

using bvec2 = OpenToolkit.Mathematics.Vector2b;
using bvec3 = OpenToolkit.Mathematics.Vector3b;
using bvec4 = OpenToolkit.Mathematics.Vector4b;

using half2 = OpenToolkit.Mathematics.Vector2h;
using half3 = OpenToolkit.Mathematics.Vector3h;
using half4 = OpenToolkit.Mathematics.Vector4h;

using float2 = OpenToolkit.Mathematics.Vector2;
using float3 = OpenToolkit.Mathematics.Vector3;
using float4 = OpenToolkit.Mathematics.Vector4;

using double2 = OpenToolkit.Mathematics.Vector2d;
using double3 = OpenToolkit.Mathematics.Vector3d;
using double4 = OpenToolkit.Mathematics.Vector4d;

using int2 = OpenToolkit.Mathematics.Vector2i;
using int3 = OpenToolkit.Mathematics.Vector3i;
using int4 = OpenToolkit.Mathematics.Vector4i;

using uint2 = OpenToolkit.Mathematics.Vector2u;
using uint3 = OpenToolkit.Mathematics.Vector3u;
using uint4 = OpenToolkit.Mathematics.Vector4u;

using bool2 = OpenToolkit.Mathematics.Vector2b;
using bool3 = OpenToolkit.Mathematics.Vector3b;
using bool4 = OpenToolkit.Mathematics.Vector4b;
#endregion

#region Matrices
using mat2 = OpenToolkit.Mathematics.Matrix2;
using mat2x2 = OpenToolkit.Mathematics.Matrix2;
using mat2x3 = OpenToolkit.Mathematics.Matrix2x3;
using mat2x4 = OpenToolkit.Mathematics.Matrix2x4;

using mat3 = OpenToolkit.Mathematics.Matrix3;
using mat3x2 = OpenToolkit.Mathematics.Matrix3x2;
using mat3x3 = OpenToolkit.Mathematics.Matrix3;
using mat3x4 = OpenToolkit.Mathematics.Matrix3x4;

using mat4 = OpenToolkit.Mathematics.Matrix4;
using mat4x2 = OpenToolkit.Mathematics.Matrix4x2;
using mat4x3 = OpenToolkit.Mathematics.Matrix4x3;
using mat4x4 = OpenToolkit.Mathematics.Matrix4;

using dmat2 = OpenToolkit.Mathematics.Matrix2d;
using dmat2x2 = OpenToolkit.Mathematics.Matrix2d;
using dmat2x3 = OpenToolkit.Mathematics.Matrix2x3d;
using dmat2x4 = OpenToolkit.Mathematics.Matrix2x4d;

using dmat3 = OpenToolkit.Mathematics.Matrix3d;
using dmat3x2 = OpenToolkit.Mathematics.Matrix3x2d;
using dmat3x3 = OpenToolkit.Mathematics.Matrix3d;
using dmat3x4 = OpenToolkit.Mathematics.Matrix3x4d;

using dmat4 = OpenToolkit.Mathematics.Matrix4d;
using dmat4x2 = OpenToolkit.Mathematics.Matrix4x2d;
using dmat4x3 = OpenToolkit.Mathematics.Matrix4x3d;
using dmat4x4 = OpenToolkit.Mathematics.Matrix4d;
#endregion
#endregion

public static class Program
{
    public static object Execute()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        try
        {
#pragma warning disable 1633
#pragma CODE_WILL_BE_PASTED_HERE
            ;
#pragma warning restore 1633
        }
        catch (Exception ex)
        {
            String.Format("{0}:" + Environment.NewLine +
                "Message: {1}" + Environment.NewLine +
                "InnerException: {2}",
                ex.GetType().ToString(), ex.Message, ex.InnerException).LogError();
        }
        return "EMPTY_STRING_FOR_LAST_RETURN_SEGMENT_DONT_USE_IT_DIRECTLY";
    }
}