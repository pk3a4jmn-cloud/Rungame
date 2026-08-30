using UnityEngine;


public class GoalGimmick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
           MainSceneManager.ChangeResult();
        }
    }
}
