using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("死にました(敵の攻撃)");
            collider.GetComponent<PlayerController>().shibou();

        }
    }
}