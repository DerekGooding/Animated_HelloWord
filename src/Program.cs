namespace Animated_HelloWord;

internal static class Program
{
    internal static void Main()
    {
        var helloWorldAnimation = new ConsoleAnimation("Hello World!");
        Console.CursorVisible = false;
        ConsoleColored.WriteLine(helloWorldAnimation.AnimationText, ConsoleColor.Cyan);

        while (true)
        {
            helloWorldAnimation.Write((AnimationType)Random.Shared.Next(0, 4));
        }
    }
}