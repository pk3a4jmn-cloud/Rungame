using UnityEngine;

public class StageScroller : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}