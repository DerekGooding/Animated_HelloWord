using Figgle.Fonts;
using static System.Console;

namespace Animated_HelloWord;

internal static class ConsoleAnimation
{
    public static string AnimationText = FiggleFonts.Larry3d.Render("Hello World!");
    private static readonly CursorPositon _cursorPosition = new(0, 0);
    private static int _curentColor = 1;

    public static void Write(AnimationType Animation = AnimationType.RightToLeft)
    {
        if (Animation is AnimationType.LeftToRight or AnimationType.RightToLeft)
        {
            var lines = AnimationText.Split("\n");
            var maxWidth = lines.Max(l => l.Length);

            foreach (var col in (Animation == AnimationType.LeftToRight) ? Enumerable.Range(0, maxWidth) : Enumerable.Range(0, maxWidth).Reverse())
            {
                for (var row = 0; row < lines.Length; row++)
                {
                    if (col >= lines[row].Length)
                        continue;

                    _cursorPosition.X = col;
                    _cursorPosition.Y = row;
                    SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                    ConsoleColored.Write(lines[row][col], FromInt<ConsoleColor>(_curentColor));

                }

                Thread.Sleep(1);

            }
        }
        else
        {
            var Lines = (Animation == AnimationType.TopToBottom ? AnimationText.Split("\n") : AnimationText.Split("\n").Reverse().ToArray());
            _cursorPosition.Y = (Animation == AnimationType.TopToBottom ? 0 : Lines.Length - 1);

            foreach (var line in Lines)
            {
                _cursorPosition.X = 0;
                SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                foreach (var c in line.ToList())
                {
                    SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);
                    ConsoleColored.Write(c, FromInt<ConsoleColor>(_curentColor));

                    _cursorPosition.X++;
                }

                Thread.Sleep(20);

                _cursorPosition.Y += (Animation == AnimationType.TopToBottom ? 1 : -1);
            }
        }
        GetNextColor();
    }

    private static void GetNextColor()
    {
        var ColorCount = Enum.GetNames<ConsoleColor>().Length;
        _curentColor++;
        if (_curentColor >= ColorCount)
            _curentColor = 1;
    }

    public static T FromInt<T>(int intValue) where T : Enum => (T)Enum.ToObject(typeof(T), intValue);

    private class CursorPositon(int X, int Y)
    {
        public int X { get; set; } = X;
        public int Y { get; set; } = Y;
    }

    public enum AnimationType
    {
        LeftToRight = 0,
        RightToLeft = 1,
        TopToBottom = 2,
        BottomToTop = 3
    }

}
