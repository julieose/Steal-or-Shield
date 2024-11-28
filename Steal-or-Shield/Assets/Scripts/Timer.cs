using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Для работы с загрузкой сцен

public class Timer: MonoBehaviour
{
    public float timeLeft = 20f;   // Время до окончания таймера 
    public string nextSceneName="Room2"; // следующая сцена

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText; // Ссылка на UI элемент для отображения таймера

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
            UpdateTimerText(); // Обновляем текст таймера
            timeLeft -= Time.deltaTime; // Уменьшаем оставшееся время
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Загружаем следующую сцену
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Форматируем время
    }
}