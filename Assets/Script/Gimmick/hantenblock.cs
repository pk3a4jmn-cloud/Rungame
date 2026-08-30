using UnityEngine;

public class hantenblock : MonoBehaviour
{
    private static readonly Color color = new Color(0, 0, 0);
    float i = 0.0f;
    int mode = 0;
    [SerializeField]
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mode < 60)
        {  
        }
        else if (mode < 80)
        {
            i += 0.05f;
            if (mode == 70)
            {
                gameObject.layer = 7;
            }
        }
        else if (mode < 140)
        {
        }
        else if (mode < 160)
        {
            i -= 0.05f;
            if (mode == 150)
            {
                gameObject.layer = 6;
            }
        }
        else
        {
            mode = 0;
        }


            mode++;
        sprite.color = new Color(i, i, i);


    }
}