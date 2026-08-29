using UnityEngine;

public class teki : MonoBehaviour
{
    GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.Find("camerablock");
    }

    // Update is called once per frame
    void Update()
    {

        //カメラが近づいたら動作開始 右にまっすぐ進む
        if (camera.transform.position.x - 10.0f < this.transform.position.x)
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.10f, this.transform.position.y, 0);
        }
        //画面の左に出たら消える
        if (camera.transform.position.x + 10.0f < this.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
