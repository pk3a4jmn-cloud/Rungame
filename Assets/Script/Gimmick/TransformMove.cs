using UnityEngine;

public class TransformMove : MonoBehaviour

{

    [SerializeField] private float moveSpeed = 0.5f; // 移動速度

    [SerializeField] private float moveDistance = 0.5f; // 右へ進む距離

   

    void Update()

    {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

     
    }

}