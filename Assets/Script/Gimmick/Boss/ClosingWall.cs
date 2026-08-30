using UnityEngine;

public class ClosingWall : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefub;
    [SerializeField] private GameObject instanPoint;

    [SerializeField] private float closingSpeed = 5f;
    [SerializeField] private float wallLifeTime = 5f;

    public void InstanWall(int MyLayer)
    {
        GameObject wall = Instantiate(wallPrefub, instanPoint.transform.position, Quaternion.identity);

        //wallのlayerをBoss.csのOnTriggerで検知したcollliderのlayerに変更する
        wall.layer = MyLayer;

        Rigidbody2D rb = wall.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(closingSpeed * -1, 0);

        //wallの削除処理
        Destroy(wall, wallLifeTime);
    }
}
