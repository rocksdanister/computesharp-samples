using ComputeSharp;
using ComputeSharp.D2D1;

namespace D2D1Shader.UWP.Shaders
{
    [D2DInputCount(1)]
    [D2DInputComplex(0)]
    [D2DRequiresScenePosition]
    [D2DShaderProfile(D2D1ShaderProfile.PixelShader50)]
    [D2DGeneratedPixelShaderDescriptor]
    [AutoConstructor]
    public readonly partial struct BasicShader : ID2D1PixelShader
    {
        private readonly int2 dispatchSize;

        private readonly int2 textureSize;

        /// <inheritdoc/>
        public float4 Execute()
        {
            float2 uv = D2D.GetScenePosition().XY / (float2)dispatchSize;

            float4 color = D2D.SampleInput(0, uv);

            return color;
        }
    }
}

// Temporary fix CS0122: 'SkipLocalsInitAttribute' is inaccessible due to its protection level
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, Inherited = false)]
    public sealed class SkipLocalsInitAttribute : Attribute
    {
    }
}