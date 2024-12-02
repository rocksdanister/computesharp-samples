using Microsoft.Graphics.Canvas.UI.Xaml;

namespace D2D1Shader.UWP.Shaders.Runners;

/// <summary>
/// An interface for a shader runner to be used with a Win2D renderer.
/// </summary>
public interface ID2D1ShaderRunner
{
    /// <summary>
    /// Draws a new frame on a target <see cref="ICanvasAnimatedControl"/> instance.
    /// </summary>
    void Execute(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, float resolutionScale);
}
