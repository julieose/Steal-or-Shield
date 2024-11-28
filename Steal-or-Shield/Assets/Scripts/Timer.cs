using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������ � ��������� ����

public class Timer: MonoBehaviour
{
    public float timeLeft = 20f;   // ����� �� ��������� ������� 
    public string nextSceneName="Room2"; // ��������� �����

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText; // ������ �� UI ������� ��� ����������� �������

    void Start()
    {
        if (timerText == null)
            Debug.LogError("Timer text is not assigned!");

        UpdateTimerText();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            UpdateTimerText(); // ��������� ����� �������
            timeLeft -= Time.deltaTime; // ��������� ���������� �����
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // ��������� ��������� �����
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // ����������� �����
    }
}