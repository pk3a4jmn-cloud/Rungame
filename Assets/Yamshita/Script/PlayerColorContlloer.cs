using System;
using UnityEngine;

public class PlayerColorContlloer : MonoBehaviour
{
    public static PlayerColorContlloer Instance { private set;get;}

    public ColorType colorType;
    void Awake()
    {
        Instance = this;
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        Debug.Log("色が変わったよ");
    }
}
