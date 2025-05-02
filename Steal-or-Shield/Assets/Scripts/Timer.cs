using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Для работы с загрузкой сцен
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Audio;

public class Timer: MonoBehaviour
{
    public float timeLeft = 20f;   // Время до окончания таймера 
    public string nextSceneName = "Room2"; // следующая сцена
    public AudioClip bcgMusicEnd;// Музыка при непрохождении комнаты
    public GameObject myGameObjectEnd;// Объект непрохождения

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText; // Ссылка на UI элемент для отображения таймера

    void Start()
    {
        myGameObjectEnd.SetActive(false);
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
            //myGameObjectEnd.SetActive(true);
            StartCoroutine(Wait5SecEnd());
            //SceneManager.LoadScene(nextSceneName); // Загружаем следующую сцену
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Форматируем время
    }
    IEnumerator Wait5SecEnd()//при непрохождении
    {
        //AudioSource audioSource = gameObject.GetComponent<AudioSource>();//определяю компонент с музыкой
        //if (audioSource.isPlaying)
        //{
        //    audioSource.Stop();
           
        //}
        // audioSource.clip = bcgMusicEnd;
        // audioSource.Play();

        //AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
        //Cursor.visible = false; //курсор не видно
        //LockMouse(true);//блокирую мышь
        myGameObjectEnd.SetActive(true);//делаю активным объект со штрафом
        yield return new WaitForSecondsRealtime(5.0f);//ждет 5 секунд
        myGameObjectEnd.SetActive(false);//делаю неактивным объект со штрафом
        //Cursor.visible = true;//включаю курсор
        //audioSource.Play();//включаю фоновую музыку
        //LockMouse(false);//разблокирую мышь
        SceneManager.LoadScene(nextSceneName); // Загружаем следующую сцену
    }
}