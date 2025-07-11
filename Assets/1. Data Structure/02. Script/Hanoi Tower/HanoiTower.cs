using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public static HanoiTower Instance { get; private set; }

    public enum HanoiLevel {         
        Easy = 3,
        Medium = 4,
        Hard = 5
    }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public HanoiStick[] sticks;

    public HanoiStick selectStick;
    public TextMeshProUGUI scoreText;
    private int score;

    public bool isStart = false;

    public GameObject select;
    public Vector3 offset;

    public Button answerButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Start()
    {
        scoreText.text = "0";
        isStart = false;

        answerButton.onClick.AddListener(HanoiAnswer);

        for(int i = (int)hanoiLevel - 1; i >= 0 ; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            
            sticks[0].PushDonut(donut);

            yield return new WaitForSeconds(0.5f);
        }

        isStart = true;
    }

    private void Update()
    {
        if(selectStick != null)
        {
            if(select.activeSelf == false)
            {
                select.SetActive(true);
            }
            select.transform.position = selectStick.transform.position + offset;
        }
        else if(select.activeSelf)
        {
            select.SetActive(false);
        }
    }

    public void GetScore(int scoreValue = 1)
    {
        score += scoreValue;
        scoreText.text = score.ToString();
    }

    public void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }

    private void HanoiRoutine(int n, int from, int temp, int to)
    {
        if (n == 0) // 도넛을 다 옮긴 상태
            return;

        if (n == 1)
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
        else
        {
            HanoiRoutine(n - 1, from, to, temp);
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");

            HanoiRoutine(n - 1, temp, from, to);
        }
    }
}
