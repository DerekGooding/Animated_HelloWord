namespace Animated_HelloWord;

internal static class ConsoleColored
{
    internal static void Write(
        string value,
        ConsoleColor foregroundColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        Console.Write(value);
        Console.ResetColor();
    }

    internal static void WriteLine(
        string value,
        ConsoleColor foregroundColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
        => Write(value + Environment.NewLine, foregroundColor, backgroundColor);
}
