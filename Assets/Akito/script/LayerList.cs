using System.Collections.Generic;
using UnityEngine;

public class Layerlist : MonoBehaviour
{
    public readonly Dictionary<Color, LayerMask> LayerTypes = new()
    {
        { Color.white, LayerMask.GetMask("White") },
        { Color.black, LayerMask.GetMask("Black") },
    };
}
