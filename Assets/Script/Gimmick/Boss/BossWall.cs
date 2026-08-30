using UnityEngine;

public class BossWall : MonoBehaviour
{
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
