using Figgle.Fonts;
using static System.Console;

namespace Animated_HelloWord;

internal class ConsoleAnimation
{
    public readonly string AnimationText;

    private CursorPositon _cursorPosition = new(0, 0);

    public static readonly int ColorCount = Enum.GetNames<ConsoleColor>().Length;

    public ConsoleAnimation(string text)
    {
        AnimationText = FiggleFonts.Larry3d.Render(text);
        ForegroundColor = ConsoleColor.DarkBlue;
    }

    internal void AnimateByDirection(AnimationType Animation = AnimationType.RightToLeft)
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

                    _cursorPosition = new(col, row);
                    SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                    Write(lines[row][col].ToString());

                }

                Thread.Sleep(1);

            }
        }
        else
        {
            var Lines = Animation == AnimationType.TopToBottom ? AnimationText.Split("\n") : [.. AnimationText.Split("\n").Reverse()];
            _cursorPosition.Y = (Animation == AnimationType.TopToBottom ? 0 : Lines.Length - 1);

            foreach (var line in Lines)
            {
                _cursorPosition.X = 0;
                SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);

                foreach (var c in line.ToList())
                {
                    SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);
                    Write(c.ToString());

                    _cursorPosition.X++;
                }

                Thread.Sleep(20);

                _cursorPosition.Y += (Animation == AnimationType.TopToBottom ? 1 : -1);
            }
        }
        ForegroundColor = NextColor();
    }

    private static ConsoleColor NextColor()
    {
        var index = (int)ForegroundColor;
        index++;
        if (index >= ColorCount)
            index = 1;
        return (ConsoleColor)index;
    }
}
