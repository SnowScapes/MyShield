using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // square의 위치를 Random.Range로 뽑아 position 설정
    // square의 크기를 Random.Range로 뽑아 localScale 설정
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector2(x, y);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);
    }

    void Update()
    {
        // Square 오브젝트가 화면 밑으로 내려갔을 때 오브젝트를 Destroy 해주는 것으로 리소스 낭비를 막음
        if (transform.position.y < -5.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Balloon 태그를 가진 오브젝트와 충돌했을 경우 GameManager의 GameOver 기능 실행
        if (collision.gameObject.CompareTag("Balloon"))
            GameManager.Instance.GameOver();
    }
}
