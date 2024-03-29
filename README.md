# 🌸 내일배움캠프 사전캠프 2주차 <img src="https://img.shields.io/badge/Unity-FFFFFF?style=flat&logo=Unity&logoColor=5D5D5D"/> <img src="https://img.shields.io/badge/C%23-5D5D5D?style=flat&logo=csharp&logoColor=FFFFFF"/>   
## 🖥 개발환경    

* CPU : I7-13700K 3.40Ghz    
* RAM : DDR4 64GB 3800Mhz    
* VGA : NVIDIA RTX 3090 GDDR6X 24GB    
* OS : MICROSOFT WINDOWS 11    
* Engine : UNITY 2021.3.16f1    
* IDE : MICROSOFT Visual Studio 2022

## 🎈 풍선을 지켜라    
<img src="/IMGS/game2.gif" width="50%" height="50%" title="game" alt="Game"></img>    
#### 실드를 마우스 커서를 움직여 이동시키며 아래의 풍선을 지키는 게임    
> ##### 🎮 게임 플레이
> 1. 게임이 시작되면 하늘에서 랜덤한 위치에서 랜덤한 크기의 상자가 떨어진다.    
> 2. 풍선을 지키기 위한 실드는 마우스 커서를 따라 움직인다.    
> 3. 실드로 상자를 밀어내어 풍선을 지킬 수 있다.    
> 4. 풍선을 오래지킬 수록 점수가 높아진다.    

## 🔑 기존 코드
<details><summary><b>접기/펼치기</b></summary>

    
<details>
<summary>    
<b>GameManager.cs</b>
</summary>

```csharp
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
    bool isPlay = true; // PlayerPrefs 기능을 사용할 때 필요한 Key 이름을 변수에 저장하여 오타 방지
    string key = "bestScore";

    void Awake()
    {
        // 인스턴스가 비어있는 상태라면 인스턴스 지정
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0.0f, 1f); // square 오브젝트를 생성하는 MakeSquare 함수를 게임시작 0초 후부터 1초마다 실행
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 플레이 중일 경우 시간(점수) 상승 및 표시
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
        isPlay = false; // 점수 및 시간이 오르는 것을 정지
        anim.SetBool("isDie", true); // 풍선이 터지는 애니메이션을 bool 값을 바꾸어 재생
        Invoke("TimeStop", 0.5f); // 애니메이션을 보기 전에 게임이 멈춰버리는 것을 방지하기 위해 0.5초 뒤에 TimeStop 함수 실행
        nowScore.text = time.ToString("N2");

        // PlayerPrefs를 통해 최고 점수를 디스크에 저장하는 기능
        // HasKey(key)는 해당 이름으로 저장된 PlayerPrefs가 있는지 확인 true,false 반환
        if (PlayerPrefs.HasKey(key)) 
        {
            // GetFloat는 Float 값으로 저장된 PlayerPrefs를 불러와 best라는 이름의 float 변수에 저장
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                // 이번 기록이 best보다 높을 경우 SetFloat를 통해 최고기록 값을 다시 저장해줌
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        // 저장된 PlayerPrefs가 없다면. 즉, 저장된 최고 기록이 없다면 SetFloat로 이번 기록을 최고기록으로 저장
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }

    // Invoke 기능으로 게임을 정지 시키는 것을 지연시키기 위한 함수
    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
```
</details>
