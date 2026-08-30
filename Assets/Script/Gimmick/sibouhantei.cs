using UnityEngine;

public class sibouhantei : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("死にました(敵の攻撃)");
            collider.GetComponent<Player>().shibou();

        }
    }
}
