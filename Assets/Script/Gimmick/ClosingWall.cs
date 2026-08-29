using System.Collections;
using UnityEngine;

public class ClosingWall : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefub;
    [SerializeField] private GameObject instanPoint;

    [SerializeField] private float closingSpeed = 5f;
    [SerializeField] private float closingDistance = 10f;

    private void Start()
    {
        StartCoroutine(CloseWall());
    }

    IEnumerator CloseWall()
    {
        while (true)
        {
            InstanWall();
            //Debug.Log("壁が閉じるよ");

            yield return new WaitForSeconds(closingDistance);
        }
    }

    void InstanWall()
    {
        GameObject wall = Instantiate(wallPrefub, instanPoint.transform.position, Quaternion.identity);

        Rigidbody2D rb = wall.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(closingSpeed, 0);
        //wall.transform.position += new Vector3(0, closingSpeed * Time.deltaTime, 0);

    }
}
