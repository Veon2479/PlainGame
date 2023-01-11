using OpenTK.Graphics.OpenGL4;

namespace PlainGame;

public class Shader : IDisposable
{
    public readonly int Handle;
    public bool IsDisposed
    {
        get;
        private set;
    }

    public Shader(string vertPath, string fragPath)
    {
        IsDisposed = false;
        
        var vertSource = File.ReadAllText(vertPath);
        var fragSource = File.ReadAllText(fragPath);

        var vertShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertShader, vertSource);

        var fragShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragShader, fragSource);    

        GL.CompileShader(vertShader);
        GL.GetShader(vertShader, ShaderParameter.CompileStatus, out var code);
        if (code == 0)
        {
            var log = GL.GetShaderInfoLog(vertShader);
            Console.WriteLine("LOG: compiling vertex shader: ", log);
        }
        
        GL.CompileShader(fragShader);
        GL.GetShader(fragShader, ShaderParameter.CompileStatus, out code);
        if (code == 0)
        {
            var log = GL.GetShaderInfoLog(fragShader);
            Console.WriteLine("LOG: compiling fragment shader: ", log);
        }

        Handle = GL.CreateProgram();
        
        GL.AttachShader(Handle, vertShader);
        GL.AttachShader(Handle, fragShader);
        
        GL.LinkProgram(Handle);

        int program = 0;
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out code);
        if (code == 0)
        {
            var log = GL.GetProgramInfoLog(program);
            Console.WriteLine("LOG: getting shader program: ", log);
        }
        
        GL.DetachShader(Handle, vertShader);
        GL.DetachShader(Handle, fragShader);
        GL.DeleteShader(vertShader);
        GL.DeleteShader(fragShader);

    }

    public int GetAttribLocation(string attribName)
    {
        return GL.GetAttribLocation(Handle, attribName);
    }
    
    public void Use()
    {
        GL.UseProgram(Handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            GL.DeleteProgram(Handle);
            IsDisposed = true;
        }
    }
  
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);  
    }

    ~Shader()
    {
        Dispose(false);
    }
}