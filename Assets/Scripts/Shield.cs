using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 �������� ���庤�� �˾Ƴ���
        transform.position = mousePos; // ������ ��ġ�� ���콺 �������� ��ġ�� �̵�
    }
}
