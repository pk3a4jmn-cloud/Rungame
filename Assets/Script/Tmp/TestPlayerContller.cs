using UnityEngine;
using TMPro;
public class TestPlayerContlloer : MonoBehaviour

{
    public float moveSpeed = 5f;
    public TextMeshProUGUI scoreText; // インスペクターからTMPをアタッチ

    private Rigidbody2D rb;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Rigidbody2Dの重力を0にする（トップダウン移動用）
        rb.gravityScale = 0f;
        UpdateScoreText();
    }

    void Update()
    {
        // WASD / 矢印キーの入力を取得（-1.0 〜 1.0）
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 移動方向のベクトルを作成し、速度を適用
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    // スコアを加算するメソッド（他スクリプトから呼ぶ用）
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // TMPのテキストを更新
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
