using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // Retry버튼을 클릭할 경우 SceneManager를 통해 MainScene을 다시 불러온다
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
