using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // Retry��ư�� Ŭ���� ��� SceneManager�� ���� MainScene�� �ٽ� �ҷ��´�
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
