using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{ 
    int jimen = 0;

    float jumpForce = 600f;

    Rigidbody2D rb;
    GameObject camera;

    int jumpstart = 0;

    int g = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();

        camera = GameObject.Find("camerablock");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーを右に動かす
        this.transform.position = new Vector3(this.transform.position.x - 0.05f, this.transform.position.y, 0);
        
        //カメラを右に動かす
        //メインカメラと親子になっているカメラ操作用ブロックを動かしています。(メインカメラの動かし方が分からない為)
        camera.transform.position = new Vector3(camera.transform.position.x - 0.05f, camera.transform.position.y, 0);
        
        if(camera.transform.position.x + 2.0f < this.transform.position.x)
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.02f, this.transform.position.y, 0);
        }

            //zキーでジャンプ 地面に立っている時のみ
            //マリオみたいにボタンを押す長さでジャンプ力を変える
            if (Keyboard.current.zKey.wasPressedThisFrame && jimen == 1)
        {
            jimen = 0;
            jumpstart = 20;
            if (rb.gravityScale > 0.0f)
            {
                this.rb.AddForce(transform.up * this.jumpForce);
            }
            else
            {
                this.rb.AddForce(transform.up * -this.jumpForce);
            }
        }
        if (jumpstart >= 1)
        {
            jumpstart--;
            if (rb.gravityScale > 0.0f)
            {
                this.rb.AddForce(transform.up * this.jumpForce / 20);
            }
            else
            {
                this.rb.AddForce(transform.up * -this.jumpForce / 20);
            }
            if (Keyboard.current.zKey.wasReleasedThisFrame || jumpstart < 0)
            {
                jumpstart = 0;
            }
        }

        //Gキーで重力反転　Rigidbody2Dの重力設定を変える
        //プレイヤ画像を上下反転
        // 一度使うと重力切り替えの権利が消える　地面接地で復活
        if (Keyboard.current.gKey.wasPressedThisFrame && g == 1)
        {
            g = 0;
            if (rb.gravityScale > 0.0f) {
                rb.gravityScale = -4.0f;
                GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                rb.gravityScale = 4.0f;
                GetComponent<SpriteRenderer>().flipY = false;
            }
        }

        /*
        //下か上に落っこちたらMainsceneシーンを再読み込み
        if (transform.position.y < -20.0f)
        {
            SceneManager.LoadScene("Mainscene");
        }
        if (transform.position.y > 20.0f)
        {
            SceneManager.LoadScene("Mainscene");
        }
        */


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        jimen = 1;
        g = 1;
    }

}

