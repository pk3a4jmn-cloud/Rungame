using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColorWheelController : MonoBehaviour
{
    
    [SerializeField]
    private List<Transform> grid;
    public void SetColor(ColorType colorType)
    {
        grid.ForEach(t => t.localScale = Vector3.one * 0.5f);
        grid[(int)colorType].localScale = Vector3.one;
        grid[(int)ColorGridUtility.GetReverseColor(colorType)].localScale = Vector3.one;
    }
}
