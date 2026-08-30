using System;
using UnityEngine;

public class PlayerColorContlloer : MonoBehaviour
{
    
    private static readonly Color Black = new Color32(53, 53, 53,255);
    private static readonly Color white = new Color32(241, 241, 241,255);
    private static readonly Color Red = new Color32(255,179,179,255);
    private static readonly Color Blue = new Color32(194, 237, 255,255);
    private static readonly Color Yellow = new Color32(255, 244, 179,255);
    private static readonly Color Green = new Color32(203, 230, 178,255);
    private static readonly Color Purple = new Color32(239, 184, 255,255);
    private static readonly Color Orange = new Color32(255, 196, 166,255);

    [SerializeField]
    private SpriteRenderer sprite;

    public static PlayerColorContlloer Instance { private set;get;}
    [SerializeField]
    private ColorWheelController colorWheelController;

    public ColorType colorType = ColorType.white;
    void Start()
    {
        ChangeColor(colorType);
    }
    void Awake()
    {
        Instance = this;
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        colorWheelController?.SetColor(colorType);
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
