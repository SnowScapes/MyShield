using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 포인터의 월드벡터 알아내기
        transform.position = mousePos; // 쉴드의 위치를 마우스 포인터의 위치로 이동
    }
}
