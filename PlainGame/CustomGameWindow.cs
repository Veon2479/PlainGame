using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace PlainGame;

public class CustomGameWindow : GameWindow
{
    public CustomGameWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        for (var i = 0; i < _vertices.Length; i++)
        {
            _vertices[i] = (float) (1 - 2 * Random.Shared.NextDouble());
        }
    }

    private readonly float[] _vertices = new float[9];
    private int _vbo;
    private int _vao;

    private Shader? _shader;
    
    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor((float)Random.Shared.NextDouble(),
            (float)Random.Shared.NextDouble(),
            (float)Random.Shared.NextDouble(),
            (float)Random.Shared.NextDouble());
        
        _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");

        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);   

        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length*sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3*sizeof(float), _shader.GetAttribLocation("aPosition"));
        GL.EnableVertexAttribArray(0);
        
        _shader.Use();

        
        
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        
        _shader!.Dispose();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        GL.UseProgram(_shader!.Handle);
        GL.BindVertexArray(_vao);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        
        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
        var input = KeyboardState;
        if (input != null)
        {
            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        
        GL.Viewport(0, 0, e.Width, e.Height);
    }
}