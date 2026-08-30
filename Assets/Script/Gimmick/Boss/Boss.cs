using UnityEngine;

public class Boss : MonoBehaviour
{
    private void Start()
    {
        BossAwake();
    }

    private void BossAwake()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // プレイヤーがボスに当たったときの処理
            Debug.Log("プレイヤーがボスに当たった！");
        }
    }
}
