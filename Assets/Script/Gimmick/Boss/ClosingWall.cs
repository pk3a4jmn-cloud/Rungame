using System.Collections;
using UnityEngine;

public class ClosingWall : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefub;
    [SerializeField] private GameObject instanPoint;

    [SerializeField] private float closingSpeed = 5f;
    [SerializeField] private float wallLifeTime = 5f;
    [SerializeField] private float startDelay = 0.5f;

    public void InstanWall(int MyLayer)
    {
        StartCoroutine(SpawnWall(MyLayer));
    }

    private IEnumerator SpawnWall(int MyLayer)
    {
        GameObject wall = Instantiate(
            wallPrefub,
            instanPoint.transform.position,
            Quaternion.identity
        );

        wall.layer = MyLayer;

        Rigidbody2D rb = wall.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(startDelay);

        rb.linearVelocity = new Vector2(-closingSpeed, 0);

        Destroy(wall, wallLifeTime);
    }
}