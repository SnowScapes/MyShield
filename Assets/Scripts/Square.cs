using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // square�� ��ġ�� Random.Range�� �̾� position ����
    // square�� ũ�⸦ Random.Range�� �̾� localScale ����
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
        // Square ������Ʈ�� ȭ�� ������ �������� �� ������Ʈ�� Destroy ���ִ� ������ ���ҽ� ���� ����
        if (transform.position.y < -5.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Balloon �±׸� ���� ������Ʈ�� �浹���� ��� GameManager�� GameOver ��� ����
        if (collision.gameObject.CompareTag("Balloon"))
            GameManager.Instance.GameOver();
    }
}
