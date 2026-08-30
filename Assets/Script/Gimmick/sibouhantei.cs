using UnityEngine;

public class sibouhantei : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("死にました(敵の攻撃)");
    }
}
