using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Sprite shiro0;
    public Sprite shiro1;
    public Sprite shiro2;

    int a = 0;
    float j = 0;

    int jimen = 0;

    float jumpForce = 800f;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    GameObject camera;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.spriteRenderer = GetComponent<SpriteRenderer>();       

        rb = GetComponent<Rigidbody2D>();

        camera = GameObject.Find("camerablock");
    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーのアニメーション
        a++;
        if (a % 24 > 8)
        {
            this.spriteRenderer.sprite = shiro0;
        }
        else if (a % 24 > 16)
        {
            this.spriteRenderer.sprite = shiro1;
        }
        else
        {
            this.spriteRenderer.sprite = shiro2;
        }

            //プレイヤーを右に動かす
            this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y, 0);
        
        //カメラを右に動かす
        //メインカメラと親子になっているカメラ操作用ブロックを動かしています。(メインカメラの動かし方が分からない為)
        camera.transform.position = new Vector3(camera.transform.position.x + 0.05f, camera.transform.position.y, 0);

        //zキーでジャンプ 地面に立っている時のみ
        if (Keyboard.current.zKey.wasPressedThisFrame && jimen == 1)
        {
            if (rb.gravityScale > 0.0f)
            {
                this.rb.AddForce(transform.up * this.jumpForce);
            }
            else
            {
                this.rb.AddForce(transform.up * -this.jumpForce);
            }

        }


        //Gキーで重力反転　Rigidbody2Dの重力設定を変える プレイヤ画像を上下反転
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
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



        //下か上に落っこちたらkatsuraシーンを再読み込み
        if (transform.position.y < -20.0f)
        {
            SceneManager.LoadScene("katsura");
        }
        if (transform.position.y > 20.0f)
        {
            SceneManager.LoadScene("katsura");
        }

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        jimen = 1;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        jimen = 0;
    }


}

