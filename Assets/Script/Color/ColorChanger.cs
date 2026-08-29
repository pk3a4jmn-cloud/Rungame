using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.layer = this.gameObject.layer;
        }
    }
}
