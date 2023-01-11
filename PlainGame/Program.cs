using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using PlainGame;

internal class Program
{
    public static void Main(string[] args)
    {
        var size = Monitors.GetPrimaryMonitor().ClientArea;
        var nativeWindowSettings = new NativeWindowSettings()
        {
            Size = size.Max, Title = "Plain Game", WindowState = WindowState.Fullscreen
        };
        using (var window = new CustomGameWindow(GameWindowSettings.Default, nativeWindowSettings))
        {
            window.Run();
        }
    }
}