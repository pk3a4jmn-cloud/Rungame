using System.Collections;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public float duration = 0.2f;   // 揺れる時間（秒）
    public float magnitude = 0.04f; // 揺れの強さ

    // 外部からこの関数を呼び出す
    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 startPos = transform.localPosition;
        float timer = 0f;

        while (timer < duration)
        {
            // 少しだけ位置をランダムにずらす
            Vector2 randomPoint = Random.insideUnitCircle * magnitude;
            transform.localPosition = startPos + new Vector3(randomPoint.x, randomPoint.y, 0);

            timer += Time.deltaTime;
            yield return null; // 1フレーム待つ
        }

        // 終わったら元の位置に戻す
        transform.localPosition = startPos;
    }
}