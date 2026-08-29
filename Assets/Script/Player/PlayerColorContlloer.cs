using System;
using UnityEngine;

public class PlayerColorContlloer : MonoBehaviour
{
    
    private static readonly Color Black = new Color(0, 0, 0);
    private static readonly Color white = new Color(1, 1, 1);
    private static readonly Color Red = new Color(1,0,0);
    private static readonly Color Blue = new Color(0, 0, 1);
    private static readonly Color Yellow = new Color(1, 1, 0);
    private static readonly Color Green = new Color(0, 1, 0);
    private static readonly Color Purple = new Color(1, 0, 1);
    private static readonly Color Orange = new Color(1, 0.5f, 0);

    [SerializeField]
    private SpriteRenderer sprite;

    public static PlayerColorContlloer Instance { private set;get;}
    [SerializeField]
    private ColorWheelController colorWheelController;

    public ColorType colorType;
    void Awake()
    {
        Instance = this;
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        //  colorWheelController.SetColor(colorType);
        Debug.Log(color + "に色が変わったよ");


        switch (color) {

            case ColorType.Black:
                sprite.color = Black;
                break;
            case ColorType.white:
                sprite.color = white;
                break;
            case ColorType.Red:
                sprite.color = Red;
                break;
            case ColorType.Blue:
                sprite.color = Blue;
                break;
            case ColorType.Yellow:
                sprite.color = Yellow;
                break;
            case ColorType.Green:
                sprite.color = Green;
                break;
            case ColorType.Purple:
                sprite.color = Purple;
                break;
            case ColorType.Orange:
                sprite.color = Orange;
                break;



            default:
                break;

        }


    }
}
