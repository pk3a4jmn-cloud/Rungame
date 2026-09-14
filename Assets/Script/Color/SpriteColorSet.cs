using UnityEngine;

public class SpriteColorSet : MonoBehaviour
{

    [SerializeField]

    private SpriteRenderer sprite;

    private static readonly Color Black = new Color32(53, 53, 53, 255);

    private static readonly Color White = new Color32(241, 241, 241, 255);

    private static readonly Color Red = new Color32(255, 179, 179, 255);

    private static readonly Color Blue = new Color32(194, 237, 255, 255);

    private static readonly Color Yellow = new Color32(255, 244, 179, 255);

    private static readonly Color Green = new Color32(203, 230, 178, 255);

    private static readonly Color Purple = new Color32(239, 184, 255, 255);

    private static readonly Color Orange = new Color32(255, 196, 166, 255);

    private void Start()

    {

        UpdateColor();

    }

    public void UpdateColor()

    {

        switch (LayerMask.LayerToName(gameObject.layer))

        {

            case "ColorBlack":

                sprite.color = Black;

                break;

            case "ColorWhite":

                sprite.color = White;

                break;

            case "ColorRed":

                sprite.color = Red;

                break;

            case "ColorBlue":

                sprite.color = Blue;

                break;

            case "ColorYellow":

                sprite.color = Yellow;

                break;

            case "ColorGreen":

                sprite.color = Green;

                break;

            case "ColorPurple":

                sprite.color = Purple;

                break;

            case "ColorOrange":

                sprite.color = Orange;

                break;

        }

    }

}