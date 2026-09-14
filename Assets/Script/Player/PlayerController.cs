using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int jimen = 0;

    float jumpForce = 600f;

    Rigidbody2D rb;

    int jumpstart = 0;

    int g = 1;

    public GameObject Prefab_gameover;

    bool shibouflag = false;

    int shiboucount = 0;
    [SerializeField] private float positionCheckTime = 2.0f;
    [SerializeField] private float positionTolerance = 0.1f;
    [SerializeField] private float returnSpeed = 3.0f;

    private float initialX;
    private float positionOutTime = 0f;

    // 色ごとのLayer
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


    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();

        initialX = transform.position.x;
    }


    void Update()
    {

        // 死亡中


        if (shibouflag)
        {
            shiboucount++;

            if (shiboucount > 150)
            {
                SceneManager.LoadScene("Tittlescene");
            }

            return;
        }



        // ジャンプ


        if (Keyboard.current.spaceKey.wasPressedThisFrame && jimen == 1)
        {
            jimen = 0;
            jumpstart = 20;

            if (rb.gravityScale > 0.0f)
            {
                rb.AddForce(transform.up * jumpForce);
            }
            else
            {
                rb.AddForce(transform.up * -jumpForce);
            }
        }


        // ジャンプ中の追加力
        if (jumpstart >= 1)
        {
            jumpstart--;

            if (rb.gravityScale > 0.0f)
            {
                rb.AddForce(transform.up * jumpForce / 20);
            }
            else
            {
                rb.AddForce(transform.up * -jumpForce / 20);
            }

            // スペースを離したらジャンプ終了
            if (Keyboard.current.spaceKey.wasReleasedThisFrame)
            {
                jumpstart = 0;
            }
        }


        // 重力反転


        if (Keyboard.current.shiftKey.wasPressedThisFrame && g == 1)
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



        // 色反転


        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ColorType reverseColor =
                ColorGridUtility.GetReverseColor(
                    PlayerColorContlloer.Instance.colorType
                );

            // 色変更
            PlayerColorContlloer.Instance.ChangeColor(reverseColor);

            // Layer変更
            gameObject.layer = GetColorLayer(reverseColor);
        }


        // 死亡判定

        // 下に落ちた
        if (transform.position.y < -8.0f)
        {
            Debug.Log("死亡：下に落ちました");
            shibou();
        }

        // 上に飛び出した
        if (transform.position.y > 8.0f)
        {
            Debug.Log("死亡：上に飛び出しました");
            shibou();
        }
        if (Mathf.Abs(transform.position.x - initialX) > positionTolerance)

            // X座標が初期位置からズレているか確認
            if (Mathf.Abs(transform.position.x - initialX) > positionTolerance)
            {
                positionOutTime += Time.deltaTime;

                // 一定時間ズレていたら、ゆっくり元の位置へ戻す
                if (positionOutTime >= positionCheckTime)
                {
                    float newX = Mathf.MoveTowards(
                        transform.position.x,
                        initialX,
                        returnSpeed * Time.deltaTime
                    );

                    transform.position = new Vector3(
                        newX,
                        transform.position.y,
                        transform.position.z
                    );

                    // 元の位置まで戻ったらタイマーリセット
                    if (Mathf.Abs(transform.position.x - initialX) <= positionTolerance)
                    {
                        positionOutTime = 0f;
                    }
                }
            }
            else
            {
                positionOutTime = 0f;
            }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        jimen = 1;
        g = 1;
    }


    // 死亡処理


    public void shibou()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
        shibouflag = true;
        GameObject go = Instantiate(Prefab_gameover);
        go.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f); ;
    }
}