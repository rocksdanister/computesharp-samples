using ComputeSharp.D2D1.Uwp;
using D2D1Shader.UWP.Helpers;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.IO;
using Windows.Foundation;

namespace D2D1Shader.UWP.Shaders.Runners;

public sealed class BasicShaderRunner : ID2D1ShaderRunner, IDisposable
{
    private CanvasBitmap texture;
    private readonly PixelShaderEffect<BasicShader>? pixelShaderEffect;

    public BasicShaderRunner()
    {
        this.pixelShaderEffect = new PixelShaderEffect<BasicShader>();
    }

    public void Execute(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, float resolutionScale)
    {
        var canvasSize = sender.Size;
        var renderSize = new Size(canvasSize.Width * resolutionScale, canvasSize.Height * resolutionScale);

        int widthInPixels = sender.ConvertDipsToPixels((float)renderSize.Width, CanvasDpiRounding.Round);
        int heightInPixels = sender.ConvertDipsToPixels((float)renderSize.Height, CanvasDpiRounding.Round);

        this.texture ??= ComputeSharpUtil.CreateCanvasBitmapOrPlaceholder(sender, 
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pexels-stywo-1772973.jpg"));
        this.pixelShaderEffect.Sources[0] = texture;

        this.pixelShaderEffect.ConstantBuffer = new BasicShader(
           new int2(widthInPixels, heightInPixels),
           new int2((int)texture.SizeInPixels.Width, (int)texture.SizeInPixels.Height));

        args.DrawingSession.DrawImage(image: this.pixelShaderEffect,
            destinationRectangle: new Rect(0, 0, canvasSize.Width, canvasSize.Height),
            sourceRectangle: new Rect(0, 0, renderSize.Width, renderSize.Height));
    }

    public void Dispose()
    {
        this.pixelShaderEffect?.Dispose();
    }
}
