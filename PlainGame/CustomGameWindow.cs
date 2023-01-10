using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace PlainGame;

public class CustomGameWindow : GameWindow
{
    public CustomGameWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
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
}