using UnityEngine;

public class kirikaeblock : MonoBehaviour
{
    private static readonly Color color = new Color(0, 0, 0);
    float i = 0.0f;
    int j = 0; 
    [SerializeField]
    private SpriteRenderer sprite;



    // Update is called once per frame
    void Update()
    {
        if (j == 0)
        {
            sprite.color = new Color(i, i, i);
            i += 0.02f;
            if (i >= 0.98f)
            {
                j = 1;
            }
        }
        else
        {
            sprite.color = new Color(i, i, i);
            i -= 0.02f;
            if (i <= 0.02f)
            {
                j = 0;
            }
        }

        if(i < 0.4f)
        {
            gameObject.layer = 6;
        }
        if (i > 0.4f)
        {
            gameObject.layer = 7;
        }


    }
}
