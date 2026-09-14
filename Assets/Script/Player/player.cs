using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int jimen = 0;

    float jumpForce = 600f;

    Rigidbody2D rb;
    GameObject camera;

    int jumpstart = 0;

    int g = 1;

    public GameObject Prefab_gameover;

    bool shibouflag = false;

    int shiboucount = 0;
    private int GetColorLayer(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.Black:
                return 6;

            case ColorType.White:
                return 7;

            case ColorType.Red:
                return 8;

            case ColorType.Blue:
                return 9;

            case ColorType.Yellow:
                return 10;

            case ColorType.Green:
                return 11;

            case ColorType.Purple:
                return 12;

            case ColorType.Orange:
                return 13;

            default:
                return gameObject.layer;
        }
    }

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
        if (shibouflag)
        {
            shiboucount++;
            if (shiboucount > 150)
            {
                SceneManager.LoadScene("Tittlescene");
            }

            return;
        }

        //プレイヤーを右に動かす
        this.transform.position = new Vector3(this.transform.position.x - 0.05f, this.transform.position.y, 0);

        //カメラを右に動かす
        //メインカメラと親子になっているカメラ操作用ブロックを動かしています。(メインカメラの動かし方が分からない為)
        camera.transform.position = new Vector3(camera.transform.position.x - 0.05f, camera.transform.position.y, 0);

        if (camera.transform.position.x + 2.0f < this.transform.position.x)
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.02f, this.transform.position.y, 0);
        }

        //zキーでジャンプ 地面に立っている時のみ
        //マリオみたいにボタンを押す長さでジャンプ力を変える
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jimen == 1)
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
            if (Keyboard.current.spaceKey.wasReleasedThisFrame || jumpstart < 0)
            {
                jumpstart = 0;
            }
        }

        //Gキーで重力反転　Rigidbody2Dの重力設定を変える
        //プレイヤ画像を上下反転
        // 一度使うと重力切り替えの権利が消える　地面接地で復活
        if (Keyboard.current.wKey.wasPressedThisFrame && g == 1)
        {
            g = 0;
            if (rb.gravityScale > 0.0f)
            {
                rb.gravityScale = -4.0f;
                GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                rb.gravityScale = 4.0f;
                GetComponent<SpriteRenderer>().flipY = false;
            }
        }


        // Fキーで現在の色を反転
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            ColorType reverseColor =
                ColorGridUtility.GetReverseColor(
                    PlayerColorContlloer.Instance.colorType
                );

            // 色を変更
            PlayerColorContlloer.Instance.ChangeColor(reverseColor);

            // Layerも変更
            gameObject.layer = GetColorLayer(reverseColor);
        }


        //下か上に落っこちたらMainsceneシーンを再読み込み
        if (transform.position.y < -8.0f)
        {
            Debug.Log("死にました(画面外)");
            shibou();
        }
        if (transform.position.y > 8.0f)
        {
            Debug.Log("死にました(画面外)");
            shibou();
        }
        if (transform.position.x > camera.transform.position.x + 11.1f)
        {
            Debug.Log("死にました(画面外)");
            shibou();
        }




    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        jimen = 1;
        g = 1;
    }

    public void shibou()
    {
        shibouflag = true;
        GameObject go = Instantiate(Prefab_gameover);
        go.transform.SetParent(camera.transform);
        go.transform.localPosition = new Vector3(0.0f, -10.0f, 0.0f);
    }

}

