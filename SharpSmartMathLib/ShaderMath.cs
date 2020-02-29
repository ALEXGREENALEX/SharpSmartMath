using System;
using OpenToolkit.Mathematics;

#region GLSL Like Vectors (simplifying "VectorNT" to "TvecN")
using vec2 = OpenToolkit.Mathematics.Vector2;
using vec3 = OpenToolkit.Mathematics.Vector3;
using vec4 = OpenToolkit.Mathematics.Vector4;

using dvec2 = OpenToolkit.Mathematics.Vector2d;
using dvec3 = OpenToolkit.Mathematics.Vector3d;
using dvec4 = OpenToolkit.Mathematics.Vector4d;

using ivec2 = OpenToolkit.Mathematics.Vector2i;
using ivec3 = OpenToolkit.Mathematics.Vector3i;
using ivec4 = OpenToolkit.Mathematics.Vector4i;

using uvec2 = OpenToolkit.Mathematics.Vector2u;
using uvec3 = OpenToolkit.Mathematics.Vector3u;
using uvec4 = OpenToolkit.Mathematics.Vector4u;

using bvec2 = OpenToolkit.Mathematics.Vector2b;
using bvec3 = OpenToolkit.Mathematics.Vector3b;
using bvec4 = OpenToolkit.Mathematics.Vector4b;
#endregion

public static class ShaderMath
{
    #region vectors initialization
    #region vec2, vec3, vec4
    public static Vector2 vec2(float x) => new Vector2(x, x);
    public static Vector2 vec2(float x, float y) => new Vector2(x, y);
    public static Vector2 vec2(Vector2 xy) => xy;
    public static Vector2 vec2(Vector3 xyz) => xyz.Xy;
    public static Vector2 vec2(Vector4 xyzw) => xyzw.Xy;

    public static Vector3 vec3(float x) => new Vector3(x, x, x);
    public static Vector3 vec3(float x, float y, float z) => new Vector3(x, y, z);
    public static Vector3 vec3(Vector2 xy, float z) => new Vector3(xy.X, xy.Y, z);
    public static Vector3 vec3(float x, Vector2 yz) => new Vector3(x, yz.X, yz.Y);
    public static Vector3 vec3(Vector3 xyz) => xyz;
    public static Vector3 vec3(Vector4 xyzw) => xyzw.Xyz;

