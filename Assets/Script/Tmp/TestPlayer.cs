using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wall;
    
    void Update()
    {
        player.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }    
}
