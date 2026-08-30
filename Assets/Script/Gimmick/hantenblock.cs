using UnityEngine;

public class hantenblock : MonoBehaviour
{
    public ColorType Color1;
    public ColorType Color2;
    Color c1;
    Color c2;

    float i = 0.0f;
    double count;
    public float 切り替え秒数 = 1;
    float f;
    int layer1 = 0;
    int layer2 = 0;

    private static readonly Color Black = new Color(0, 0, 0);
    private static readonly Color white = new Color(1, 1, 1);
    private static readonly Color Red = new Color(1, 0, 0);
    private static readonly Color Blue = new Color(0, 0, 1);
    private static readonly Color Yellow = new Color(1, 1, 0);
    private static readonly Color Green = new Color(0, 1, 0);
    private static readonly Color Purple = new Color(1, 0, 1);
    private static readonly Color Orange = new Color(1, 0.5f, 0);





    [SerializeField]
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        f = 切り替え秒数 * 60;

        switch (Color1)
        {
            case ColorType.Black: c1 = new Color(0, 0, 0);  layer1 = 6; break;
            case ColorType.white: c1 = new Color(1, 1, 1);  layer1 = 7; break;
            case ColorType.Red: c1 = new Color(1, 0, 0);    layer1 = 8; break;
            case ColorType.Blue: c1 = new Color(0, 0, 1);   layer1 = 9; break;
            case ColorType.Yellow: c1 = new Color(1, 1, 0); layer1 = 10; break;
            case ColorType.Green: c1 = new Color(0, 1, 0);  layer1 = 11; break;
            case ColorType.Purple: c1 = new Color(1, 0, 1); layer1 = 12; break;
            case ColorType.Orange: c1 = new Color(1, 0.5f, 0); layer1 = 13; break;
        }
        switch (Color2)
        {
            case ColorType.Black: c2 = new Color(0, 0, 0);  layer2 = 6; break;
            case ColorType.white: c2 = new Color(1, 1, 1);  layer2 = 7; break;
            case ColorType.Red: c2 = new Color(1, 0, 0);    layer2 = 8; break;
            case ColorType.Blue: c2 = new Color(0, 0, 1);   layer2 = 9; break;
            case ColorType.Yellow: c2 = new Color(1, 1, 0); layer2 = 10; break;
            case ColorType.Green: c2 = new Color(0, 1, 0);  layer2 = 11; break;
            case ColorType.Purple: c2 = new Color(1, 0, 1); layer2 = 12; break;
            case ColorType.Orange: c2 = new Color(1, 0.5f, 0); layer2 = 13; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if(count < f)
        {  
        }
        else if (count < f + 10)
        {
            i += 0.1f;
            if (count == f + 5)
            {
                gameObject.layer = layer2;
            }
        }
        else if (count < f + 10 + f)
        {
        }
        else if (count < f + 10 + f + 10)
        {
            i -= 0.1f;
            if (count == f + 10 + f + 5)
            {
                gameObject.layer = layer1;
            }
        }
        else
        {
            count = 0;
        }


        count++;
        sprite.color = new Color(c1.r * i + c2.r * (1.0f - i)
                               , c1.g * i + c2.g * (1.0f - i)
                               , c1.b * i + c2.b * (1.0f - i));

    }
}