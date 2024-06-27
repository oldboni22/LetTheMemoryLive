using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class EnumerableExtentions
{
    private static readonly System.Random Rng = new();
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> @enum)
    {
        return @enum.OrderBy(d => Rng.Next());
    }
}

public static class ButtonExtensions
{
    public static void ToggleAll(this IEnumerable<AnswerButton> buttons, bool state)
    {
        foreach (var button in buttons)
            button.Button.interactable = state;
    }
}


public static class StringExtensions
{
    public static IEnumerable<string> Sort(this IEnumerable<string> elements)
    {
        return elements.OrderBy(el => el);
    }
}
