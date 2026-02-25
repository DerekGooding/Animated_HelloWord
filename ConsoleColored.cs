using static System.Console;

namespace Animated_HelloWord;

internal static class ConsoleColored
{
    internal static void Write(object value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
        Console.Write(value);
        ResetColor();
    }

    internal static void WriteLine(object? value = null, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        ConsoleColored.Write(value, foregroundColor, backgroundColor);
        Console.WriteLine();
    }
}