    public static Vector4 vec4(float x) => new Vector4(x, x, x, x);
    public static Vector4 vec4(float x, float y, float z, float w) => new Vector4(x, y, z, w);
    public static Vector4 vec4(Vector2 xy, float z, float w) => new Vector4(xy.X, xy.Y, z, w);
    public static Vector4 vec4(float x, Vector2 yz, float w) => new Vector4(x, yz.X, yz.Y, w);
    public static Vector4 vec4(float x, float y, Vector2 zw) => new Vector4(x, y, zw.X, zw.Y);
    public static Vector4 vec4(Vector2 xy, Vector2 zw) => new Vector4(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4 vec4(Vector3 xyz, float w) => new Vector4(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4 vec4(float x, Vector3 yzw) => new Vector4(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4 vec4(Vector4 xyzw) => xyzw;
    #endregion

    #region dvec2, dvec3, dvec4
    public static Vector2d dvec2(double x) => new Vector2d(x, x);
    public static Vector2d dvec2(double x, double y) => new Vector2d(x, y);
    public static Vector2d dvec2(Vector2d xy) => xy;
    public static Vector2d dvec2(Vector3d xyz) => xyz.Xy;
    public static Vector2d dvec2(Vector4d xyzw) => xyzw.Xy;

    public static Vector3d dvec3(double x) => new Vector3d(x, x, x);
    public static Vector3d dvec3(double x, double y, double z) => new Vector3d(x, y, z);
    public static Vector3d dvec3(Vector2d xy, double z) => new Vector3d(xy.X, xy.Y, z);
    public static Vector3d dvec3(double x, Vector2d yz) => new Vector3d(x, yz.X, yz.Y);
    public static Vector3d dvec3(Vector3d xyz) => xyz;
    public static Vector3d dvec3(Vector4d xyzw) => xyzw.Xyz;

    public static Vector4d dvec4(double x) => new Vector4d(x, x, x, x);
    public static Vector4d dvec4(double x, double y, double z, double w) => new Vector4d(x, y, z, w);
    public static Vector4d dvec4(Vector2d xy, double z, double w) => new Vector4d(xy.X, xy.Y, z, w);
    public static Vector4d dvec4(double x, Vector2d yz, double w) => new Vector4d(x, yz.X, yz.Y, w);
    public static Vector4d dvec4(double x, double y, Vector2d zw) => new Vector4d(x, y, zw.X, zw.Y);
    public static Vector4d dvec4(Vector2d xy, Vector2d zw) => new Vector4d(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4d dvec4(Vector3d xyz, double w) => new Vector4d(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4d dvec4(double x, Vector3d yzw) => new Vector4d(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4d dvec4(Vector4d xyzw) => xyzw;
    #endregion

    #region ivec2, ivec3, ivec4
    public static Vector2i ivec2(int x) => new Vector2i(x, x);
    public static Vector2i ivec2(int x, int y) => new Vector2i(x, y);
    public static Vector2i ivec2(Vector2i xy) => xy;
    public static Vector2i ivec2(Vector3i xyz) => xyz.Xy;
    public static Vector2i ivec2(Vector4i xyzw) => xyzw.Xy;

    public static Vector3i ivec3(int x) => new Vector3i(x, x, x);
    public static Vector3i ivec3(int x, int y, int z) => new Vector3i(x, y, z);
    public static Vector3i ivec3(Vector2i xy, int z) => new Vector3i(xy.X, xy.Y, z);
    public static Vector3i ivec3(int x, Vector2i yz) => new Vector3i(x, yz.X, yz.Y);
    public static Vector3i ivec3(Vector3i xyz) => xyz;
    public static Vector3i ivec3(Vector4i xyzw) => xyzw.Xyz;

    public static Vector4i ivec4(int x) => new Vector4i(x, x, x, x);
    public static Vector4i ivec4(int x, int y, int z, int w) => new Vector4i(x, y, z, w);
    public static Vector4i ivec4(Vector2i xy, int z, int w) => new Vector4i(xy.X, xy.Y, z, w);
    public static Vector4i ivec4(int x, Vector2i yz, int w) => new Vector4i(x, yz.X, yz.Y, w);
    public static Vector4i ivec4(int x, int y, Vector2i zw) => new Vector4i(x, y, zw.X, zw.Y);
    public static Vector4i ivec4(Vector2i xy, Vector2i zw) => new Vector4i(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4i ivec4(Vector3i xyz, int w) => new Vector4i(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4i ivec4(int x, Vector3i yzw) => new Vector4i(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4i ivec4(Vector4i xyzw) => xyzw;
    #endregion

    #region uvec2, uvec3, uvec4
    public static Vector2u uvec2(uint x) => new Vector2u(x, x);
    public static Vector2u uvec2(uint x, uint y) => new Vector2u(x, y);
    public static Vector2u uvec2(Vector2u xy) => xy;
    public static Vector2u uvec2(Vector3u xyz) => xyz.Xy;
    public static Vector2u uvec2(Vector4u xyzw) => xyzw.Xy;

    public static Vector3u uvec3(uint x) => new Vector3u(x, x, x);
    public static Vector3u uvec3(uint x, uint y, uint z) => new Vector3u(x, y, z);
    public static Vector3u uvec3(Vector2u xy, uint z) => new Vector3u(xy.X, xy.Y, z);
    public static Vector3u uvec3(uint x, Vector2u yz) => new Vector3u(x, yz.X, yz.Y);
    public static Vector3u uvec3(Vector3u xyz) => xyz;
    public static Vector3u uvec3(Vector4u xyzw) => xyzw.Xyz;

    public static Vector4u uvec4(uint x) => new Vector4u(x, x, x, x);
    public static Vector4u uvec4(uint x, uint y, uint z, uint w) => new Vector4u(x, y, z, w);
    public static Vector4u uvec4(Vector2u xy, uint z, uint w) => new Vector4u(xy.X, xy.Y, z, w);
    public static Vector4u uvec4(uint x, Vector2u yz, uint w) => new Vector4u(x, yz.X, yz.Y, w);
    public static Vector4u uvec4(uint x, uint y, Vector2u zw) => new Vector4u(x, y, zw.X, zw.Y);
    public static Vector4u uvec4(Vector2u xy, Vector2u zw) => new Vector4u(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4u uvec4(Vector3u xyz, uint w) => new Vector4u(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4u uvec4(uint x, Vector3u yzw) => new Vector4u(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4u uvec4(Vector4u xyzw) => xyzw;
    #endregion

    #region bvec2, bvec3, bvec4
    public static Vector2b bvec2(bool x) => new Vector2b(x, x);
    public static Vector2b bvec2(bool x, bool y) => new Vector2b(x, y);
    public static Vector2b bvec2(Vector2b xy) => xy;
    public static Vector2b bvec2(Vector3b xyz) => xyz.Xy;
    public static Vector2b bvec2(Vector4b xyzw) => xyzw.Xy;

    public static Vector3b bvec3(bool x) => new Vector3b(x, x, x);
    public static Vector3b bvec3(bool x, bool y, bool z) => new Vector3b(x, y, z);
    public static Vector3b bvec3(Vector2b xy, bool z) => new Vector3b(xy.X, xy.Y, z);
    public static Vector3b bvec3(bool x, Vector2b yz) => new Vector3b(x, yz.X, yz.Y);
    public static Vector3b bvec3(Vector3b xyz) => xyz;
    public static Vector3b bvec3(Vector4b xyzw) => xyzw.Xyz;

    public static Vector4b bvec4(bool x) => new Vector4b(x, x, x, x);
    public static Vector4b bvec4(bool x, bool y, bool z, bool w) => new Vector4b(x, y, z, w);
    public static Vector4b bvec4(Vector2b xy, bool z, bool w) => new Vector4b(xy.X, xy.Y, z, w);
    public static Vector4b bvec4(bool x, Vector2b yz, bool w) => new Vector4b(x, yz.X, yz.Y, w);
    public static Vector4b bvec4(bool x, bool y, Vector2b zw) => new Vector4b(x, y, zw.X, zw.Y);
    public static Vector4b bvec4(Vector2b xy, Vector2b zw) => new Vector4b(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4b bvec4(Vector3b xyz, bool w) => new Vector4b(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4b bvec4(bool x, Vector3b yzw) => new Vector4b(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4b bvec4(Vector4b xyzw) => xyzw;
    #endregion

    #region hvec2, hvec3, hvec4
    public static Vector2h hvec2(Half x) => new Vector2h(x, x);
    public static Vector2h hvec2(Half x, Half y) => new Vector2h(x, y);
    public static Vector2h hvec2(Vector2h xy) => xy;
    public static Vector2h hvec2(Vector3h xyz) => xyz.Xy;
    public static Vector2h hvec2(Vector4h xyzw) => xyzw.Xy;

    public static Vector3h hvec3(Half x) => new Vector3h(x, x, x);
    public static Vector3h hvec3(Half x, Half y, Half z) => new Vector3h(x, y, z);
    public static Vector3h hvec3(Vector2h xy, Half z) => new Vector3h(xy.X, xy.Y, z);
    public static Vector3h hvec3(Half x, Vector2h yz) => new Vector3h(x, yz.X, yz.Y);
    public static Vector3h hvec3(Vector3h xyz) => xyz;
    public static Vector3h hvec3(Vector4h xyzw) => xyzw.Xyz;

    public static Vector4h hvec4(Half x) => new Vector4h(x, x, x, x);
    public static Vector4h hvec4(Half x, Half y, Half z, Half w) => new Vector4h(x, y, z, w);
    public static Vector4h hvec4(Vector2h xy, Half z, Half w) => new Vector4h(xy.X, xy.Y, z, w);
    public static Vector4h hvec4(Half x, Vector2h yz, Half w) => new Vector4h(x, yz.X, yz.Y, w);
    public static Vector4h hvec4(Half x, Half y, Vector2h zw) => new Vector4h(x, y, zw.X, zw.Y);
    public static Vector4h hvec4(Vector2h xy, Vector2h zw) => new Vector4h(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4h hvec4(Vector3h xyz, Half w) => new Vector4h(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4h hvec4(Half x, Vector3h yzw) => new Vector4h(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4h hvec4(Vector4h xyzw) => xyzw;
    #endregion

    #region float2, float3, float4
    public static Vector2 float2(float x) => new Vector2(x, x);
    public static Vector2 float2(float x, float y) => new Vector2(x, y);
    public static Vector2 float2(Vector2 xy) => xy;
    public static Vector2 float2(Vector3 xyz) => xyz.Xy;
    public static Vector2 float2(Vector4 xyzw) => xyzw.Xy;

    public static Vector3 float3(float x) => new Vector3(x, x, x);
    public static Vector3 float3(float x, float y, float z) => new Vector3(x, y, z);
    public static Vector3 float3(Vector2 xy, float z) => new Vector3(xy.X, xy.Y, z);
    public static Vector3 float3(float x, Vector2 yz) => new Vector3(x, yz.X, yz.Y);
    public static Vector3 float3(Vector3 xyz) => xyz;
    public static Vector3 float3(Vector4 xyzw) => xyzw.Xyz;

    public static Vector4 float4(float x) => new Vector4(x, x, x, x);
    public static Vector4 float4(float x, float y, float z, float w) => new Vector4(x, y, z, w);
    public static Vector4 float4(Vector2 xy, float z, float w) => new Vector4(xy.X, xy.Y, z, w);
    public static Vector4 float4(float x, Vector2 yz, float w) => new Vector4(x, yz.X, yz.Y, w);
    public static Vector4 float4(float x, float y, Vector2 zw) => new Vector4(x, y, zw.X, zw.Y);
    public static Vector4 float4(Vector2 xy, Vector2 zw) => new Vector4(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4 float4(Vector3 xyz, float w) => new Vector4(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4 float4(float x, Vector3 yzw) => new Vector4(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4 float4(Vector4 xyzw) => xyzw;
    #endregion

    #region double2, double3, double4
    public static Vector2d double2(double x) => new Vector2d(x, x);
    public static Vector2d double2(double x, double y) => new Vector2d(x, y);
    public static Vector2d double2(Vector2d xy) => xy;
    public static Vector2d double2(Vector3d xyz) => xyz.Xy;
    public static Vector2d double2(Vector4d xyzw) => xyzw.Xy;

    public static Vector3d double3(double x) => new Vector3d(x, x, x);
    public static Vector3d double3(double x, double y, double z) => new Vector3d(x, y, z);
    public static Vector3d double3(Vector2d xy, double z) => new Vector3d(xy.X, xy.Y, z);
    public static Vector3d double3(double x, Vector2d yz) => new Vector3d(x, yz.X, yz.Y);
    public static Vector3d double3(Vector3d xyz) => xyz;
    public static Vector3d double3(Vector4d xyzw) => xyzw.Xyz;

    public static Vector4d double4(double x) => new Vector4d(x, x, x, x);
    public static Vector4d double4(double x, double y, double z, double w) => new Vector4d(x, y, z, w);
    public static Vector4d double4(Vector2d xy, double z, double w) => new Vector4d(xy.X, xy.Y, z, w);
    public static Vector4d double4(double x, Vector2d yz, double w) => new Vector4d(x, yz.X, yz.Y, w);
    public static Vector4d double4(double x, double y, Vector2d zw) => new Vector4d(x, y, zw.X, zw.Y);
    public static Vector4d double4(Vector2d xy, Vector2d zw) => new Vector4d(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4d double4(Vector3d xyz, double w) => new Vector4d(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4d double4(double x, Vector3d yzw) => new Vector4d(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4d double4(Vector4d xyzw) => xyzw;
    #endregion

    #region int2, int3, int4
    public static Vector2i int2(int x) => new Vector2i(x, x);
    public static Vector2i int2(int x, int y) => new Vector2i(x, y);
    public static Vector2i int2(Vector2i xy) => xy;
    public static Vector2i int2(Vector3i xyz) => xyz.Xy;
    public static Vector2i int2(Vector4i xyzw) => xyzw.Xy;

    public static Vector3i int3(int x) => new Vector3i(x, x, x);
    public static Vector3i int3(int x, int y, int z) => new Vector3i(x, y, z);
    public static Vector3i int3(Vector2i xy, int z) => new Vector3i(xy.X, xy.Y, z);
    public static Vector3i int3(int x, Vector2i yz) => new Vector3i(x, yz.X, yz.Y);
    public static Vector3i int3(Vector3i xyz) => xyz;
    public static Vector3i int3(Vector4i xyzw) => xyzw.Xyz;

    public static Vector4i int4(int x) => new Vector4i(x, x, x, x);
    public static Vector4i int4(int x, int y, int z, int w) => new Vector4i(x, y, z, w);
    public static Vector4i int4(Vector2i xy, int z, int w) => new Vector4i(xy.X, xy.Y, z, w);
    public static Vector4i int4(int x, Vector2i yz, int w) => new Vector4i(x, yz.X, yz.Y, w);
    public static Vector4i int4(int x, int y, Vector2i zw) => new Vector4i(x, y, zw.X, zw.Y);
    public static Vector4i int4(Vector2i xy, Vector2i zw) => new Vector4i(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4i int4(Vector3i xyz, int w) => new Vector4i(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4i int4(int x, Vector3i yzw) => new Vector4i(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4i int4(Vector4i xyzw) => xyzw;
    #endregion

    #region uint2, uint3, uint4
    public static Vector2u uint2(uint x) => new Vector2u(x, x);
    public static Vector2u uint2(uint x, uint y) => new Vector2u(x, y);
    public static Vector2u uint2(Vector2u xy) => xy;
    public static Vector2u uint2(Vector3u xyz) => xyz.Xy;
    public static Vector2u uint2(Vector4u xyzw) => xyzw.Xy;

    public static Vector3u uint3(uint x) => new Vector3u(x, x, x);
    public static Vector3u uint3(uint x, uint y, uint z) => new Vector3u(x, y, z);
    public static Vector3u uint3(Vector2u xy, uint z) => new Vector3u(xy.X, xy.Y, z);
    public static Vector3u uint3(uint x, Vector2u yz) => new Vector3u(x, yz.X, yz.Y);
    public static Vector3u uint3(Vector3u xyz) => xyz;
    public static Vector3u uint3(Vector4u xyzw) => xyzw.Xyz;

    public static Vector4u uint4(uint x) => new Vector4u(x, x, x, x);
    public static Vector4u uint4(uint x, uint y, uint z, uint w) => new Vector4u(x, y, z, w);
    public static Vector4u uint4(Vector2u xy, uint z, uint w) => new Vector4u(xy.X, xy.Y, z, w);
    public static Vector4u uint4(uint x, Vector2u yz, uint w) => new Vector4u(x, yz.X, yz.Y, w);
    public static Vector4u uint4(uint x, uint y, Vector2u zw) => new Vector4u(x, y, zw.X, zw.Y);
    public static Vector4u uint4(Vector2u xy, Vector2u zw) => new Vector4u(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4u uint4(Vector3u xyz, uint w) => new Vector4u(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4u uint4(uint x, Vector3u yzw) => new Vector4u(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4u uint4(Vector4u xyzw) => xyzw;
    #endregion

    #region bool2, bool3, bool4
    public static Vector2b bool2(bool x) => new Vector2b(x, x);
    public static Vector2b bool2(bool x, bool y) => new Vector2b(x, y);
    public static Vector2b bool2(Vector2b xy) => xy;
    public static Vector2b bool2(Vector3b xyz) => xyz.Xy;
    public static Vector2b bool2(Vector4b xyzw) => xyzw.Xy;

    public static Vector3b bool3(bool x) => new Vector3b(x, x, x);
    public static Vector3b bool3(bool x, bool y, bool z) => new Vector3b(x, y, z);
    public static Vector3b bool3(Vector2b xy, bool z) => new Vector3b(xy.X, xy.Y, z);
    public static Vector3b bool3(bool x, Vector2b yz) => new Vector3b(x, yz.X, yz.Y);
    public static Vector3b bool3(Vector3b xyz) => xyz;
    public static Vector3b bool3(Vector4b xyzw) => xyzw.Xyz;

    public static Vector4b bool4(bool x) => new Vector4b(x, x, x, x);
    public static Vector4b bool4(bool x, bool y, bool z, bool w) => new Vector4b(x, y, z, w);
    public static Vector4b bool4(Vector2b xy, bool z, bool w) => new Vector4b(xy.X, xy.Y, z, w);
    public static Vector4b bool4(bool x, Vector2b yz, bool w) => new Vector4b(x, yz.X, yz.Y, w);
    public static Vector4b bool4(bool x, bool y, Vector2b zw) => new Vector4b(x, y, zw.X, zw.Y);
    public static Vector4b bool4(Vector2b xy, Vector2b zw) => new Vector4b(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4b bool4(Vector3b xyz, bool w) => new Vector4b(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4b bool4(bool x, Vector3b yzw) => new Vector4b(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4b bool4(Vector4b xyzw) => xyzw;
    #endregion

    #region half2, half3, half4
    public static Vector2h half2(Half x) => new Vector2h(x, x);
    public static Vector2h half2(Half x, Half y) => new Vector2h(x, y);
    public static Vector2h half2(Vector2h xy) => xy;
    public static Vector2h half2(Vector3h xyz) => xyz.Xy;
    public static Vector2h half2(Vector4h xyzw) => xyzw.Xy;

    public static Vector3h half3(Half x) => new Vector3h(x, x, x);
    public static Vector3h half3(Half x, Half y, Half z) => new Vector3h(x, y, z);
    public static Vector3h half3(Vector2h xy, Half z) => new Vector3h(xy.X, xy.Y, z);
    public static Vector3h half3(Half x, Vector2h yz) => new Vector3h(x, yz.X, yz.Y);
    public static Vector3h half3(Vector3h xyz) => xyz;
    public static Vector3h half3(Vector4h xyzw) => xyzw.Xyz;

    public static Vector4h half4(Half x) => new Vector4h(x, x, x, x);
    public static Vector4h half4(Half x, Half y, Half z, Half w) => new Vector4h(x, y, z, w);
    public static Vector4h half4(Vector2h xy, Half z, Half w) => new Vector4h(xy.X, xy.Y, z, w);
    public static Vector4h half4(Half x, Vector2h yz, Half w) => new Vector4h(x, yz.X, yz.Y, w);
    public static Vector4h half4(Half x, Half y, Vector2h zw) => new Vector4h(x, y, zw.X, zw.Y);
    public static Vector4h half4(Vector2h xy, Vector2h zw) => new Vector4h(xy.X, xy.Y, zw.X, zw.Y);
    public static Vector4h half4(Vector3h xyz, Half w) => new Vector4h(xyz.X, xyz.Y, xyz.Z, w);
    public static Vector4h half4(Half x, Vector3h yzw) => new Vector4h(x, yzw.X, yzw.Y, yzw.Z);
    public static Vector4h half4(Vector4h xyzw) => xyzw;
    #endregion
    #endregion

    #region radians, degrees
    public static float radians(float degrees) => MathHelper.DegreesToRadians(degrees);
    public static vec2 radians(vec2 degrees) => new vec2(radians(degrees.X), radians(degrees.Y));
    public static vec3 radians(vec3 degrees) => new vec3(radians(degrees.X), radians(degrees.Y), radians(degrees.Z));
    public static vec4 radians(vec4 degrees) => new vec4(radians(degrees.X), radians(degrees.Y), radians(degrees.Z), radians(degrees.W));

    public static double radians(double degrees) => MathHelper.DegreesToRadians(degrees);
    public static dvec2 radians(dvec2 degrees) => new dvec2(radians(degrees.X), radians(degrees.Y));
    public static dvec3 radians(dvec3 degrees) => new dvec3(radians(degrees.X), radians(degrees.Y), radians(degrees.Z));
    public static dvec4 radians(dvec4 degrees) => new dvec4(radians(degrees.X), radians(degrees.Y), radians(degrees.Z), radians(degrees.W));

    public static float degrees(float radians) => MathHelper.RadiansToDegrees(radians);
    public static vec2 degrees(vec2 radians) => new vec2(degrees(radians.X), degrees(radians.Y));
    public static vec3 degrees(vec3 radians) => new vec3(degrees(radians.X), degrees(radians.Y), degrees(radians.Z));
    public static vec4 degrees(vec4 radians) => new vec4(degrees(radians.X), degrees(radians.Y), degrees(radians.Z), degrees(radians.W));

    public static double degrees(double radians) => MathHelper.RadiansToDegrees(radians);
    public static dvec2 degrees(dvec2 radians) => new dvec2(degrees(radians.X), degrees(radians.Y));
    public static dvec3 degrees(dvec3 radians) => new dvec3(degrees(radians.X), degrees(radians.Y), degrees(radians.Z));
    public static dvec4 degrees(dvec4 radians) => new dvec4(degrees(radians.X), degrees(radians.Y), degrees(radians.Z), degrees(radians.W));
    #endregion

    #region sin, cos, sincos, sinh, cosh, asin, acos
    // float sin
    public static float sin(float x) => (float)Math.Sin(x);
    public static vec2 sin(vec2 x) => new vec2(sin(x.X), sin(x.Y));
    public static vec3 sin(vec3 x) => new vec3(sin(x.X), sin(x.Y), sin(x.Z));
    public static vec4 sin(vec4 x) => new vec4(sin(x.X), sin(x.Y), sin(x.Z), sin(x.W));

    // double sin
    public static double sin(double x) => Math.Sin(x);
    public static dvec2 sin(dvec2 x) => new dvec2(sin(x.X), sin(x.Y));
    public static dvec3 sin(dvec3 x) => new dvec3(sin(x.X), sin(x.Y), sin(x.Z));
    public static dvec4 sin(dvec4 x) => new dvec4(sin(x.X), sin(x.Y), sin(x.Z), sin(x.W));

    // float cos
    public static float cos(float x) => (float)Math.Cos(x);
    public static vec2 cos(vec2 x) => new vec2(cos(x.X), cos(x.Y));
    public static vec3 cos(vec3 x) => new vec3(cos(x.X), cos(x.Y), cos(x.Z));
    public static vec4 cos(vec4 x) => new vec4(cos(x.X), cos(x.Y), cos(x.Z), cos(x.W));

    // double cos
    public static double cos(double x) => Math.Cos(x);
    public static dvec2 cos(dvec2 x) => new dvec2(cos(x.X), cos(x.Y));
    public static dvec3 cos(dvec3 x) => new dvec3(cos(x.X), cos(x.Y), cos(x.Z));
    public static dvec4 cos(dvec4 x) => new dvec4(cos(x.X), cos(x.Y), cos(x.Z), cos(x.W));

    // float sincos
    public static void sincos(float x, out float s, out float c) { s = sin(x); c = cos(x); }
    public static void sincos(vec2 x, out vec2 s, out vec2 c) { s = sin(x); c = cos(x); }
    public static void sincos(vec3 x, out vec3 s, out vec3 c) { s = sin(x); c = cos(x); }
    public static void sincos(vec4 x, out vec4 s, out vec4 c) { s = sin(x); c = cos(x); }

    // double sincos
    public static void sincos(double x, out double s, out double c) { s = sin(x); c = cos(x); }
    public static void sincos(dvec2 x, out dvec2 s, out dvec2 c) { s = sin(x); c = cos(x); }
    public static void sincos(dvec3 x, out dvec3 s, out dvec3 c) { s = sin(x); c = cos(x); }
    public static void sincos(dvec4 x, out dvec4 s, out dvec4 c) { s = sin(x); c = cos(x); }

    // float sinh
    public static float sinh(float x) => (float)Math.Sinh(x);
    public static vec2 sinh(vec2 x) => new vec2(sinh(x.X), sinh(x.Y));
    public static vec3 sinh(vec3 x) => new vec3(sinh(x.X), sinh(x.Y), sinh(x.Z));
    public static vec4 sinh(vec4 x) => new vec4(sinh(x.X), sinh(x.Y), sinh(x.Z), sinh(x.W));

    // double sinh
    public static double sinh(double x) => Math.Sinh(x);
    public static dvec2 sinh(dvec2 x) => new dvec2(sinh(x.X), sinh(x.Y));
    public static dvec3 sinh(dvec3 x) => new dvec3(sinh(x.X), sinh(x.Y), sinh(x.Z));
    public static dvec4 sinh(dvec4 x) => new dvec4(sinh(x.X), sinh(x.Y), sinh(x.Z), sinh(x.W));

    // float cosh
    public static float cosh(float x) => (float)Math.Cosh(x);
    public static vec2 cosh(vec2 x) => new vec2(cosh(x.X), cosh(x.Y));
    public static vec3 cosh(vec3 x) => new vec3(cosh(x.X), cosh(x.Y), cosh(x.Z));
    public static vec4 cosh(vec4 x) => new vec4(cosh(x.X), cosh(x.Y), cosh(x.Z), cosh(x.W));

    // double cosh
    public static double cosh(double x) => Math.Cosh(x);
    public static dvec2 cosh(dvec2 x) => new dvec2(cosh(x.X), cosh(x.Y));
    public static dvec3 cosh(dvec3 x) => new dvec3(cosh(x.X), cosh(x.Y), cosh(x.Z));
    public static dvec4 cosh(dvec4 x) => new dvec4(cosh(x.X), cosh(x.Y), cosh(x.Z), cosh(x.W));

    // float asin
    public static float asin(float x) => (float)Math.Asin(x);
    public static vec2 asin(vec2 x) => new vec2(asin(x.X), asin(x.Y));
    public static vec3 asin(vec3 x) => new vec3(asin(x.X), asin(x.Y), asin(x.Z));
    public static vec4 asin(vec4 x) => new vec4(asin(x.X), asin(x.Y), asin(x.Z), asin(x.W));

    // double asin
    public static double asin(double x) => Math.Asin(x);
    public static dvec2 asin(dvec2 x) => new dvec2(asin(x.X), asin(x.Y));
    public static dvec3 asin(dvec3 x) => new dvec3(asin(x.X), asin(x.Y), asin(x.Z));
    public static dvec4 asin(dvec4 x) => new dvec4(asin(x.X), asin(x.Y), asin(x.Z), asin(x.W));

    // float acos
    public static float acos(float x) => (float)Math.Acos(x);
    public static vec2 acos(vec2 x) => new vec2(acos(x.X), acos(x.Y));
    public static vec3 acos(vec3 x) => new vec3(acos(x.X), acos(x.Y), acos(x.Z));
    public static vec4 acos(vec4 x) => new vec4(acos(x.X), acos(x.Y), acos(x.Z), acos(x.W));

    // double acos
    public static double acos(double x) => Math.Acos(x);
    public static dvec2 acos(dvec2 x) => new dvec2(acos(x.X), acos(x.Y));
    public static dvec3 acos(dvec3 x) => new dvec3(acos(x.X), acos(x.Y), acos(x.Z));
    public static dvec4 acos(dvec4 x) => new dvec4(acos(x.X), acos(x.Y), acos(x.Z), acos(x.W));
    #endregion

    #region tan, atan, atan2, tanh
    // float tan
    public static float tan(float angle) => (float)Math.Tan(angle);
    public static vec2 tan(vec2 angle) => new vec2(tan(angle.X), tan(angle.Y));
    public static vec3 tan(vec3 angle) => new vec3(tan(angle.X), tan(angle.Y), tan(angle.Z));
    public static vec4 tan(vec4 angle) => new vec4(tan(angle.X), tan(angle.Y), tan(angle.Z), tan(angle.W));

    // double tan
    public static double tan(double angle) => Math.Tan(angle);
    public static dvec2 tan(dvec2 angle) => new dvec2(tan(angle.X), tan(angle.Y));
    public static dvec3 tan(dvec3 angle) => new dvec3(tan(angle.X), tan(angle.Y), tan(angle.Z));
    public static dvec4 tan(dvec4 angle) => new dvec4(tan(angle.X), tan(angle.Y), tan(angle.Z), tan(angle.W));

    // float atan
    public static float atan(float y_over_x) => (float)Math.Atan(y_over_x);
    public static vec2 atan(vec2 y_over_x) => new vec2(atan(y_over_x.X), atan(y_over_x.Y));
    public static vec3 atan(vec3 y_over_x) => new vec3(atan(y_over_x.X), atan(y_over_x.Y), atan(y_over_x.Z));
    public static vec4 atan(vec4 y_over_x) => new vec4(atan(y_over_x.X), atan(y_over_x.Y), atan(y_over_x.Z), atan(y_over_x.W));

    // double atan
    public static double atan(double y_over_x) => Math.Atan(y_over_x);
    public static dvec2 atan(dvec2 y_over_x) => new dvec2(atan(y_over_x.X), atan(y_over_x.Y));
    public static dvec3 atan(dvec3 y_over_x) => new dvec3(atan(y_over_x.X), atan(y_over_x.Y), atan(y_over_x.Z));
    public static dvec4 atan(dvec4 y_over_x) => new dvec4(atan(y_over_x.X), atan(y_over_x.Y), atan(y_over_x.Z), atan(y_over_x.W));

    // float atan2, atan overload
    public static float atan2(float x, float y) => atan(y, x);
    public static vec2 atan2(vec2 x, vec2 y) => atan(y, x);
    public static vec3 atan2(vec3 x, vec3 y) => atan(y, x);
    public static vec4 atan2(vec4 x, vec4 y) => atan(y, x);
    public static float atan(float y, float x) => (float)Math.Atan2(y, x);
    public static vec2 atan(vec2 y, vec2 x) => new vec2(atan(y.X, x.X), atan(y.Y, x.Y));
    public static vec3 atan(vec3 y, vec3 x) => new vec3(atan(y.X, x.X), atan(y.Y, x.Y), atan(y.Z, x.Z));
    public static vec4 atan(vec4 y, vec4 x) => new vec4(atan(y.X, x.X), atan(y.Y, x.Y), atan(y.Z, x.Z), atan(y.W, x.W));

    // double atan2, atan overload
    public static double atan2(double x, double y) => atan(y, x);
    public static dvec2 atan2(dvec2 x, dvec2 y) => atan(y, x);
    public static dvec3 atan2(dvec3 x, dvec3 y) => atan(y, x);
    public static dvec4 atan2(dvec4 x, dvec4 y) => atan(y, x);
    public static double atan(double y, double x) => Math.Atan2(y, x);
    public static dvec2 atan(dvec2 y, dvec2 x) => new dvec2(atan(y.X, x.X), atan(y.Y, x.Y));
    public static dvec3 atan(dvec3 y, dvec3 x) => new dvec3(atan(y.X, x.X), atan(y.Y, x.Y), atan(y.Z, x.Z));
    public static dvec4 atan(dvec4 y, dvec4 x) => new dvec4(atan(y.X, x.X), atan(y.Y, x.Y), atan(y.Z, x.Z), atan(y.W, x.W));

    // float tanh
    public static float tanh(float angle) => (float)Math.Tanh(angle);
    public static vec2 tanh(vec2 angle) => new vec2(tanh(angle.X), tanh(angle.Y));
    public static vec3 tanh(vec3 angle) => new vec3(tanh(angle.X), tanh(angle.Y), tanh(angle.Z));
    public static vec4 tanh(vec4 angle) => new vec4(tanh(angle.X), tanh(angle.Y), tanh(angle.Z), tanh(angle.W));

    // double tanh
    public static double tanh(double angle) => Math.Tanh(angle);
    public static dvec2 tanh(dvec2 angle) => new dvec2(tanh(angle.X), tanh(angle.Y));
    public static dvec3 tanh(dvec3 angle) => new dvec3(tanh(angle.X), tanh(angle.Y), tanh(angle.Z));
    public static dvec4 tanh(dvec4 angle) => new dvec4(tanh(angle.X), tanh(angle.Y), tanh(angle.Z), tanh(angle.W));
    #endregion

    #region pow, exp, exp2, ldexp, log, log2, log10, sqrt, inversesqrt, frexp
    // float pow
    public static float pow(float x, float y) => (float)Math.Pow(x, y);
    public static vec2 pow(vec2 x, vec2 y) => new vec2(pow(x.X, y.X), pow(x.Y, y.Y));
    public static vec3 pow(vec3 x, vec3 y) => new vec3(pow(x.X, y.X), pow(x.Y, y.Y), pow(x.Z, y.Z));
    public static vec4 pow(vec4 x, vec4 y) => new vec4(pow(x.X, y.X), pow(x.Y, y.Y), pow(x.Z, y.Z), pow(x.W, y.W));

    // double pow
    public static double pow(double x, double y) => Math.Pow(x, y);
    public static dvec2 pow(dvec2 x, dvec2 y) => new dvec2(pow(x.X, y.X), pow(x.Y, y.Y));
    public static dvec3 pow(dvec3 x, dvec3 y) => new dvec3(pow(x.X, y.X), pow(x.Y, y.Y), pow(x.Z, y.Z));
    public static dvec4 pow(dvec4 x, dvec4 y) => new dvec4(pow(x.X, y.X), pow(x.Y, y.Y), pow(x.Z, y.Z), pow(x.W, y.W));

    // float exp
    public static float exp(float x) => (float)Math.Exp(x);
    public static vec2 exp(vec2 x) => new vec2(exp(x.X), exp(x.Y));
    public static vec3 exp(vec3 x) => new vec3(exp(x.X), exp(x.Y), exp(x.Z));
    public static vec4 exp(vec4 x) => new vec4(exp(x.X), exp(x.Y), exp(x.Z), exp(x.W));

    // double exp
    public static double exp(double x) => Math.Exp(x);
    public static dvec2 exp(dvec2 x) => new dvec2(exp(x.X), exp(x.Y));
    public static dvec3 exp(dvec3 x) => new dvec3(exp(x.X), exp(x.Y), exp(x.Z));
    public static dvec4 exp(dvec4 x) => new dvec4(exp(x.X), exp(x.Y), exp(x.Z), exp(x.W));

    // float exp2
    public static float exp2(float x) => exp(x * log(2.0f));
    public static vec2 exp2(vec2 x) => new vec2(exp2(x.X), exp2(x.Y));
    public static vec3 exp2(vec3 x) => new vec3(exp2(x.X), exp2(x.Y), exp2(x.Z));
    public static vec4 exp2(vec4 x) => new vec4(exp2(x.X), exp2(x.Y), exp2(x.Z), exp2(x.W));

    // double exp2
    public static double exp2(double x) => exp(x * log(2.0));
    public static dvec2 exp2(dvec2 x) => new dvec2(exp2(x.X), exp2(x.Y));
    public static dvec3 exp2(dvec3 x) => new dvec3(exp2(x.X), exp2(x.Y), exp2(x.Z));
    public static dvec4 exp2(dvec4 x) => new dvec4(exp2(x.X), exp2(x.Y), exp2(x.Z), exp2(x.W));

    // float ldexp
    public static float ldexp(float x) => x * (float)Math.Pow(2, Math.E);
    public static vec2 ldexp(vec2 x) => new vec2(ldexp(x.X), ldexp(x.Y));
    public static vec3 ldexp(vec3 x) => new vec3(ldexp(x.X), ldexp(x.Y), ldexp(x.Z));
    public static vec4 ldexp(vec4 x) => new vec4(ldexp(x.X), ldexp(x.Y), ldexp(x.Z), ldexp(x.W));

    // double ldexp
    public static double ldexp(double x) => x * Math.Pow(2, Math.E);
    public static dvec2 ldexp(dvec2 x) => new dvec2(ldexp(x.X), ldexp(x.Y));
    public static dvec3 ldexp(dvec3 x) => new dvec3(ldexp(x.X), ldexp(x.Y), ldexp(x.Z));
    public static dvec4 ldexp(dvec4 x) => new dvec4(ldexp(x.X), ldexp(x.Y), ldexp(x.Z), ldexp(x.W));

    // float log
    public static float log(float x) => (float)Math.Log(x);
    public static vec2 log(vec2 x) => new vec2(log(x.X), log(x.Y));
    public static vec3 log(vec3 x) => new vec3(log(x.X), log(x.Y), log(x.Z));
    public static vec4 log(vec4 x) => new vec4(log(x.X), log(x.Y), log(x.Z), log(x.W));

    // double log
    public static double log(double x) => Math.Log(x);
    public static dvec2 log(dvec2 x) => new dvec2(log(x.X), log(x.Y));
    public static dvec3 log(dvec3 x) => new dvec3(log(x.X), log(x.Y), log(x.Z));
    public static dvec4 log(dvec4 x) => new dvec4(log(x.X), log(x.Y), log(x.Z), log(x.W));

    // float log2
    public static float log2(float x) => (float)Math.Log(x, 2);
    public static vec2 log2(vec2 x) => new vec2(log2(x.X), log2(x.Y));
    public static vec3 log2(vec3 x) => new vec3(log2(x.X), log2(x.Y), log2(x.Z));
    public static vec4 log2(vec4 x) => new vec4(log2(x.X), log2(x.Y), log2(x.Z), log2(x.W));

    // double log2
    public static double log2(double x) => Math.Log(x, 2);
    public static dvec2 log2(dvec2 x) => new dvec2(log2(x.X), log2(x.Y));
    public static dvec3 log2(dvec3 x) => new dvec3(log2(x.X), log2(x.Y), log2(x.Z));
    public static dvec4 log2(dvec4 x) => new dvec4(log2(x.X), log2(x.Y), log2(x.Z), log2(x.W));

    // float log10
    public static float log10(float x) => (float)Math.Log10(x);
    public static vec2 log10(vec2 x) => new vec2(log10(x.X), log10(x.Y));
    public static vec3 log10(vec3 x) => new vec3(log10(x.X), log10(x.Y), log10(x.Z));
    public static vec4 log10(vec4 x) => new vec4(log10(x.X), log10(x.Y), log10(x.Z), log10(x.W));

    // double log10
    public static double log10(double x) => Math.Log10(x);
    public static dvec2 log10(dvec2 x) => new dvec2(log10(x.X), log10(x.Y));
    public static dvec3 log10(dvec3 x) => new dvec3(log10(x.X), log10(x.Y), log10(x.Z));
    public static dvec4 log10(dvec4 x) => new dvec4(log10(x.X), log10(x.Y), log10(x.Z), log10(x.W));

    // float sqrt
    public static float sqrt(float x) => (float)Math.Sqrt(x);
    public static vec2 sqrt(vec2 x) => new vec2(sqrt(x.X), sqrt(x.Y));
    public static vec3 sqrt(vec3 x) => new vec3(sqrt(x.X), sqrt(x.Y), sqrt(x.Z));
    public static vec4 sqrt(vec4 x) => new vec4(sqrt(x.X), sqrt(x.Y), sqrt(x.Z), sqrt(x.W));

    // double sqrt
    public static double sqrt(double x) => Math.Sqrt(x);
    public static dvec2 sqrt(dvec2 x) => new dvec2(sqrt(x.X), sqrt(x.Y));
    public static dvec3 sqrt(dvec3 x) => new dvec3(sqrt(x.X), sqrt(x.Y), sqrt(x.Z));
    public static dvec4 sqrt(dvec4 x) => new dvec4(sqrt(x.X), sqrt(x.Y), sqrt(x.Z), sqrt(x.W));

    // float inversesqrt, rsqrt
    public static float inversesqrt(float x) => 1.0f / sqrt(x);
    public static vec2 inversesqrt(vec2 x) => new vec2(inversesqrt(x.X), inversesqrt(x.Y));
    public static vec3 inversesqrt(vec3 x) => new vec3(inversesqrt(x.X), inversesqrt(x.Y), inversesqrt(x.Z));
    public static vec4 inversesqrt(vec4 x) => new vec4(inversesqrt(x.X), inversesqrt(x.Y), inversesqrt(x.Z), inversesqrt(x.W));
    public static float rsqrt(float x) => inversesqrt(x);
    public static vec2 rsqrt(vec2 x) => inversesqrt(x);
    public static vec3 rsqrt(vec3 x) => inversesqrt(x);
    public static vec4 rsqrt(vec4 x) => inversesqrt(x);

    // double inversesqrt, rsqrt
    public static double inversesqrt(double x) => 1.0 / sqrt(x);
    public static dvec2 inversesqrt(dvec2 x) => new dvec2(inversesqrt(x.X), inversesqrt(x.Y));
    public static dvec3 inversesqrt(dvec3 x) => new dvec3(inversesqrt(x.X), inversesqrt(x.Y), inversesqrt(x.Z));
    public static dvec4 inversesqrt(dvec4 x) => new dvec4(inversesqrt(x.X), inversesqrt(x.Y), inversesqrt(x.Z), inversesqrt(x.W));
    public static double rsqrt(double x) => inversesqrt(x);
    public static dvec2 rsqrt(dvec2 x) => inversesqrt(x);
    public static dvec3 rsqrt(dvec3 x) => inversesqrt(x);
    public static dvec4 rsqrt(dvec4 x) => inversesqrt(x);

    // float frexp
    public static float frexp(float x, out float exp) { MathHelper.frexp(x, out double m, out int e); exp = e; return (float)m; }
    public static Vector2 frexp(Vector2 x, out Vector2 exp) { Vector2 m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); return m; }
    public static Vector3 frexp(Vector3 x, out Vector3 exp) { Vector3 m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); exp.Z = frexp(x.Z, out m.Z); return m; }
    public static Vector4 frexp(Vector4 x, out Vector4 exp) { Vector4 m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); exp.Z = frexp(x.Z, out m.Z); exp.W = frexp(x.W, out m.W); return m; }

    // double frexp
    public static double frexp(double x, out double exp) { MathHelper.frexp(x, out double m, out int e); exp = e; return m; }
    public static Vector2d frexp(Vector2d x, out Vector2d exp) { Vector2d m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); return m; }
    public static Vector3d frexp(Vector3d x, out Vector3d exp) { Vector3d m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); exp.Z = frexp(x.Z, out m.Z); return m; }
    public static Vector4d frexp(Vector4d x, out Vector4d exp) { Vector4d m; exp.X = frexp(x.X, out m.X); exp.Y = frexp(x.Y, out m.Y); exp.Z = frexp(x.Z, out m.Z); exp.W = frexp(x.W, out m.W); return m; }
    #endregion

    #region abs, sign, floor, ceil, fract, frac, trunc, round, mod, fmod, modf
    // float abs
    public static float abs(float x) => Math.Abs(x);
    public static vec2 abs(vec2 x) => new vec2(abs(x.X), abs(x.Y));
    public static vec3 abs(vec3 x) => new vec3(abs(x.X), abs(x.Y), abs(x.Z));
    public static vec4 abs(vec4 x) => new vec4(abs(x.X), abs(x.Y), abs(x.Z), abs(x.W));

    // double abs
    public static double abs(double x) => Math.Abs(x);
    public static dvec2 abs(dvec2 x) => new dvec2(abs(x.X), abs(x.Y));
    public static dvec3 abs(dvec3 x) => new dvec3(abs(x.X), abs(x.Y), abs(x.Z));
    public static dvec4 abs(dvec4 x) => new dvec4(abs(x.X), abs(x.Y), abs(x.Z), abs(x.W));

    // int abs
    public static int abs(int x) => Math.Abs(x);
    public static ivec2 abs(ivec2 x) => new ivec2(abs(x.X), abs(x.Y));
    public static ivec3 abs(ivec3 x) => new ivec3(abs(x.X), abs(x.Y), abs(x.Z));
    public static ivec4 abs(ivec4 x) => new ivec4(abs(x.X), abs(x.Y), abs(x.Z), abs(x.W));

    // float sign
    public static float sign(float x) => Math.Sign(x);
    public static vec2 sign(vec2 x) => new vec2(sign(x.X), sign(x.Y));
    public static vec3 sign(vec3 x) => new vec3(sign(x.X), sign(x.Y), sign(x.Z));
    public static vec4 sign(vec4 x) => new vec4(sign(x.X), sign(x.Y), sign(x.Z), sign(x.W));

    // double sign
    public static double sign(double x) => Math.Sign(x);
    public static dvec2 sign(dvec2 x) => new dvec2(sign(x.X), sign(x.Y));
    public static dvec3 sign(dvec3 x) => new dvec3(sign(x.X), sign(x.Y), sign(x.Z));
    public static dvec4 sign(dvec4 x) => new dvec4(sign(x.X), sign(x.Y), sign(x.Z), sign(x.W));

    // int sign
    public static int sign(int x) => Math.Sign(x);
    public static ivec2 sign(ivec2 x) => new ivec2(sign(x.X), sign(x.Y));
    public static ivec3 sign(ivec3 x) => new ivec3(sign(x.X), sign(x.Y), sign(x.Z));
    public static ivec4 sign(ivec4 x) => new ivec4(sign(x.X), sign(x.Y), sign(x.Z), sign(x.W));

    // float floor
    public static float floor(float x) => (float)Math.Floor(x);
    public static vec2 floor(vec2 x) => new vec2(floor(x.X), floor(x.Y));
    public static vec3 floor(vec3 x) => new vec3(floor(x.X), floor(x.Y), floor(x.Z));
    public static vec4 floor(vec4 x) => new vec4(floor(x.X), floor(x.Y), floor(x.Z), floor(x.W));

    // double floor
    public static double floor(double x) => Math.Floor(x);
    public static dvec2 floor(dvec2 x) => new dvec2(floor(x.X), floor(x.Y));
    public static dvec3 floor(dvec3 x) => new dvec3(floor(x.X), floor(x.Y), floor(x.Z));
    public static dvec4 floor(dvec4 x) => new dvec4(floor(x.X), floor(x.Y), floor(x.Z), floor(x.W));

    // float ceil
    public static float ceil(float x) => (float)Math.Ceiling(x);
    public static vec2 ceil(vec2 x) => new vec2(ceil(x.X), ceil(x.Y));
    public static vec3 ceil(vec3 x) => new vec3(ceil(x.X), ceil(x.Y), ceil(x.Z));
    public static vec4 ceil(vec4 x) => new vec4(ceil(x.X), ceil(x.Y), ceil(x.Z), ceil(x.W));

    // double ceil
    public static double ceil(double x) => Math.Ceiling(x);
    public static dvec2 ceil(dvec2 x) => new dvec2(ceil(x.X), ceil(x.Y));
    public static dvec3 ceil(dvec3 x) => new dvec3(ceil(x.X), ceil(x.Y), ceil(x.Z));
    public static dvec4 ceil(dvec4 x) => new dvec4(ceil(x.X), ceil(x.Y), ceil(x.Z), ceil(x.W));

    // float fract, frac
    public static float fract(float x) => x - (float)Math.Floor(x);
    public static vec2 fract(vec2 x) => new vec2(fract(x.X), fract(x.Y));
    public static vec3 fract(vec3 x) => new vec3(fract(x.X), fract(x.Y), fract(x.Z));
    public static vec4 fract(vec4 x) => new vec4(fract(x.X), fract(x.Y), fract(x.Z), fract(x.W));
    public static float frac(float x) => fract(x);
    public static vec2 frac(vec2 x) => fract(x);
    public static vec3 frac(vec3 x) => fract(x);
    public static vec4 frac(vec4 x) => fract(x);

    // double fract, frac
    public static double fract(double x) => x - Math.Floor(x);
    public static dvec2 fract(dvec2 x) => new dvec2(fract(x.X), fract(x.Y));
    public static dvec3 fract(dvec3 x) => new dvec3(fract(x.X), fract(x.Y), fract(x.Z));
    public static dvec4 fract(dvec4 x) => new dvec4(fract(x.X), fract(x.Y), fract(x.Z), fract(x.W));
    public static double frac(double x) => fract(x);
    public static dvec2 frac(dvec2 x) => fract(x);
    public static dvec3 frac(dvec3 x) => fract(x);
    public static dvec4 frac(dvec4 x) => fract(x);

    // float trunc
    public static float trunc(float x) => (float)Math.Truncate(x);
    public static vec2 trunc(vec2 x) => new vec2(trunc(x.X), trunc(x.Y));
    public static vec3 trunc(vec3 x) => new vec3(trunc(x.X), trunc(x.Y), trunc(x.Z));
    public static vec4 trunc(vec4 x) => new vec4(trunc(x.X), trunc(x.Y), trunc(x.Z), trunc(x.W));

    // double trunc
    public static double trunc(double x) => Math.Truncate(x);
    public static dvec2 trunc(dvec2 x) => new dvec2(trunc(x.X), trunc(x.Y));
    public static dvec3 trunc(dvec3 x) => new dvec3(trunc(x.X), trunc(x.Y), trunc(x.Z));
    public static dvec4 trunc(dvec4 x) => new dvec4(trunc(x.X), trunc(x.Y), trunc(x.Z), trunc(x.W));

    // float round
    public static float round(float x) => (float)Math.Round(x);
    public static vec2 round(vec2 x) => new vec2(round(x.X), round(x.Y));
    public static vec3 round(vec3 x) => new vec3(round(x.X), round(x.Y), round(x.Z));
    public static vec4 round(vec4 x) => new vec4(round(x.X), round(x.Y), round(x.Z), round(x.W));

    // double round
    public static double round(double x) => Math.Round(x);
    public static dvec2 round(dvec2 x) => new dvec2(round(x.X), round(x.Y));
    public static dvec3 round(dvec3 x) => new dvec3(round(x.X), round(x.Y), round(x.Z));
    public static dvec4 round(dvec4 x) => new dvec4(round(x.X), round(x.Y), round(x.Z), round(x.W));

    // float mod, fmod
    public static float mod(float x, float y) => x - y * floor(x / y);
    public static vec2 mod(vec2 x, float y) => new vec2(mod(x.X, y), mod(x.Y, y));
    public static vec3 mod(vec3 x, float y) => new vec3(mod(x.X, y), mod(x.Y, y), mod(x.Z, y));
    public static vec4 mod(vec4 x, float y) => new vec4(mod(x.X, y), mod(x.Y, y), mod(x.Z, y), mod(x.W, y));
    public static vec2 mod(vec2 x, vec2 y) => new vec2(mod(x.X, y.X), mod(x.Y, y.Y));
    public static vec3 mod(vec3 x, vec3 y) => new vec3(mod(x.X, y.X), mod(x.Y, y.Y), mod(x.Z, y.Z));
    public static vec4 mod(vec4 x, vec4 y) => new vec4(mod(x.X, y.X), mod(x.Y, y.Y), mod(x.Z, y.Z), mod(x.W, y.W));
    public static float fmod(float x, float y) => mod(x, y);
    public static vec2 fmod(vec2 x, float y) => mod(x, y);
    public static vec3 fmod(vec3 x, float y) => mod(x, y);
    public static vec4 fmod(vec4 x, float y) => mod(x, y);
    public static vec2 fmod(vec2 x, vec2 y) => mod(x, y);
    public static vec3 fmod(vec3 x, vec3 y) => mod(x, y);
    public static vec4 fmod(vec4 x, vec4 y) => mod(x, y);

    // double mod, fmod
    public static double mod(double x, double y) => x - y * floor(x / y);
    public static dvec2 mod(dvec2 x, double y) => new dvec2(mod(x.X, y), mod(x.Y, y));
    public static dvec3 mod(dvec3 x, double y) => new dvec3(mod(x.X, y), mod(x.Y, y), mod(x.Z, y));
    public static dvec4 mod(dvec4 x, double y) => new dvec4(mod(x.X, y), mod(x.Y, y), mod(x.Z, y), mod(x.W, y));
    public static dvec2 mod(dvec2 x, dvec2 y) => new dvec2(mod(x.X, y.X), mod(x.Y, y.Y));
    public static dvec3 mod(dvec3 x, dvec3 y) => new dvec3(mod(x.X, y.X), mod(x.Y, y.Y), mod(x.Z, y.Z));
    public static dvec4 mod(dvec4 x, dvec4 y) => new dvec4(mod(x.X, y.X), mod(x.Y, y.Y), mod(x.Z, y.Z), mod(x.W, y.W));
    public static double fmod(double x, double y) => mod(x, y);
    public static dvec2 fmod(dvec2 x, double y) => mod(x, y);
    public static dvec3 fmod(dvec3 x, double y) => mod(x, y);
    public static dvec4 fmod(dvec4 x, double y) => mod(x, y);
    public static dvec2 fmod(dvec2 x, dvec2 y) => mod(x, y);
    public static dvec3 fmod(dvec3 x, dvec3 y) => mod(x, y);
    public static dvec4 fmod(dvec4 x, dvec4 y) => mod(x, y);

    // float modf
    public static float modf(float x, out int i) { i = (int)(x); return x - i; }
    public static vec2 modf(vec2 x, out ivec2 i) { i = new ivec2((int)x.X, (int)x.Y); return x - i.ToVector2(); }
    public static vec3 modf(vec3 x, out ivec3 i) { i = new ivec3((int)x.X, (int)x.Y, (int)x.Z); return x - i.ToVector3(); }
    public static vec4 modf(vec4 x, out ivec4 i) { i = new ivec4((int)x.X, (int)x.Y, (int)x.Z, (int)x.W); return x - i.ToVector4(); }

    // double modf
    public static double modf(double x, out int i) { i = (int)x; return x - i; }
    public static dvec2 modf(dvec2 x, out ivec2 i) { i = new ivec2((int)x.X, (int)x.Y); return x - new dvec2(i.X, i.Y); }
    public static dvec3 modf(dvec3 x, out ivec3 i) { i = new ivec3((int)x.X, (int)x.Y, (int)x.Z); return x - new dvec3(i.X, i.Y, i.Z); }
    public static dvec4 modf(dvec4 x, out ivec4 i) { i = new ivec4((int)x.X, (int)x.Y, (int)x.Z, (int)x.W); return x - new dvec4(i.X, i.Y, i.Z, i.W); }
    #endregion

    #region min, max, clamp, saturate
    // float min
    public static float min(float x, float y) => Math.Min(x, y);
    public static vec2 min(vec2 x, vec2 y) => new vec2(min(x.X, y.X), min(x.Y, y.Y));
    public static vec3 min(vec3 x, vec3 y) => new vec3(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z));
    public static vec4 min(vec4 x, vec4 y) => new vec4(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z), min(x.W, y.W));
    public static vec2 min(vec2 x, float y) => new vec2(min(x.X, y), min(x.Y, y));
    public static vec3 min(vec3 x, float y) => new vec3(min(x.X, y), min(x.Y, y), min(x.Z, y));
    public static vec4 min(vec4 x, float y) => new vec4(min(x.X, y), min(x.Y, y), min(x.Z, y), min(x.W, y));

    // double min
    public static double min(double x, double y) => Math.Min(x, y);
    public static dvec2 min(dvec2 x, dvec2 y) => new dvec2(min(x.X, y.X), min(x.Y, y.Y));
    public static dvec3 min(dvec3 x, dvec3 y) => new dvec3(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z));
    public static dvec4 min(dvec4 x, dvec4 y) => new dvec4(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z), min(x.W, y.W));
    public static dvec2 min(dvec2 x, double y) => new dvec2(min(x.X, y), min(x.Y, y));
    public static dvec3 min(dvec3 x, double y) => new dvec3(min(x.X, y), min(x.Y, y), min(x.Z, y));
    public static dvec4 min(dvec4 x, double y) => new dvec4(min(x.X, y), min(x.Y, y), min(x.Z, y), min(x.W, y));

    // int min
    public static int min(int x, int y) => Math.Min(x, y);
    public static ivec2 min(ivec2 x, ivec2 y) => new ivec2(min(x.X, y.X), min(x.Y, y.Y));
    public static ivec3 min(ivec3 x, ivec3 y) => new ivec3(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z));
    public static ivec4 min(ivec4 x, ivec4 y) => new ivec4(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z), min(x.W, y.W));
    public static ivec2 min(ivec2 x, int y) => new ivec2(min(x.X, y), min(x.Y, y));
    public static ivec3 min(ivec3 x, int y) => new ivec3(min(x.X, y), min(x.Y, y), min(x.Z, y));
    public static ivec4 min(ivec4 x, int y) => new ivec4(min(x.X, y), min(x.Y, y), min(x.Z, y), min(x.W, y));

    // uint min
    public static uint min(uint x, uint y) => Math.Min(x, y);
    public static uvec2 min(uvec2 x, uvec2 y) => new uvec2(min(x.X, y.X), min(x.Y, y.Y));
    public static uvec3 min(uvec3 x, uvec3 y) => new uvec3(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z));
    public static uvec4 min(uvec4 x, uvec4 y) => new uvec4(min(x.X, y.X), min(x.Y, y.Y), min(x.Z, y.Z), min(x.W, y.W));
    public static uvec2 min(uvec2 x, uint y) => new uvec2(min(x.X, y), min(x.Y, y));
    public static uvec3 min(uvec3 x, uint y) => new uvec3(min(x.X, y), min(x.Y, y), min(x.Z, y));
    public static uvec4 min(uvec4 x, uint y) => new uvec4(min(x.X, y), min(x.Y, y), min(x.Z, y), min(x.W, y));

    // float max
    public static float max(float x, float y) => Math.Max(x, y);
    public static vec2 max(vec2 x, vec2 y) => new vec2(max(x.X, y.X), max(x.Y, y.Y));
    public static vec3 max(vec3 x, vec3 y) => new vec3(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z));
    public static vec4 max(vec4 x, vec4 y) => new vec4(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z), max(x.W, y.W));
    public static vec2 max(vec2 x, float y) => new vec2(max(x.X, y), max(x.Y, y));
    public static vec3 max(vec3 x, float y) => new vec3(max(x.X, y), max(x.Y, y), max(x.Z, y));
    public static vec4 max(vec4 x, float y) => new vec4(max(x.X, y), max(x.Y, y), max(x.Z, y), max(x.W, y));

    // double max
    public static double max(double x, double y) => Math.Max(x, y);
    public static dvec2 max(dvec2 x, dvec2 y) => new dvec2(max(x.X, y.X), max(x.Y, y.Y));
    public static dvec3 max(dvec3 x, dvec3 y) => new dvec3(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z));
    public static dvec4 max(dvec4 x, dvec4 y) => new dvec4(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z), max(x.W, y.W));
    public static dvec2 max(dvec2 x, double y) => new dvec2(max(x.X, y), max(x.Y, y));
    public static dvec3 max(dvec3 x, double y) => new dvec3(max(x.X, y), max(x.Y, y), max(x.Z, y));
    public static dvec4 max(dvec4 x, double y) => new dvec4(max(x.X, y), max(x.Y, y), max(x.Z, y), max(x.W, y));

    // int max
    public static int max(int x, int y) => Math.Max(x, y);
    public static ivec2 max(ivec2 x, ivec2 y) => new ivec2(max(x.X, y.X), max(x.Y, y.Y));
    public static ivec3 max(ivec3 x, ivec3 y) => new ivec3(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z));
    public static ivec4 max(ivec4 x, ivec4 y) => new ivec4(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z), max(x.W, y.W));
    public static ivec2 max(ivec2 x, int y) => new ivec2(max(x.X, y), max(x.Y, y));
    public static ivec3 max(ivec3 x, int y) => new ivec3(max(x.X, y), max(x.Y, y), max(x.Z, y));
    public static ivec4 max(ivec4 x, int y) => new ivec4(max(x.X, y), max(x.Y, y), max(x.Z, y), max(x.W, y));

    // uint max
    public static uint max(uint x, uint y) => Math.Max(x, y);
    public static uvec2 max(uvec2 x, uvec2 y) => new uvec2(max(x.X, y.X), max(x.Y, y.Y));
    public static uvec3 max(uvec3 x, uvec3 y) => new uvec3(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z));
    public static uvec4 max(uvec4 x, uvec4 y) => new uvec4(max(x.X, y.X), max(x.Y, y.Y), max(x.Z, y.Z), max(x.W, y.W));
    public static uvec2 max(uvec2 x, uint y) => new uvec2(max(x.X, y), max(x.Y, y));
    public static uvec3 max(uvec3 x, uint y) => new uvec3(max(x.X, y), max(x.Y, y), max(x.Z, y));
    public static uvec4 max(uvec4 x, uint y) => new uvec4(max(x.X, y), max(x.Y, y), max(x.Z, y), max(x.W, y));

    // float clamp
    public static float clamp(float x, float minVal, float maxVal) => MathHelper.Clamp(x, minVal, maxVal);
    public static vec2 clamp(vec2 x, vec2 minVal, vec2 maxVal) => new vec2(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y));
    public static vec3 clamp(vec3 x, vec3 minVal, vec3 maxVal) => new vec3(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z));
    public static vec4 clamp(vec4 x, vec4 minVal, vec4 maxVal) => new vec4(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z), clamp(x.W, minVal.W, maxVal.W));
    public static vec2 clamp(vec2 x, float minVal, float maxVal) => new vec2(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal));
    public static vec3 clamp(vec3 x, float minVal, float maxVal) => new vec3(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal));
    public static vec4 clamp(vec4 x, float minVal, float maxVal) => new vec4(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal), clamp(x.W, minVal, maxVal));

    // double clamp
    public static double clamp(double x, double minVal, double maxVal) => MathHelper.Clamp(x, minVal, maxVal);
    public static dvec2 clamp(dvec2 x, dvec2 minVal, dvec2 maxVal) => new dvec2(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y));
    public static dvec3 clamp(dvec3 x, dvec3 minVal, dvec3 maxVal) => new dvec3(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z));
    public static dvec4 clamp(dvec4 x, dvec4 minVal, dvec4 maxVal) => new dvec4(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z), clamp(x.W, minVal.W, maxVal.W));
    public static dvec2 clamp(dvec2 x, double minVal, double maxVal) => new dvec2(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal));
    public static dvec3 clamp(dvec3 x, double minVal, double maxVal) => new dvec3(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal));
    public static dvec4 clamp(dvec4 x, double minVal, double maxVal) => new dvec4(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal), clamp(x.W, minVal, maxVal));

    // int clamp
    public static int clamp(int x, int minVal, int maxVal) => MathHelper.Clamp(x, minVal, maxVal);
    public static ivec2 clamp(ivec2 x, ivec2 minVal, ivec2 maxVal) => new ivec2(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y));
    public static ivec3 clamp(ivec3 x, ivec3 minVal, ivec3 maxVal) => new ivec3(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z));
    public static ivec4 clamp(ivec4 x, ivec4 minVal, ivec4 maxVal) => new ivec4(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z), clamp(x.W, minVal.W, maxVal.W));
    public static ivec2 clamp(ivec2 x, int minVal, int maxVal) => new ivec2(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal));
    public static ivec3 clamp(ivec3 x, int minVal, int maxVal) => new ivec3(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal));
    public static ivec4 clamp(ivec4 x, int minVal, int maxVal) => new ivec4(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal), clamp(x.W, minVal, maxVal));

    // uint clamp
    public static uint clamp(uint x, uint minVal, uint maxVal) => MathHelper.Clamp(x, minVal, maxVal);
    public static uvec2 clamp(uvec2 x, uvec2 minVal, uvec2 maxVal) => new uvec2(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y));
    public static uvec3 clamp(uvec3 x, uvec3 minVal, uvec3 maxVal) => new uvec3(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z));
    public static uvec4 clamp(uvec4 x, uvec4 minVal, uvec4 maxVal) => new uvec4(clamp(x.X, minVal.X, maxVal.X), clamp(x.Y, minVal.Y, maxVal.Y), clamp(x.Z, minVal.Z, maxVal.Z), clamp(x.W, minVal.W, maxVal.W));
    public static uvec2 clamp(uvec2 x, uint minVal, uint maxVal) => new uvec2(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal));
    public static uvec3 clamp(uvec3 x, uint minVal, uint maxVal) => new uvec3(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal));
    public static uvec4 clamp(uvec4 x, uint minVal, uint maxVal) => new uvec4(clamp(x.X, minVal, maxVal), clamp(x.Y, minVal, maxVal), clamp(x.Z, minVal, maxVal), clamp(x.W, minVal, maxVal));

    // float saturate
    public static float saturate(float x) => MathHelper.Clamp(x, 0f, 1f);
    public static vec2 saturate(vec2 x) => new vec2(saturate(x.X), saturate(x.Y));
    public static vec3 saturate(vec3 x) => new vec3(saturate(x.X), saturate(x.Y), saturate(x.Z));
    public static vec4 saturate(vec4 x) => new vec4(saturate(x.X), saturate(x.Y), saturate(x.Z), saturate(x.W));

    // double saturate
    public static double saturate(double x) => MathHelper.Clamp(x, 0.0, 1.0);
    public static dvec2 saturate(dvec2 x) => new dvec2(saturate(x.X), saturate(x.Y));
    public static dvec3 saturate(dvec3 x) => new dvec3(saturate(x.X), saturate(x.Y), saturate(x.Z));
    public static dvec4 saturate(dvec4 x) => new dvec4(saturate(x.X), saturate(x.Y), saturate(x.Z), saturate(x.W));
    #endregion

    #region mix, lerp, step, smoothstep
    // float mix, lerp
    public static float mix(float x, float y, float a) => x * (1 - a) + y * a;
    public static vec2 mix(vec2 x, vec2 y, vec2 a) => new vec2(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y));
    public static vec3 mix(vec3 x, vec3 y, vec3 a) => new vec3(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z));
    public static vec4 mix(vec4 x, vec4 y, vec4 a) => new vec4(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z), mix(x.W, y.W, a.W));
    public static vec2 mix(vec2 x, float y, float a) => new vec2(mix(x.X, y, a), mix(x.Y, y, a));
    public static vec3 mix(vec3 x, float y, float a) => new vec3(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a));
    public static vec4 mix(vec4 x, float y, float a) => new vec4(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a), mix(x.W, y, a));
    public static float lerp(float x, float y, float a) => x + a * (y - x);
    public static vec2 lerp(vec2 x, vec2 y, vec2 a) => new vec2(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y));
    public static vec3 lerp(vec3 x, vec3 y, vec3 a) => new vec3(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z));
    public static vec4 lerp(vec4 x, vec4 y, vec4 a) => new vec4(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z), lerp(x.W, y.W, a.W));
    public static vec2 lerp(vec2 x, float y, float a) => new vec2(lerp(x.X, y, a), lerp(x.Y, y, a));
    public static vec3 lerp(vec3 x, float y, float a) => new vec3(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a));
    public static vec4 lerp(vec4 x, float y, float a) => new vec4(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a), lerp(x.W, y, a));

    // double mix, lerp
    public static double mix(double x, double y, double a) => x * (1 - a) + y * a;
    public static dvec2 mix(dvec2 x, dvec2 y, dvec2 a) => new dvec2(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y));
    public static dvec3 mix(dvec3 x, dvec3 y, dvec3 a) => new dvec3(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z));
    public static dvec4 mix(dvec4 x, dvec4 y, dvec4 a) => new dvec4(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z), mix(x.W, y.W, a.W));
    public static dvec2 mix(dvec2 x, double y, double a) => new dvec2(mix(x.X, y, a), mix(x.Y, y, a));
    public static dvec3 mix(dvec3 x, double y, double a) => new dvec3(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a));
    public static dvec4 mix(dvec4 x, double y, double a) => new dvec4(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a), mix(x.W, y, a));
    public static double lerp(double x, double y, double a) => x + a * (y - x);
    public static dvec2 lerp(dvec2 x, dvec2 y, dvec2 a) => new dvec2(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y));
    public static dvec3 lerp(dvec3 x, dvec3 y, dvec3 a) => new dvec3(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z));
    public static dvec4 lerp(dvec4 x, dvec4 y, dvec4 a) => new dvec4(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z), lerp(x.W, y.W, a.W));
    public static dvec2 lerp(dvec2 x, double y, double a) => new dvec2(lerp(x.X, y, a), lerp(x.Y, y, a));
    public static dvec3 lerp(dvec3 x, double y, double a) => new dvec3(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a));
    public static dvec4 lerp(dvec4 x, double y, double a) => new dvec4(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a), lerp(x.W, y, a));

    // int mix, lerp
    public static int mix(int x, int y, int a) => x * (1 - a) + y * a;
    public static ivec2 mix(ivec2 x, ivec2 y, ivec2 a) => new ivec2(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y));
    public static ivec3 mix(ivec3 x, ivec3 y, ivec3 a) => new ivec3(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z));
    public static ivec4 mix(ivec4 x, ivec4 y, ivec4 a) => new ivec4(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z), mix(x.W, y.W, a.W));
    public static ivec2 mix(ivec2 x, int y, int a) => new ivec2(mix(x.X, y, a), mix(x.Y, y, a));
    public static ivec3 mix(ivec3 x, int y, int a) => new ivec3(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a));
    public static ivec4 mix(ivec4 x, int y, int a) => new ivec4(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a), mix(x.W, y, a));
    public static int lerp(int x, int y, int a) => x + a * (y - x);
    public static ivec2 lerp(ivec2 x, ivec2 y, ivec2 a) => new ivec2(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y));
    public static ivec3 lerp(ivec3 x, ivec3 y, ivec3 a) => new ivec3(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z));
    public static ivec4 lerp(ivec4 x, ivec4 y, ivec4 a) => new ivec4(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z), lerp(x.W, y.W, a.W));
    public static ivec2 lerp(ivec2 x, int y, int a) => new ivec2(lerp(x.X, y, a), lerp(x.Y, y, a));
    public static ivec3 lerp(ivec3 x, int y, int a) => new ivec3(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a));
    public static ivec4 lerp(ivec4 x, int y, int a) => new ivec4(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a), lerp(x.W, y, a));

    // uint mix, lerp
    public static uint mix(uint x, uint y, uint a) => x * (1 - a) + y * a;
    public static uvec2 mix(uvec2 x, uvec2 y, uvec2 a) => new uvec2(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y));
    public static uvec3 mix(uvec3 x, uvec3 y, uvec3 a) => new uvec3(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z));
    public static uvec4 mix(uvec4 x, uvec4 y, uvec4 a) => new uvec4(mix(x.X, y.X, a.X), mix(x.Y, y.Y, a.Y), mix(x.Z, y.Z, a.Z), mix(x.W, y.W, a.W));
    public static uvec2 mix(uvec2 x, uint y, uint a) => new uvec2(mix(x.X, y, a), mix(x.Y, y, a));
    public static uvec3 mix(uvec3 x, uint y, uint a) => new uvec3(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a));
    public static uvec4 mix(uvec4 x, uint y, uint a) => new uvec4(mix(x.X, y, a), mix(x.Y, y, a), mix(x.Z, y, a), mix(x.W, y, a));
    public static uint lerp(uint x, uint y, uint a) => x + a * (y - x);
    public static uvec2 lerp(uvec2 x, uvec2 y, uvec2 a) => new uvec2(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y));
    public static uvec3 lerp(uvec3 x, uvec3 y, uvec3 a) => new uvec3(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z));
    public static uvec4 lerp(uvec4 x, uvec4 y, uvec4 a) => new uvec4(lerp(x.X, y.X, a.X), lerp(x.Y, y.Y, a.Y), lerp(x.Z, y.Z, a.Z), lerp(x.W, y.W, a.W));
    public static uvec2 lerp(uvec2 x, uint y, uint a) => new uvec2(lerp(x.X, y, a), lerp(x.Y, y, a));
    public static uvec3 lerp(uvec3 x, uint y, uint a) => new uvec3(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a));
    public static uvec4 lerp(uvec4 x, uint y, uint a) => new uvec4(lerp(x.X, y, a), lerp(x.Y, y, a), lerp(x.Z, y, a), lerp(x.W, y, a));

    // float step
    public static float step(float edge, float x) => (x >= edge ? 1 : 0);
    public static vec2 step(vec2 edge, vec2 x) => new vec2(step(edge.X, x.X), step(edge.Y, x.Y));
    public static vec3 step(vec3 edge, vec3 x) => new vec3(step(edge.X, x.X), step(edge.Y, x.Y), step(edge.Z, x.Z));
    public static vec4 step(vec4 edge, vec4 x) => new vec4(step(edge.X, x.X), step(edge.Y, x.Y), step(edge.Z, x.Z), step(edge.W, x.W));
    public static vec2 step(float edge, vec2 x) => new vec2(step(edge, x.X), step(edge, x.Y));
    public static vec3 step(float edge, vec3 x) => new vec3(step(edge, x.X), step(edge, x.Y), step(edge, x.Z));
    public static vec4 step(float edge, vec4 x) => new vec4(step(edge, x.X), step(edge, x.Y), step(edge, x.Z), step(edge, x.W));

    // double step
    public static double step(double edge, double x) => (x >= edge ? 1 : 0);
    public static dvec2 step(dvec2 edge, dvec2 x) => new dvec2(step(edge.X, x.X), step(edge.Y, x.Y));
    public static dvec3 step(dvec3 edge, dvec3 x) => new dvec3(step(edge.X, x.X), step(edge.Y, x.Y), step(edge.Z, x.Z));
    public static dvec4 step(dvec4 edge, dvec4 x) => new dvec4(step(edge.X, x.X), step(edge.Y, x.Y), step(edge.Z, x.Z), step(edge.W, x.W));
    public static dvec2 step(double edge, dvec2 x) => new dvec2(step(edge, x.X), step(edge, x.Y));
    public static dvec3 step(double edge, dvec3 x) => new dvec3(step(edge, x.X), step(edge, x.Y), step(edge, x.Z));
    public static dvec4 step(double edge, dvec4 x) => new dvec4(step(edge, x.X), step(edge, x.Y), step(edge, x.Z), step(edge, x.W));

    // float smoothstep
    public static float smoothstep(float edge0, float edge1, float x) { float t = saturate((x - edge0) / (edge1 - edge0)); return t * t * (3 - 2 * t); }
    public static vec2 smoothstep(vec2 edge0, vec2 edge1, vec2 x) => new vec2(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y));
    public static vec3 smoothstep(vec3 edge0, vec3 edge1, vec3 x) => new vec3(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y), smoothstep(edge0.Z, edge1.Z, x.Z));
    public static vec4 smoothstep(vec4 edge0, vec4 edge1, vec4 x) => new vec4(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y), smoothstep(edge0.Z, edge1.Z, x.Z), smoothstep(edge0.W, edge1.W, x.W));
    public static vec2 smoothstep(float edge0, float edge1, vec2 x) => new vec2(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y));
    public static vec3 smoothstep(float edge0, float edge1, vec3 x) => new vec3(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y), smoothstep(edge0, edge1, x.Z));
    public static vec4 smoothstep(float edge0, float edge1, vec4 x) => new vec4(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y), smoothstep(edge0, edge1, x.Z), smoothstep(edge0, edge1, x.W));

    // double smoothstep
    public static double smoothstep(double edge0, double edge1, double x) { double t = saturate((x - edge0) / (edge1 - edge0)); return t * t * (3 - 2 * t); }
    public static dvec2 smoothstep(dvec2 edge0, dvec2 edge1, dvec2 x) => new dvec2(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y));
    public static dvec3 smoothstep(dvec3 edge0, dvec3 edge1, dvec3 x) => new dvec3(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y), smoothstep(edge0.Z, edge1.Z, x.Z));
    public static dvec4 smoothstep(dvec4 edge0, dvec4 edge1, dvec4 x) => new dvec4(smoothstep(edge0.X, edge1.X, x.X), smoothstep(edge0.Y, edge1.Y, x.Y), smoothstep(edge0.Z, edge1.Z, x.Z), smoothstep(edge0.W, edge1.W, x.W));
    public static dvec2 smoothstep(double edge0, double edge1, dvec2 x) => new dvec2(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y));
    public static dvec3 smoothstep(double edge0, double edge1, dvec3 x) => new dvec3(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y), smoothstep(edge0, edge1, x.Z));
    public static dvec4 smoothstep(double edge0, double edge1, dvec4 x) => new dvec4(smoothstep(edge0, edge1, x.X), smoothstep(edge0, edge1, x.Y), smoothstep(edge0, edge1, x.Z), smoothstep(edge0, edge1, x.W));
    #endregion

    #region mad, fma, rcp, FindLSB, findMSB
    // mad
    public static float mad(float m, float a, float b) => m * a + b;
    public static double mad(double m, double a, double b) => m * a + b;
    public static int mad(int m, int a, int b) => m * a + b;
    public static uint mad(uint m, uint a, uint b) => m * a + b;

    // fma
    public static float fma(float a, float b, float c) => a * b + c;
    public static double fma(double a, double b, double c) => a * b + c;
    public static int fma(int a, int b, int c) => a * b + c;
    public static uint fma(uint a, uint b, uint c) => a * b + c;

    // rcp
    public static float fma(float x) => 1f / x;
    public static double fma(double x) => 1.0 / x;

    // int findLSB
    public static int findLSB(int x) => MathHelper.FindLSB(x);
    public static ivec2 findLSB(ivec2 x) => new Vector2i(findLSB(x.X), findLSB(x.Y));
    public static ivec3 findLSB(ivec3 x) => new Vector3i(findLSB(x.X), findLSB(x.Y), findLSB(x.Z));
    public static ivec4 findLSB(ivec4 x) => new Vector4i(findLSB(x.X), findLSB(x.Y), findLSB(x.Z), findLSB(x.W));

    // uint findLSB
    public static int findLSB(uint x) => MathHelper.FindLSB((int)x);
    public static ivec2 findLSB(uvec2 x) => new Vector2i(findLSB(x.X), findLSB(x.Y));
    public static ivec3 findLSB(uvec3 x) => new Vector3i(findLSB(x.X), findLSB(x.Y), findLSB(x.Z));
    public static ivec4 findLSB(uvec4 x) => new Vector4i(findLSB(x.X), findLSB(x.Y), findLSB(x.Z), findLSB(x.W));

    // int findMSB
    public static int findMSB(int x) => MathHelper.FindLSB(x);
    public static ivec2 findMSB(ivec2 x) => new Vector2i(findMSB(x.X), findMSB(x.Y));
    public static ivec3 findMSB(ivec3 x) => new Vector3i(findMSB(x.X), findMSB(x.Y), findMSB(x.Z));
    public static ivec4 findMSB(ivec4 x) => new Vector4i(findMSB(x.X), findMSB(x.Y), findMSB(x.Z), findMSB(x.W));

    // uint findMSB
    public static int findMSB(uint x) => MathHelper.FindLSB((int)x);
    public static ivec2 findMSB(uvec2 x) => new Vector2i(findMSB(x.X), findMSB(x.Y));
    public static ivec3 findMSB(uvec3 x) => new Vector3i(findMSB(x.X), findMSB(x.Y), findMSB(x.Z));
    public static ivec4 findMSB(uvec4 x) => new Vector4i(findMSB(x.X), findMSB(x.Y), findMSB(x.Z), findMSB(x.W));
    #endregion

    #region length, distance, dot, cross, normalize, reflect, refract, faceforward
    // float length
    public static float length(float x) => Math.Abs(x);
    public static float length(vec2 x) => x.Length;
    public static float length(vec3 x) => x.Length;
    public static float length(vec4 x) => x.Length;

    // double length
    public static double length(double x) => Math.Abs(x);
    public static double length(dvec2 x) => x.Length;
    public static double length(dvec3 x) => x.Length;
    public static double length(dvec4 x) => x.Length;

    // float dot
    public static float dot(float x, float y) => x * y;
    public static float dot(vec2 x, vec2 y) => Vector2.Dot(x, y);
    public static float dot(vec3 x, vec3 y) => Vector3.Dot(x, y);
    public static float dot(vec4 x, vec4 y) => Vector4.Dot(x, y);

    // double dot
    public static double dot(double x, double y) => x * y;
    public static double dot(dvec2 x, dvec2 y) => Vector2d.Dot(x, y);
    public static double dot(dvec3 x, dvec3 y) => Vector3d.Dot(x, y);
    public static double dot(dvec4 x, dvec4 y) => Vector4d.Dot(x, y);

    // int dot
    public static int dot(int x, int y) => x * y;
    public static int dot(ivec2 x, ivec2 y) => (x.X * y.X) + (x.Y * y.Y);
    public static int dot(ivec3 x, ivec3 y) => (x.X * y.X) + (x.Y * y.Y) + (x.Z * y.Z);
    public static int dot(ivec4 x, ivec4 y) => (x.X * y.X) + (x.Y * y.Y) + (x.Z * y.Z) + (x.W * y.W);

    // float cross
    public static vec3 cross(vec3 x, vec3 y) => Vector3.Cross(x, y);

    // double cross
    public static dvec3 cross(dvec3 x, dvec3 y) => Vector3d.Cross(x, y);

    // float normalize
    public static float normalize(float x) => 1f;
    public static vec2 normalize(vec2 x) => x.Normalized();
    public static vec3 normalize(vec3 x) => x.Normalized();
    public static vec4 normalize(vec4 x) => x.Normalized();

    // double normalize
    public static double normalize(double x) => 1.0;
    public static dvec2 normalize(dvec2 x) => x.Normalized();
    public static dvec3 normalize(dvec3 x) => x.Normalized();
    public static dvec4 normalize(dvec4 x) => x.Normalized();

    // float reflect
    public static float reflect(float I, float N) => I - 2f * dot(N, I) * N;
    public static vec2 reflect(vec2 I, vec2 N) => I - 2f * dot(N, I) * N;
    public static vec3 reflect(vec3 I, vec3 N) => I - 2f * dot(N, I) * N;
    public static vec4 reflect(vec4 I, vec4 N) => I - 2f * dot(N, I) * N;

    // double reflect
    public static double reflect(double I, double N) => I - 2.0 * dot(N, I) * N;
    public static dvec2 reflect(dvec2 I, dvec2 N) => I - 2.0 * dot(N, I) * N;
    public static dvec3 reflect(dvec3 I, dvec3 N) => I - 2.0 * dot(N, I) * N;
    public static dvec4 reflect(dvec4 I, dvec4 N) => I - 2.0 * dot(N, I) * N;

    // float refract
    public static float refract(float I, float N, float eta = 1) { float k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? 0 : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static vec2 refract(vec2 I, vec2 N, float eta = 1) { float k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector2.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static vec3 refract(vec3 I, vec3 N, float eta = 1) { float k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector3.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static vec4 refract(vec4 I, vec4 N, float eta = 1) { float k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector4.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }

    // double refract
    public static double refract(double I, double N, float eta = 1) { double k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? 0 : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static dvec2 refract(dvec2 I, dvec2 N, float eta = 1) { double k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector2d.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static dvec3 refract(dvec3 I, dvec3 N, float eta = 1) { double k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector3d.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }
    public static dvec4 refract(dvec4 I, dvec4 N, float eta = 1) { double k = 1 - eta * eta * (1 - dot(N, I) * dot(N, I)); return k < 0 ? Vector4d.Zero : eta * I - (eta * dot(N, I) + sqrt(k)) * N; }

    // float faceforward
    public static float faceforward(float I, float N, float Nref) => -N * sign(dot(I, Nref));
    public static vec2 faceforward(vec2 I, vec2 N, vec2 Nref) => -N * sign(dot(I, Nref));
    public static vec3 faceforward(vec3 I, vec3 N, vec3 Nref) => -N * sign(dot(I, Nref));
    public static vec4 faceforward(vec4 I, vec4 N, vec4 Nref) => -N * sign(dot(I, Nref));

    // double faceforward
    public static double faceforward(double I, double N, double Nref) => -N * sign(dot(I, Nref));
    public static dvec2 faceforward(dvec2 I, dvec2 N, dvec2 Nref) => -N * sign(dot(I, Nref));
    public static dvec3 faceforward(dvec3 I, dvec3 N, dvec3 Nref) => -N * sign(dot(I, Nref));
    public static dvec4 faceforward(dvec4 I, dvec4 N, dvec4 Nref) => -N * sign(dot(I, Nref));
    #endregion

    #region any, all, not, equal, notEqual, lessThan, lessThanEqual, greaterThan, greaterThanEqual
    // bool any
    public static bool any(bool x) => x;
    public static bool any(bvec2 x) => x.X | x.Y;
    public static bool any(bvec3 x) => x.X | x.Y | x.Z;
    public static bool any(bvec4 x) => x.X | x.Y | x.Z | x.W;

    // float any
    public static bool any(float x) => x != 0;
    public static bool any(vec2 x) => x.X != 0 | x.Y != 0;
    public static bool any(vec3 x) => x.X != 0 | x.Y != 0 | x.Z != 0;
    public static bool any(vec4 x) => x.X != 0 | x.Y != 0 | x.Z != 0 | x.W != 0;

    // double any
    public static bool any(double x) => x != 0;
    public static bool any(dvec2 x) => x.X != 0 | x.Y != 0;
    public static bool any(dvec3 x) => x.X != 0 | x.Y != 0 | x.Z != 0;
    public static bool any(dvec4 x) => x.X != 0 | x.Y != 0 | x.Z != 0 | x.W != 0;

    // int any
    public static bool any(int x) => x != 0;
    public static bool any(ivec2 x) => x.X != 0 | x.Y != 0;
    public static bool any(ivec3 x) => x.X != 0 | x.Y != 0 | x.Z != 0;
    public static bool any(ivec4 x) => x.X != 0 | x.Y != 0 | x.Z != 0 | x.W != 0;

    // uint any
    public static bool any(uint x) => x > 0;
    public static bool any(uvec2 x) => x.X > 0 | x.Y > 0;
    public static bool any(uvec3 x) => x.X > 0 | x.Y > 0 | x.Z > 0;
    public static bool any(uvec4 x) => x.X > 0 | x.Y > 0 | x.Z > 0 | x.W > 0;

    // bool all
    public static bool all(bool x) => x;
    public static bool all(bvec2 x) => x.X & x.Y;
    public static bool all(bvec3 x) => x.X & x.Y & x.Z;
    public static bool all(bvec4 x) => x.X & x.Y & x.Z & x.W;

    // float all
    public static bool all(float x) => x != 0;
    public static bool all(vec2 x) => x.X != 0 && x.Y != 0;
    public static bool all(vec3 x) => x.X != 0 && x.Y != 0 && x.Z != 0;
    public static bool all(vec4 x) => x.X != 0 && x.Y != 0 && x.Z != 0 && x.W != 0;

    // double all
    public static bool all(double x) => x != 0;
    public static bool all(dvec2 x) => x.X != 0 && x.Y != 0;
    public static bool all(dvec3 x) => x.X != 0 && x.Y != 0 && x.Z != 0;
    public static bool all(dvec4 x) => x.X != 0 && x.Y != 0 && x.Z != 0 && x.W != 0;

    // int all
    public static bool all(int x) => x != 0;
    public static bool all(ivec2 x) => x.X != 0 && x.Y != 0;
    public static bool all(ivec3 x) => x.X != 0 && x.Y != 0 && x.Z != 0;
    public static bool all(ivec4 x) => x.X != 0 && x.Y != 0 && x.Z != 0 && x.W != 0;

    // uint all
    public static bool all(uint x) => x > 0;
    public static bool all(uvec2 x) => x.X > 0 && x.Y > 0;
    public static bool all(uvec3 x) => x.X > 0 && x.Y > 0 && x.Z > 0;
    public static bool all(uvec4 x) => x.X > 0 && x.Y > 0 && x.Z > 0 && x.W > 0;

    // bool not
    public static bool not(bool x) => !x;
    public static bvec2 not(bvec2 x) => !x;
    public static bvec3 not(bvec3 x) => !x;
    public static bvec4 not(bvec4 x) => !x;

    // float equal
    public static bool equal(float x, float y) => x == y;
    public static Vector2b equal(vec2 x, vec2 y) => new Vector2b(x.X == y.X, x.Y == y.Y);
    public static Vector3b equal(vec3 x, vec3 y) => new Vector3b(x.X == y.X, x.Y == y.Y, x.Z == y.Z);
    public static Vector4b equal(vec4 x, vec4 y) => new Vector4b(x.X == y.X, x.Y == y.Y, x.Z == y.Z, x.W == y.W);

    // double equal
    public static bool equal(double x, double y) => x == y;
    public static Vector2b equal(dvec2 x, dvec2 y) => new Vector2b(x.X == y.X, x.Y == y.Y);
    public static Vector3b equal(dvec3 x, dvec3 y) => new Vector3b(x.X == y.X, x.Y == y.Y, x.Z == y.Z);
    public static Vector4b equal(dvec4 x, dvec4 y) => new Vector4b(x.X == y.X, x.Y == y.Y, x.Z == y.Z, x.W == y.W);

    // int equal
    public static bool equal(int x, int y) => x == y;
    public static Vector2b equal(ivec2 x, ivec2 y) => new Vector2b(x.X == y.X, x.Y == y.Y);
    public static Vector3b equal(ivec3 x, ivec3 y) => new Vector3b(x.X == y.X, x.Y == y.Y, x.Z == y.Z);
    public static Vector4b equal(ivec4 x, ivec4 y) => new Vector4b(x.X == y.X, x.Y == y.Y, x.Z == y.Z, x.W == y.W);

    // uint equal
    public static bool equal(uint x, uint y) => x == y;
    public static Vector2b equal(uvec2 x, uvec2 y) => new Vector2b(x.X == y.X, x.Y == y.Y);
    public static Vector3b equal(uvec3 x, uvec3 y) => new Vector3b(x.X == y.X, x.Y == y.Y, x.Z == y.Z);
    public static Vector4b equal(uvec4 x, uvec4 y) => new Vector4b(x.X == y.X, x.Y == y.Y, x.Z == y.Z, x.W == y.W);

    // float notEqual
    public static bool notEqual(float x, float y) => x != y;
    public static Vector2b notEqual(vec2 x, vec2 y) => new Vector2b(x.X != y.X, x.Y != y.Y);
    public static Vector3b notEqual(vec3 x, vec3 y) => new Vector3b(x.X != y.X, x.Y != y.Y, x.Z != y.Z);
    public static Vector4b notEqual(vec4 x, vec4 y) => new Vector4b(x.X != y.X, x.Y != y.Y, x.Z != y.Z, x.W != y.W);

    // double notEqual
    public static bool notEqual(double x, double y) => x != y;
    public static Vector2b notEqual(dvec2 x, dvec2 y) => new Vector2b(x.X != y.X, x.Y != y.Y);
    public static Vector3b notEqual(dvec3 x, dvec3 y) => new Vector3b(x.X != y.X, x.Y != y.Y, x.Z != y.Z);
    public static Vector4b notEqual(dvec4 x, dvec4 y) => new Vector4b(x.X != y.X, x.Y != y.Y, x.Z != y.Z, x.W != y.W);

    // int notEqual
    public static bool notEqual(int x, int y) => x != y;
    public static Vector2b notEqual(ivec2 x, ivec2 y) => new Vector2b(x.X != y.X, x.Y != y.Y);
    public static Vector3b notEqual(ivec3 x, ivec3 y) => new Vector3b(x.X != y.X, x.Y != y.Y, x.Z != y.Z);
    public static Vector4b notEqual(ivec4 x, ivec4 y) => new Vector4b(x.X != y.X, x.Y != y.Y, x.Z != y.Z, x.W != y.W);

    // uint notEqual
    public static bool notEqual(uint x, uint y) => x != y;
    public static Vector2b notEqual(uvec2 x, uvec2 y) => new Vector2b(x.X != y.X, x.Y != y.Y);
    public static Vector3b notEqual(uvec3 x, uvec3 y) => new Vector3b(x.X != y.X, x.Y != y.Y, x.Z != y.Z);
    public static Vector4b notEqual(uvec4 x, uvec4 y) => new Vector4b(x.X != y.X, x.Y != y.Y, x.Z != y.Z, x.W != y.W);

    // float lessThan
    public static bool lessThan(float x, float y) => x < y;
    public static Vector2b lessThan(vec2 x, vec2 y) => new Vector2b(x.X < y.X, x.Y < y.Y);
    public static Vector3b lessThan(vec3 x, vec3 y) => new Vector3b(x.X < y.X, x.Y < y.Y, x.Z < y.Z);
    public static Vector4b lessThan(vec4 x, vec4 y) => new Vector4b(x.X < y.X, x.Y < y.Y, x.Z < y.Z, x.W < y.W);

    // double lessThan
    public static bool lessThan(double x, double y) => x < y;
    public static Vector2b lessThan(dvec2 x, dvec2 y) => new Vector2b(x.X < y.X, x.Y < y.Y);
    public static Vector3b lessThan(dvec3 x, dvec3 y) => new Vector3b(x.X < y.X, x.Y < y.Y, x.Z < y.Z);
    public static Vector4b lessThan(dvec4 x, dvec4 y) => new Vector4b(x.X < y.X, x.Y < y.Y, x.Z < y.Z, x.W < y.W);

    // int lessThan
    public static bool lessThan(int x, int y) => x < y;
    public static Vector2b lessThan(ivec2 x, ivec2 y) => new Vector2b(x.X < y.X, x.Y < y.Y);
    public static Vector3b lessThan(ivec3 x, ivec3 y) => new Vector3b(x.X < y.X, x.Y < y.Y, x.Z < y.Z);
    public static Vector4b lessThan(ivec4 x, ivec4 y) => new Vector4b(x.X < y.X, x.Y < y.Y, x.Z < y.Z, x.W < y.W);

    // uint lessThan
    public static bool lessThan(uint x, uint y) => x < y;
    public static Vector2b lessThan(uvec2 x, uvec2 y) => new Vector2b(x.X < y.X, x.Y < y.Y);
    public static Vector3b lessThan(uvec3 x, uvec3 y) => new Vector3b(x.X < y.X, x.Y < y.Y, x.Z < y.Z);
    public static Vector4b lessThan(uvec4 x, uvec4 y) => new Vector4b(x.X < y.X, x.Y < y.Y, x.Z < y.Z, x.W < y.W);

    // float lessThanEqual
    public static bool lessThanEqual(float x, float y) => x <= y;
    public static Vector2b lessThanEqual(vec2 x, vec2 y) => new Vector2b(x.X <= y.X, x.Y <= y.Y);
    public static Vector3b lessThanEqual(vec3 x, vec3 y) => new Vector3b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z);
    public static Vector4b lessThanEqual(vec4 x, vec4 y) => new Vector4b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z, x.W <= y.W);

    // double lessThanEqual
    public static bool lessThanEqual(double x, double y) => x <= y;
    public static Vector2b lessThanEqual(dvec2 x, dvec2 y) => new Vector2b(x.X <= y.X, x.Y <= y.Y);
    public static Vector3b lessThanEqual(dvec3 x, dvec3 y) => new Vector3b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z);
    public static Vector4b lessThanEqual(dvec4 x, dvec4 y) => new Vector4b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z, x.W <= y.W);

    // int lessThanEqual
    public static bool lessThanEqual(int x, int y) => x <= y;
    public static Vector2b lessThanEqual(ivec2 x, ivec2 y) => new Vector2b(x.X <= y.X, x.Y <= y.Y);
    public static Vector3b lessThanEqual(ivec3 x, ivec3 y) => new Vector3b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z);
    public static Vector4b lessThanEqual(ivec4 x, ivec4 y) => new Vector4b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z, x.W <= y.W);

    // uint lessThanEqual
    public static bool lessThanEqual(uint x, uint y) => x <= y;
    public static Vector2b lessThanEqual(uvec2 x, uvec2 y) => new Vector2b(x.X <= y.X, x.Y <= y.Y);
    public static Vector3b lessThanEqual(uvec3 x, uvec3 y) => new Vector3b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z);
    public static Vector4b lessThanEqual(uvec4 x, uvec4 y) => new Vector4b(x.X <= y.X, x.Y <= y.Y, x.Z <= y.Z, x.W <= y.W);

    // float greaterThan
    public static bool greaterThan(float x, float y) => x > y;
    public static Vector2b greaterThan(vec2 x, vec2 y) => new Vector2b(x.X > y.X, x.Y > y.Y);
    public static Vector3b greaterThan(vec3 x, vec3 y) => new Vector3b(x.X > y.X, x.Y > y.Y, x.Z > y.Z);
    public static Vector4b greaterThan(vec4 x, vec4 y) => new Vector4b(x.X > y.X, x.Y > y.Y, x.Z > y.Z, x.W > y.W);

    // double greaterThan
    public static bool greaterThan(double x, double y) => x > y;
    public static Vector2b greaterThan(dvec2 x, dvec2 y) => new Vector2b(x.X > y.X, x.Y > y.Y);
    public static Vector3b greaterThan(dvec3 x, dvec3 y) => new Vector3b(x.X > y.X, x.Y > y.Y, x.Z > y.Z);
    public static Vector4b greaterThan(dvec4 x, dvec4 y) => new Vector4b(x.X > y.X, x.Y > y.Y, x.Z > y.Z, x.W > y.W);

    // int greaterThan
    public static bool greaterThan(int x, int y) => x > y;
    public static Vector2b greaterThan(ivec2 x, ivec2 y) => new Vector2b(x.X > y.X, x.Y > y.Y);
    public static Vector3b greaterThan(ivec3 x, ivec3 y) => new Vector3b(x.X > y.X, x.Y > y.Y, x.Z > y.Z);
    public static Vector4b greaterThan(ivec4 x, ivec4 y) => new Vector4b(x.X > y.X, x.Y > y.Y, x.Z > y.Z, x.W > y.W);

    // uint greaterThan
    public static bool greaterThan(uint x, uint y) => x > y;
    public static Vector2b greaterThan(uvec2 x, uvec2 y) => new Vector2b(x.X > y.X, x.Y > y.Y);
    public static Vector3b greaterThan(uvec3 x, uvec3 y) => new Vector3b(x.X > y.X, x.Y > y.Y, x.Z > y.Z);
    public static Vector4b greaterThan(uvec4 x, uvec4 y) => new Vector4b(x.X > y.X, x.Y > y.Y, x.Z > y.Z, x.W > y.W);

    // float greaterThanEqual
    public static bool greaterThanEqual(float x, float y) => x >= y;
    public static Vector2b greaterThanEqual(vec2 x, vec2 y) => new Vector2b(x.X >= y.X, x.Y >= y.Y);
    public static Vector3b greaterThanEqual(vec3 x, vec3 y) => new Vector3b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z);
    public static Vector4b greaterThanEqual(vec4 x, vec4 y) => new Vector4b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z, x.W >= y.W);

    // double greaterThanEqual
    public static bool greaterThanEqual(double x, double y) => x >= y;
    public static Vector2b greaterThanEqual(dvec2 x, dvec2 y) => new Vector2b(x.X >= y.X, x.Y >= y.Y);
    public static Vector3b greaterThanEqual(dvec3 x, dvec3 y) => new Vector3b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z);
    public static Vector4b greaterThanEqual(dvec4 x, dvec4 y) => new Vector4b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z, x.W >= y.W);

    // int greaterThanEqual
    public static bool greaterThanEqual(int x, int y) => x >= y;
    public static Vector2b greaterThanEqual(ivec2 x, ivec2 y) => new Vector2b(x.X >= y.X, x.Y >= y.Y);
    public static Vector3b greaterThanEqual(ivec3 x, ivec3 y) => new Vector3b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z);
    public static Vector4b greaterThanEqual(ivec4 x, ivec4 y) => new Vector4b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z, x.W >= y.W);

    // uint greaterThanEqual
    public static bool greaterThanEqual(uint x, uint y) => x >= y;
    public static Vector2b greaterThanEqual(uvec2 x, uvec2 y) => new Vector2b(x.X >= y.X, x.Y >= y.Y);
    public static Vector3b greaterThanEqual(uvec3 x, uvec3 y) => new Vector3b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z);
    public static Vector4b greaterThanEqual(uvec4 x, uvec4 y) => new Vector4b(x.X >= y.X, x.Y >= y.Y, x.Z >= y.Z, x.W >= y.W);
    #endregion

    #region asfloat, asdouble, asint, asuint, floatBitsToInt, floatBitsToUint, intBitsToFloat and uintBitsToFloat
    // float asfloat
    public static float asfloat(float x) => x;
    public static Vector2 asfloat(Vector2 x) => x;
    public static Vector3 asfloat(Vector3 x) => x;
    public static Vector4 asfloat(Vector4 x) => x;

    // int asfloat
    public static float asfloat(int x) => BitConverter.ToSingle(BitConverter.GetBytes(x), 0);
    public static Vector2 asfloat(Vector2i x) => new Vector2(asfloat(x.X), asfloat(x.Y));
    public static Vector3 asfloat(Vector3i x) => new Vector3(asfloat(x.X), asfloat(x.Y), asfloat(x.Z));
    public static Vector4 asfloat(Vector4i x) => new Vector4(asfloat(x.X), asfloat(x.Y), asfloat(x.Z), asfloat(x.W));

    // uint asfloat
    public static float asfloat(uint x) => BitConverter.ToSingle(BitConverter.GetBytes(x), 0);
    public static Vector2 asfloat(Vector2u x) => new Vector2(asfloat(x.X), asfloat(x.Y));
    public static Vector3 asfloat(Vector3u x) => new Vector3(asfloat(x.X), asfloat(x.Y), asfloat(x.Z));
    public static Vector4 asfloat(Vector4u x) => new Vector4(asfloat(x.X), asfloat(x.Y), asfloat(x.Z), asfloat(x.W));

    // double asdouble
    public static double asdouble(uint l, uint h) => BitConverter.Int64BitsToDouble(h << 32 | l);

    // float asint
    public static int asint(float x) => BitConverter.ToInt32(BitConverter.GetBytes(x), 0);
    public static Vector2i asint(Vector2 x) => new Vector2i(asint(x.X), asint(x.Y));
    public static Vector3i asint(Vector3 x) => new Vector3i(asint(x.X), asint(x.Y), asint(x.Z));
    public static Vector4i asint(Vector4 x) => new Vector4i(asint(x.X), asint(x.Y), asint(x.Z), asint(x.W));

    // uint asint
    public static int asint(uint x) => BitConverter.ToInt32(BitConverter.GetBytes(x), 0);
    public static Vector2i asint(Vector2u x) => new Vector2i(asint(x.X), asint(x.Y));
    public static Vector3i asint(Vector3u x) => new Vector3i(asint(x.X), asint(x.Y), asint(x.Z));
    public static Vector4i asint(Vector4u x) => new Vector4i(asint(x.X), asint(x.Y), asint(x.Z), asint(x.W));

    // float asuint
    public static uint asuint(float x) => BitConverter.ToUInt32(BitConverter.GetBytes(x), 0);
    public static Vector2u asuint(Vector2 x) => new Vector2u(asuint(x.X), asuint(x.Y));
    public static Vector3u asuint(Vector3 x) => new Vector3u(asuint(x.X), asuint(x.Y), asuint(x.Z));
    public static Vector4u asuint(Vector4 x) => new Vector4u(asuint(x.X), asuint(x.Y), asuint(x.Z), asuint(x.W));

    // uint asuint
    public static uint asuint(int x) => BitConverter.ToUInt32(BitConverter.GetBytes(x), 0);
    public static Vector2u asuint(Vector2i x) => new Vector2u(asuint(x.X), asuint(x.Y));
    public static Vector3u asuint(Vector3i x) => new Vector3u(asuint(x.X), asuint(x.Y), asuint(x.Z));
    public static Vector4u asuint(Vector4i x) => new Vector4u(asuint(x.X), asuint(x.Y), asuint(x.Z), asuint(x.W));

    // int, uint <=> float
    public static int floatBitsToInt(float x) => BitConverter.ToInt32(BitConverter.GetBytes(x), 0);
    public static uint floatBitsToUint(float x) => BitConverter.ToUInt32(BitConverter.GetBytes(x), 0);
    public static float intBitsToFloat(int x) => BitConverter.ToSingle(BitConverter.GetBytes(x), 0);
    public static float uintBitsToFloat(uint x) => BitConverter.ToSingle(BitConverter.GetBytes(x), 0);
    #endregion

    #region isfinite, isinf, isnan
    // isfinite
    public static bool isfinite(float x) => !float.IsInfinity(x);
    public static bool isfinite(double x) => !double.IsInfinity(x);

    // isinf
    public static bool isinf(float x) => float.IsInfinity(x);
    public static bool isinf(double x) => double.IsInfinity(x);

    // isnan
    public static bool isnan(float x) => float.IsNaN(x);
    public static bool isnan(double x) => double.IsNaN(x);
    #endregion

    #region dst, countbits, bitCount
    // float dst
    public static vec4 dst(vec4 x, vec4 y) => new vec4(1f, x.Y * y.Y, x.Z, y.W);

    // double dst
    public static dvec4 dst(dvec4 x, dvec4 y) => new dvec4(1.0, x.Y * y.Y, x.Z, y.W);

    // uint countbits
    public static uint countbits(uint x) => (uint)MathHelper.HammingWeight(x);
    public static uvec2 countbits(uvec2 x) => new Vector2u(countbits(x.X), countbits(x.Y));
    public static uvec3 countbits(uvec3 x) => new Vector3u(countbits(x.X), countbits(x.Y), countbits(x.Z));
    public static uvec4 countbits(uvec4 x) => new Vector4u(countbits(x.X), countbits(x.Y), countbits(x.Z), countbits(x.W));

    // int bitCount
    public static int bitCount(int x) => MathHelper.HammingWeight(x);
    public static ivec2 bitCount(ivec2 x) => new Vector2i(bitCount(x.X), bitCount(x.Y));
    public static ivec3 bitCount(ivec3 x) => new Vector3i(bitCount(x.X), bitCount(x.Y), bitCount(x.Z));
    public static ivec4 bitCount(ivec4 x) => new Vector4i(bitCount(x.X), bitCount(x.Y), bitCount(x.Z), bitCount(x.W));

    // uint bitCount
    public static int bitCount(uint x) => MathHelper.HammingWeight(x);
    public static ivec2 bitCount(uvec2 x) => new Vector2i(bitCount(x.X), bitCount(x.Y));
    public static ivec3 bitCount(uvec3 x) => new Vector3i(bitCount(x.X), bitCount(x.Y), bitCount(x.Z));
    public static ivec4 bitCount(uvec4 x) => new Vector4i(bitCount(x.X), bitCount(x.Y), bitCount(x.Z), bitCount(x.W));
    #endregion

    #region Matrices
    // float determinant
    public static float determinant(float x) => 1;
    public static float determinant(Matrix2 m) => m.Determinant;
    public static float determinant(Matrix3 m) => m.Determinant;
    public static float determinant(Matrix4 m) => m.Determinant;

    // double determinant
    public static double determinant(double x) => 1;
    public static double determinant(Matrix2d m) => m.Determinant;
    public static double determinant(Matrix3d m) => m.Determinant;
    public static double determinant(Matrix4d m) => m.Determinant;

    // float transpose
    public static Matrix2 transpose(Matrix2 m) => Matrix2.Transpose(m);
    public static Matrix3x2 transpose(Matrix2x3 m) => Matrix2x3.Transpose(m);
    public static Matrix4x2 transpose(Matrix2x4 m) => Matrix2x4.Transpose(m);
    public static Matrix2x3 transpose(Matrix3x2 m) => Matrix3x2.Transpose(m);
    public static Matrix3 transpose(Matrix3 m) => Matrix3.Transpose(m);
    public static Matrix4x3 transpose(Matrix3x4 m) => Matrix3x4.Transpose(m);
    public static Matrix2x4 transpose(Matrix4x2 m) => Matrix4x2.Transpose(m);
    public static Matrix3x4 transpose(Matrix4x3 m) => Matrix4x3.Transpose(m);
    public static Matrix4 transpose(Matrix4 m) => Matrix4.Transpose(m);

    // double transpose
    public static Matrix2d transpose(Matrix2d m) => Matrix2d.Transpose(m);
    public static Matrix3x2d transpose(Matrix2x3d m) => Matrix2x3d.Transpose(m);
    public static Matrix4x2d transpose(Matrix2x4d m) => Matrix2x4d.Transpose(m);
    public static Matrix2x3d transpose(Matrix3x2d m) => Matrix3x2d.Transpose(m);
    public static Matrix3d transpose(Matrix3d m) => Matrix3d.Transpose(m);
    public static Matrix4x3d transpose(Matrix3x4d m) => Matrix3x4d.Transpose(m);
    public static Matrix2x4d transpose(Matrix4x2d m) => Matrix4x2d.Transpose(m);
    public static Matrix3x4d transpose(Matrix4x3d m) => Matrix4x3d.Transpose(m);
    public static Matrix4d transpose(Matrix4d m) => Matrix4d.Transpose(m);

    // float matrixCompMult
    public static Matrix2 matrixCompMult(Matrix2 x, Matrix2 y) => new Matrix2(x.Row0 * y.Row0, x.Row1 * y.Row1);
    public static Matrix3 matrixCompMult(Matrix3 x, Matrix3 y) => new Matrix3(x.Row0 * y.Row0, x.Row1 * y.Row1, x.Row2 * y.Row2);
    public static Matrix4 matrixCompMult(Matrix4 x, Matrix4 y) => new Matrix4(x.Row0 * y.Row0, x.Row1 * y.Row1, x.Row2 * y.Row2, x.Row3 * y.Row3);

    // double matrixCompMult
    public static Matrix2d matrixCompMult(Matrix2d x, Matrix2d y) => new Matrix2d(x.Row0 * y.Row0, x.Row1 * y.Row1);
    public static Matrix3d matrixCompMult(Matrix3d x, Matrix3d y) => new Matrix3d(x.Row0 * y.Row0, x.Row1 * y.Row1, x.Row2 * y.Row2);
    public static Matrix4d matrixCompMult(Matrix4d x, Matrix4d y) => new Matrix4d(x.Row0 * y.Row0, x.Row1 * y.Row1, x.Row2 * y.Row2, x.Row3 * y.Row3);

    // float mul
    public static float mul(float x, float y) => x * y;
    public static Matrix2 mul(Matrix2 x, Matrix2 y) => x * y;
    public static Matrix3 mul(Matrix3 x, Matrix3 y) => x * y;
    public static Matrix4 mul(Matrix4 x, Matrix4 y) => x * y;

    // double mul
    public static double mul(double x, double y) => x * y;
    public static Matrix2d mul(Matrix2d x, Matrix2d y) => x * y;
    public static Matrix3d mul(Matrix3d x, Matrix3d y) => x * y;
    public static Matrix4d mul(Matrix4d x, Matrix4d y) => x * y;
    #endregion
}