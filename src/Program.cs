namespace Animated_HelloWorld;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var text = args.Length == 0 ? "Hello World! This is Awesome!" : args[0];

        var helloWorldAnimation = new ConsoleAnimation(text);
        Console.CursorVisible = false;

        while (true)
        {
            var direction = (AnimationType)Random.Shared.Next(0, 4);
            helloWorldAnimation.AnimateByDirection(direction);
        }
    }
}