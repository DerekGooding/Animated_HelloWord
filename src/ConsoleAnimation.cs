using Figgle.Fonts;
using static System.Console;

namespace Animated_HelloWord;

internal class ConsoleAnimation
{
    public ConsoleAnimation(string text)
    {
        _animationText = FiggleFonts.Larry3d.Render(text);
        ForegroundColor = ConsoleColor.DarkBlue;
    }

    private readonly string _animationText;
    private CursorPositon _cursorPosition = new(0, 0);

    public static readonly int ColorCount = Enum.GetNames<ConsoleColor>().Length;

    internal void AnimateByDirection(AnimationType type)
    {
        if (type is AnimationType.LeftToRight or AnimationType.RightToLeft)
        {
            HandleHorizontal(type);
        }
        else
        {
            HandleVertical(type);
        }
        ForegroundColor = NextColor();
    }

    private void HandleHorizontal(AnimationType type)
    {
        var lines = _animationText.Split("\n");
        var maxWidth = lines.Max(l => l.Length);

        foreach (var col in (type == AnimationType.LeftToRight)
            ? Enumerable.Range(0, maxWidth)
            : Enumerable.Range(0, maxWidth).Reverse())
        {
            for (var row = 0; row < lines.Length; row++)
            {
                if (col >= lines[row].Length)
                    continue;

                _cursorPosition = new(col, row);
                SetPosition();

                Write(lines[row][col].ToString());

            }

            Thread.Sleep(1);
        }
    }
    private void HandleVertical(AnimationType type)
    {
        var Lines = type == AnimationType.TopToBottom
            ? _animationText.Split("\n")
            : [.. _animationText.Split("\n").Reverse()];

        _cursorPosition.Y = type == AnimationType.TopToBottom ? 0 : Lines.Length - 1;

        foreach (var line in Lines)
        {
            _cursorPosition.X = 0;
            SetPosition();

            foreach (var c in line.ToList())
            {
                SetPosition();
                Write(c.ToString());

                _cursorPosition.X++;
            }

            Thread.Sleep(20);

            _cursorPosition.Y += type == AnimationType.TopToBottom ? 1 : -1;
        }
    }

    private static ConsoleColor NextColor()
    {
        var index = (int)ForegroundColor;
        index++;
        if (index >= ColorCount)
            index = 1;
        return (ConsoleColor)index;
    }

    private void SetPosition()
    {
        if(_cursorPosition.X < BufferWidth)
            SetCursorPosition(_cursorPosition.X, _cursorPosition.Y);
    }
}
