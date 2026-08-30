using UnityEngine;

public class ClosingWallFlag : MonoBehaviour
{
    public ClosingWall closingWall;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            int MyLayer = this.gameObject.layer;

            //せまる壁の生成処理
            closingWall.InstanWall(MyLayer);

            Debug.Log("せまる壁の生成");
        }
    }
}
