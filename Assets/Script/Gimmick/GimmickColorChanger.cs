using UnityEngine;

public class GimmickColorChanger : MonoBehaviour
{
     public ColorType targetColorType;
     PlayerColorContlloer playerColorContlloer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerColorContlloer.Instance.ChangeColor(targetColorType);
        }
    }
}
