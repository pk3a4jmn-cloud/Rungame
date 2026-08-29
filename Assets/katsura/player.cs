using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Sprite kuro0;
    public Sprite kuro1;

    int a = 0;
    float j = 0;

    int jimen = 0;

    float jumpForce = 800f;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.spriteRenderer = GetComponent<SpriteRenderer>();       

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーのアニメーション
        a++;
        if (a % 8 >= 4)
        {
            this.spriteRenderer.sprite = kuro0;
        }
        else
        {
            this.spriteRenderer.sprite = kuro1;
        }

        //プレイヤーを右に動かす
        this.transform.position = new Vector3(this.transform.position.x + 0.01f, this.transform.position.y, 0);

        //zキーでジャンプ 地面に立っている時のみ
        if (Keyboard.current.zKey.wasPressedThisFrame && jimen == 1)
        {
            this.rb.AddForce(transform.up * this.jumpForce);
        }




        //Gキーで重力反転　Rigidbody2Dの重力設定を変える
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

