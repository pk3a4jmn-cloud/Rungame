using System;
using UnityEngine;

public class PlayerColorContlloer : MonoBehaviour
{
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
        //colorWheelController.SetColor(colorType);
        Debug.Log(color+"に色が変わったよ");
    }
}
