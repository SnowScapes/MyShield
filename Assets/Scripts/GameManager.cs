using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text nowScore;
    public Text bestScore;
    public Animator anim;

    float time = 0f;
    bool isPlay = true; // PlayerPrefs ����� ����� �� �ʿ��� Key �̸��� ������ �����Ͽ� ��Ÿ ����
    string key = "bestScore";

    void Awake()
    {
        // �ν��Ͻ��� ����ִ� ���¶�� �ν��Ͻ� ����
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0.0f, 1f); // square ������Ʈ�� �����ϴ� MakeSquare �Լ��� ���ӽ��� 0�� �ĺ��� 1�ʸ��� ����
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �÷��� ���� ��� �ð�(����) ��� �� ǥ��
        if (isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false; // ���� �� �ð��� ������ ���� ����
        anim.SetBool("isDie", true); // ǳ���� ������ �ִϸ��̼��� bool ���� �ٲپ� ���
        Invoke("TimeStop", 0.5f); // �ִϸ��̼��� ���� ���� ������ ��������� ���� �����ϱ� ���� 0.5�� �ڿ� TimeStop �Լ� ����
        nowScore.text = time.ToString("N2");

        // PlayerPrefs�� ���� �ְ� ������ ��ũ�� �����ϴ� ���
        // HasKey(key)�� �ش� �̸����� ����� PlayerPrefs�� �ִ��� Ȯ�� true,false ��ȯ
        if (PlayerPrefs.HasKey(key)) 
        {
            // GetFloat�� Float ������ ����� PlayerPrefs�� �ҷ��� best��� �̸��� float ������ ����
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                // �̹� ����� best���� ���� ��� SetFloat�� ���� �ְ��� ���� �ٽ� ��������
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        // ����� PlayerPrefs�� ���ٸ�. ��, ����� �ְ� ����� ���ٸ� SetFloat�� �̹� ����� �ְ������� ����
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }

    // Invoke ������� ������ ���� ��Ű�� ���� ������Ű�� ���� �Լ�
    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
