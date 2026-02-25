namespace Animated_HelloWord;

internal static class Program
{
    internal static void Main()
    {
        Console.CursorVisible = false;
        ConsoleColored.WriteLine(ConsoleAnimation.AnimationText, ConsoleColor.Cyan);

        while (true)
        {
            var Animation =
                ConsoleAnimation.FromInt<ConsoleAnimation.AnimationType>(Random.Shared.Next(0, 4));
            ConsoleAnimation.Write(Animation);
        }
    }
}