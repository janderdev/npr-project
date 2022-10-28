using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace NprProject
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "NPR Project",
            };

            using (var game = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                game.Run();
            }
        }
    }
}
