using System.Collections.Generic;
using UnityEngine;

public static class ColorGridUtility
{
    private static readonly  Dictionary<ColorType , ColorType> ReverseColors;

    static ColorGridUtility()
    {
        ReverseColors = new Dictionary<ColorType ,ColorType>
        {
            { ColorType.Black, ColorType.white},
            { ColorType.white, ColorType.Black},
            { ColorType.Red, ColorType.Green},
            { ColorType.Green, ColorType.Red},
            { ColorType.Blue, ColorType.Orange},
            { ColorType.Orange, ColorType.Blue},
            { ColorType.Yellow, ColorType.Purple},
            { ColorType.Purple, ColorType.Yellow}
        };
    }
    public static ColorType GetReverseColor(ColorType colorType)
    {
        return ReverseColors[colorType];
    }
}
 