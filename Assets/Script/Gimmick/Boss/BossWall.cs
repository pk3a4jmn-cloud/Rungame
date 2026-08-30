using UnityEngine;

public class BossWall : MonoBehaviour
{
    private static readonly Color Black = new Color32(53, 53, 53,255);
    private static readonly Color white = new Color32(241, 241, 241,255);
    private static readonly Color Red = new Color32(255,179,179,255);
    private static readonly Color Blue = new Color32(194, 237, 255,255);
    private static readonly Color Yellow = new Color32(255, 244, 179,255);
    private static readonly Color Green = new Color32(203, 230, 178,255);
    private static readonly Color Purple = new Color32(239, 184, 255,255);
    private static readonly Color Orange = new Color32(255, 196, 166,255);

    private Color[] _colors = new Color[] { Black, white, Red, Blue, Yellow, Green, Purple, Orange };

    [SerializeField] private SpriteRenderer render;

    private void Start()
    {
        var layer = gameObject.layer;
        render.color = _colors[layer - 6];
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.gameObject.layer == gameObject.layer)
            {
                return;
            }
            else
            {
                //ゲームオーバー処理
                Debug.Log("ゲームオーバー");
            }
        }
    }
}
